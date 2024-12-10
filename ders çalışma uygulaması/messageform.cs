using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ders_çalışma_uygulaması
{
    public partial class messageform : Form
    {
        int kazan;
        int sure;
        int toppuan;
        public messageform(int soru, int süre,int puan)
        {
            InitializeComponent();
            kazan = soru;
            sure = süre;
            toppuan = puan;
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void messageform_Load(object sender, EventArgs e)
        {
            label1.Text = "çözülen soru : " + kazan;
            label2.Text = "Puan : " + toppuan;
            label3.Text = "Süre : " + sure;
            label4.Text = "Ortalama(soru/sn) : " + (Convert.ToDouble( sure)/ Convert.ToDouble(kazan));
        }
    }
}
