using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahibineOtoGaleri.Class
{
    public class ActiveCarTransaction
    {
        MySqlConnection conect;
        MySqlDataAdapter data;
        public DataTable table;

        //status değeri true olan araçları listeler
        public void DataTransfer()
        {
            conect = new MySqlConnection(DataConnection.con);
            conect.Open();
            data = new MySqlDataAdapter("select * from cars_tbl where CarSatus = 1", conect);
            table = new DataTable("veriler");
            data.Fill(table);
            conect.Close();
        }


    }
}
