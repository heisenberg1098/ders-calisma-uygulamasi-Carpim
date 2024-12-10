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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = trackBar1.Value.ToString() + " SN";
            saniye = trackBar1.Value;
        }
        Random rnd = new Random();
        int saniye;
        int sayi1;
        int sayi2;
        string[] isaret = { "+", "*", "/", "-" };
        int isl;
        public void Islem()
        {
            textBox1.Focus();
            timer1.Start();
            sayi2= rnd.Next(1,trackBar2.Value);
            sayi1 = rnd.Next(sayi2,trackBar2.Value);
            isl = rnd.Next(0, 4);
            label3.Text = (sayi1+" "+ isaret[isl]+" "+sayi2 ).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            saniye= trackBar1.Value;
            progressBar1.Maximum = saniye - 1;
            progressBar1.Minimum = 0;
            progressBar1.Value = progressBar1.Maximum;
            Islem();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString() + " SN";
            saniye = trackBar1.Value;
            progressBar1.Maximum = saniye - 1;
        }
        int topsure = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            topsure++;
            saniye--;
            label1.Text = saniye.ToString();

            if (saniye==0)
            {
                button2.PerformClick();
            }
            else
            {
                progressBar1.Value = saniye;
            }
        }
        int puan=0;
        public void yapilinca()
        {
            puan += trackBar2.Value;
            saniye = trackBar1.Value;
            progressBar1.Maximum = saniye - 1;
            textBox1.Text = "";
            Islem();
            ++kazanilan;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text)))
            {


                double kuldeger = Convert.ToDouble(textBox1.Text);
                switch (isl)
                {
                    case 0://+ * / -
                        if (kuldeger == Convert.ToDouble(sayi2 + sayi1))
                        {
                            yapilinca();
                        }
                        break;
                    case 1://+ * / -
                        if (kuldeger == Convert.ToDouble(sayi2 * sayi1))
                        {
                            yapilinca();
                        }
                        break;
                    case 2://+ * / -
                        if (kuldeger == Convert.ToDouble( sayi1 / sayi2))
                        {
                            yapilinca();
                        }
                        break;
                    case 3://+ * / -
                        if (kuldeger == Convert.ToDouble(sayi1 - sayi2))
                        {
                            yapilinca();
                        }
                        break;
                }
                label5.Text = "Puan :" + puan.ToString();
            }
            else
            {

            }
        }
        int kazanilan=0;
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            messageform m1 = new messageform(kazanilan, topsure, puan);
            m1.Show();
            puan = 0;
            kazanilan = 0;
            topsure = 0;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value<33)
               label4.ForeColor= Color.Green;
            else if (trackBar2.Value<66)
               label4.ForeColor= Color.Yellow;
            else if (trackBar2.Value<100)
               label4.ForeColor= Color.Red;
        }
    }
}
