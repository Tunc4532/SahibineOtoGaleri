using MySql.Data.MySqlClient;
using SahibineOtoGaleri.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SahibineOtoGaleri
{
    public partial class NewCarSatis : Form
    {
        public NewCarSatis()
        {
            InitializeComponent();
        }
        
        //satiş yapma işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            string customerAd, customerPhone, customerTC, personName, personPhone, personTC, carBrand,
                carModel, carModelYear, carPlateNumber, carColor, ikiniSifir, carImage, carPricing, carSalesDate;

            NewCarSalesTransactions newCarSalesTransactions = new NewCarSalesTransactions();
            customerAd = txt_aliciadsad.Text;
            customerPhone = txt_alicitelefon.Text;
            customerTC = txt_aliciTC.Text;
            personName = txt_saticiadsad.Text;
            personPhone = txt_saticitelefon.Text;
            personTC = txt_saticiTC.Text;
            carBrand = txt_marka.Text;
            carModel = txt_model.Text;
            carModelYear = txt_yil.Text;
            carPlateNumber = txt_plaka.Text;
            carColor = txt_renk.Text;
            ikiniSifir = txt_sifir.Text;
            carImage = txt_image.Text;
            carPricing = txt_fiyat.Text;
            carSalesDate = txt_satistarih.Text;
            try
            {
                newCarSalesTransactions.AddCarsSold(customerAd, customerPhone, customerTC, personName, personPhone
                    , personTC, carBrand, carModel, carModelYear, carPlateNumber, carColor, ikiniSifir, carImage, carPricing, carSalesDate);
                MessageBox.Show("Satış Yapma İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString(), "Error");
            }
        }


        //open file dilog ile resim ekleme işlemi
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txt_image.Text = openFileDialog1.FileName;
        }

        //ilanı pasif hale getirme işlemi
        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=sahibineotodb;Uid=root;Pwd='';";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE cars_tbl SET CarSatus=@e8 WHERE CarId=@e9 ";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@e8", 0);
                    command.Parameters.AddWithValue("@e9", txt_carid.Text);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Satılan Araç İlandan Kaldırıldı");
                    }
                    else
                    {
                        MessageBox.Show("Hatalı İşlem Bütün Alanların Dolu Olduğundan Emin Olunuz");
                    }
                }
            }

        }

        //form açılınca verileri listeleme islemi
        private void NewCarSatis_Load(object sender, EventArgs e)
        {
            NewCarSalesTransactions data = new NewCarSalesTransactions();
            data.DataTransfer();
            dataGridView1.DataSource = data.table;
        }

        //veri taşıma işlemi
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txt_carid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_marka.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_model.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txt_plaka.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txt_renk.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txt_sifir.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txt_image.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txt_fiyat.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            txt_durum.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            txt_yil.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            txt_saticitelefon.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
            txt_saticiadsad.Text = dataGridView1.Rows[secilen].Cells[16].Value.ToString();
        }

        //ilanı aktif hale getirme işlemi
        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=sahibineotodb;Uid=root;Pwd='';";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE cars_tbl SET CarSatus=@e8 WHERE CarId=@e9 ";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@e8", 1);
                    command.Parameters.AddWithValue("@e9", txt_carid.Text);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(" Araç İlanı Yeniden Aktifleştirildi");
                    }
                    else
                    {
                        MessageBox.Show("Hatalı İşlem Bütün Alanların Dolu Olduğundan Emin Olunuz");
                    }
                }
            }
        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
