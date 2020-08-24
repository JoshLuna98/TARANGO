using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Evidencia4
{
    class Usuario
    {
        private string usuario, contraseña;
        private Conexion conexion = new Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        public string USUARIO { get { return usuario; } set { usuario = value; } }
        public string CONTRASEÑA { get { return contraseña; } set { contraseña = value; } }
        public DataTable IniciarSesion(Form login)
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "IniciarSesion";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contraseña", contraseña);
                leer = comando.ExecuteReader();
                comando.Parameters.Clear();
                tabla.Load(leer);
                leer.Close();
                comando.Connection = conexion.CerrarConexion();
                if (tabla.Rows.Count==1)
                {
                    if (tabla.Rows[0][0].ToString()=="Tarango"|| tabla.Rows[0][0].ToString() == "Christian Tarango"|| tabla.Rows[0][0].ToString() == "Christian")
                    {
                        login.Hide();
                        PaseoGP paseo = new PaseoGP();
                        paseo.Show();
                        inicio inicio = new inicio();
                        inicio.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario y/o contraseña que ingresó son incorrectos.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al iniciar sesión.", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }

    }
}
