using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace RandomVariableCalculator
{
    

    
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
