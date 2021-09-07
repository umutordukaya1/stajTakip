using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace StajTakip
{
    public partial class Form5 : Form
    {
        
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-89CQ59UG;Database=staj;Integrated Security = true");
        int i = 0;
       
        private void button1_Click(object sender, EventArgs e)
        {
             i = 0;
             this.printPreviewControl1.Document = this.printDocument1;
          

        }



        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string sorgu;
            if (textBox1.Text == " ")
                sorgu = "SELECT*FROM tblogrenci";
            else
            sorgu = "SELECT*FROM tblogrenci WHERE BOLUM='" + textBox1.Text + "'";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            adp.Fill(tablo);

            Font myfont = new Font("Arial", 10, FontStyle.Bold);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen mypen = new Pen(Color.Black);
            e.Graphics.DrawString("TC NO", myfont, sbrush, 30, 50);
            e.Graphics.DrawString("NUMARA", myfont, sbrush, 125, 50);
            e.Graphics.DrawString("AD", myfont, sbrush, 217, 50);
            e.Graphics.DrawString("SOYAD", myfont, sbrush, 250, 50);
            e.Graphics.DrawString("BOLUM", myfont, sbrush, 325, 50);
            //e.Graphics.DrawString("ALAN", myfont, sbrush, 485, 50);
            e.Graphics.DrawString("ADRES", myfont, sbrush, 490, 50);
            e.Graphics.DrawString("İSLETME", myfont, sbrush, 595, 50);
            e.Graphics.DrawString("TELEFON", myfont, sbrush, 720, 50);
            /*e.Graphics.DrawString("KOORDİNATOR", myfont, sbrush, 590, 50);*/
            e.Graphics.DrawLine(mypen, 30, 75, 770, 75);
            int y = 90;
            myfont = new Font("Arial", 10, FontStyle.Regular);
            while (i < tablo.Rows.Count)
            {
                e.Graphics.DrawString(tablo.Rows[i][0].ToString(), myfont, sbrush, 30, y);
                e.Graphics.DrawString(tablo.Rows[i][1].ToString(), myfont, sbrush, 125, y);
                e.Graphics.DrawString(tablo.Rows[i][2].ToString(), myfont, sbrush, 215, y);
                e.Graphics.DrawString(tablo.Rows[i][3].ToString(), myfont, sbrush, 255, y);
                e.Graphics.DrawString(tablo.Rows[i][4].ToString(), myfont, sbrush, 325, y);
                //e.Graphics.DrawString(tablo.Rows[i][5].ToString(), myfont, sbrush, 485, y);
                e.Graphics.DrawString(tablo.Rows[i][8].ToString(), myfont, sbrush, 490, y);
                e.Graphics.DrawString(tablo.Rows[i][6].ToString(), myfont, sbrush, 595, y);
                e.Graphics.DrawString(tablo.Rows[i][9].ToString(), myfont, sbrush, 720, y);
                y += 20; i++;
            }
        }
    }
}
