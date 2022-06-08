using IkORM.Entitiy;
using IkORM.Facade;
using System;
using System.Windows.Forms;

namespace _2KatmanliProje
{
    public partial class Company : Form
    {
        public Company()
        {
            InitializeComponent();
        }

        public void sirketList()
        {
            dataGridView1.DataSource = Sirketler.Listele();
        }
        private void btn_list_Click(object sender, EventArgs e)
        {
            sirketList();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Sirket sirket1 = new Sirket();
            sirket1.SirketAd = txt_sAd.Text;
            sirket1.SirketAdres = txt_sAdres.Text;
            sirket1.Stel = txt_sTel.Text;
            sirket1.Smail = txt_sMail.Text;
            sirket1.BolumId = Convert.ToInt32(comboBoxBolum.SelectedValue);
            sirket1.PozisyonId = Convert.ToInt32(comboBoxPozisyon.SelectedValue);
            if (!Sirketler.Ekle(sirket1))
            {
                MessageBox.Show("Şirket Eklenemedi.");
            }
            sirketList();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Sirket sirket1 = new Sirket();
            sirket1.sirketId = Convert.ToInt32(txt_sAd.Tag);
            sirket1.SirketAd = txt_sAd.Text;
            sirket1.SirketAdres = txt_sAdres.Text;
            sirket1.Stel = txt_sTel.Text;
            sirket1.Smail = txt_sMail.Text;
            sirket1.BolumId = Convert.ToInt32(comboBoxBolum.SelectedValue);
            sirket1.PozisyonId = Convert.ToInt32(comboBoxPozisyon.SelectedValue);

            if (!Sirketler.Guncelle(sirket1))
            {
                MessageBox.Show("Şirket Güncellenemedi.");
            }
            sirketList();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Sirket sirket1 = new Sirket();

            sirket1.sirketId = (int)dataGridView1.CurrentRow.Cells["id"].Value;
            if (!Sirketler.Sil(sirket1))
            { MessageBox.Show("Silinmedi."); }
            sirketList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            txt_sAd.Tag = row.Cells["id"].Value.ToString();
            txt_sAd.Text = row.Cells["sAd"].Value.ToString();
            txt_sAdres.Text = row.Cells["sAdres"].Value.ToString();
            txt_sTel.Text = row.Cells["sTel"].Value.ToString();
            txt_sMail.Text = row.Cells["sMail"].Value.ToString();
            string bolumId = row.Cells["bolumId"].Value.ToString();
            comboBoxBolum.Text = Bolumler.BolumlerCombo(bolumId);
            string pozId = row.Cells["pozisyonId"].Value.ToString();
            comboBoxPozisyon.Text = Pozisyonlar.PozisyonCombo(pozId);
        }
        private void çalışanlarToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void Company_Load(object sender, EventArgs e)
        {
            comboBoxBolum.DataSource = Bolumler.Listele();
            comboBoxBolum.DisplayMember = "bolumAd";
            comboBoxBolum.ValueMember = "id";
            comboBoxPozisyon.DataSource = Pozisyonlar.Listele();
            comboBoxPozisyon.DisplayMember = "pozisyonAd";
            comboBoxPozisyon.ValueMember = "pozisyonId";
        }
    }
}
