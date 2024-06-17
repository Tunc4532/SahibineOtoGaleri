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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        //yeni araç giriş sayfasına yönlendirme işlemi
        private void btn_yeniarac_Click(object sender, EventArgs e)
        {
            NewAddCar newAddCar = new NewAddCar();
            newAddCar.Show();
            this.Hide();
        }

        //satılan araçlar sayfasına yönlendirme işlemi
        private void btn_SatilanArac_Click(object sender, EventArgs e)
        {
            SatilanAraclar satilanAraclar = new SatilanAraclar();
            satilanAraclar.Show();
            this.Hide();
        }
        //aktif araçlar sayfasına yönlendirme işlemi
        private void btn_ActiveCar_Click(object sender, EventArgs e)
        {
            AktifAraclar aktifAraclar = new AktifAraclar();
            aktifAraclar.Show();
            this.Hide();

        }
        //yeni müşteri ekleme sayfasına yönlendirme işlemi
        private void btn_NewCoustemer_Click(object sender, EventArgs e)
        {
            Custemers custemers = new Custemers();
            custemers.Show();
            this.Hide();
        }
        //müşteri bilgileri sayfasına yönlendirme işlemi
        private void btn_Coustumers_Click(object sender, EventArgs e)
        {
            Custemers custemers = new Custemers();
            custemers.Show();
            this.Hide();
        }
        //satılan araçlar Hareket sayfasına yönlendirme işlemi
        private void btn_Hareketler_Click(object sender, EventArgs e)
        {
            SatilanAraclar satilanAraclar = new SatilanAraclar();
            satilanAraclar.Show();
            this.Hide();
        }

        private void btn_CarSatis_Click(object sender, EventArgs e)
        {
            NewCarSatis satis = new NewCarSatis();
            satis.Show();
            this.Hide();
        }

        private void btn_message_Click(object sender, EventArgs e)
        {
            Messages messages = new Messages();
            messages.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

    }
}
