using Eczane.Connection;
using Eczane.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eczane.DAL
{
    public class EtkinMaddeDAL
    {
        Connection_ context = new Connection_();
        SQLiteCommand cmd;

        public List<EtkinMadde> EtkinMadde(int ID)
        {
            List<EtkinMadde> etkinMaddes = new List<EtkinMadde>();
            string sql = "SELECT ETKINMADDE, MIKTAR  || ' ' ||  BIRIM AS Birim from ETKIN_MADDELER " +
"inner JOIN ILAC_ETKIN_MADDELER on ETKIN_MADDELER.ID = ILAC_ETKIN_MADDELER.ETKIN_MADDE " +
"where ILAC_ETKIN_MADDELER.ILAC_FORM_ID = " + ID;
            context.sqlite.Open();

            cmd = new SQLiteCommand(sql, context.sqlite);
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                EtkinMadde liste = new EtkinMadde();
                liste.Adi = (dr[0].ToString());
                liste.Gr = dr[1].ToString();



                etkinMaddes.Add(liste);
            }
            return etkinMaddes;

        }
    }
}
