using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahibineOtoGaleri.Class
{
    public class MessageTransaction
    {
        MySqlConnection conect;
        MySqlDataAdapter data;
        public DataTable table;

        //veri taşı
        public void DataTransfer()
        {
            conect = new MySqlConnection(DataConnection.con);
            conect.Open();
            data = new MySqlDataAdapter("select * from contact_tbl", conect);
            table = new DataTable("veriler");
            data.Fill(table);
            conect.Close();
        }

        //gelen parametredeki id numarasına göre silme işlemmi
        public void MessageDelete(int id)
        {
            conect = new MySqlConnection(DataConnection.con);
            MySqlCommand delete = new MySqlCommand();
            delete.Connection = conect;
            delete.CommandText = "delete from contact_tbl where Id=@no";
            int no = id;
            delete.Parameters.AddWithValue("@no", no);
            conect.Open();
            delete.ExecuteNonQuery();
            conect.Close();
        }

    }
}
