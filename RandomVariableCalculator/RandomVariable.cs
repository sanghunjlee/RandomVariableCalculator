using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RandomVariableCalculator
{
    public enum DataType
    {
        Float,
        Integer
    }
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
    public class Variable
    {
        public string Name;
        public DataType Type;
        public bool IsList;
        public string Value;

        public Variable(string name, DataType dataType, bool isList = false, string presetValue = "")
        {
            this.Name = name;
            this.Type = dataType;
            this.IsList = isList;
            this.Value = presetValue;
        }
        public void UpdateValue(string value)
        {
            this.Value = value;
        }
    }
    public class RandomVariable
    {
        public string Name;
        public RandomVariableType Type;
        public List<Variable> Argument = new List<Variable>();
        public RandomVariable(RandomVariableType rvType)
        {
            switch (rvType)
            {
                case RandomVariableType.Uniform:
                    this.Name = "Unifrom Random Variable";
                    this.Argument.Add(new Variable(name: "X", dataType: DataType.Integer, isList: true));
                    break;
                case RandomVariableType.Binomial:
                    this.Name = "Binomial Random Variable";
                    this.Argument.Add(new Variable(name: "r", dataType: DataType.Integer, isList: true));
                    this.Argument.Add(new Variable(name: "n", dataType: DataType.Integer));
                    this.Argument.Add(new Variable(name: "p", dataType: DataType.Float));
                    break;
                case RandomVariableType.Poisson:
                    this.Name = "Poisson Random Variable";
                    this.Argument.Add(new Variable(name: "k", dataType: DataType.Integer, isList: true));
                    this.Argument.Add(new Variable(name: MathSymbol.Lambda, dataType: DataType.Float));
                    this.Argument.Add(new Variable(name: "w", dataType: DataType.Float, presetValue: "1"));
                    break;
                case RandomVariableType.Geometric:
                    this.Name = "Geometric Random Variable";
                    this.Argument.Add(new Variable(name: "n", dataType: DataType.Integer));
                    this.Argument.Add(new Variable(name: "p", dataType: DataType.Float));
                    break;
                case RandomVariableType.NegativeBinomial:
                    this.Name = "Negative Binomial Random Variable";
                    this.Argument.Add(new Variable(name: "n", dataType: DataType.Integer));
                    this.Argument.Add(new Variable(name: "p", dataType: DataType.Float));
                    this.Argument.Add(new Variable(name: "r", dataType: DataType.Integer));
                    break;
                case RandomVariableType.HyperGeometric:
                    this.Name = "Hyper-Geometric Random Variable";
                    this.Argument.Add(new Variable(name: "N", dataType: DataType.Integer));
                    this.Argument.Add(new Variable(name: "n", dataType: DataType.Integer));
                    this.Argument.Add(new Variable(name: "r", dataType: DataType.Integer));
                    this.Argument.Add(new Variable(name: "k", dataType: DataType.Integer));
                    break;
            }
        }
    }
}

