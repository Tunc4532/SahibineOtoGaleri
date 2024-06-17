using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using SahibineOtoGaleri.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SahibineOtoGaleri
{
    public partial class Custemers : Form
    {
        public Custemers()
        {
            InitializeComponent();
        }

        //openfile dialog kullanarak resim ekleme işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txt_image.Text = openFileDialog1.FileName;
        }

        //ekle butonu tıklanınca sınıf nesnesi üzerinden yeni müşteri ekleme işlemi
        private void button2_Click(object sender, EventArgs e)
        {
            string firstName, lastName, phone, adress, tc, mail, password, userImage;
            CoustemerTransactions transactions = new CoustemerTransactions();

            firstName = txt_name.Text;
            lastName = txt_surname.Text;
            phone = txt_telefon.Text;
            adress = txt_adress.Text;
            tc = txt_tcno.Text;
            mail = txt_email.Text;
            password = txt_password.Text;
            userImage = txt_image.Text;
            try
            {
                transactions.AddCoustomer (firstName, lastName, phone, adress, tc, mail, password, userImage);
                MessageBox.Show("Müşteri Ekleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString(), "Error");
            }
        }

        //sil butonu tıklanınca sınıf nesnesi üzerinden müşteri silme işlemi
        private void btn_delete_Click(object sender, EventArgs e)
        {
            int numara;
            CoustemerTransactions silme = new CoustemerTransactions();
            //veri tabanı konfigurasyon uyumu kontrol edilecek
            numara = Convert.ToInt32(txt_id.Text);
            try
            {
                silme.CoustemerDelete(numara);
                MessageBox.Show("Kullanıcı Kayıdı Silindi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString(), "Error");
            }
        }

        //coustomer formu yükllendiği anda verileri datagiride aktarma
        private void Custemers_Load(object sender, EventArgs e)
        {
            CoustemerTransactions data = new CoustemerTransactions();
            data.DataTransfer();
            dataGridView1.DataSource = data.table;
        }

        //datagride çift tıklayarak verileri taşıma işlemi
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txt_name.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_surname.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txt_telefon.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txt_adress.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txt_email.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txt_tcno.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txt_password.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txt_image.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            txt_id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        #region
        //müşteri güncelleme işlemi
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=sahibineotodb;Uid=root;Pwd='';");
        //    baglanti.Open();
        //    // MySqlCommand komut = new MySqlCommand("Update user_tbl Set UserID='" + txt_id.Text + "', FirstName ='" + txt_name.Text + "'," + "LastName='" + txt_surname.Text + "'," + "Phone='" + msk_phone.Text + "'," + "Adress='" + txt_adress.Text + "'," + "'," + "TC='" + txt_tcno.Text + "'," + "Mail='" + txt_email.Text + "'," + "Password='" + txt_password.Text + "'," + "UserImage='" + txt_image.Text + "'," + "Where UserID='" + txt_id.Text + "'," + "'", baglanti);
        //    MySqlCommand komut = new MySqlCommand("UPDATE user_tbl SET UserID='" + txt_id.Text+ "',FirstName='" + txt_name.Text+ "',LastName='" + txt_surname.Text+ "',Phone='" + msk_phone.Text+ "',Adress='" + txt_adress.Text+ "'',TC='" + txt_tcno.Text+ "',Mail='" + txt_email.Text+ "',Password='" + txt_password.Text+ "',UserImage='" + txt_image.Text+ "' WHERE UserID='" + txt_id.Text+ "'",baglanti);
        //    komut.ExecuteNonQuery();
        //    baglanti.Close();
        //    MessageBox.Show("Kayıt Güncellendi");
        //}
        // UPDATE user_tbl SET UserID=+"''"+,`FirstName`='[value-2]',`LastName`='[value-3]',`Phone`='[value-4]',`Adress`='[value-5]',`TC`='[value-6]',`Mail`='[value-7]',`Password`='[value-8]',`UserImage`='[value-9]' WHERE 1
        #endregion

        //güncelle butonu tıklanınca sınıf nesnesi üzerinden müşteri güncelleme işlemi
        private void button4_Click(object sender, EventArgs e)
        {

            string connectionString = "Server=localhost;Database=sahibineotodb;Uid=root;Pwd='';";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE user_tbl SET FirstName=@e1, LastName=@e2, Phone=@e3, Adress=@e4,TC=@e5, Mail=@e6, Password=@e7, UserImage=@e8 WHERE UserID=@e9 ";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Parametreleri değerleriyle birlikte tanımlayın
                    command.Parameters.AddWithValue("@e1", txt_name.Text);
                    command.Parameters.AddWithValue("@e2", txt_surname.Text);
                    command.Parameters.AddWithValue("@e3", txt_telefon.Text);
                    command.Parameters.AddWithValue("@e4", txt_adress.Text);
                    command.Parameters.AddWithValue("@e5", txt_tcno.Text);
                    command.Parameters.AddWithValue("@e6", txt_email.Text);
                    command.Parameters.AddWithValue("@e7", txt_password.Text);
                    command.Parameters.AddWithValue("@e8", txt_image.Text);

                    command.Parameters.AddWithValue("@e9", txt_id.Text); // UserID değerini belirleyin

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                       MessageBox.Show("Güncelleme İşlemi Başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Belirtilen kullanıcı ID ile eşleşen kayıt bulunamadı veya herhangi bir güncelleme yapılmadı");
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
