using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udemy.BusinessLogicLayer;
using Udemy.Entities;

namespace Udemy.TelefonRehberi
{
    public partial class KullaniciKayitForm : Form
    {
        public KullaniciKayitForm()
        {
            InitializeComponent();
            
        }

        private void btnKayıtKaydol_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bLL = new BusinessLogicLayer.BLL();
            List<Kullanici> KullaniciKontrol = bLL.KullaniciKayitListe();
            
            string aranandeger = txtKayitKullaniciAdi.Text;
            Kullanici KontrolListe = KullaniciKontrol.Find(x => x.KullaniciAdi.ToLower() == aranandeger.ToLower());
            if (KontrolListe == null)
            {
                int returnValue = bLL.KullaniciEkle(txtKayitKullaniciAdi.Text, txtKayitSifre.Text, Guid.NewGuid());
                if (returnValue > 0)
                {
                    MessageBox.Show("Kullanıcı kayıdı başarılı");
                }
                else
                {
                    MessageBox.Show("Eksik parametre");
                }

            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı ile kayıt bulunmaktadır");
            }
           

        }
    }
}
