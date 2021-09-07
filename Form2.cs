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
    public partial class Form2 : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-89CQ59UG;Database=staj;Integrated Security = true");

        public Form2()
        {
            InitializeComponent();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "INSERT INTO tblogrenci VALUES(@TC,@numara,@ad,@soyad,@bölüm,@alan,@isletme,@koordinatör,@adres,@telefon)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@TC", textBox1.Text);
                komut.Parameters.AddWithValue("@numara", textBox2.Text);
                komut.Parameters.AddWithValue("@ad", textBox3.Text);
                komut.Parameters.AddWithValue("@soyad", textBox4.Text);
                komut.Parameters.AddWithValue("@bölüm", textBox5.Text);
                komut.Parameters.AddWithValue("@alan", textBox6.Text);
                komut.Parameters.AddWithValue("@isletme", textBox7.Text);
                komut.Parameters.AddWithValue("@koordinatör", comboBox1.Text);
                komut.Parameters.AddWithValue("@adres", textBox9.Text);
                komut.Parameters.AddWithValue("@telefon", textBox10.Text);
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
        public void combobox()
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM tblkoordinator";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["AD SOYAD"]);
            }
            baglanti.Close();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            combobox();
        }
    }
}
