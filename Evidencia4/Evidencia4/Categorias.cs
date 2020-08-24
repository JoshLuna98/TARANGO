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
    class Categorias
    {
        private Conexion conexion = new Conexion();
        private SqlCommand comando = new SqlCommand();
        private int id_categoria;
        private string nombre;
        public int ID_CATEGORIA
        {
            get { return id_categoria; }
            set { id_categoria = value; }
        }
        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public void AgregarCategoria()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_AGREGAR_CATEGORIA";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha agregado la categoria de manera exitosa", "Agregar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar la categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EliminarCategoria()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_ELIMINAR_CATEGORIA";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_categoria", id_categoria);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha eliminado la categoria de manera exitosa", "Eliminar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
