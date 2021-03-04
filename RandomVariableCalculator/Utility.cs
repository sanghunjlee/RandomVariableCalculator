using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

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
        public static List<Label> GetDescriptionLabelList(RandomVariableType type)
        {
            var descriptionLabels = new List<Label>();
            Func<string, Label> newLabel = x => new Label() { Text = x, };
            switch (type)
            {
                case RandomVariableType.Uniform:
                    descriptionLabels.Add(newLabel("The probability mass function: $p(x) = \\frac{1}{n}$"));
                    descriptionLabels.Add(newLabel("The expected value: $E(X) = \\frac{\\sum x_i}{n}$"));
                    descriptionLabels.Add(newLabel("The variance: $Var(X) = \\frac{\\sum x_i^2}{n} - \\left(\\frac{\\sum x_i}{n}\\right)^2$"));
                    break;
                case RandomVariableType.Binomial:
                    descriptionLabels.Add(newLabel("The probability mass function: $p(r) = _{n}C_{r} p^r (1-p)^{n-r}$"));
                    descriptionLabels.Add(newLabel("The expected value: $E(X) = np$"));
                    descriptionLabels.Add(newLabel("The variance: $Var(X) = np(1-p)$"));
                    break;
                case RandomVariableType.Poisson:
                    descriptionLabels.Add(newLabel("The probability mass function: $p(X(w)=k) = e^{-\\lambda w}\\frac{(\\lambda w)^k}{k!}$"));
                    descriptionLabels.Add(newLabel("The expected value: $E(X) = \\lambda w$"));
                    descriptionLabels.Add(newLabel("The variance: $Var(X) = \\lambda w$"));
                    break;
                case RandomVariableType.Geometric:
                    descriptionLabels.Add(newLabel("The probability mass function: $p(n) = p(1-p)^{n-1}$"));
                    descriptionLabels.Add(newLabel("The expected value: $E(X) = \\frac{1}{p}$"));
                    descriptionLabels.Add(newLabel("The variance: $Var(X) = \\frac{1-p}{p^2}$"));
                    break;
                case RandomVariableType.NegativeBinomial:
                    descriptionLabels.Add(newLabel("The probability mass function: $p(n) = {}_{n-1}C_{r-1} p^r (1-p)^{n-r}$"));
                    descriptionLabels.Add(newLabel("The expected value: $E(X) = \\frac{r}{p}$"));
                    descriptionLabels.Add(newLabel("The variance: $Var(X) = \\frac{r(1-p)}{p^2}$"));
                    break;
                case RandomVariableType.HyperGeometric:
                    descriptionLabels.Add(newLabel("The probability mass function: $p(X=k) = \\frac{{}_nC_k {}_{N-n}C_{r-k}}{{}_NC_r}$"));
                    descriptionLabels.Add(newLabel("The expected value: $E(X) = \\frac{rn}{N}$"));
                    descriptionLabels.Add(newLabel("The variance: $Var(X) = \\frac{rn}{N}\\cdot\\frac{N-r}{N}\\cdot\\frac{N-n}{N-1}$"));
                    break;
                default:
                    descriptionLabels.Add(newLabel(""));
                    break;
            }
            return descriptionLabels;

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
