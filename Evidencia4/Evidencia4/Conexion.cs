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
    class Conexion
    {
        static private string cadena = "Data Source=DESKTOP-AAI7VU3\\SQLEXPRESS;Initial Catalog=MALL;Integrated Security=True";
        private SqlConnection conexion = new SqlConnection(cadena);
        public SqlConnection AbrirConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
             
            }
            catch (Exception)
            {
                MessageBox.Show("Error de conexion", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conexion;
        }
        public SqlConnection CerrarConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cerrar la conexion", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conexion;
        }
    }
}
