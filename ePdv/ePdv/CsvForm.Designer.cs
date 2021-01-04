
namespace ePdv
{
    partial class CsvForm
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
            this.btnCsv = new System.Windows.Forms.Button();
            this.PoreskiPeriod = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCsv
            // 
            this.btnCsv.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCsv.Location = new System.Drawing.Point(199, 220);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(120, 50);
            this.btnCsv.TabIndex = 0;
            this.btnCsv.Text = "Generiraj CSV";
            this.btnCsv.UseVisualStyleBackColor = true;
            this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click);
            // 
            // PoreskiPeriod
            // 
            this.PoreskiPeriod.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PoreskiPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoreskiPeriod.Location = new System.Drawing.Point(261, 44);
            this.PoreskiPeriod.Name = "PoreskiPeriod";
            this.PoreskiPeriod.Size = new System.Drawing.Size(162, 21);
            this.PoreskiPeriod.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(34, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Odaberi porezni period (mjesec)";
            // 
            // CsvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PoreskiPeriod);
            this.Controls.Add(this.btnCsv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CsvForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CsvForm";
            this.Load += new System.EventHandler(this.CsvForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.DateTimePicker PoreskiPeriod;
        private System.Windows.Forms.Label label1;
    }
}