using IkORM.Entitiy;
using IkORM.Facade;
using System;
using System.Windows.Forms;


namespace _2KatmanliProje
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }
        public void bolumList()
        {
            dataGridView1.DataSource = Bolumler.Listele();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            txt_depAdi.Tag = row.Cells["id"].Value.ToString();
            txt_depAdi.Text = row.Cells["bolumAd"].Value.ToString();
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            bolumList();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Bolum bolum1 = new Bolum();
            bolum1.BolumAd = txt_depAdi.Text;
            if (!Bolumler.Ekle(bolum1))
            {
                MessageBox.Show("Pozisyon Eklenemedi.");

            }
            bolumList();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Bolum bolum1 = new Bolum();
            bolum1.BolumAd = txt_depAdi.Text;
            bolum1.Bolumid = Convert.ToInt32(txt_depAdi.Tag);
            if (!Bolumler.Guncelle(bolum1))
            {
                MessageBox.Show("Güncellenemedi.");
            }
            bolumList();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            Bolum bolum1 = new Bolum();
            if (dataGridView1.CurrentRow == null) return;

            bolum1.Bolumid = (int)dataGridView1.CurrentRow.Cells["id"].Value;
            if (!Bolumler.Sil(bolum1))
            { MessageBox.Show("Silinmedi."); }
            bolumList();
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

    }
}
