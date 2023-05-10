using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eczane
{
    public partial class Web : Form
    {
        string _Barkod;
        public Web(string barkod)
        {
            InitializeComponent();
            _Barkod = barkod;
        }

        private void Web_Load(object sender, EventArgs e)
        {
            string HTML = _Barkod;
            webBrowser1.DocumentText = "<html>"+ _Barkod +"</html>";
        }
    }
}
