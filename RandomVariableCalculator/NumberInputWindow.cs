using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomVariableCalculator
{
    public partial class NumberInputWindow : Form
    {
        public List<char> DisplayTextList { get; private set; }
        public List<string> ListMemeberCollection { get; private set; }
        private bool IsNegative;
        private readonly DataType type;
        public NumberInputWindow(RandomVariable randomVariable)
        {
            this.DisplayTextList = new List<char>();
            this.ListMemeberCollection = new List<string>();
            this.IsNegative = false;
            this.type = randomVariable.Type;
            if (randomVariable.Value != "")
            {
                if (randomVariable.Type == DataType.List)
                {
                    ListMemeberCollection.AddRange(randomVariable.Value.Replace(", ", ",").Split(','));
                }
                else
                {
                    DisplayTextList.AddRange(randomVariable.Value.ToCharArray());
                }
            }
            
            InitializeComponent();
            UpdateDisplay();
            this.CenterToParent();

            if (this.type != DataType.List)
            {
                this.addButton.Dispose();
                this.listLabel.Dispose();
                this.listMemberLabel.Dispose();
                this.listDeleteButton.Dispose();
                this.listClearButton.Dispose();
                this.flowLayoutPanel1.Dispose();
                this.displayLabel.Height += 24;
                this.displayLabel.Location = new Point(
                    this.displayLabel.Location.X, this.displayLabel.Location.Y - 24);

            }
            if (this.type == DataType.Integer)
            {
                this.periodButton.Dispose();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var focusGroup = new List<Keys> 
            { 
                Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4,
                Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
                Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4,
                Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9
            };
            var kc = new KeysConverter();
            if (focusGroup.Contains(keyData))
            {
                string keyChar = kc.ConvertToString(keyData);
                this.DisplayTextList.Add(char.Parse(keyChar));
                this.UpdateDisplay();
                return true;
            }
            else if (keyData == Keys.OemPeriod || keyData == Keys.Decimal)
            {
                if (this.periodButton.Enabled)
                {
                    this.PeriodButtonClick(null, EventArgs.Empty);
                    return true;
                }
            }
            else if (keyData == Keys.Back)
            {
                this.DeleteButtonClick(null, EventArgs.Empty);
                return true;
            }
            else if (keyData == Keys.Enter || keyData == Keys.Return)
            {
                if (this.type == DataType.List)
                {
                    this.AddButtonClick(null, EventArgs.Empty);
                }
                else
                {
                    this.OkButtonClick(null, EventArgs.Empty);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void NumberButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (Char.TryParse(button.Text, out char c))
            {
                this.DisplayTextList.Add(c);
                this.UpdateDisplay();
            }
        }
        private void PlusOrMinusButtonClick(object sender, EventArgs e)
        {
            if (IsNegative == (DisplayTextList[0] == '-'))
            {
                if (IsNegative)
                {
                    this.DisplayTextList.RemoveAt(0);
                }
                else
                {
                    this.DisplayTextList.Insert(0, '-');
                }
                this.IsNegative = !this.IsNegative;
                this.UpdateDisplay();
            }
            else
            {
                throw new NegativeSignNotFoundException();
            }
        }
        private void PeriodButtonClick(object sender, EventArgs e)
        {
            int count = this.DisplayTextList.Count;
            if (!this.DisplayTextList.Contains('.'))
            {
                if (count == 0)
                {
                    this.DisplayTextList.AddRange(new List<Char> { '0', '.' });
                }
                else
                {
                    this.DisplayTextList.Add('.');
                }
            }
            else
            {
                if (this.DisplayTextList[count - 1] == '.')
                {
                    this.DisplayTextList.RemoveAt(count - 1);
                    if (count == 2 && this.DisplayTextList[count - 2] == '0')
                    {
                        this.DisplayTextList.RemoveAt(count - 2);
                    }
                }
            }
            UpdateDisplay();
        }
        private void OkButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void ClearButtonClick(object sender, EventArgs e)
        {
            this.DisplayTextList.Clear();
            this.UpdateDisplay();
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (DisplayTextList.Count > 0)
            {
                this.DisplayTextList.RemoveAt(DisplayTextList.Count - 1);
                this.UpdateDisplay();
            }
        }
        private void AddButtonClick(object sender, EventArgs e)
        {
            this.ListMemeberCollection.Add(String.Join("", this.DisplayTextList));
            this.DisplayTextList.Clear();
            this.UpdateDisplay();
        }
        private void ListDeleteButtonClick(object sender, EventArgs e)
        {
            if (this.ListMemeberCollection.Count > 0)
            {
                this.ListMemeberCollection.RemoveAt(this.ListMemeberCollection.Count - 1);
                this.UpdateDisplay();
            }
        }
        private void ListClearButtonClick(object sender, EventArgs e)
        {
            this.ListMemeberCollection.Clear();
            this.UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            this.displayLabel.Text = String.Join("", this.DisplayTextList);
            this.listMemberLabel.Text = String.Join(", ", this.ListMemeberCollection);
        }
    }
}
