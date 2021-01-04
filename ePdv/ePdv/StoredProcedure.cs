using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ePdv
{
    class StoredProcedure
    {
        private string sConn = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public DataTable KontrolaPDV(DateTime datum_od, DateTime datum_do)
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@Datum_od", SqlDbType.DateTime).Value = datum_od;

            command.Parameters.Add("@Datum_do", SqlDbType.DateTime).Value = datum_do;

            command.CommandText = "dbo.kontrola_ePDV";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }

        public DataTable KontrolaEnabavke(DateTime datum_od, DateTime datum_do)
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@Datum_od", SqlDbType.DateTime).Value = datum_od;

            command.Parameters.Add("@Datum_do", SqlDbType.DateTime).Value = datum_do;

            command.CommandText = "dbo.kontrola_eNabavke";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }

        public DataTable KontrolaEisporuke(DateTime datum_od, DateTime datum_do)
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@Datum_od", SqlDbType.DateTime).Value = datum_od;

            command.Parameters.Add("@Datum_do", SqlDbType.DateTime).Value = datum_do;

            command.CommandText = "dbo.kontrola_eIsporuke";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }

        public void Insert_eNabavke(string Poreski_period, DateTime datum_od, DateTime datum_do)
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Parametri
            command.Parameters.Add("@Poreski_period", SqlDbType.VarChar).Value = Poreski_period;

            command.Parameters.Add("@Datum_od", SqlDbType.DateTime).Value = datum_od;

            command.Parameters.Add("@Datum_do", SqlDbType.DateTime).Value = datum_do;

            command.CommandText = "dbo.insert_eNabavke";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable DohvatiEnabavke()
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.CommandText = "dbo.SelectEnabavke";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }

        public DataTable SumEnabavke()
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.CommandText = "dbo.SumEnabavke";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }

        public DataTable DohvatiEnabavkeZaglavlje()
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.CommandText = "dbo.SelectEnabavkeZaglavlje";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }
        public void Insert_eZaglavlje(string Poreski_period, DateTime datumKreiranja)
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Parametri
            command.Parameters.Add("@Poreski_period", SqlDbType.VarChar).Value = Poreski_period;

            command.Parameters.Add("@datum_kreiranja", SqlDbType.DateTime).Value = datumKreiranja;


            command.CommandText = "dbo.insert_eZaglavlje";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        // ISPORUKE

        public void Insert_eIsporuke(string Poreski_period, DateTime datum_od, DateTime datum_do)
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Parametri
            command.Parameters.Add("@Poreski_period", SqlDbType.VarChar).Value = Poreski_period;

            command.Parameters.Add("@Datum_od", SqlDbType.DateTime).Value = datum_od;

            command.Parameters.Add("@Datum_do", SqlDbType.DateTime).Value = datum_do;

            command.CommandText = "dbo.insert_eIsporuke";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable Dohvati_eIsporukeZaglavlje()
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.CommandText = "dbo.SelecteIsporukeZaglavlje";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }

        public DataTable Sum_eIsporuke()
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.CommandText = "dbo.SelectSum_eIsporuke";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }
        public DataTable Dohvati_eIsporuke()
        {
            SqlConnection connection = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.CommandText = "dbo.Select_eIsporuke";

            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            connection.Close();

            return dt;
        }
    }
}
