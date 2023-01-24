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
    public partial class Form2 : Form 
    {
    public Form2() 
    {
    InitializeComponent(); 
    }
    OleDbConnection baglantim=new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=superlig.accdb");
    private void OyuncuListele(string link) 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM OyuncuVerileri WHERE Takım=@Takım", baglantim);
    listele.SelectCommand.Parameters.AddWithValue("@Takım", link);
    listele.Fill(tablo);
    dataGridView1.DataSource = tablo;
    dataGridView1.Columns[0].Visible=false;
    for(int i=6;i<15;i++) 
    {
    dataGridView1.Columns[i].Visible=false; 
    }
    baglantim.Close(); 
    }
    private void IstatistikListele(string link) 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM OyuncuVerileri WHERE Takım=@Takım", baglantim);
    listele.SelectCommand.Parameters.AddWithValue("@Takım", link);
    listele.Fill(tablo);
    dataGridView2.DataSource = tablo;
    dataGridView2.Columns[0].Visible=false;
    dataGridView2.Columns[15].Visible=false;
    baglantim.Close(); 
    }
    private void TakimBilgisi(string link) 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM TakimVerileri WHERE Takım=@Takım", baglantim);
    komut.Parameters.AddWithValue("@Takım", link);
    tablo.Clear();
    OleDbDataReader VeriOku=komut.ExecuteReader();
    tablo.Load(VeriOku);
    int k=0;
    label11.Text=tablo.Rows[0][0].ToString();
    Label[] labelDizi = new Label[] 
    {
    label14,label15,label16,label19,label20,label22 
    };
    for(int i=9;i<16;i++) 
    {
    if(i==12) 
    { 
    continue; 
    }
    labelDizi[k].Text=tablo.Rows[0][i].ToString();
    k++; 
    }
    pictureBox1.Image = new Bitmap(tablo.Rows[0][16].ToString());
    baglantim.Close(); 
    }
    private void TeknikDirektor(string link) 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM TeknikDirektor WHERE Takım=@Takım", baglantim);
    komut.Parameters.AddWithValue("@Takım", link);
    tablo.Clear();
    OleDbDataReader VeriOku=komut.ExecuteReader();
    tablo.Load(VeriOku);
    Label[] labelDizi = new Label[] 
    {
    label6,label7,label8,label9 
    };
    for(int i=1;i<5;i++) 
    {
    labelDizi[i-1].Text=tablo.Rows[0][i].ToString(); 
    }
    baglantim.Close(); 
    }
    private void BaskanBilgisi(string link) 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM BaskanVerileri WHERE Takım=@Takım", baglantim);
    komut.Parameters.AddWithValue("@Takım", link);
    tablo.Clear();
    OleDbDataReader VeriOku=komut.ExecuteReader();
    tablo.Load(VeriOku);
    Label[] labelDizi = new Label[] 
    {
    label26,label25,label24 
    };
    for(int i=1;i<4;i++) 
    {
    labelDizi[i-1].Text=tablo.Rows[0][i].ToString(); 
    }
    baglantim.Close(); 
    }
    private void FiksturBilgisi(string link) 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM FiksturSirala WHERE ([Ev Sahibi]=@Takım OR [Deplasman]=@Takım)", baglantim);
    listele.SelectCommand.Parameters.AddWithValue("@Takım", link);
    listele.Fill(tablo);
    dataGridView3.DataSource = tablo;
    dataGridView3.Columns[0].Visible=false;
    baglantim.Close(); 
    }
    private void Form2_Load(object sender, EventArgs e) 
    {
    OyuncuListele(sender.ToString().Remove(0, 24));
    IstatistikListele(sender.ToString().Remove(0, 24));
    TakimBilgisi(sender.ToString().Remove(0, 24));
    TeknikDirektor(sender.ToString().Remove(0, 24));
    FiksturBilgisi(sender.ToString().Remove(0, 24));
    BaskanBilgisi(sender.ToString().Remove(0, 24)); 
    } 
    } 
    }