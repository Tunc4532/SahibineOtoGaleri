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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SahibineOtoGaleri
{
    public partial class NewAddCar : Form
    {
        public NewAddCar()
        {
            InitializeComponent();
        }

        // yeni aktif araç ilanı girişi
        private void button2_Click(object sender, EventArgs e)
        {
            string brand, model, plateNumber, color, firstOrSecond, description, carImage, pricing, gearType, fuel, modelYear,iletisim,img2,img3,name;
            byte status;
            CarTransactions transactions = new CarTransactions();

            brand = txt_brand.Text;
            model = txt_model.Text;
            plateNumber = txt_plaka.Text;
            color = txt_color.Text;
            firstOrSecond = txt_sifir.Text;
            description = rctxt_description.Text;
            carImage = txt_image.Text;
            pricing = txt_pricing.Text;
            gearType = txt_vites.Text;
            fuel = txt_yakit.Text;
            modelYear = txt_date.Text;
            status = 1;
            img2 = txt_image2.Text;
            img3 = txt_image3.Text;
            iletisim = txt_iltisim.Text;
            name = txt_adsoyad.Text;
            try
            {
                transactions.AddCars(brand, model, plateNumber, color, firstOrSecond, description, carImage, pricing, gearType, fuel, modelYear, status,iletisim,img2,img3,name);
                MessageBox.Show("Araba Ekleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString(), "Error");
            }
        }

        //open file dialog kullanarak resim ekleme işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Görsel seçimini url yolunu yapıştırarak'da kayıt edebilirsiniz");

            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txt_image.Text = openFileDialog1.FileName;
        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
