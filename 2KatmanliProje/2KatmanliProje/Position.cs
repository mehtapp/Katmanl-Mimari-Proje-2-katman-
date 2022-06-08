using IkORM.Entitiy;
using IkORM.Facade;
using System;
using System.Windows.Forms;

namespace _2KatmanliProje
{
    public partial class Position : Form
    {
        public Position()
        {
            InitializeComponent();
        }

        public void pozisyonList()
        {
            dataGridView1.DataSource = Pozisyonlar.Listele();
        }
        private void btn_list_Click(object sender, EventArgs e)
        {
            pozisyonList();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Pozisyon poz1 = new Pozisyon();
            poz1.pozisyonAd = txt_pozisyonAdi.Text;
            if (!Pozisyonlar.Ekle(poz1))
            {
                MessageBox.Show("Pozisyon Eklenemedi.");

            }
            pozisyonList();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Pozisyon poz1 = new Pozisyon();
            poz1.pozisyonAd = txt_pozisyonAdi.Text;
            poz1.pozisyonId = Convert.ToInt32(txt_pozisyonAdi.Tag);
            if (!Pozisyonlar.Guncelle(poz1))
            {
                MessageBox.Show("Güncellenemedi.");
            }
            pozisyonList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            txt_pozisyonAdi.Tag = row.Cells["pozisyonId"].Value.ToString();
            txt_pozisyonAdi.Text = row.Cells["pozisyonAd"].Value.ToString();

        }

        private void btn_del_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow == null) return;
            Pozisyon poz1 = new Pozisyon();

            poz1.pozisyonId = (int)dataGridView1.CurrentRow.Cells["pozisyonId"].Value;
            if (!Pozisyonlar.Sil(poz1))
            { MessageBox.Show("Silinmedi."); }
            pozisyonList();
        }
        private void çalışanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            worker.Show();
            this.Hide();
        }

        private void bölümlerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Department dep = new Department();
            dep.Show();
            this.Hide();
        }

        private void pozisyonlarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Position pos = new Position();
            pos.Show();
            this.Hide();
        }

        private void şirketlerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
