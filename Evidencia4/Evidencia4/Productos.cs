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
    class Productos
    {
        private int id_producto, id_categoria, id_proveedor, unidades;
        private decimal precio;
        private string nombre;
        private Conexion conexion = new Conexion();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leer;
        public int ID_PRODUCTO { get { return id_producto; } set { id_producto = value; } }
        public int ID_CATEGORIA { get { return id_categoria; } set { id_categoria = value; } }
        public int ID_PROVEEDOR { get { return id_proveedor; } set { id_proveedor = value; } }
        public int UNIDADES { get { return unidades; } set { unidades = value; } }
        public decimal PRECIO { get { return precio; }set { precio = value; } }
        public string NOMBRE { get { return nombre; } set { nombre = value; } }
        public DataTable LlenarComboProveedor()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_LLENAR_COMBO_PROVEEDORES";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos en el ComboBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable LlenarComboCategorias()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_LLENAR_COMBO_CATEGORIAS";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos en el ComboBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable LlenarComboProductos()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_LLENAR_COMBO_PRODUCTOS";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos en el ComboBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable MostrarProductos()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_MOSTRAR_PRODUCTOS";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void AgregarProductos()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_AGREGAR_PRODUCTO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                comando.Parameters.AddWithValue("@id_categoria", id_categoria);
                comando.Parameters.AddWithValue("@precio", precio);
                comando.Parameters.AddWithValue("@unidades", unidades);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha agregado el producto", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        public void ActualizarProductos()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_ACTUALIZAR_PRODUCTOS";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_producto", id_producto);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                comando.Parameters.AddWithValue("@id_categoria", id_categoria);
                comando.Parameters.AddWithValue("@precio", precio);
                comando.Parameters.AddWithValue("@unidades", unidades);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha actualizado el producto", "Producto Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EliminarProducto()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_ELIMINAR_PRODUCTO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_producto", id_producto);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha eliminado el producto", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable BuscarProductosID()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_PRODUCTOS";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_producto", id_producto);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                if (tabla.Rows.Count==0)
                {
                    MessageBox.Show("El producto que desea buscar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
                         
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
        public DataTable BuscarProductosNombre()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_PRODUCTO_NOMBRE";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", nombre);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("El producto que desea buscar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }

            catch (Exception)
            {
                MessageBox.Show("Error al buscar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}
