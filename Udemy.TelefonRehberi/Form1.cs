using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Udemy.TelefonRehberi
{
    public partial class Form1 : Form
    {
        Udemy.BusinessLogicLayer.BLL bll;
        public Form1()
        {
            InitializeComponent();
            bll = new BusinessLogicLayer.BLL();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            int returnValue = bll.SistemKontrol(txtKullaniciAdi.Text, txtSifre.Text);
            if (returnValue > 0) 
            {
                AnaForm AF = new AnaForm();
                AF.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre Girişi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
