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
    public partial class Form1 : Form 
    {
    public Form1() 
    {
    InitializeComponent(); 
    }
    OleDbConnection baglantim=new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=superlig.accdb");
    private void LigBilgisi() 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM TakimVerileri", baglantim);
    tablo.Clear();
    OleDbDataReader VeriOku=komut.ExecuteReader();
    tablo.Load(VeriOku);
    int OyuncuSayisi=0,YabanciSayisi=0; double OrtYas=0,OrtDeger=0,ToplamDeger=0;
    for(int i=0;i<20;i++) 
    {
    OyuncuSayisi+=Convert.ToInt32(tablo.Rows[i][9]);
    YabanciSayisi+=Convert.ToInt32(tablo.Rows[i][11]);
    OrtYas+=Convert.ToInt32(tablo.Rows[i][10]);
    OrtDeger+=Convert.ToInt32(tablo.Rows[i][12]);
    ToplamDeger+=Convert.ToInt32(tablo.Rows[i][13]); 
    }
    OrtYas=OrtYas/20;
    OrtDeger=OrtDeger/20;
    label426.Text = OyuncuSayisi.ToString();
    label427.Text = YabanciSayisi.ToString();
    label428.Text = OrtYas.ToString();
    label429.Text = OrtDeger.ToString();
    label431.Text = ToplamDeger.ToString();
    baglantim.Close(); 
    }
    private void PuanListele() 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM TakimVerileri ORDER BY TakimVerileri.Puan DESC, TakimVerileri.Averaj DESC, TakimVerileri.[Atılan Gol] DESC; ", baglantim);
    tablo.Clear();
    OleDbDataReader VeriOku=komut.ExecuteReader();
    tablo.Load(VeriOku);
    Label[] linkLabelDizi = new Label[] 
    {
    linkLabel1,linkLabel2,linkLabel3,linkLabel4,linkLabel5,linkLabel6,linkLabel7,linkLabel8,linkLabel9,linkLabel10,linkLabel11,linkLabel12,linkLabel13,linkLabel14,linkLabel15,linkLabel16,linkLabel17,linkLabel18,linkLabel19,linkLabel20 
    };
    for(int i=0;i<20;i++) 
    {
    linkLabelDizi[i].Text=tablo.Rows[i][0].ToString(); 
    }
    int k=0;
    Label[] labelDizi = new Label[] 
    {
    label12,label13,label14,label15,label16,label17,label18,label19,label21,label22,label23,label24,label25,label26,label27,label28,label30,label31,label32,label33,label34,label35,label36,label37,label39,label40,label41,label42,label43,label44,label45,label46,label48,label49,label50,label51,label52,label53,label54,label55,label57,label58,label59,label60,label61,label62,label63,label64,label66,label67,label68,label69,label70,label71,label72,label73,label75,label76,label77,label78,label79,label80,label81,label82,label84,label85,label86,label87,label88,label89,label90,label91,label93,label94,label95,label96,label97,label98,label99,label100,label102,label103,label104,label105,label106,label107,label108,label109,label111,label112,label113,label114,label115,label116,label117,label118,label120,label121,label122,label123,label124,label125,label126,label127,label129,label130,label131,label132,label133,label134,label135,label136,label138,label139,label140,label141,label142,label143,label144,label145,label147,label148,label149,label150,label151,label152,label153,label154,label156,label157,label158,label159,label160,label161,label162,label163,label165,label166,label167,label168,label169,label170,label171,label172,label174,label175,label176,label177,label178,label179,label180,label181,label183,label184,label185,label186,label187,label188,label189,label190 
    };
    for(int i=0;i<20;i++) 
    {
    for(int j=1;j<9;j++) 
    {
    labelDizi[k].Text=tablo.Rows[i][j].ToString();
    k++; 
    } 
    }
    baglantim.Close(); 
    }
    private void DegerListele() 
    { 
    DataTable tablo=new DataTable();
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM TakimVerileri ORDER BY TakimVerileri.[Toplam Piyasa Değeri] DESC; ", baglantim);
    tablo.Clear();
    OleDbDataReader VeriOku=komut.ExecuteReader();
    tablo.Load(VeriOku);
    Label[] linkLabelDizi=new Label[] 
    {
    linkLabel51,linkLabel52,linkLabel53,linkLabel54,linkLabel55,linkLabel56,linkLabel57,linkLabel58,linkLabel59,linkLabel60,linkLabel61,linkLabel62,linkLabel63,linkLabel64,linkLabel65,linkLabel66,linkLabel67,linkLabel68,linkLabel69,linkLabel70 
    };
    for(int i=0;i<20;i++) 
    {
    linkLabelDizi[i].Text=tablo.Rows[i][0].ToString(); 
    }
    int k=0;
    Label[] labelDizi = new Label[] 
    {
    label221,label222,label223,label224,label225,label226,label227,label228,label229,label230,label231,label232,label233,label234,label235,label236,label237,label238,label239,label240,label241,label242,label243,label244,label245,label246,label247,label248,label249,label250,label251,label252,label253,label254,label255,label256,label257,label258,label259,label260,label261,label262,label263,label264,label265,label266,label267,label268,label269,label270,label271,label272,label273,label274,label275,label276,label277,label278,label279,label280,label281,label282,label283,label284,label285,label286,label287,label288,label289,label290,label291,label292,label293,label294,label295,label296,label297,label298,label299,label300,label301,label302,label303,label304,label305,label306,label307,label308,label309,label310,label311,label312,label313,label314,label315,label316,label317,label318,label319,label320 
    };
    for(int i=0;i<20;i++) 
    {
    for(int j=9;j<14;j++) 
    {
    labelDizi[k].Text=tablo.Rows[i][j].ToString();
    k++; 
    } 
    }
    baglantim.Close(); 
    }
    private void FiksturListele() 
    {
    comboBox1.Text="1";
    DataTable tablo=new DataTable();
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand();
    tablo.Clear();
    komut=new OleDbCommand("SELECT * FROM FiksturBilgileri ORDER BY FiksturBilgileri.Kimlik;",baglantim);
    OleDbDataReader VeriOku=komut.ExecuteReader();
    tablo.Load(VeriOku);
    int k=0;
    Label[] linkLabelDizi = new Label[] 
    {
    linkLabel21,linkLabel23,linkLabel24,linkLabel26,linkLabel27,linkLabel29,linkLabel30,linkLabel32,linkLabel33,linkLabel35,linkLabel36,linkLabel38,linkLabel39,linkLabel41,linkLabel42,linkLabel44,linkLabel45,linkLabel47,linkLabel48,linkLabel50 
    };
    for(int i=0;i<10; i++) 
    {
    for(int j=2;j<4;j++) 
    {
    linkLabelDizi[k].Text=tablo.Rows[i][j].ToString();
    k++; 
    } 
    }
    k=0;
    Label[] labelDizi = new Label[] 
    {
    label194,label195,label196,label197,label198,label199,label200,label201,label202,label203,label204,label205,label206,label207,label208,label209,label210,label211,label212,label213 
    };
    for(int i=0;i<10; i++) 
    {
    for(int j=4;j<6;j++) 
    {
    labelDizi[k].Text=tablo.Rows[i][j].ToString();
    k++; 
    } 
    }
    baglantim.Close(); 
    }
    private void OyuncuListele() 
    { 
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM OyuncuVerileri ORDER BY OyuncuVerileri.[Piyasa Değeri] DESC;", baglantim);
    listele.Fill(tablo);
    dataGridView1.DataSource = tablo;
    dataGridView1.Columns[0].Visible=false;
    for(int i=6;i<15;i++) 
    {
    dataGridView1.Columns[i].Visible=false; 
    }
    label430.Text= tablo.Rows[0][1].ToString() + " (" + tablo.Rows[0][15].ToString() + ")";
    baglantim.Close(); 
    }
    private void GolListele() 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM OyuncuVerileri ORDER BY OyuncuVerileri.Gol DESC , OyuncuVerileri.Asist DESC;", baglantim);
    listele.Fill(tablo);
    dataGridView2.DataSource = tablo;
    dataGridView2.Columns[0].Visible=false;
    dataGridView2.Columns[7].Visible=false;
    for(int i=10;i<16;i++) 
    {
    dataGridView2.Columns[i].Visible=false; 
    }
    baglantim.Close(); 
    }
    private void MacListele() 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM OyuncuVerileri ORDER BY OyuncuVerileri.[Oynadığı Dakika] DESC;", baglantim);
    listele.Fill(tablo);
    dataGridView3.DataSource = tablo;
    dataGridView3.Columns[0].Visible=false;
    for(int i=8;i<16;i++) 
    {
    dataGridView3.Columns[i].Visible=false; 
    }
    dataGridView3.Columns[12].Visible=true;
    baglantim.Close(); 
    }
    private void KartListele() 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM OyuncuVerileri ORDER BY OyuncuVerileri.[Kırmızı Kart] DESC , OyuncuVerileri.[Sarı Kart] DESC;", baglantim);
    listele.Fill(tablo);
    dataGridView4.DataSource = tablo;
    dataGridView4.Columns[0].Visible=false;
    for(int i=7;i<16;i++) 
    {
    dataGridView4.Columns[i].Visible=false; 
    }
    dataGridView4.Columns[10].Visible=true;
    dataGridView4.Columns[11].Visible=true;
    baglantim.Close(); 
    }
    private void KaleciListele() 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM KaleciSiralama WHERE Maç BETWEEN 10 AND 38 AND Mevki='Kaleci'", baglantim);
    listele.Fill(tablo);
    dataGridView5.DataSource = tablo;
    dataGridView5.Columns[0].Visible=false;
    for(int i=7;i<16;i++) 
    {
    dataGridView5.Columns[i].Visible=false; 
    }
    dataGridView5.Columns[13].Visible=true;
    dataGridView5.Columns[14].Visible=true;
    baglantim.Close(); 
    }
    private void ComboBoxEkle() 
    {
    baglantim.Open();
    comboBox2.Items.Add(" ");
    OleDbCommand komut=new OleDbCommand("SELECT * FROM OyuncuVerileri",baglantim);
    OleDbDataReader VeriOku=komut.ExecuteReader();
    for(int i=1;i<39;i++) 
    { 
    comboBox1.Items.Add(i); 
    }
    while(VeriOku.Read()) 
    {
    if(!comboBox2.Items.Contains(VeriOku[2])) 
    { 
    comboBox2.Items.Add(VeriOku[2]); 
    } 
    }
    baglantim.Close(); 
    }
    private void Form1_Load(object sender, EventArgs e) 
    {
    ComboBoxEkle();
    textBox2.PasswordChar='*';
    LigBilgisi();
    PuanListele();
    DegerListele();
    FiksturListele();
    OyuncuListele();
    GolListele();
    MacListele();
    KartListele();
    KaleciListele(); 
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand();
    tablo.Clear();
    komut=new OleDbCommand("SELECT * FROM FiksturBilgileri Where Hafta=@Hafta;",baglantim);
    komut.Parameters.AddWithValue("@Hafta", Convert.ToInt32(comboBox1.SelectedItem));
    OleDbDataReader VeriOku=komut.ExecuteReader();
    tablo.Load(VeriOku);
    int k=0;
    Label[] linkLabelDizi = new Label[] 
    {
    linkLabel21,linkLabel23,linkLabel24,linkLabel26,linkLabel27,linkLabel29,linkLabel30,linkLabel32,linkLabel33,linkLabel35,linkLabel36,linkLabel38,linkLabel39,linkLabel41,linkLabel42,linkLabel44,linkLabel45,linkLabel47,linkLabel48,linkLabel50 
    };
    for(int i=0;i<10; i++) 
    {
    for(int j=2;j<4;j++) 
    {
    linkLabelDizi[k].Text=tablo.Rows[i][j].ToString();
    k++; 
    } 
    }
    k=0;
    Label[] labelDizi = new Label[] 
    {
    label194,label195,label196,label197,label198,label199,label200,label201,label202,label203,label204,label205,label206,label207,label208,label209,label210,label211,label212,label213 
    };
    for(int i=0;i<10; i++) 
    {
    for(int j=4;j<6;j++) 
    {
    labelDizi[k].Text=tablo.Rows[i][j].ToString();
    k++; 
    } 
    }
    baglantim.Close(); 
    }
    private void textBox3_TextChanged(object sender, EventArgs e)
    {
    DataTable tablo=new DataTable();
    baglantim.Open();
    tablo.Clear();
    comboBox2.SelectedIndex=-1;
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM OyuncuVerileri WHERE [Oyuncu Adı] LIKE '" + textBox3.Text + "%'", baglantim);
    DataSet data=new DataSet();
    listele.Fill(data,"tablo");
    dataGridView1.DataSource=data.Tables["tablo"];
    dataGridView1.Columns[0].Visible=false;
    for(int i=6;i<15;i++) 
    {
    dataGridView1.Columns[i].Visible=false; 
    }
    baglantim.Close();
    }
    private void button1_Click(object sender, EventArgs e) 
    {
    DataTable tablo=new DataTable();
    tablo.Clear();
    if(comboBox2.Text==" ") 
    {
    OyuncuListele(); 
    }
    else 
    {
    baglantim.Open();
    OleDbDataAdapter listele=new OleDbDataAdapter("SELECT * FROM PiyasaDegeriSiralama WHERE Mevki=@Mevki", baglantim);
    listele.SelectCommand.Parameters.AddWithValue("@Mevki", comboBox2.Text);
    listele.Fill(tablo);
    dataGridView1.DataSource = tablo;
    dataGridView1.Columns[0].Visible=false;
    for(int i=6;i<15;i++) 
    {
    dataGridView1.Columns[i].Visible=false; 
    } 
    baglantim.Close(); 
    } 
    }
    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) 
    {
    Form2 form2 = new Form2();
    form2.Text = sender.ToString().Remove(0, 38);
    form2.Show(); 
    }
    private void button2_Click(object sender, EventArgs e) 
    {
    baglantim.Open();
    OleDbCommand komut=new OleDbCommand("SELECT * FROM YoneticiBilgileri", baglantim);
    OleDbDataReader VeriOku=komut.ExecuteReader();
    while(VeriOku.Read()) 
    { 
    if(VeriOku["Kullanıcı Adı"].ToString()==textBox1.Text && VeriOku["Şifre"].ToString() == textBox2.Text) 
    {
    Form3 form3 = new Form3();
    form3.Show(); 
    }
    else 
    { 
    label436.Text="Hatalı Giriş Yaptınız. Lütfen Tekrar Deneyiniz."; 
    } 
    }
    baglantim.Close(); 
    }
    } 
    }