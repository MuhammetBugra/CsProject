using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _201180003
    {
    public partial class Form4 : Form
    {
    public Form4()
    {
    InitializeComponent();
    }
    OleDbConnection baglantim=new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=superlig.accdb");
    private void ComboBoxEkle() 
    {
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM OyuncuVerileri",baglantim);
    OleDbDataReader VeriOku=komut.ExecuteReader();
    while(VeriOku.Read()) 
    {
    if(!comboBox1.Items.Contains(VeriOku[2])) 
    { 
    comboBox1.Items.Add(VeriOku[2]); 
    }
    if(!comboBox2.Items.Contains(VeriOku[4])) 
    {
    comboBox2.Items.Add(VeriOku[4]);
    }
    }
    baglantim.Close(); 
    }
    private void TextBoxOzellik()
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM OyuncuVerileri ORDER BY OyuncuVerileri.Kimlik ASC", baglantim);
    OleDbDataReader VeriOku=komut.ExecuteReader();
    tablo.Load(VeriOku);
    int i=tablo.Rows.Count;
    textBox1.Text = (Convert.ToInt32(tablo.Rows[i - 1][0])+1).ToString();
    textBox2.Text="0";
    textBox3.Text = "0";
    textBox4.Text = "0";
    textBox5.Text = "0";
    textBox6.Text = "0";
    textBox7.Text = "0";
    textBox8.Text = "0";
    textBox9.Text = "0";
    textBox10.Text = "0";
    textBox11.Text = "0";
    textBox13.Text = "0";
    textBox14.Text = "0";
    textBox15.Text = "0";
    baglantim.Close();
    }
    private void OyuncuEkle() 
    {
    baglantim.Open();
    OleDbDataAdapter kaydet=new OleDbDataAdapter("Insert into OyuncuVerileri (Kimlik, [Oyuncu Adı], Mevki, Yaş, Takım, Uyruk, Maç, [İlk 11], Gol, Asist, [Sarı Kart], [Kırmızı Kart], [Oynadığı Dakika], [Gol Yemediği Maç], [Yediği Gol], [Piyasa Değeri]) Values (@Kimlik, @OyuncuAdı, @Mevki, @Yaş, @Takım, @Uyruk, @Maç, @İlk11, @Gol, @Asist, @SarıKart, @KırmızıKart, @OynadığıDakika, @GolYemediğiMaç, @YediğiGol, @PiyasaDeğeri)", baglantim);
    kaydet.SelectCommand.Parameters.AddWithValue("@Kimlik", Convert.ToInt32(textBox1.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@OyuncuAdı", textBox2.Text);
    kaydet.SelectCommand.Parameters.AddWithValue("@Mevki", comboBox1.Text);
    kaydet.SelectCommand.Parameters.AddWithValue("@Yaş", Convert.ToInt32(textBox3.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@Takım", comboBox2.Text);
    kaydet.SelectCommand.Parameters.AddWithValue("@Uyruk", textBox4.Text);
    kaydet.SelectCommand.Parameters.AddWithValue("@Maç", Convert.ToInt32(textBox5.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@İlk11", Convert.ToInt32(textBox6.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@Gol", Convert.ToInt32(textBox7.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@Asist", Convert.ToInt32(textBox8.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@SarıKart", Convert.ToInt32(textBox9.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@KırmızıKart", Convert.ToInt32(textBox10.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@OynadığıDakika", Convert.ToInt32(textBox11.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@GolYemediğiMaç", Convert.ToInt32(textBox13.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@YediğiGol", Convert.ToInt32(textBox14.Text));
    kaydet.SelectCommand.Parameters.AddWithValue("@PiyasaDeğeri", Convert.ToInt32(textBox15.Text));
    kaydet.SelectCommand.ExecuteNonQuery(); 
    baglantim.Close();
    }
    private void Form4_Load(object sender, EventArgs e)
    {
    ComboBoxEkle();
    TextBoxOzellik();
    }
    private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
    {
    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }
    private void button1_Click(object sender, EventArgs e)
    {
    OyuncuEkle();
    button2_Click(sender, e);
    MessageBox.Show("Yeni Oyuncu Başarıyla Eklendi...");
    TextBoxOzellik();
    }
    private void button2_Click(object sender, EventArgs e)
    {
    textBox2.Clear();
    textBox3.Clear();
    textBox4.Clear();
    textBox5.Clear();
    textBox6.Clear();
    textBox7.Clear();
    textBox8.Clear();
    textBox9.Clear();
    textBox10.Clear();
    textBox11.Clear();
    textBox13.Clear();
    textBox14.Clear();
    textBox15.Clear();
    comboBox1.SelectedIndex=-1;
    comboBox2.SelectedIndex=-1;
    }
    }
    }