using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using RandomVariableCalculator.Properties;

namespace RandomVariableCalculator
{
    public enum RandomVariableType
    {
        [Description("Unifrom Random Variable")]
        Uniform,
        [Description("Binomial Random Variable")]
        Binomial,
        [Description("Poisson Random Variable")]
        Poisson,
        [Description("Geometric Random Variable")]
        Geometric,
        [Description("Negative Binomial Random Variable")]
        NegativeBinomial,
        [Description("Hyper-Geometric Random Variable")]
        HyperGeometric
    }
    public enum DataType
    { 
        Float,
        Integer,
        List
    }
    public class RandomVariable
    {
        public string Name;
        public DataType Type;
        public string Value;

        public RandomVariable(string variableName, DataType dataType = DataType.Float, string presetValue = "")
        {
            this.Name = variableName;
            this.Type = dataType;
            this.Value = presetValue;
        }
        public void UpdateValue(string value)
        {
            this.Value = value;
        }
    }
    public class ProbabilityResult
    {
        public readonly string ExpectedValue;
        public readonly string Variance;
        public readonly Dictionary<string, string> PmfTable;

        public ProbabilityResult(Dictionary<string, string> resultTable, string e, string v)
        {
            ExpectedValue = e;
            Variance = v;
            PmfTable = resultTable;
        }
    }
    public class MathSymbol
    {
        public static readonly string Lambda = "\u03bb";
    }
    public class NegativeSignNotFoundException : Exception
    {
        public NegativeSignNotFoundException()
        {
        }
        public NegativeSignNotFoundException(string message)
            : base(message)
        {
        }
        public NegativeSignNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class ValueTypeMismatchException : Exception
    { 
        public ValueTypeMismatchException()
        {
        }
        public ValueTypeMismatchException(string message)
            : base(message)
        {
        }
        public ValueTypeMismatchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class ProbabilityOutOfBoundException : Exception
    {
        public ProbabilityOutOfBoundException()
        {
        }
        public ProbabilityOutOfBoundException(string message)
            : base(message)
        {
        }
        public ProbabilityOutOfBoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public static class Utility
    {
        public static Label GetDescriptionLabel(RandomVariableType type)
        {
            Label descriptionLabel = new Label();
            Image labelImage = null;
            switch (type)
            {
                case RandomVariableType.Uniform:
                    labelImage = Resources.uniformRVTex;
                    break;
                case RandomVariableType.Binomial:
                    labelImage = Resources.binomialRVTex;
                    break;
                case RandomVariableType.Poisson:
                    labelImage = Resources.poissonRVTex;
                    break;
                case RandomVariableType.Geometric:
                    labelImage = Resources.geometricRVTex;
                    break;
                case RandomVariableType.NegativeBinomial:
                    labelImage = Resources.negBinomialRVTex;
                    break;
                case RandomVariableType.HyperGeometric:
                    labelImage = Resources.hyperGeoRVTex;
                    break;
            }
            double scale = 0.8;
            Size scaledSize = new Size((int)(labelImage.Width * scale), (int)(labelImage.Height * scale));
            descriptionLabel.Image = (Image)(new Bitmap(labelImage, scaledSize));
            return descriptionLabel;

        }
        public static List<RandomVariable> GetVariableList(RandomVariableType type)
        {
            switch (type)
            {
                case RandomVariableType.Uniform:
                    return new List<RandomVariable> { 
                        new RandomVariable("X", DataType.List) 
                    };
                case RandomVariableType.Binomial:
                    return new List<RandomVariable> { 
                        new RandomVariable("r", DataType.List),
                        new RandomVariable("n", DataType.Integer),
                        new RandomVariable("p")
                    };
                case RandomVariableType.Poisson:
                    return new List<RandomVariable> {
                        new RandomVariable("k", DataType.List),
                        new RandomVariable(MathSymbol.Lambda),
                        new RandomVariable("w", presetValue: "1")
                    };
                case RandomVariableType.Geometric:
                    return new List<RandomVariable> {
                        new RandomVariable("n", DataType.Integer),
                        new RandomVariable("p")
                    };
                case RandomVariableType.NegativeBinomial:
                    return new List<RandomVariable> {
                        new RandomVariable("n", DataType.Integer),
                        new RandomVariable("p"),
                        new RandomVariable("r", DataType.Integer)
                    };
                case RandomVariableType.HyperGeometric:
                    return new List<RandomVariable> {
                        new RandomVariable("N", DataType.Integer),
                        new RandomVariable("n", DataType.Integer),
                        new RandomVariable("r", DataType.Integer),
                        new RandomVariable("k", DataType.Integer)
                    };
                default:
                    return new List<RandomVariable> { };
            }
        }
        public static void DisplayResult(
            string randomVariableName, ProbabilityResult result)
        {
            Dictionary<string, string> pmfTable = result.PmfTable;
            string expectedValue = result.ExpectedValue;
            string variance = result.Variance;
            var displayText = new List<string>();
            displayText.Add($"Expected Value: {expectedValue}");
            displayText.Add($"Variance: {variance}");
            displayText.Add("");
            foreach (KeyValuePair<string, string> kvp in pmfTable)
            {
                displayText.Add($"P({kvp.Key})\t = \t {kvp.Value}");
            }
            MessageBox.Show(text: String.Join("\n", displayText), caption: randomVariableName, buttons: MessageBoxButtons.OK);
        }
    }
}
