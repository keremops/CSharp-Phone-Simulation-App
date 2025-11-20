using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Telefon telefon;

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (Int32.TryParse(txtSarj.Text, out int sarj_int) &&
                txtMarka.Text.Length > 0 &&
                txtModel.Text.Length > 0) // Veri formatı düzgünse telefona atama yap ve butonları aç
            {
                telefon = new Telefon(sarj_int, txtMarka.Text, txtModel.Text);

                btnCharge.Enabled = true;
                btnPlay.Enabled = true;
                btnShow.Enabled = true;
                btnSave.Enabled = false;

                txtMarka.ReadOnly = true;
                txtModel.ReadOnly = true;
                txtSarj.ReadOnly = true;

                telefon.DurumGuncelle(txtMarka, txtModel, txtSarj);
            }
            else
            {
                MessageBox.Show("Hata: Uygun formatta veri girişi yapın!\nÖrn. Şarj değeri bir sayı olmalıdır.");
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                telefon.OyunOyna();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            telefon.DurumGuncelle(txtMarka, txtModel, txtSarj);
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            telefon.SarjEt();
            telefon.DurumGuncelle(txtMarka, txtModel, txtSarj);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            lblStat.Text = telefon.DurumGoster();
            telefon.DurumGuncelle(txtMarka, txtModel, txtSarj);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMarka.Clear();
            txtModel.Clear();
            txtSarj.Clear();
            telefon = null;

            btnCharge.Enabled = false;
            btnPlay.Enabled = false;
            btnShow.Enabled = false;
            btnSave.Enabled = true;

            txtMarka.ReadOnly = false;
            txtModel.ReadOnly = false;
            txtSarj.ReadOnly = false;
        }
    }
}
