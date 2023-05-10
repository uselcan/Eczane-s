using Eczane.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eczane.DataAccess
{
    class IlacSorgula
    {
        Connection_ context = new Connection_();

        public DataTable selectQuery()
        {

            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand cmd;
                context.sqlite.Open();
                cmd = context.sqlite.CreateCommand();
                cmd.CommandText = "select ILAC_ADI || ' ' || OLCU || ' ' || FARMASOTIKFORM  AS 'ILAC ADI',  BARKOD from vs_Liste";  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource

            }
            catch (SQLiteException ex)
            {
       
            }
            context.sqlite.Close();
            return dt;

        }
        public DataTable IlacİsimileArama(string adi)
        {

            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            
            try
            {
                SQLiteCommand cmd;
                context.sqlite.Open();
                cmd = context.sqlite.CreateCommand();
                cmd.CommandText = "select ILAC_ADI || ' ' || OLCU || ' ' || FARMASOTIKFORM  AS 'ILAC ADI',  BARKOD from vs_Liste where [ILAC ADI] like " + "'%" + adi + "%'";  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource

            }
            catch (SQLiteException ex)
            {
               
            }
            context.sqlite.Close();
            return dt;

        }
        public DataTable filterQuery(string BARKOD)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand cmd;
                context.sqlite.Open();
                cmd = context.sqlite.CreateCommand();
                cmd.CommandText = "select ILAC_ADI || ' ' || OLCU || ' ' || FARMASOTIKFORM  AS 'ILAC ADI',  BARKOD  from vs_Liste where BARKOD=" + BARKOD;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource
            }
            catch (SQLiteException ex)
            {
               
            }
            context.sqlite.Close();
            return dt;
        }
      


    }
}
