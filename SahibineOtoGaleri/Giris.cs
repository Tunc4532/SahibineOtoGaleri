using MySql.Data.MySqlClient;
using SahibineOtoGaleri.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SahibineOtoGaleri
{
    public partial class Giris : Form
    {
        // anasayfa türünde bir field oluşturup nesnenin özelliklerine erişildi
        Anasayfa anasayfa;
        public Giris()
        {
            InitializeComponent();
        }

        //Kayıtlı lullanıcı sorgulayarak giriş yapma işlemleri 
        private void girisBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection conect;

            conect = new MySqlConnection(DataConnection.con);
            conect.Open();
            MySqlCommand komut = new MySqlCommand("Select * from user_tbl where FirstName=@l1 and Password=@l2", conect)
            {
                Connection = conect
            };

            komut.Parameters.AddWithValue("@l1", txt_name.Text);
            komut.Parameters.AddWithValue("@l2", txt_password.Text);

            MySqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                anasayfa= new Anasayfa();
                anasayfa.Show();
                anasayfa.lbl_UserName.Text = txt_name.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı veya Şifre Girişi");
            }

            conect.Close();
        }

        //LogOut İşlemi
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                txt_password.UseSystemPasswordChar = false;
            else
                txt_password.UseSystemPasswordChar = true;

        }

        private void btn_Kayit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni kayıt eklemek için giriş yapıp 'Yeni Müşteri' butonundan kayıt ekleyebilirsiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
