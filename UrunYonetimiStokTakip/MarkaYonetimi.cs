﻿using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Entities;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class MarkaYonetimi : Form
    {
        public MarkaYonetimi()
        {
            InitializeComponent();
        }
        MarkaManager manager = new MarkaManager();

        void Yukle()
        {
            dgvMarkalar.DataSource = manager.GetAll();
        }
        private void MarkaYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        void Temizle()
        {
            txtMarkaAciklamasi.Text = string.Empty;
            txtMarkaAdi.Text = string.Empty;
            lblEklenmeTarihi.Text = string.Empty;
            cbDurum.Checked = false;
            lblId.Text = "0";
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            int islemSonucu = manager.Add(
                new Marka
                {
                    MarkaAdi = txtMarkaAdi.Text,
                    Aciklamasi = txtMarkaAciklamasi.Text,
                    Aktif = cbDurum.Checked,
                    EklenmeTarihi = DateTime.Now
               
                }
                );
            if (islemSonucu > 0)
            {
                Temizle();
                Yukle();
                MessageBox.Show("Kayıt Eklendi!");
            }
            else MessageBox.Show("Kayıt Eklenemedi.");

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);
            if (id>0)
            {
                int islemSonucu=manager.Update(
                    new Marka
                    {
                        Id = id,
                        MarkaAdi = txtMarkaAdi.Text,
                        Aciklamasi = txtMarkaAciklamasi.Text,
                        Aktif = cbDurum.Checked,
                        EklenmeTarihi = Convert.ToDateTime(lblEklenmeTarihi.Text)
                    }) ;
                if (islemSonucu > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Güncellendi!");
                }
                else MessageBox.Show("Kayıt Güncellenemedi.");
            }
            else  MessageBox.Show("Listeden güncellenecek kaydı seçiniz!");
 
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);

            if (id>0)
            {
                
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int islemSonucu = manager.Delete(id);

                    if (islemSonucu > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                    else MessageBox.Show("Kayıt Silinemedi.");
                }
                
            }
            else MessageBox.Show("Listeden silinecek kaydı seçiniz!");

        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void dgvMarkalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text = dgvMarkalar.CurrentRow.Cells[0].Value.ToString();
            txtMarkaAdi.Text = dgvMarkalar.CurrentRow.Cells[1].Value.ToString();
            txtMarkaAciklamasi.Text = dgvMarkalar.CurrentRow.Cells[2].Value.ToString();
            lblEklenmeTarihi.Text = dgvMarkalar.CurrentRow.Cells[3].Value.ToString();
             cbDurum.Checked = Convert.ToBoolean(dgvMarkalar.CurrentRow.Cells[4].Value.ToString());

        }
    }
}
