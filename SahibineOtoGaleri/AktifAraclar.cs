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
    public partial class AktifAraclar : Form
    {
        public AktifAraclar()
        {
            InitializeComponent();
        }

        //durumu aktif olan araçları listeleme işlemi
        private void AktifAraclar_Load(object sender, EventArgs e)
        {
            ActiveCarTransaction data = new ActiveCarTransaction();
            data.DataTransfer();
            dataGridView1.DataSource = data.table;
        }

        //Çift tıklayarak veri taşıma
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            lbl_yıl.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            lbl_vites.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            lbl_fiyat.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            lbl_marka.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            lbl_model.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            lbl_plaka.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            lbl_sifir.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            lbl_renk.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            lbl_yakit.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            lbl_iletisim.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
