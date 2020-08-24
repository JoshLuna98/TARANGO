using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Evidencia4
{
    public partial class inicio : Form
    {
        public inicio()
        {
            InitializeComponent();           
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.USUARIO = txt_usuario.Text;
            usuario.CONTRASEÑA = txt_contraseña.Text;
            usuario.IniciarSesion(this);
            
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            
        
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_contraseña.UseSystemPasswordChar = false;
            }
            else
            {
                txt_contraseña.UseSystemPasswordChar = true;
            }
        }

        private void PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txt_usuario.Text == "" || txt_contraseña.Text == "")
            {
                MessageBox.Show("Debe ingresar un usuario y contraseña.", "Observación.", MessageBoxButtons.OK, MessageBoxIcon.Information);              
            }
            else
            {                
                Usuario usuario = new Usuario();               
                usuario.USUARIO = txt_usuario.Text;
                usuario.CONTRASEÑA = txt_contraseña.Text;                
                usuario.IniciarSesion(this);
            }

        }

        private void Cbx_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_registrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
