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
    class Empleados
    {
        private int id_empleado, id_area;
        private string nombre, apellidoP, apellidoM, telefono, fecha, correo;
        private decimal sueldo;
        private Conexion conexion = new Conexion();
        private SqlCommand comando= new SqlCommand();
        private SqlDataReader leer;
        public int ID_EMPLEADO { get { return id_empleado; } set { id_empleado = value; } }
        public int ID_AREA { get { return id_area; } set { id_area = value; } }
        public string NOMBRE { get { return nombre; } set { nombre = value; } }
        public string APELLIDO_P { get { return apellidoP; } set { apellidoP = value; } }
        public string APELLIDO_M { get { return apellidoM; } set { apellidoM = value; } }
        public string TELEFONO { get { return telefono; }set { telefono = value; } }
        public string FECHA { get { return fecha; } set { fecha = value; } }
        public string CORREO { get { return correo; }set { correo = value; } }
        public decimal SUELDO { get { return sueldo; } set { sueldo = value; } }
        public DataTable CargarCombo()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_MOSTRAR_COMBO_AREA";
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
        public DataTable MostrarEmpleados()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_MOSTRAR_EMPLEADOS";
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
        public DataTable BuscarEmpleadosID()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_EMPLEADOS_ID";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_empleado", id_empleado);                             
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("El empleado que desea buscar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se ha encontrado el empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable BuscarEmpleadosNombre()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_EMPLEADO_NOMBRE";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombres", nombre);                
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("El empleado que desea buscar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se ha encontrado el empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable BuscarEmpleadosApellido()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_BUSCAR_EMPLEADO_APELLIDO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@apellido", apellidoP);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("El empleado que desea buscar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se ha encontrado el empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar el empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void InsertarEmpleado()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_INSERTAR_EMPLEADO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombres", nombre);
                comando.Parameters.AddWithValue("@apellidoP", apellidoP);
                comando.Parameters.AddWithValue("@apellidoM", apellidoM);
                comando.Parameters.AddWithValue("@id_area", id_area);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@sueldo", sueldo);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha registrado el empleado de manera exitosa", "Registrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        public void ModificarEmpleado()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_MODIFICAR_EMPLEADO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_empleado", id_empleado);
                comando.Parameters.AddWithValue("@nombres", nombre);
                comando.Parameters.AddWithValue("@apellidoP", apellidoP);
                comando.Parameters.AddWithValue("@apellidoM", apellidoM);
                comando.Parameters.AddWithValue("@id_area", id_area);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@sueldo", sueldo);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha actualizado el empleado", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar el empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EliminarEmpleado()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_ELIMINAR_EMPLEADO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_empleado", id_empleado);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CerrarConexion();
                MessageBox.Show("Se ha eliminado el empleado de manera exitosa", "Empleado Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
