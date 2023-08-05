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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            int returnValue = bll.KayitEkle(txtYIsim.Text, txtYSoyisim.Text, txtYTelefonI.Text, txtYTelefonII.Text, txtYTelefonIII.Text, txtYEmailAdres.Text, txtYWebAdres.Text, txtYAdres.Text, txtYAciklama.Text);
            if (returnValue > 0)
            {
                ListeDoldur();
                MessageBox.Show("Yeni Kayıt Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            ListeDoldur();
        }

        private void ListeDoldur()
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            List<Rehber> Kayitlar = bll.KayitListe();
            if(Kayitlar != null&&Kayitlar.Count > 0) 
            {
                lstListe.DataSource = Kayitlar;
            }
            
        }

        private void lstListe_DoubleClick(object sender, EventArgs e)
        {
            ListBox LST = (ListBox)sender;
            Rehber Secilenkayit = (Rehber)LST.SelectedItem;
            if (Secilenkayit != null)
            {
                txtGIsim.Text = Secilenkayit.Isim;
                txtGSoyisim.Text = Secilenkayit.Soyisim;
                txtGEmailAdres.Text = Secilenkayit.EmailAdres;
                txtGTelefonI.Text = Secilenkayit.TelefonNumarasiI;
                txtGTelefonII.Text = Secilenkayit.TelefonNumarasiII;
                txtGTelefonIII.Text = Secilenkayit.TelefonNumarasiIII;
                txtGWebAdres.Text = Secilenkayit.WebAdres;
                txtYAdres.Text = Secilenkayit.Adres;
                txtGAciklama.Text = Secilenkayit.Aciklama;
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Guid ID = ((Rehber)lstListe.SelectedItem).ID;
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            int returnValues = bll.KayitDuzenle(ID, txtGIsim.Text, txtGSoyisim.Text, txtGTelefonI.Text, txtGTelefonII.Text, txtGTelefonIII.Text, txtYEmailAdres.Text, txtGWebAdres.Text, txtYAdres.Text, txtGAciklama.Text);
            if (returnValues > 0)
            {
                ListeDoldur();
                MessageBox.Show("Kaydınız başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Guid ID = ((Rehber)lstListe.SelectedItem).ID;
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            int returnValues = bll.KayitSil(ID);
            if(returnValues > 0) 
            {
                ListeDoldur();
                MessageBox.Show("Kaydınız başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
