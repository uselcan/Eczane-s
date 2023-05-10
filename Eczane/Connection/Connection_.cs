using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data.Entity;
using Eczane.DataAccess;

namespace Eczane.Connection
{
    public class Connection_: DbContext
    {



        public SQLiteConnection sqlite;

        public Connection_()
        {

            sqlite = new SQLiteConnection("Data Source=rxsample.db");

        }

        

        public DbSet<IlacAmbalaj> IlacAmbalajs { get; set; }

       
    }
}
