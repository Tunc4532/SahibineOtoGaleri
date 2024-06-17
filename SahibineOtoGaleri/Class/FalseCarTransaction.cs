using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahibineOtoGaleri.Class
{
    public class FalseCarTransaction
    {
        MySqlConnection conect;
        MySqlDataAdapter data;
        public DataTable table;

        //satılan araçları listeleme işlemi
        public void DataTransfer()
        {
            conect = new MySqlConnection(DataConnection.con);
            conect.Open();
            data = new MySqlDataAdapter("select * from carssold_tbl", conect);
            table = new DataTable("veriler");
            data.Fill(table);
            conect.Close();
        }

    }
}
