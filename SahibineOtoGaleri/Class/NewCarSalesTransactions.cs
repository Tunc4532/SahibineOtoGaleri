using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SahibineOtoGaleri.Class
{
    public class NewCarSalesTransactions
    {
        MySqlConnection conect;
        MySqlDataAdapter data;
        public DataTable table;

        //yeni satış yapma işlemi
        public void AddCarsSold(string customerAd, string customerPhone, string customerTC, string personName, string personPhone, string personTC, string carBrand, string carModel, string carModelYear, string carPlateNumber, string carColor, string ikiniSifir, string carImage, string carPricing, string carSalesDate)
        {
            conect = new MySqlConnection(DataConnection.con);
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = conect;
            conect.Open();
            komut.CommandText = "INSERT INTO carssold_tbl VALUES (NULL,'" + customerAd + "','" + customerPhone + "','" + customerTC + "','" + personName + "','" + personPhone + "','" + personTC + "','" + carBrand + "','" + carModel + "','" + carModelYear + "','" + carPlateNumber + "','" + carColor + "','" + ikiniSifir + "','" + carImage + "','" + carPricing + "','" + carSalesDate + "')";
            komut.ExecuteNonQuery();
            conect.Close();
        }

        //dataadapter ile veri taşıma işlemi
        public void DataTransfer()
        {
            conect = new MySqlConnection(DataConnection.con);
            conect.Open();
            data = new MySqlDataAdapter("select * from CARS_tbl", conect);
            table = new DataTable("veriler");
            data.Fill(table);
            conect.Close();
        }


    }
}
