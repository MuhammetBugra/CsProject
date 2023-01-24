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
    public partial class Form3 : Form 
    {
    public Form3() 
    {
    InitializeComponent(); 
    }
    OleDbConnection baglantim=new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=superlig.accdb");
    private void TakimListele() 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM TakimVerileri", baglantim);
    listele.Fill(tablo);
    dataGridView1.DataSource = tablo;
    baglantim.Close();
    }
    private void BaskanListele() 
    { 
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM BaskanVerileri", baglantim);
    listele.Fill(tablo);
    dataGridView4.DataSource = tablo;
    dataGridView4.Columns[0].Visible=false;
    baglantim.Close(); 
    }
    private void AntrenorListele() 
    { 
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM TeknikDirektor", baglantim);
    listele.Fill(tablo);
    dataGridView5.DataSource = tablo;
    dataGridView5.Columns[0].Visible=false;
    baglantim.Close(); 
    }
    private void ComboBoxEkle() 
    {
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM TakimVerileri",baglantim);
    OleDbDataReader VeriOku=komut.ExecuteReader();
    for(int i=1;i<39;i++) 
    { 
    comboBox2.Items.Add(i); 
    }
    while(VeriOku.Read()) 
    {
    if(!comboBox1.Items.Contains(VeriOku[0])) 
    { 
    comboBox1.Items.Add(VeriOku[0]); 
    } 
    }
    baglantim.Close(); 
    }
    private void Form3_Load(object sender, EventArgs e) 
    {
    ComboBoxEkle();
    TakimListele();
    BaskanListele();
    AntrenorListele(); 
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
    {
    DataTable tablo=new DataTable();
    tablo.Clear();
    baglantim.Open();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM OyuncuVerileri WHERE Takım=@Takım", baglantim);
    listele.SelectCommand.Parameters.AddWithValue("@Takım", comboBox1.Text);
    listele.Fill(tablo);
    dataGridView2.DataSource = tablo;
    dataGridView2.Columns[0].Visible=false; 
    baglantim.Close(); 
    }
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) 
    {
    DataTable tablo=new DataTable();
    tablo.Clear();
    baglantim.Open();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM FiksturBilgileri WHERE Hafta=@Hafta", baglantim);
    listele.SelectCommand.Parameters.AddWithValue("@Hafta", comboBox2.Text);
    listele.Fill(tablo);
    dataGridView3.DataSource = tablo;
    dataGridView3.Columns[0].Visible=false;
    dataGridView3.Columns[1].Visible=false;
    baglantim.Close(); 
    }
    private void button1_Click(object sender, EventArgs e) 
    {
    baglantim.Open();
    OleDbDataAdapter kaydet=new OleDbDataAdapter("Update TakimVerileri SET Maç=@Maç, Galibiyet=@Galibiyet, Beraberlik=@Beraberlik, Mağlubiyet=@Mağlubiyet, [Atılan Gol]=@AtılanGol, [Yenilen Gol]=@YenilenGol, Averaj=@Averaj, Puan=@Puan, [Kadro Genişliği]=@KadroGenişliği, [Ortalama Yaş]=@OrtalamaYaş, [Yabancı Sayısı]=@YabancıSayısı, [Ortalama Piyasa Değeri]=@OrtalamaPiyasaDeğeri, [Toplam Piyasa Değeri]=@ToplamPiyasaDeğeri, Stat=@Stat, [Kuruluş Yılı]=@KuruluşYılı WHERE Takım=@Takım", baglantim);
    for(int i=0;i<20;i++) 
    {
    kaydet.SelectCommand.Parameters.Clear();
    kaydet.SelectCommand.Parameters.AddWithValue("@Maç", dataGridView1.Rows[i].Cells[1].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Galibiyet", dataGridView1.Rows[i].Cells[2].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Beraberlik", dataGridView1.Rows[i].Cells[3].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Mağlubiyet", dataGridView1.Rows[i].Cells[4].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@AtılanGol", dataGridView1.Rows[i].Cells[5].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@YenilenGol", dataGridView1.Rows[i].Cells[6].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Averaj", dataGridView1.Rows[i].Cells[7].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Puan", dataGridView1.Rows[i].Cells[8].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@KadroGenişliği", dataGridView1.Rows[i].Cells[9].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@OrtalamaYaş", dataGridView1.Rows[i].Cells[10].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@YabancıSayısı", dataGridView1.Rows[i].Cells[11].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@OrtalamaPiyasaDeğeri", dataGridView1.Rows[i].Cells[12].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@ToplamPiyasaDeğeri", dataGridView1.Rows[i].Cells[13].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Stat", dataGridView1.Rows[i].Cells[14].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@KuruluşYılı", dataGridView1.Rows[i].Cells[15].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Takım", dataGridView1.Rows[i].Cells[0].Value);
    kaydet.SelectCommand.ExecuteNonQuery(); 
    }
    baglantim.Close(); 
    }
    private void button4_Click(object sender, EventArgs e) 
    {
    baglantim.Open();
    OleDbDataAdapter kaydet=new OleDbDataAdapter("Update OyuncuVerileri SET [Oyuncu Adı]=@OyuncuAdı, Mevki=@Mevki, Yaş=@Yaş, Takım=@Takım, Uyruk=@Uyruk, Maç=@Maç, [İlk 11]=@İlk11, Gol=@Gol, Asist=@Asist, [Sarı Kart]=@SarıKart, [Kırmızı Kart]=@KırmızıKart, [Oynadığı Dakika]=@OynadığıDakika, [Gol Yemediği Maç]=@GolYemediğiMaç, [Yediği Gol]=@YediğiGol, [Piyasa Değeri]=@PiyasaDeğeri WHERE Kimlik=@Kimlik", baglantim);
    for(int i=0;i<dataGridView2.RowCount;i++) 
    {
    kaydet.SelectCommand.Parameters.Clear();
    kaydet.SelectCommand.Parameters.AddWithValue("@OyuncuAdı", dataGridView2.Rows[i].Cells[1].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Mevki", dataGridView2.Rows[i].Cells[2].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Yaş", dataGridView2.Rows[i].Cells[3].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Takım", dataGridView2.Rows[i].Cells[4].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Uyruk", dataGridView2.Rows[i].Cells[5].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Maç", dataGridView2.Rows[i].Cells[6].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@İlk11", dataGridView2.Rows[i].Cells[7].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Gol", dataGridView2.Rows[i].Cells[8].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Asist", dataGridView2.Rows[i].Cells[9].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@SarıKart", dataGridView2.Rows[i].Cells[10].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@KırmızıKart", dataGridView2.Rows[i].Cells[11].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@OynadığıDakika", dataGridView2.Rows[i].Cells[12].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@GolYemediğiMaç", dataGridView2.Rows[i].Cells[13].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@YediğiGol", dataGridView2.Rows[i].Cells[14].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@PiyasaDeğeri", dataGridView2.Rows[i].Cells[15].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Kimlik", dataGridView2.Rows[i].Cells[0].Value);
    kaydet.SelectCommand.ExecuteNonQuery(); 
    }
    baglantim.Close(); 
    }
    private void button6_Click(object sender, EventArgs e) 
    {
    baglantim.Open();
    OleDbDataAdapter kaydet=new OleDbDataAdapter("Update FiksturBilgileri SET Hafta=@Hafta, [Ev Sahibi]=@EvSahibi, Deplasman=@Deplasman, [Ev Sahibi Skor]=@EvSahibiSkor, [Deplasman Skor]=@DeplasmanSkor WHERE Kimlik=@Kimlik", baglantim);
    for(int i=0;i<10;i++) 
    {
    kaydet.SelectCommand.Parameters.Clear();
    kaydet.SelectCommand.Parameters.AddWithValue("@Hafta", dataGridView3.Rows[i].Cells[1].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@EvSahibi", dataGridView3.Rows[i].Cells[2].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Deplasman", dataGridView3.Rows[i].Cells[3].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@EvSahibiSkor", dataGridView3.Rows[i].Cells[4].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@DeplasmanSkor", dataGridView3.Rows[i].Cells[5].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Kimlik", dataGridView3.Rows[i].Cells[0].Value);
    kaydet.SelectCommand.ExecuteNonQuery(); 
    }
    baglantim.Close(); 
    }
    private void button8_Click(object sender, EventArgs e) 
    {
    baglantim.Open();
    OleDbDataAdapter kaydet=new OleDbDataAdapter("Update BaskanVerileri SET [Adı Soyadı]=@AdıSoyadı, Yaş=@Yaş, Uyruk=@Uyruk WHERE Takım=@Takım", baglantim);
    for(int i=0;i<20;i++) 
    {
    kaydet.SelectCommand.Parameters.Clear();
    kaydet.SelectCommand.Parameters.AddWithValue("@AdıSoyadı", dataGridView4.Rows[i].Cells[1].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Yaş", dataGridView4.Rows[i].Cells[2].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Uyruk", dataGridView4.Rows[i].Cells[3].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Takım", dataGridView4.Rows[i].Cells[4].Value);
    kaydet.SelectCommand.ExecuteNonQuery(); 
    }
    baglantim.Close(); 
    }
    private void button10_Click(object sender, EventArgs e) 
    {
    baglantim.Open();
    OleDbDataAdapter kaydet=new OleDbDataAdapter("Update TeknikDirektor SET [Adı Soyadı]=@AdıSoyadı, Yaş=@Yaş, Uyruk=@Uyruk, [Tercih Edilen Diziliş]=@TercihEdilenDiziliş WHERE Takım=@Takım", baglantim);
    for(int i=0;i<20;i++) 
    {
    kaydet.SelectCommand.Parameters.Clear();
    kaydet.SelectCommand.Parameters.AddWithValue("@AdıSoyadı", dataGridView5.Rows[i].Cells[1].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Yaş", dataGridView5.Rows[i].Cells[2].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Uyruk", dataGridView5.Rows[i].Cells[3].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@TercihEdilenDiziliş", dataGridView5.Rows[i].Cells[4].Value);
    kaydet.SelectCommand.Parameters.AddWithValue("@Takım", dataGridView5.Rows[i].Cells[5].Value);
    kaydet.SelectCommand.ExecuteNonQuery(); 
    }
    baglantim.Close(); 
    }
    private void button2_Click(object sender, EventArgs e) 
    {
    TakimListele(); 
    }
    private void button3_Click(object sender, EventArgs e) 
    {
    comboBox1_SelectedIndexChanged(sender,e); 
    }
    private void button5_Click(object sender, EventArgs e) 
    {
    comboBox2_SelectedIndexChanged(sender,e); 
    }
    private void button7_Click(object sender, EventArgs e) 
    {
    BaskanListele(); 
    }
    private void button9_Click(object sender, EventArgs e) 
    {
    AntrenorListele(); 
    }
    private void button11_Click(object sender, EventArgs e)
    {
    try {
    baglantim.Open();
    OleDbDataAdapter sil=new OleDbDataAdapter("Delete FROM OyuncuVerileri WHERE Kimlik=@Kimlik", baglantim);
    sil.SelectCommand.Parameters.AddWithValue("@Kimlik", dataGridView2.SelectedRows[0].Cells[0].Value);
    sil.SelectCommand.ExecuteNonQuery();
    MessageBox.Show("Seçtiğiniz Oyuncu Başarıyla Silindi...");
    baglantim.Close();
    comboBox1_SelectedIndexChanged(sender,e);
    }
    catch 
    {
    MessageBox.Show("Seçtiğiniz Satır Silinemedi. Lütfen Satırın Başına Tıklayınız...");
    }
    }
    private void button12_Click(object sender, EventArgs e)
    {
    Form4 form4= new Form4();
    form4.Show(); 
    }
    } 
    }