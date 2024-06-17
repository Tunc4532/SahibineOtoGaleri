using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SahibineOtoGaleri.Class
{
    public class CoustemerTransactions
    {
        MySqlConnection conect;
        MySqlDataAdapter data;
        public DataTable table;

        //yeni müşteri ekleme 
        public void AddCoustomer(string firstName, string lastName, string phone, string adress, string tc, string mail, string password, string userImage)
        {
            conect = new MySqlConnection(DataConnection.con);
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = conect;
            conect.Open();
            komut.CommandText = "INSERT INTO user_tbl VALUES (NULL,'" + firstName + "','" + lastName + "','" + phone + "','" + adress + "','" + tc + "','" + mail + "','" + password + "','" + userImage + "')";
            komut.ExecuteNonQuery();
            conect.Close();
        }

        //id değerine göre silme işlemi
        public void CoustemerDelete(int id)
        {
            conect = new MySqlConnection(DataConnection.con);
            MySqlCommand delete = new MySqlCommand
            {
                Connection = conect,
                CommandText = "delete from user_tbl where UserID=@no"
            };
            int no = id;
            delete.Parameters.AddWithValue("@no", no);
            conect.Open();
            delete.ExecuteNonQuery();
            conect.Close();
        }

        //dataadapter ile veri taşıma işlemi
        public void DataTransfer()
        {
            conect = new MySqlConnection(DataConnection.con);
            conect.Open();
            data = new MySqlDataAdapter("select * from user_tbl", conect);
            table = new DataTable("veriler");
            data.Fill(table);
            conect.Close();
        }

    }
}
