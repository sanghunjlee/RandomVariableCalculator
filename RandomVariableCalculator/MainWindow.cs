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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void RV_Button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                this.Enabled = false;
                if (Enum.TryParse(((Button) sender).Name, out RandomVariableType rvType))
                {
                    var rv = new RandomVariable(rvType);
                    var rvWindow = new RandomVariableWindow(rv);
                    if (rvWindow.ShowDialog() != DialogResult.None)
                    {
                        this.Enabled = true;
                    }
                }
                else
                {
                    this.Enabled = true;
                }
            }

        }
    }
}
