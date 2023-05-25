using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BrendonEksamen
{
    public class DBlayer
    {
        public void BindGrid()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnElev"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Elev", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
        }

        public DataTable GetElevByNavn(string navn)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnElev"].ConnectionString;
            DataTable dt = new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Elev.ElevID, Elev.Fornavn, Elev.Etternavn, Elev.Adresse, Poststeder.Poststed, Klasse.KlasseNavn FROM Elev JOIN Poststeder ON Elev.PostNr = Poststeder.PostNr JOIN Klasse ON Elev.KlasseID = Klasse.KlasseID WHERE Elev.Fornavn = @navn", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@navn", SqlDbType.NVarChar);
                param.Value = navn;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt; 
        }

        public DataTable GetElevByFag(string fagNavn)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnElev"].ConnectionString;
            DataTable dt = new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT fornavn,etternavn,adresse,postnr,klasseid,fagnavn FROM elev,fag,fagelev WHERE fagelev.elevid = elev.elevid AND fagelev.fagkode = fag.fagkode AND fag.fagnavn = @fagNavn", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@fagNavn", SqlDbType.NVarChar);
                param.Value = fagNavn;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt; 
        }
        public DataTable GetElevByKlasse(string klasseNavn)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnElev"].ConnectionString;
            DataTable dt = new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Elev.Fornavn, Elev.Etternavn, Klasse.KlasseNavn FROM Elev INNER JOIN Klasse ON Elev.KlasseID = Klasse.KlasseID WHERE (Klasse.KlasseNavn = @klasseNavn OR @klasseNavn = '')", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@klasseNavn", SqlDbType.NVarChar);
                param.Value = klasseNavn; 
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt; 
        }

        public DataTable GetElevByKlasseogFag(string klasseNavn, string fagNavn)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnElev"].ConnectionString;
            DataTable dt = new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT fornavn,etternavn,adresse,postnr,klassenavn,fagnavn FROM elev,fag,fagelev,klasse WHERE fagelev.elevid = elev.elevid AND fagelev.fagkode = fag.fagkode and elev.klasseid = klasse.klasseid AND klasse.klasseNavn = @klasseNavn and fag.fagnavn = @fagNavn", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@klasseNavn", SqlDbType.NVarChar);
                param.Value = klasseNavn; 
                cmd.Parameters.Add(param);
                param = new SqlParameter("@fagNavn", SqlDbType.NVarChar);
                param.Value = fagNavn; 
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt;
        }
    }
}
