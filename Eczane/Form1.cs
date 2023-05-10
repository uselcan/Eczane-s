using Eczane.Connection;
using Eczane.DAL;
using Eczane.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;


namespace Eczane
{
    public partial class Form1 : Form
    {
        Connection_ context = new Connection_(); // veritabanı bağlantısı 
        IlacSorgula sorgu = new IlacSorgula(); // İlaç sorgulama ile ilgili sql kodlar
        IlacGetir op = new IlacGetir();

        int ID;
        string html;

        public Form1()
        {
            InitializeComponent();

        }

        private TextBox searchBox = new TextBox();
        private void form()
        {
            Liste();


        }
        private void Liste()
        {
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            this.Controls.Add(searchBox);


            int a = sorgu.selectQuery().Columns.Count;


            foreach (var item in sorgu.selectQuery().Columns)
            {
                listView1.Columns.Add(item.ToString(), 100);
                listView1.Columns.Add(item.ToString(), 100);
            }
            foreach (DataRow row in sorgu.selectQuery().Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < a; i++)
                {

                    item.SubItems.Add(row[i].ToString());

                }
                listView1.Items.Add(item);

            }

            listView1.Columns[0].Width = -6;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            form();
        }

        private void btnKub_Click(object sender, EventArgs e)
        {
            Web fr = new Web(html);
            fr.Show();


        }


        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int favori;
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var rectangle = listView1.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    try
                    {


                        Listele();


                    }
                    catch (Exception)
                    {


                    }

                }

            }

        }

        private void Listele()
        {
            string Barkod = listView1.SelectedItems[0].SubItems[1].Text;
            lblBarkodno.Text = op.Ilacgetir(Barkod).FirstOrDefault().barkod.ToString();
            lblFirma.Text = op.Ilacgetir(Barkod).FirstOrDefault().firma.ToString();
            lblUrunAdi.Text = op.Ilacgetir(Barkod).FirstOrDefault().IlacAdi.ToString();
            lblAtcKodu.Text = op.Ilacgetir(Barkod).FirstOrDefault().atckodu.ToString();
            lblDepocuFiyati.Text = op.Ilacgetir(Barkod).FirstOrDefault().depocuFiyat.ToString();
            lblFiyat.Text = op.Ilacgetir(Barkod).FirstOrDefault().Fiyati.ToString();
            lblImlatciFiyati.Text = op.Ilacgetir(Barkod).FirstOrDefault().ImalatciFiyat.ToString();
            lblKamuFiyati.Text = op.Ilacgetir(Barkod).FirstOrDefault().kamuFiyati.ToString();
            lblKamuOdenen.Text = op.Ilacgetir(Barkod).FirstOrDefault().kamuOdenen.ToString();
            lblKdv.Text = op.Ilacgetir(Barkod).FirstOrDefault().kdv.ToString();
            lblOrijin.Text = op.Ilacgetir(Barkod).FirstOrDefault().orijin.ToString();
            lblRecete.Text = op.Ilacgetir(Barkod).FirstOrDefault().recete.ToString();
            lblSgkKodu.Text = op.Ilacgetir(Barkod).FirstOrDefault().sgkKodu.ToString();
            html = op.Ilacgetir(Barkod).FirstOrDefault().KUB.ToString();
            ID = Convert.ToInt32(op.Ilacgetir(Barkod).FirstOrDefault().IlacFormID);
            favori = Convert.ToInt32(op.Ilacgetir(Barkod).FirstOrDefault().Favori);

            if (favori == 1)
            {
                btnFavari.BackgroundImage = ımageList1.Images[1];
                btnFavari.ImageAlign = ContentAlignment.TopCenter;
                btnFavari.BackgroundImageLayout = ImageLayout.Center;
            }
            else
            {
                btnFavari.BackgroundImage = ımageList1.Images[0];
                btnFavari.ImageAlign = ContentAlignment.TopCenter;
                btnFavari.BackgroundImageLayout = ImageLayout.Center;
            }


            bool v = op.Ilacgetir(Barkod).FirstOrDefault().Amblajresim != null;
            if (v)
            {
                Image img = byteArrayToImage(op.Ilacgetir(Barkod).FirstOrDefault().Amblajresim);
                pictureBox1.Image = img;
            }
            else
            { pictureBox1.Image = null; }

            BarcodeWriter barcode = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128
            };
            picBarcode.Image = barcode.Write(lblBarkodno.Text);


            EtkinMaddeDAL Em = new EtkinMaddeDAL();


            dataGridView1.DataSource = Em.EtkinMadde(ID).ToList();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            return;
        }


        private void btnSctnArama_Click(object sender, EventArgs e)
        {
            if (txtArama.Text == "")
            {
                Liste();
            }
            listView1.Columns.Clear();
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            this.Controls.Add(searchBox);


            int a = sorgu.selectQuery().Columns.Count;


            foreach (var item in sorgu.IlacİsimileArama(txtArama.Text).Columns)
            {
                listView1.Columns.Add(item.ToString(), 100);
                listView1.Columns.Add(item.ToString(), 100);
            }
            foreach (DataRow row in sorgu.IlacİsimileArama(txtArama.Text).Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < a; i++)
                {

                    item.SubItems.Add(row[i].ToString());

                }
                listView1.Items.Add(item);

            }

            listView1.Columns[0].Width = -6;
        }

        private void txtArama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    listView1.Columns.Clear();
                    listView1.Clear();
                    listView1.GridLines = true;
                    listView1.FullRowSelect = true;

                    this.Controls.Add(searchBox);


                    int a = sorgu.selectQuery().Columns.Count;


                    foreach (var item in sorgu.filterQuery(txtArama.Text).Columns)
                    {
                        listView1.Columns.Add(item.ToString(), 100);
                        listView1.Columns.Add(item.ToString(), 100);
                    }
                    foreach (DataRow row in sorgu.filterQuery(txtArama.Text).Rows)
                    {
                        ListViewItem item = new ListViewItem(row[0].ToString());
                        for (int i = 1; i < a; i++)
                        {

                            item.SubItems.Add(row[i].ToString());

                        }
                        listView1.Items.Add(item);

                    }

                    listView1.Columns[0].Width = 0;
                    txtArama.Clear();
                }
                catch (Exception)
                {
                    Liste();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblBarkodno.Text);
        }

        private void btnFavari_Click(object sender, EventArgs e)
        {
            if (lblBarkodno.Text == "#" && lblBarkodno.Text != null)
            {
                MessageBox.Show("Favoriye eklemek için bir ilaç seçin");
                return;
            }

            int a;
            if (favori == 1)
            {
                a = 0;
            }
            else
            {
                a = 1;
            }

            string sql = "update ILAC_AMBALAJ set FAVORI = @favori where BARKOD = @barkod";
            SQLiteCommand command = new SQLiteCommand(sql, context.sqlite);
            command.Parameters.AddWithValue("@favori", a);
            command.Parameters.AddWithValue("@barkod", lblBarkodno.Text);
            context.sqlite.Open();
            command.ExecuteNonQuery();
            context.sqlite.Close();
            Listele();
        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            int a = listView1.Items.Count;
            int i = 1;
            try
            {


                btnGeri.Enabled = true;
                int index = listView1.SelectedIndices[0] + 1;
                listView1.SelectedIndices.Clear();
                listView1.SelectedIndices.Add(index);
                Listele();
                i++;
                if (i == a)
                {
                    btnIleri.Enabled = false;

                }


            }
            catch (Exception)
            {


            }


        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            int i = 1;
            int a = listView1.Items.Count;
            try
            {
                btnIleri.Enabled = true;
                int index = listView1.SelectedIndices[0] - 1;
                listView1.SelectedIndices.Clear();
                listView1.SelectedIndices.Add(index);
                Listele();

                i++;
                if (i == a)
                {
                    btnIleri.Enabled = false;

                }
            }
            catch (Exception)
            {
                btnGeri.Enabled = false;
            }

        }

        private void btnKub_TextChanged(object sender, EventArgs e)
        {
            Web fr = new Web(html);
            fr.Show();
        }
    }
}
