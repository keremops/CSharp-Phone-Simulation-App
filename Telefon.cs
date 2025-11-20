using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Telefon
    {
        private int tel_sarj;
        public string marka, model;

        public Telefon(int sarj, string marka, string model)  // Başlatıcı
        {
            if (sarj < 0)
            {
                sarj = 0;
            }
            else if (sarj > 100) 
            {
                sarj = 100;
            }

            this.tel_sarj = sarj;
            this.marka = marka;
            this.model = model;
        }

        public void OyunOyna() 
        {
            if (this.tel_sarj >= 20)
            {
                this.tel_sarj -= 20; // Oyun Başarıyla Oynandı
            }
            else if (this.tel_sarj > 0)
            {
                this.tel_sarj = 0; // Oyun Oynarken İşlem Yarıda Kesildi (Şarj Bitti)
                throw new Exception("Hata: Şarj yetersiz olduğu için oyun yarıda kesildi!");

            }
            else
            {   // Şarj zaten yok
                throw new Exception("Hata: Şarj bitmişken oyun oynanamaz!");
            }
        }

        public void SarjEt()
        {
            this.tel_sarj += 30;

            if (this.tel_sarj > 100)
            {
                this.tel_sarj = 100;
            }
        }

        public string DurumGoster()
        {
            return "Marka: " + this.marka + " Model: " + this.model + " Şarj: " + this.tel_sarj;
        }

        public void DurumGuncelle(TextBox txtMarka, TextBox txtModel, TextBox txtSarj)
        {
            txtMarka.Text = this.marka;
            txtModel.Text = this.model;
            txtSarj.Text = this.tel_sarj.ToString();
        }
    }
}
