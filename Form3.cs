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

namespace StajTakip
{
    public partial class Form3 : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-89CQ59UG;Database=staj;Integrated Security = true");
        public Form3()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "INSERT INTO tblisletme VALUES(@no,@isletmeadi,@alan,@adres,@telefon,@staj_sorumlusu,@koordinator,@il,@ilce,@mail)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@no", textBox1.Text);
                komut.Parameters.AddWithValue("@isletmeadi", textBox2.Text);
                komut.Parameters.AddWithValue("@alan", textBox3.Text);
                komut.Parameters.AddWithValue("@adres", textBox4.Text);
                komut.Parameters.AddWithValue("@telefon", textBox5.Text);
                komut.Parameters.AddWithValue("@staj_sorumlusu", textBox6.Text);
                komut.Parameters.AddWithValue("@koordinator", textBox7.Text);
                komut.Parameters.AddWithValue("@il", textBox8.Text);
                komut.Parameters.AddWithValue("@ilce", textBox9.Text);
                komut.Parameters.AddWithValue("@mail", textBox10.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("KAYIT EKLENDİ");
                this.Hide();

            }

            catch (Exception hata)
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                MessageBox.Show("Hatamız budur: " + hata);
            }

        }
    }
}
