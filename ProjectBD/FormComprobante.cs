using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace ProjectBD
{
    public partial class FormComprobante : Form
    {
        private string comprobanteText;

        public FormComprobante(string text)
        {
            InitializeComponent();
            comprobanteText = text;
            rtbComprobante.Text = comprobanteText;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtbComprobante.Text, rtbComprobante.Font, Brushes.Black, 10, 10);
        }
    }
}
