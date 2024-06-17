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
    public partial class SatilanAraclar : Form
    {
        public SatilanAraclar()
        {
            InitializeComponent();
        }
         //LSTELEME İŞLEMİ
        private void SatilanAraclar_Load(object sender, EventArgs e)
        {
            FalseCarTransaction data = new FalseCarTransaction();
            data.DataTransfer();
            dataGridView1.DataSource = data.table;
        }

        //çift tıklayınca verileri textboxlara taşıma işlemi
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            lbl_saticiad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            lbl_saticitelefon.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            lbl_saticiTC.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            lbl_aliciad.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            lbl_alicitelefon.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            lbl_aliciTC.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

            lbl_marka.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            lbl_model.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            lbl_yıl.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            lbl_plaka.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            lbl_renk.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            lbl_sifir.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
            lbl_fiyat.Text = dataGridView1.Rows[secilen].Cells[14].Value.ToString();
            lbl_tarih.Text = dataGridView1.Rows[secilen].Cells[15].Value.ToString();
        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
