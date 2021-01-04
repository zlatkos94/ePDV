using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;


namespace ePdv
{
    public partial class IzbornikForm : Form
    {
        ConnectionString cnnString = new ConnectionString();
        Pregled pregled = new Pregled();
        IsporukePregled isporuke = new IsporukePregled();

        public IzbornikForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            string database_name = Convert.ToString(selectedRow.Cells["database_name"].Value);

            lblPoduzece.Text = Convert.ToString(selectedRow.Cells["firma"].Value);

            SqlConnection myConnection = new SqlConnection();
            SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();


            myBuilder.DataSource = ParametriBaze.DataSource;

            myBuilder.UserID = ParametriBaze.UserID;

            myBuilder.Password = ParametriBaze.Password;

            myBuilder.InitialCatalog = database_name;

            myBuilder.ConnectTimeout = 15;

            myConnection.ConnectionString = myBuilder.ConnectionString;


            panel1.Visible = false;
            menuStrip1.Enabled = true;

            ConfigurationManager.RefreshSection("connectionStrings");

            cnnString.UpdateAppConfigFile(myConnection.ConnectionString);
        }

        private void btnOdabranaBaza_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection();
            SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();

            myBuilder.DataSource = ParametriBaze.DataSource;

            myBuilder.UserID = ParametriBaze.UserID;

            myBuilder.Password = ParametriBaze.Password;

            myBuilder.InitialCatalog = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            myBuilder.ConnectTimeout = 2;

            myConnection.ConnectionString = myBuilder.ConnectionString;

            lblPoduzece.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

            panel1.Visible = false;
            menuStrip1.Enabled = true;

            ConfigurationManager.RefreshSection("connectionStrings");

            cnnString.UpdateAppConfigFile(myConnection.ConnectionString);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = string.Format("Firma like '%{0}%'", txtSearch.Text);
            dataGridView1.DataSource = bs;
        }

        private void IzbornikForm_Load(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            dataGridView1.DataSource = cnnString.DohvatiBaze();
        }

        private void stvoricsvDokumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsvForm csv = new CsvForm();
            csv.MdiParent = this;
            csv.Dock = DockStyle.Fill;
            csv.Show();
        }

        private void pregledNabavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isporuke.Hide();

            if (Preview.PregledEnabavke == null || Preview.PregledEnabavke.Rows.Count < 1)
            {

                MessageBox.Show("Generirajte csv dokument da bi vidjeli podatke");

            }
            else
            {
                pregled.MdiParent = this;
                pregled.Dock = DockStyle.Fill;
                pregled.Show();
            }
        }

        private void pregledIsporukeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pregled.Hide();

            if (Preview.PregledEisporuke == null || Preview.PregledEisporuke.Rows.Count < 1)
            {

                MessageBox.Show("Generirajte csv dokument da bi vidjeli podatke");

            }
            else
            {
                if (Form.ActiveForm != isporuke)
                {
                    isporuke.MdiParent = this;
                    isporuke.Dock = DockStyle.Fill;
                    isporuke.Show();
                }

                else
                {
                    isporuke.Show();
                }

            }
        }

        private void evidencijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isporuke.Hide();

            pregled.Hide();
            txtSearch.Text = "";
            menuStrip1.Enabled = false;
            panel1.Visible = true;

            Preview.PregledEnabavkeZaglavlje = null;

            Preview.PregledEnabavke = null;

            Preview.PregledEnabavkeSum = null;

            Preview.PregledEisporukeZaglavlje = null;

            Preview.PregledEisporuke = null;

            Preview.PregledEisporukeSum = null;
        }
    }
}
