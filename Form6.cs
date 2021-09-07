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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=LAPTOP-89CQ59UG;Database=staj;Integrated Security = true");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "INSERT INTO tblkoordinator VALUES(@adsoyad,@mail)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@adsoyad", textBox1.Text);
                komut.Parameters.AddWithValue("@mail", textBox2.Text);
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
