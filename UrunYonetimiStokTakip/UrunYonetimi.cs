using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class UrunYonetimi : Form
    {
        public UrunYonetimi()
        {
            InitializeComponent();
        }
        UrunManager manager = new UrunManager();
        void Yukle()
        {
            dgvUrunler.DataSource = manager.GetAll();
        }
        private void UrunYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                new Urun
                {
                    UrunAdi = txtUrunAdi.Text,
                    UrunFiyati = Decimal.Parse(txtUrunFiyati.Text),
                    Aciklama = rtbUrunAciklamasi.Text,
                    Aktif = cbDurum.Checked,
                    EklenmeTarihi = DateTime.Now,
                    Iskonto = int.Parse(txtIskonto.Text),
                    Kdv = int.Parse(txtKdv.Text),
                    StokMiktari = int.Parse(txtStokMiktari.Text),
                    ToptanFiyat = decimal.Parse(txtUrunFiyati.Text)
                    


                });
                if (sonuc > 0)
                {
                   
                    Yukle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception hata) //buradaki hata nesnesinden hata detaylarına ulaşabiliriz.
            {

                MessageBox.Show("Hata oluştu! Kayıt Eklenemedi!n\\Boş Alan bırakmadan tekrar deneyiniz.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void markaYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kullanıcıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
