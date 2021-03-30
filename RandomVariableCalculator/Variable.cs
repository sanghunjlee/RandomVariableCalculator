using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVariableCalculator
{
    public enum DataType
    {
        Float,
        Integer,
        List
    }
    public class Variable
    {
        public string Name;
        public DataType Type;
        public string Value;

        public Variable(string variableName, DataType dataType = DataType.Float, string presetValue = "")
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
}

