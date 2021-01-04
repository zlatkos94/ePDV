using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace ePdv
{
    class ConnectionString
    {
        string conString =System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        public void UpdateAppConfigFile(string con)
        {

            XmlDocument objXmlfile = new XmlDocument();
            objXmlfile.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in objXmlfile.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    xElement.FirstChild.Attributes[2].Value = con;
                }
            }
            objXmlfile.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        public bool Proba(string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    return (con.State == ConnectionState.Open);
                }
                catch
                {
                    return false;
                }
            }
        }


        public DataTable DohvatiBaze()
        {
            SqlConnection connection = new SqlConnection(conString);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.CommandText = "dbo.select_se_evidencija_bt";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }
    }
}
