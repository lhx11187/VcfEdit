namespace VcfEdit
{
    partial class FormReading
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
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SpinningProgress1 = new CircularProgress.SpinningProgress.SpinningProgress();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(71, 34);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 12);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "请稍候...";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(71, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(33, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "正在";
            // 
            // SpinningProgress1
            // 
            this.SpinningProgress1.ActiveSegmentColour = System.Drawing.Color.RoyalBlue;
            this.SpinningProgress1.AutoIncrementFrequency = 75D;
            this.SpinningProgress1.InactiveSegmentColour = System.Drawing.SystemColors.Control;
            this.SpinningProgress1.Location = new System.Drawing.Point(20, 15);
            this.SpinningProgress1.Name = "SpinningProgress1";
            this.SpinningProgress1.Size = new System.Drawing.Size(30, 28);
            this.SpinningProgress1.TabIndex = 5;
            this.SpinningProgress1.TransistionSegment = 5;
            this.SpinningProgress1.TransistionSegmentColour = System.Drawing.Color.LightSteelBlue;
            // 
            // FormReading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 64);
            this.ControlBox = false;
            this.Controls.Add(this.SpinningProgress1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormReading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请稍等...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal CircularProgress.SpinningProgress.SpinningProgress SpinningProgress1;
    }
}