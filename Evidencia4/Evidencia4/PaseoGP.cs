using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidencia4
{
    public partial class PaseoGP : Form
    {
        public PaseoGP()
        {
            InitializeComponent();
        }

        private void Btn_Mall_Click(object sender, EventArgs e)
        {
            Mall mall = new Mall();
            mall.Show();
            this.Hide();
        }
    }
}
