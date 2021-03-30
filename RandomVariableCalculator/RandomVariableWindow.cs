using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RandomVariableCalculator.Properties;

namespace RandomVariableCalculator
{
    public partial class RandomVariableWindow : Form
    {
        private List<Variable> RandomVariableList;
        private readonly RandomVariableType Type;
        private readonly string Title;

        public RandomVariableWindow(RandomVariableType rvType)
        {
            this.Type = rvType;
            this.Title = Enum.GetName(typeof(RandomVariableType), Type);
            RandomVariableList = Utility.GetVariableList(Type);
            InitializeComponent();
            UpdateContents();
            this.CenterToParent();
        }
        private void UpdateContents()
        {
            this.titleLabel.Text = this.Title;
            Label descriptionLabel = GetDescriptionLabel(Type);
            descriptionLabel.Width = displayFlowLayout.Width - displayFlowLayout.Margin.Left - displayFlowLayout.Margin.Right;
            descriptionLabel.Height = displayFlowLayout.Height - displayFlowLayout.Margin.Top - displayFlowLayout.Margin.Bottom;

            displayFlowLayout.Controls.Add(descriptionLabel);
            for (int i = 0; i < RandomVariableList.Count; i++)
            {
                int index = i;
                Variable rv = RandomVariableList[i];
                // buttonText setup needs to be refined to consider the case when the preset is a list
                string buttonText = rv.Value == "" ? rv.Name : String.Concat(rv.Name, " = ", rv.Value); 
                var variableButton = new Button()
                {
                    Width = buttonFlowLayout.Width - buttonFlowLayout.Margin.Left - buttonFlowLayout.Margin.Right,
                    Text = buttonText,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                buttonFlowLayout.Controls.Add(variableButton);
                variableButton.Click += (sender, e) => this.VariableInputButtonClick(sender, e, index);
            }
        }
        private void VariableInputButtonClick(object sender, EventArgs e, int index)
        {
            this.Enabled = false;
            var niWindow = new NumberInputWindow(this.RandomVariableList[index]);
            string variableName = this.RandomVariableList[index].Name;
            string buttonText;
            string value;
            if (niWindow.ShowDialog() == DialogResult.OK)
            {
                if (this.RandomVariableList[index].Type == DataType.List)
                {
                    value = String.Join(", ", niWindow.ListMemberCollection);
                    buttonText = (value == "") ? variableName : String.Concat(variableName, " = { ", value, " }");
                }
                else
                {
                    value = String.Join("", niWindow.DisplayTextList);
                    buttonText = String.IsNullOrWhiteSpace(value) ? variableName : String.Concat(variableName, " = ", value);

                }
                this.RandomVariableList[index].UpdateValue(value);
                ((Button)sender).Text = buttonText;
                this.Enabled = true;
            }
        }
        
        private void CalcButton_Click(object sender, EventArgs e)
        {
            List<string> xList;
            List<string> kList;
            string n;
            string p;
            string h;
            string w;
            string r;
            try
            {
                switch (Type)
                {
                    case RandomVariableType.Uniform:
                        xList = this.RandomVariableList[0].Value.Split(',').ToList();
                        Utility.DisplayResult(this.Title, Logic.UniformDiscreteRV(xList));
                        break;
                    case RandomVariableType.Binomial:
                        n = this.RandomVariableList[1].Value;
                        p = this.RandomVariableList[2].Value;
                        Utility.DisplayResult(this.Title, Logic.BinomialDistributionRV(n, p));
                        break;
                    case RandomVariableType.Poisson:
                        kList = this.RandomVariableList[0].Value.Split(',').ToList();
                        h = this.RandomVariableList[1].Value;
                        w = this.RandomVariableList[2].Value;
                        Utility.DisplayResult(this.Title, Logic.PoissonRV(kList, h, w));
                        break;
                    case RandomVariableType.Geometric:
                        n = this.RandomVariableList[0].Value;
                        p = this.RandomVariableList[1].Value;
                        Utility.DisplayResult(this.Title, Logic.GeometricRV(n, p));
                        break;
                    case RandomVariableType.NegativeBinomial:
                        n = this.RandomVariableList[0].Value;
                        p = this.RandomVariableList[1].Value;
                        r = this.RandomVariableList[2].Value;
                        Utility.DisplayResult(this.Title, Logic.NegativeBinomialRV(n, p, r));
                        break;
                    case RandomVariableType.HyperGeometric:
                        break;
                }
            }
            catch (ValueTypeMismatchException error) when (!String.IsNullOrWhiteSpace(error.Message))
            {
                MessageBox.Show(error.Message);
            }
            catch (ProbabilityOutOfBoundException error) when (!string.IsNullOrWhiteSpace(error.Message))
            {
                MessageBox.Show(error.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }
        private static Label GetDescriptionLabel(RandomVariableType type)
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


    }
}
