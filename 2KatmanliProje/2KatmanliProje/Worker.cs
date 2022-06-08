using IkORM.Entitiy;
using IkORM.Facade;
using System;
using System.Windows.Forms;

namespace _2KatmanliProje
{
    public partial class Worker : Form
    {
        public Worker()
        {
            InitializeComponent();
        }
        public void calisanList()
        {
            dataGridView1.DataSource = calisanKisiler.Listele();
        }
        private void Worker_Load(object sender, EventArgs e)
        {
            comboBoxPozisyon.DataSource = Pozisyonlar.Listele();
            comboBoxPozisyon.ValueMember = "pozisyonId";
            comboBoxPozisyon.DisplayMember = "pozisyonAd";
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            calisanList();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            calisanKisi calisan1 = new calisanKisi();
            calisan1.calisanAdSoyad = txt_adSoyad.Text;
            calisan1.calisanYas = Convert.ToInt32(txt_yas.Text);
            calisan1.calisanMaas = Convert.ToInt32(txt_maas.Text);
            calisan1.calisanAdres = txt_adress.Text;
            calisan1.calisanMail = txt_mail.Text;
            calisan1.pozisyonId = Convert.ToInt32(comboBoxPozisyon.SelectedValue);

            if (!calisanKisiler.Ekle(calisan1))
            {
                MessageBox.Show("Çalışan Eklenemedi.");
            }
            calisanList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            txt_adSoyad.Tag = row.Cells["calisanid"].Value.ToString();
            txt_adSoyad.Text = row.Cells["cAdSoyad"].Value.ToString();
            txt_mail.Text = row.Cells["cMail"].Value.ToString();
            txt_maas.Text = row.Cells["cMaas"].Value.ToString();
            txt_yas.Text = row.Cells["cYas"].Value.ToString();
            txt_adress.Text = row.Cells["cAdres"].Value.ToString();      //fdlgudroıghjdfogdfjgmfd
            string pozNo = row.Cells["pozisyonId"].Value.ToString();
            comboBoxPozisyon.Text = Pozisyonlar.PozisyonCombo(pozNo);

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            calisanKisi sil = new calisanKisi();

            sil.calisanId = (int)dataGridView1.CurrentRow.Cells["calisanid"].Value;
            if (!calisanKisiler.Sil(sil))
            { MessageBox.Show("Silinmedi."); }
            calisanList();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            calisanKisi calisan1 = new calisanKisi();
            calisan1.calisanId = Convert.ToInt32(txt_adSoyad.Tag);
            calisan1.calisanAdSoyad = txt_adSoyad.Text;
            calisan1.calisanYas = Convert.ToInt32(txt_yas.Text);
            calisan1.calisanMaas = Convert.ToInt32(txt_maas.Text);
            calisan1.calisanAdres = txt_adress.Text;
            calisan1.calisanMail = txt_mail.Text;
            calisan1.pozisyonId = Convert.ToInt32(comboBoxPozisyon.SelectedValue);
            if (!calisanKisiler.Guncelle(calisan1))
            {
                MessageBox.Show("Güncellenemedi.");
            }
            calisanList();

        }
        private void çalışanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            worker.Show();
            this.Hide();
        }

        private void bölümlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Department dep = new Department();
            dep.Show();
            this.Hide();
        }

        private void pozisyonlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Position pos = new Position();
            pos.Show();
            this.Hide();
        }

        private void şirketlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxPozisyon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
