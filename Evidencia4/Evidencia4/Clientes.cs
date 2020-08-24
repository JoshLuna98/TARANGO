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
    class Clientes
    {
        Conexion conexion = new Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        private int id_cliente;
        private string nombres, apellidoP, apellidoM, telefono, direccion;
        public int ID_CLIENTE { get { return id_cliente; } set { id_cliente = value; } }
        public string NOMBRES { get { return nombres; } set { nombres = value; } }
        public string APELLIDO_P { get { return apellidoP; } set { apellidoP = value; } }
        public string APELLIDO_M { get { return apellidoM; } set { apellidoM = value; } }
        public string TELEFONO { get { return telefono; } set { telefono = value; } }
        public string DIRECCION { get { return direccion; } set { direccion = value; } }
        public DataTable MostrarClientes()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_MOSTRAR_CLIENTES";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar los clientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void AgregarClientes()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_AGREGAR_CLIENTE";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombres", nombres);
                comando.Parameters.AddWithValue("@apellidoP", apellidoP);
                comando.Parameters.AddWithValue("@apellidoM", apellidoM);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha registrado el cliente de manera exitosa", "Registrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ActualizarCliente()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_ACTUALIZAR_CLIENTE";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_cliente", id_cliente);
                comando.Parameters.AddWithValue("@nombres", nombres);
                comando.Parameters.AddWithValue("@apellidoP", apellidoP);
                comando.Parameters.AddWithValue("@apellidoM", apellidoM);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha actualizado el cliente de manera exitosa", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EliminarCliente()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_ELIMINAR_CLIENTE";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_cliente", id_cliente);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha eliminado el cliente de manera exitosa", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable BuscarClienteID()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_CLIENTE_ID";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_cliente", id_cliente);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No existe el cliente con ese número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se ha encontrado el cliente", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable BuscarClienteNombre()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_CLIENTE_NOMBRE";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombres", nombres);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No existe el cliente con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se ha encontrado el cliente", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable BuscarClienteApellido()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_CLIENTE_APELLIDO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@apellidoP", apellidoP);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No existe el cliente con ese apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se ha encontrado el cliente", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
    
}
