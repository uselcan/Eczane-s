using Eczane.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Data;

namespace Eczane.DataAccess
{
    public class IlacGetir
    {
        Connection_ context = new Connection_();
        SQLiteCommand cmd;

        public List<IlacListe> IlacListes()
        {
            List<IlacListe> ılacListes = new List<IlacListe>();
            string sql = "SELECT * FROM vs_liste Order by [ID:4] asc";
            context.sqlite.Open();

            cmd = new SQLiteCommand(sql, context.sqlite);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IlacListe liste = new IlacListe();
                liste.ID = Convert.ToInt32(dr[0]);
                liste.IlacAdi = dr[1].ToString();
                liste.barkod = dr[16].ToString();
                liste.firma = dr[9].ToString();
                liste.Fiyati = Convert.ToDouble(dr[20]);
                liste.kamuFiyati = dr[23] != DBNull.Value ? Convert.ToInt32(dr[23]) : 0; ;
                liste.kamuOdenen = dr[24] != DBNull.Value ? Convert.ToInt32(dr[24]) : 0; ;
                liste.depocuFiyat = dr[21] != DBNull.Value ? Convert.ToInt32(dr[21]) : 0; ;
                liste.ImalatciFiyat = dr[22] != DBNull.Value ? Convert.ToInt32(dr[22]) : 0; ;
                liste.kdv = 8;
                liste.orijin = dr[10].ToString();
                liste.sgkKodu = dr[11].ToString();
                liste.atckodu = dr[12].ToString();
                liste.recete = dr[13].ToString();
                liste.IlacFormID = Convert.ToInt32(dr[17]);


                ılacListes.Add(liste);
            }
            context.sqlite.Close();
            return ılacListes;
        }


        public List<IlacListe> Ilacgetir(string barkod)
        {
            List<IlacListe> ılacListes = new List<IlacListe>();
            string sql = "SELECT * FROM vs_liste where BARKOD=" + barkod;
            context.sqlite.Open();

            cmd = new SQLiteCommand(sql, context.sqlite);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IlacListe liste = new IlacListe();
                liste.ID = Convert.ToInt32(dr[0]);
                liste.IlacAdi = dr[1].ToString();
                liste.barkod = dr[16].ToString();
                liste.firma = dr[9].ToString();
                liste.Fiyati = Convert.ToDouble(dr[20]);
                liste.kamuFiyati = dr[23] != DBNull.Value ? Convert.ToInt32(dr[23]) : 0; ;
                liste.kamuOdenen = dr[24] != DBNull.Value ? Convert.ToInt32(dr[24]) : 0; ;
                liste.depocuFiyat = dr[21] != DBNull.Value ? Convert.ToInt32(dr[21]) : 0; ;
                liste.ImalatciFiyat = dr[22] != DBNull.Value ? Convert.ToInt32(dr[22]) : 0; ;
                liste.kdv = 8;
                liste.orijin = dr[10].ToString();
                liste.sgkKodu = dr[11].ToString();
                liste.atckodu = dr[12].ToString();
                liste.recete = dr[13].ToString();
                liste.IlacFormID = Convert.ToInt32(dr[17]);
                liste.KUB = dr[14].ToString();
                liste.Favori = dr[29] != DBNull.Value ? Convert.ToInt32(dr[29]) : 0;
                if (dr[28] != DBNull.Value)
                {
                    liste.Amblajresim = (byte[])dr[28];
                }


                ılacListes.Add(liste);
            }
            context.sqlite.Close();
            return ılacListes;
        }

       

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public List<IlacAmbalaj> Urunbul(string barkod)
        {
            List<IlacAmbalaj> URUNBUL = new List<IlacAmbalaj>();
            string sql = "SELECT BARKOD, FAVORI FROM ILAC_AMBALAJ where BARKOD = " + barkod;
            context.sqlite.Open();

            cmd = new SQLiteCommand(sql, context.sqlite);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IlacAmbalaj liste = new IlacAmbalaj();
                liste.BARKOD = dr[0].ToString();
                liste.FAVORI = Convert.ToInt32(dr[1]);



                URUNBUL.Add(liste);
            }
            context.sqlite.Close();
            return URUNBUL;

        }

        public void Favori(string BARKOD, int fav)
        {
            string sql = "update ILAC_AMBALAJ set FAVORI = @favori where BARKOD = @barkod";
            SQLiteCommand command = new SQLiteCommand(sql, context.sqlite);
            command.Parameters.AddWithValue("@favori", fav);
            command.Parameters.AddWithValue("@barkod", BARKOD);
            context.sqlite.Open();
            command.ExecuteNonQuery();
            context.sqlite.Close();


        }
    }
}
