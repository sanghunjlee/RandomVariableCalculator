using System;
using System.Collections.Generic;
using System.Drawing;
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
        
        public static List<Variable> GetVariableList(RandomVariableType type)
        {
            switch (type)
            {
                case RandomVariableType.Uniform:
                    return new List<Variable> { 
                        new Variable("X", DataType.List) 
                    };
                case RandomVariableType.Binomial:
                    return new List<Variable> { 
                        new Variable("r", DataType.List),
                        new Variable("n", DataType.Integer),
                        new Variable("p")
                    };
                case RandomVariableType.Poisson:
                    return new List<Variable> {
                        new Variable("k", DataType.List),
                        new Variable(MathSymbol.Lambda),
                        new Variable("w", presetValue: "1")
                    };
                case RandomVariableType.Geometric:
                    return new List<Variable> {
                        new Variable("n", DataType.Integer),
                        new Variable("p")
                    };
                case RandomVariableType.NegativeBinomial:
                    return new List<Variable> {
                        new Variable("n", DataType.Integer),
                        new Variable("p"),
                        new Variable("r", DataType.Integer)
                    };
                case RandomVariableType.HyperGeometric:
                    return new List<Variable> {
                        new Variable("N", DataType.Integer),
                        new Variable("n", DataType.Integer),
                        new Variable("r", DataType.Integer),
                        new Variable("k", DataType.Integer)
                    };
                default:
                    return new List<Variable> { };
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
