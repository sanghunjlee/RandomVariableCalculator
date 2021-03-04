
namespace RandomVariableCalculator
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Uniform = new System.Windows.Forms.Button();
            this.Binomial = new System.Windows.Forms.Button();
            this.Poisson = new System.Windows.Forms.Button();
            this.Geometric = new System.Windows.Forms.Button();
            this.NegativeBinomial = new System.Windows.Forms.Button();
            this.HyperGeometric = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.Uniform);
            this.flowLayoutPanel1.Controls.Add(this.Binomial);
            this.flowLayoutPanel1.Controls.Add(this.Poisson);
            this.flowLayoutPanel1.Controls.Add(this.Geometric);
            this.flowLayoutPanel1.Controls.Add(this.NegativeBinomial);
            this.flowLayoutPanel1.Controls.Add(this.HyperGeometric);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 301);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Random Variable Calculator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 0, 12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please select the type of random variable probability to calculate. ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Uniform
            // 
            this.Uniform.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Uniform.Location = new System.Drawing.Point(3, 111);
            this.Uniform.Name = "Uniform";
            this.Uniform.Size = new System.Drawing.Size(280, 23);
            this.Uniform.TabIndex = 2;
            this.Uniform.Text = "Uniform Discrete Distribution";
            this.Uniform.UseVisualStyleBackColor = true;
            this.Uniform.Click += new System.EventHandler(this.RV_Button_Click);
            // 
            // Binomial
            // 
            this.Binomial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Binomial.Location = new System.Drawing.Point(3, 140);
            this.Binomial.Name = "Binomial";
            this.Binomial.Size = new System.Drawing.Size(280, 23);
            this.Binomial.TabIndex = 3;
            this.Binomial.Text = "Binomial Distribution";
            this.Binomial.UseVisualStyleBackColor = true;
            this.Binomial.Click += new System.EventHandler(this.RV_Button_Click);
            // 
            // Poisson
            // 
            this.Poisson.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Poisson.Location = new System.Drawing.Point(3, 169);
            this.Poisson.Name = "Poisson";
            this.Poisson.Size = new System.Drawing.Size(280, 23);
            this.Poisson.TabIndex = 4;
            this.Poisson.Text = "Poisson Distribution";
            this.Poisson.UseVisualStyleBackColor = true;
            this.Poisson.Click += new System.EventHandler(this.RV_Button_Click);
            // 
            // Geometric
            // 
            this.Geometric.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Geometric.Location = new System.Drawing.Point(3, 198);
            this.Geometric.Name = "Geometric";
            this.Geometric.Size = new System.Drawing.Size(280, 23);
            this.Geometric.TabIndex = 5;
            this.Geometric.Text = "Geometric Distribution";
            this.Geometric.UseVisualStyleBackColor = true;
            this.Geometric.Click += new System.EventHandler(this.RV_Button_Click);
            // 
            // NegativeBinomial
            // 
            this.NegativeBinomial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NegativeBinomial.Location = new System.Drawing.Point(3, 227);
            this.NegativeBinomial.Name = "NegativeBinomial";
            this.NegativeBinomial.Size = new System.Drawing.Size(280, 23);
            this.NegativeBinomial.TabIndex = 6;
            this.NegativeBinomial.Text = "Negative Binomial Distribution";
            this.NegativeBinomial.UseVisualStyleBackColor = true;
            this.NegativeBinomial.Click += new System.EventHandler(this.RV_Button_Click);
            // 
            // HyperGeometric
            // 
            this.HyperGeometric.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HyperGeometric.Location = new System.Drawing.Point(3, 256);
            this.HyperGeometric.Name = "HyperGeometric";
            this.HyperGeometric.Size = new System.Drawing.Size(280, 23);
            this.HyperGeometric.TabIndex = 7;
            this.HyperGeometric.Text = "Hyper-geometric Distribution";
            this.HyperGeometric.UseVisualStyleBackColor = true;
            this.HyperGeometric.Click += new System.EventHandler(this.RV_Button_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Random Variable Calculator";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Uniform;
        private System.Windows.Forms.Button Binomial;
        private System.Windows.Forms.Button Poisson;
        private System.Windows.Forms.Button Geometric;
        private System.Windows.Forms.Button NegativeBinomial;
        private System.Windows.Forms.Button HyperGeometric;
    }
}

