using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_PDF_Viewer : Form
    {
        string PDF_filename;
        public Form_PDF_Viewer(string filename)
        {
            InitializeComponent();
            PDF_filename = filename;
        }

        private void Form_PDF_Viewer_Load(object sender, EventArgs e)
        {
            string Path = Application.StartupPath.ToString();
            string Filename =@"\" + PDF_filename + ".pdf";
            axAcroPDF1.src = Path+Filename;
        }
    }
}
