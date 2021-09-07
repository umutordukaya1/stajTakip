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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button14.Text = DateTime.Now.ToLongDateString();
            button15.Text = DateTime.Now.ToLongTimeString();
            listeOgrenci();
            listeİsletme();
            combobox1();
            combobox2();


        }


        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-89CQ59UG;Database=staj;Integrated Security = true");
        public void listeOgrenci()
        {
            try
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "Select *From tblogrenci";
                SqlDataAdapter adp = new SqlDataAdapter(komut);
                DataTable tablo = new DataTable();
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hatamız budur: " + hata);
            }

        }
        public void listeİsletme() {

            try
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "Select *From tblisletme";
                SqlDataAdapter adp = new SqlDataAdapter(komut);
                DataTable tablo = new DataTable();
                adp.Fill(tablo);
                dataGridView2.DataSource = tablo;
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hatamız budur: " + hata);
            }



        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string mesaj = "BU PROGRAM UMUT ORDUKAYA TARAFINDAN YAPILMIŞTIR BÜTÜN HAKLARI SAKLIDIR";
            MessageBox.Show(mesaj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
           /* Form6 form6 = new Form6();
            form6.Show();*/
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int i = 0;
            string sorgu;
           
            sorgu = "SELECT*FROM tblogrenci";
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
            e.Graphics.DrawString("TELEFON", myfont, sbrush, 710, 50);
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
                e.Graphics.DrawString(tablo.Rows[i][9].ToString(), myfont, sbrush, 710, y);
                y += 20; i++;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "Select *From tblogrenci where [TC NO] ='"+textBox1.Text+"'AND BOLUM ='"+comboBox2.Text+"'";
                SqlDataAdapter adp = new SqlDataAdapter(komut);
                DataTable tablo = new DataTable();
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
                textBox1.Focus();
                comboBox2.Text = "";
                textBox1.Clear();
                
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hatamız budur: " + hata);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }
        public void combobox1()
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT DISTINCT ALAN FROM tblogrenci";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["ALAN"]);
            }
            baglanti.Close();
          


        }
        public void combobox2()
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT DISTINCT BOLUM FROM tblogrenci ";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["BOLUM"]);
            }
            baglanti.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tablo1 = comboBox1.Text;
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT *FROM tblogrenci WHERE ALAN='" + tablo1 + "'";
                SqlDataAdapter adp = new SqlDataAdapter(komut);
                DataTable tablo = new DataTable();
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }catch(Exception hata)
            {
                MessageBox.Show(hata + "hatsı");
            }
          
        }

        private void button17_Click(object sender, EventArgs e)
        {
            listeOgrenci();
            listeİsletme();
            

        }
    }
}
