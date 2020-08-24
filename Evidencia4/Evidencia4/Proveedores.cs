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
    class Proveedores
    {
        Conexion conexion = new Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        private int id_proveedor;
        private string compañia, nombre, direccion, ciudad, pais, telefono;
        public int ID_PROVEEDOR { get { return id_proveedor; }set { id_proveedor = value; } }
        public string COMPAÑIA { get { return compañia; } set { compañia = value; } }
        public string NOMBRE { get { return nombre; } set { nombre = value; } }
        public string DIRECCION { get { return direccion; } set { direccion = value; } }
        public string CIUDAD { get { return ciudad; } set { ciudad = value; } }
        public string PAIS { get { return pais; } set { pais = value; } }
        public string TELEFONO { get { return telefono; } set { telefono = value; } }
        public DataTable MostrarProveedores()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_MOSTRAR_PROVEEDORES";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los proveedores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void AgregarProveedores()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_AGREGAR_PROVEEDOR";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@compañia", compañia);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.Parameters.AddWithValue("@ciudad", ciudad);
                comando.Parameters.AddWithValue("@pais", pais);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha registrado el proveedor de manera exitosa", "Registrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ActualizarProveedores()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_ACTUALIZAR_PROVEEEDOR";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                comando.Parameters.AddWithValue("@compañia", compañia);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.Parameters.AddWithValue("@ciudad", ciudad);
                comando.Parameters.AddWithValue("@pais", pais);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha actualizado el proveedor de manera exitosa", "Registrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }
        public void EliminarProveedores()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_ELIMINAR_PROVEEDOR";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha eliminado el proveedor de manera exitosa", "Registrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable BuscarProveedorID()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_PROVEEDOR_ID";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                if (tabla.Rows.Count==0)
                {
                    MessageBox.Show("No existe el proveedor con ese ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable BuscarProveedorCompañia()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_PROVEEDOR_COMPAÑIA";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@compañia", compañia);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No existe la compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable BuscarProveedorNombre()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_PROVEEDOR_NOMBRE";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", nombre);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No existe el proveedor con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
