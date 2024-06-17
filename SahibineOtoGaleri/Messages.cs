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
    public partial class Messages : Form
    {
        public Messages()
        {
            InitializeComponent();
        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        //Cell Click olayı gerçekleşştiği anda verileri taşıma işlemi
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txt_id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_name.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_mail.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txt_message.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void Messages_Load(object sender, EventArgs e)
        {
            MessageTransaction data = new MessageTransaction();
            data.DataTransfer();
            dataGridView1.DataSource = data.table;
        }

        //butona tıklama olayı gerçekleşirken textboxtan id'yi alıp Transaction sınııfına gönderme işleemi
        private void button1_Click(object sender, EventArgs e)
        {
            int numara;
            MessageTransaction silme = new MessageTransaction();
            numara = Convert.ToInt32(txt_id.Text);
            try
            {
                silme.MessageDelete(numara);
                MessageBox.Show("Mesaj Silindi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString(), "Error");
            }
        }
    }
}
