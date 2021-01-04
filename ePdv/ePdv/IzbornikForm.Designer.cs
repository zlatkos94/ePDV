
namespace ePdv
{
    partial class IzbornikForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzbornikForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.evidencijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stvoricsvDokumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledNabavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledIsporukeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOdabranaBaza = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblPoduzece = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evidencijaToolStripMenuItem,
            this.stvoricsvDokumentToolStripMenuItem,
            this.pregledNabavkeToolStripMenuItem,
            this.pregledIsporukeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // evidencijaToolStripMenuItem
            // 
            this.evidencijaToolStripMenuItem.Name = "evidencijaToolStripMenuItem";
            this.evidencijaToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.evidencijaToolStripMenuItem.Text = "Evidencija";
            this.evidencijaToolStripMenuItem.Click += new System.EventHandler(this.evidencijaToolStripMenuItem_Click);
            // 
            // stvoricsvDokumentToolStripMenuItem
            // 
            this.stvoricsvDokumentToolStripMenuItem.Name = "stvoricsvDokumentToolStripMenuItem";
            this.stvoricsvDokumentToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.stvoricsvDokumentToolStripMenuItem.Text = "Stvori .csv dokument";
            this.stvoricsvDokumentToolStripMenuItem.Click += new System.EventHandler(this.stvoricsvDokumentToolStripMenuItem_Click);
            // 
            // pregledNabavkeToolStripMenuItem
            // 
            this.pregledNabavkeToolStripMenuItem.Name = "pregledNabavkeToolStripMenuItem";
            this.pregledNabavkeToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.pregledNabavkeToolStripMenuItem.Text = "Pregled nabavke";
            this.pregledNabavkeToolStripMenuItem.Click += new System.EventHandler(this.pregledNabavkeToolStripMenuItem_Click);
            // 
            // pregledIsporukeToolStripMenuItem
            // 
            this.pregledIsporukeToolStripMenuItem.Name = "pregledIsporukeToolStripMenuItem";
            this.pregledIsporukeToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.pregledIsporukeToolStripMenuItem.Text = "Pregled isporuke";
            this.pregledIsporukeToolStripMenuItem.Click += new System.EventHandler(this.pregledIsporukeToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOdabranaBaza);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 522);
            this.panel1.TabIndex = 1;
            // 
            // btnOdabranaBaza
            // 
            this.btnOdabranaBaza.Location = new System.Drawing.Point(213, 402);
            this.btnOdabranaBaza.Name = "btnOdabranaBaza";
            this.btnOdabranaBaza.Size = new System.Drawing.Size(134, 36);
            this.btnOdabranaBaza.TabIndex = 3;
            this.btnOdabranaBaza.Text = "Spoji se na bazu";
            this.btnOdabranaBaza.UseVisualStyleBackColor = true;
            this.btnOdabranaBaza.Click += new System.EventHandler(this.btnOdabranaBaza_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pretraga ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(266, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(132, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(213, 73);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(595, 311);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // lblPoduzece
            // 
            this.lblPoduzece.AutoSize = true;
            this.lblPoduzece.Location = new System.Drawing.Point(542, 8);
            this.lblPoduzece.Name = "lblPoduzece";
            this.lblPoduzece.Size = new System.Drawing.Size(0, 13);
            this.lblPoduzece.TabIndex = 2;
            // 
            // IzbornikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblPoduzece);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IzbornikForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izbornik";
            this.Load += new System.EventHandler(this.IzbornikForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOdabranaBaza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem evidencijaToolStripMenuItem;
        private System.Windows.Forms.Label lblPoduzece;
        private System.Windows.Forms.ToolStripMenuItem stvoricsvDokumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledNabavkeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledIsporukeToolStripMenuItem;
    }
}