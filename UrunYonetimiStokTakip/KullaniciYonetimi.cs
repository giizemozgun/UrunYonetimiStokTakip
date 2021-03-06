using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        KullaniciManager manager = new KullaniciManager();
        
        void Yukle()
        {
            dgvKullanicilar.DataSource = manager.GetAll();
        }
        void Temizle()
        {
            txtAdi.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtKullaniciAdi.Text = string.Empty;
            txtSifre.Text = string.Empty;
            txtSoyadi.Text = string.Empty;
            cbDurum.Checked = false;
            lblId.Text = "0";


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                new Kullanici
                {
                    Adi = txtAdi.Text,
                    Soyadi = txtSoyadi.Text,
                    Email = txtEmail.Text,
                    KullaniciAdi = txtKullaniciAdi.Text,
                    Sifre = txtSifre.Text,
                    Aktif = cbDurum.Checked

                });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata oluştu! Kayıt Eklenemedi!n\\Boş Alan bırakmadan tekrar deneyiniz.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Update(
                new Kullanici
                {
                    Id = int.Parse(lblId.Text),
                    Adi = txtAdi.Text,
                    Soyadi = txtSoyadi.Text,
                    Email = txtEmail.Text,
                    KullaniciAdi = txtKullaniciAdi.Text,
                    Sifre = txtSifre.Text,
                    Aktif = cbDurum.Checked

                });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Güncellendi!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata oluştu! Kayıt Güncellenemedi!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden silinecek kaydı seçiniz!");
                }
                else
                {
                    var sonuc = manager.Delete(int.Parse(lblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Kayıt Silinemedi!");

            }
        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void markaYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ürünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kullanıcıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgvKullanicilar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = dgvKullanicilar.CurrentRow.Cells[0].Value.ToString();
                txtKullaniciAdi.Text = dgvKullanicilar.CurrentRow.Cells[1].Value.ToString();
                if (dgvKullanicilar.CurrentRow.Cells[2].Value != null)
                {
                    txtSifre.Text = dgvKullanicilar.CurrentRow.Cells[2].Value.ToString();
                }

                txtEmail.Text = dgvKullanicilar.CurrentRow.Cells[3].Value.ToString();
                txtAdi.Text= dgvKullanicilar.CurrentRow.Cells[4].Value.ToString();
                txtSoyadi.Text = dgvKullanicilar.CurrentRow.Cells[5].Value.ToString();
                cbDurum.Checked = Convert.ToBoolean(dgvKullanicilar.CurrentRow.Cells[6].Value.ToString());
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt atanırken Hata oluştu!");
            }

        }
    }
    }

