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
    public class CarTransactions
    {
        MySqlConnection conect;
         
        //yeni araç girişi
        public void AddCars(string brand, string model, string plateNumber, string color, string firstOrSecond, string description, string carImage, string pricing,string gearType,string fuel,string modelYear,byte status,string iletisim,string img2,string img3, string name)
        {
            conect = new MySqlConnection(DataConnection.con);
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = conect;
            conect.Open();
            komut.CommandText = "INSERT INTO cars_tbl VALUES (NULL,'" + brand + "','" + model + "','" + plateNumber + "','" + color + "','" + firstOrSecond + "','" + description + "','" + carImage + "','" + pricing + "','" + status + "','" + gearType + "','" + fuel + "','" + modelYear + "','" + iletisim + "','" + img2 + "','" + img3 + "','" + name + "')";
            komut.ExecuteNonQuery();
            conect.Close();
        }

    }
}
