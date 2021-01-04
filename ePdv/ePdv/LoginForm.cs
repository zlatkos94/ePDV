using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ePdv
{
    public partial class LoginForm : Form
    {
        ConnectionString cnnString = new ConnectionString();

        readonly string database = "G2SYSTEM_000005";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                bool errorflag = false;
                errorProvider1.Clear();
                if (txtUserName.Text.Trim() == "")
                {
                    errorflag = true;
                    errorProvider1.SetError(txtUserName, "Please provide User Name");

                }
                if (txtPassword.Text.Trim() == "")
                {
                    errorflag = true;
                    errorProvider1.SetError(txtPassword, "Please provide password");

                }
                if (cboServer.Text.Trim() == "")
                {
                    errorflag = true;
                    errorProvider1.SetError(cboServer, "Please provide password");

                }
                if (errorflag == false)
                {

                    SqlConnection myConnection = new SqlConnection();

                    SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();

                    myBuilder.DataSource = cboServer.Text;

                    myBuilder.UserID = txtUserName.Text;

                    myBuilder.Password = txtPassword.Text;

                    myBuilder.InitialCatalog = database;

                    myBuilder.ConnectTimeout = 15;

                    myConnection.ConnectionString = myBuilder.ConnectionString;

                    ParametriBaze.DataSource = myBuilder.DataSource;
                    ParametriBaze.UserID = myBuilder.UserID;
                    ParametriBaze.Password = myBuilder.Password;
                    ParametriBaze.ConnectTimeout = myBuilder.ConnectTimeout;

                    try
                    {
                        SqlConnection con = new SqlConnection(myConnection.ConnectionString);
                        con.Open();
                        if (ConnectionState.Open == con.State)
                        {
                            cnnString.UpdateAppConfigFile(myConnection.ConnectionString);
                            ConfigurationManager.RefreshSection("connectionStrings");
                            this.Hide();
                            IzbornikForm izbornik = new IzbornikForm();
                            izbornik.Dock = DockStyle.Fill;
                            izbornik.ShowDialog();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("You Are not connected to this database");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                }

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cboServer.Items.Add("SERVER");
            cboServer.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboServer.SelectedIndex = 0;
            this.cboServer.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
