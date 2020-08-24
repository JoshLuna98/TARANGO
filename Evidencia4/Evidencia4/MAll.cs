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
    public partial class Mall : Form
    {
        public Mall()
        {
            InitializeComponent();
            tab_Clientes.Visible = false;
            tab_empleados.Visible = false;
            tab_Proveedores.Visible = false;
            tab_productos.Visible = false;
            CargarComboEmpleados();
            MostrarEmpleados();
            CargarCombosProductos();
            MostrarProductos();
            MostrarClientes();
            MostrarProveedores();
        }
        private void CargarComboEmpleados()
        {
            Empleados empleados = new Empleados();
            cbx_area_RE.DataSource = empleados.CargarCombo();
            cbx_area_RE.DisplayMember = "nombre";
            cbx_area_RE.ValueMember = "id_area";
            cbx_area_EA.DataSource = empleados.CargarCombo();
            cbx_area_EA.DisplayMember = "nombre";
            cbx_area_EA.ValueMember = "id_area";
        }
        private void CargarCombosProductos()
        {
            Productos productos = new Productos();
            cbx_proveedor_productos.DataSource = productos.LlenarComboProveedor();
            cbx_proveedor_productos.DisplayMember = "nombre";
            cbx_proveedor_productos.ValueMember = "id_proveedor";
            cbx_Proveedor_PA.DataSource = productos.LlenarComboProveedor();
            cbx_Proveedor_PA.DisplayMember = "nombre";
            cbx_Proveedor_PA.ValueMember = "id_proveedor";
            cbx_categoria_producto.DataSource = productos.LlenarComboCategorias();
            cbx_categoria_producto.DisplayMember = "Nombre";
            cbx_categoria_producto.ValueMember = "id_categoria";
            cbx_Categoria_PA.DataSource = productos.LlenarComboCategorias();
            cbx_Categoria_PA.DisplayMember = "Nombre";
            cbx_Categoria_PA.ValueMember = "id_categoria";
            cbx_eliminar_categoria.DataSource = productos.LlenarComboCategorias();
            cbx_eliminar_categoria.DisplayMember = "nombre";
            cbx_eliminar_categoria.ValueMember = "id_categoria";
            cbx_producto_eliminar.DataSource = productos.LlenarComboProductos();
            cbx_producto_eliminar.DisplayMember = "nombre";
            cbx_producto_eliminar.ValueMember = "id_producto";

        }
        private void MostrarEmpleados()
        {
            Empleados empleados = new Empleados();
            dataGridView1.DataSource = empleados.MostrarEmpleados();
        }
        private void MostrarProductos()
        {
            Productos productos = new Productos();
            dataGridView9.DataSource = productos.MostrarProductos();
        }
        private void MostrarClientes()
        {
            Clientes clientes = new Clientes();
            dataGridView8.DataSource = clientes.MostrarClientes();
        }
        private void MostrarProveedores()
        {
            Proveedores proveedores = new Proveedores();
            dataGridView3.DataSource = proveedores.MostrarProveedores();
        }
        private void BuscarEmpleadoActualizar()
        {
            Conexion conexion = new Conexion();
            SqlCommand comando;
            SqlDataReader leer;
            if (txt_Nombre_EA.Text != "" && txt_ApellidoP_EA.Text != "")
            {
                MessageBox.Show("Debes buscar solo por un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ApellidoP_EA.Clear();
                txt_Nombre_EA.Clear();
                lbl_no_empleado.Text = "";
            }
            else if (txt_ApellidoP_EA.Text != "" && txt_Nombre_EA.Text == "")
            {               
                comando = new SqlCommand("SELECT*FROM Empleados WHERE apellidoP like+'%'+@apellidoP+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@apellidoP", txt_ApellidoP_EA.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_empleado.Text = leer["id_empleado"].ToString();
                    txt_Nombre_EA.Text = leer["nombres"].ToString();
                    txt_ApellidoP_EA.Text = leer["apellidoP"].ToString();
                    txt_ApellidoM_EA.Text = leer["apellidoM"].ToString();
                    cbx_area_EA.SelectedValue = leer["id_area"].ToString();
                    txt_fecha_EA.Text = leer["fecha"].ToString();
                    txt_telefono_EA.Text = leer["telefono"].ToString();
                    txt_Correo_EA.Text = leer["correo"].ToString();
                    txt_SueldoBase_EA.Text = leer["sueldo"].ToString();
                }
                else
                {
                    MessageBox.Show("No existe el empleado con ese Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
            else
            {
                comando = new SqlCommand("SELECT*FROM Empleados WHERE nombres like+'%'+@nombres+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@nombres", txt_Nombre_EA.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_empleado.Text = leer["id_empleado"].ToString();
                    txt_Nombre_EA.Text = leer["nombres"].ToString();
                    txt_ApellidoP_EA.Text = leer["apellidoP"].ToString();
                    txt_ApellidoM_EA.Text = leer["apellidoM"].ToString();
                    cbx_area_EA.SelectedValue = leer["id_area"].ToString();
                    txt_fecha_EA.Text = leer["fecha"].ToString();
                    txt_telefono_EA.Text = leer["telefono"].ToString();
                    txt_Correo_EA.Text = leer["correo"].ToString();
                    txt_SueldoBase_EA.Text = leer["sueldo"].ToString();
                }
                else
                {
                    MessageBox.Show("No existe el empleado con ese Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
        }
        private void BuscarEmpleadoEliminar()
        {
            Conexion conexion = new Conexion();
            SqlCommand comando;
            SqlDataReader leer;
            if (txt_Nombre_EE.Text != "" && txt_ApellidoP_EE.Text != "")
            {
                MessageBox.Show("Debes buscar solo por un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ApellidoP_EE.Clear();
                txt_Nombre_EE.Clear();
                txt_ApellidoM_EE.Clear();
                lbl_noempleado_eliminar.Text = "";
            }
            else if (txt_ApellidoP_EE.Text != "" && txt_Nombre_EE.Text == "")
            {
                comando = new SqlCommand("SELECT*FROM Empleados WHERE apellidoP like+'%'+@apellidoP+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@apellidoP", txt_ApellidoP_EE.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_noempleado_eliminar.Text = leer["id_empleado"].ToString();
                    txt_Nombre_EE.Text = leer["nombres"].ToString();
                    txt_ApellidoP_EE.Text = leer["apellidoP"].ToString();
                    txt_ApellidoM_EE.Text = leer["apellidoM"].ToString();                  
                }
                else
                {
                    MessageBox.Show("No existe el empleado con ese Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
            else
            {
                comando = new SqlCommand("SELECT*FROM Empleados WHERE nombres like+'%'+@nombres+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@nombres", txt_Nombre_EE.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_noempleado_eliminar.Text = leer["id_empleado"].ToString();
                    txt_Nombre_EE.Text = leer["nombres"].ToString();
                    txt_ApellidoP_EE.Text = leer["apellidoP"].ToString();
                    txt_ApellidoM_EE.Text = leer["apellidoM"].ToString();               
                }
                else
                {
                    MessageBox.Show("No existe el empleado con ese Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
        }
        private void BuscarEmpleadoID()
        {
            Empleados empleados = new Empleados();         
            empleados.ID_EMPLEADO = Convert.ToInt32(txt_NoEmpleado.Text);          
            dataGridView1.DataSource = empleados.BuscarEmpleadosID();  
        }
        private void BuscarEmpleadoNombre()
        {
            Empleados empleados = new Empleados();
            empleados.NOMBRE = txt_name_E.Text;
            dataGridView1.DataSource = empleados.BuscarEmpleadosNombre();
        }
        private void BuscarEmpleadoApellido()
        {
            Empleados empleados = new Empleados();
            empleados.APELLIDO_P = txt_apellidoE.Text;
            dataGridView1.DataSource = empleados.BuscarEmpleadosApellido();
        }
        private void AgregarEmpleado()
        {
            string correo = txt_Correo_ER.Text;
            bool formato = correo.Contains("@gmail.com");
            bool formato2 = correo.Contains("@hotmail.com");
            bool formato3 = correo.Contains("@outlook.com");
            if (txt_Nombre_ER.Text=="")
            {
                errorProvider1.SetError(txt_Nombre_ER, "Campo Obligatorio");
                txt_Nombre_ER.Focus();
                return;
            }
            else if (txt_ApellidoP_ER.Text == "")
            {
                errorProvider1.SetError(txt_ApellidoP_ER, "Campo Obligatiro");
                txt_ApellidoP_ER.Focus();
                return;
            }
            else if (txt_ApellidoM_ER.Text == "")
            {
                errorProvider1.SetError(txt_ApellidoM_ER, "Campo Obligatorio");
                txt_ApellidoM_ER.Focus();
                return;
            }
            else if (txt_sueldo.Text == "")
            {
                errorProvider1.SetError(txt_sueldo, "Campo Obligatorio");
                txt_sueldo.Focus();
                return;
            }
            else if (txt_fecha_empleado.MaskFull==false)
            {
                errorProvider1.SetError(txt_fecha_empleado, "Informacion Incompleta");
                txt_fecha_empleado.Focus();
                return;
            }
            else if (txt_Telefono_ER.MaskFull==false)
            {
                errorProvider1.SetError(txt_Telefono_ER, "Informacion Incompleta");
                txt_Telefono_ER.Focus();
                return;
            }
            else if (formato==true||formato2==true||formato3==true)
            {
                Empleados empleados = new Empleados();
                empleados.NOMBRE = txt_Nombre_ER.Text;
                empleados.APELLIDO_P = txt_ApellidoP_ER.Text;
                empleados.APELLIDO_M = txt_ApellidoM_ER.Text;
                empleados.ID_AREA = Convert.ToInt32(cbx_area_RE.SelectedValue);
                empleados.FECHA = txt_fecha_empleado.Text;
                empleados.TELEFONO = txt_Telefono_ER.Text;
                empleados.CORREO = txt_Correo_ER.Text;
                empleados.SUELDO = Convert.ToDecimal(txt_sueldo.Text);
                empleados.InsertarEmpleado();              
                txt_Nombre_ER.Clear();
                txt_ApellidoP_ER.Clear();
                txt_ApellidoM_ER.Clear();
                txt_fecha_empleado.Clear();
                txt_Telefono_ER.Clear();
                txt_Correo_ER.Clear();
                txt_sueldo.Clear();
                MostrarEmpleados();
            }
            else
            {
                errorProvider1.SetError(txt_Correo_ER, "Formato incorrecto");
                txt_Correo_ER.Focus();
                return;
            }
            errorProvider1.SetError(txt_Correo_ER, "");
            errorProvider1.SetError(txt_Telefono_ER, "");
            errorProvider1.SetError(txt_fecha_empleado, "");
            errorProvider1.SetError(txt_Nombre_ER, "");
            errorProvider1.SetError(txt_ApellidoP_ER, "");
            errorProvider1.SetError(txt_ApellidoM_ER, "");
            errorProvider1.SetError(txt_sueldo, "");
            
        }
        private void ModificarEmpleado()
        {
            string correo = txt_Correo_EA.Text;
            bool formato = correo.Contains("@gmail.com");
            bool formato2 = correo.Contains("@hotmail.com");
            bool formato3 = correo.Contains("@outlook.com");
            if (txt_Nombre_EA.Text == "")
            {
                errorProvider1.SetError(txt_Nombre_EA, "Campo Obligatorio");
                txt_Nombre_EA.Focus();
                return;
            }
            else if (txt_ApellidoP_EA.Text == "")
            {
                errorProvider1.SetError(txt_ApellidoP_EA, "Campo Obligatiro");
                txt_ApellidoP_EA.Focus();
                return;
            }
           else if (txt_ApellidoM_EA.Text == "")
            {
                errorProvider1.SetError(txt_ApellidoM_EA, "Campo Obligatorio");
                txt_ApellidoM_EA.Focus();
                return;
            }
            else if (txt_SueldoBase_EA.Text == "")
            {
                errorProvider1.SetError(txt_SueldoBase_EA, "Campo Obligatorio");
                txt_SueldoBase_EA.Focus();
                return;
            }
            else if (txt_fecha_EA.MaskFull == false)
            {
                errorProvider1.SetError(txt_fecha_EA, "Informacion Incompleta");
                txt_fecha_EA.Focus();
                return;
            }
            else if (txt_telefono_EA.MaskFull == false)
            {
                errorProvider1.SetError(txt_telefono_EA, "Informacion Incompleta");
                txt_telefono_EA.Focus();
                return;
            }                    
            Empleados empleados = new Empleados();
            if (lbl_no_empleado.Text == "")
            {
                MessageBox.Show("Debes de buscar al empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (formato==true||formato2==true||formato3==true)
                {
                    if (MessageBox.Show("Se actualizara el empleado", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        empleados.ID_EMPLEADO = Convert.ToInt32(lbl_no_empleado.Text);
                        empleados.NOMBRE = txt_Nombre_EA.Text;
                        empleados.APELLIDO_P = txt_ApellidoP_EA.Text;
                        empleados.APELLIDO_M = txt_ApellidoM_EA.Text;
                        empleados.ID_AREA = Convert.ToInt32(cbx_area_EA.SelectedValue);
                        empleados.FECHA = txt_fecha_EA.Text;
                        empleados.TELEFONO = txt_telefono_EA.Text;
                        empleados.CORREO = txt_Correo_EA.Text;
                        empleados.SUELDO = Convert.ToDecimal(txt_SueldoBase_EA.Text);
                        empleados.ModificarEmpleado();                        
                        MostrarEmpleados();
                    }
                    txt_Nombre_EA.Clear();
                    txt_ApellidoP_EA.Clear();
                    txt_ApellidoM_EA.Clear();
                    txt_fecha_EA.Clear();
                    txt_telefono_EA.Clear();
                    txt_SueldoBase_EA.Clear();
                    txt_Correo_EA.Clear();
                    lbl_no_empleado.Text = "";
                }
                else
                {
                    errorProvider1.SetError(txt_Correo_EA, "Formato Incorrecto");
                    txt_Correo_EA.Focus();
                    return;
                }
                
            }
            errorProvider1.SetError(txt_Correo_EA, "");
            errorProvider1.SetError(txt_telefono_EA, "");
            errorProvider1.SetError(txt_fecha_EA, "");
            errorProvider1.SetError(txt_Nombre_EA, "");
            errorProvider1.SetError(txt_ApellidoP_EA, "");
            errorProvider1.SetError(txt_ApellidoM_EA, "");
            errorProvider1.SetError(txt_SueldoBase_EA, "");          
        }
        private void EliminarEmpleado()
        {
            Empleados empleados = new Empleados();
            if (lbl_noempleado_eliminar.Text=="")
            {
                MessageBox.Show("Debes de buscar un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Se eliminara el empledo","Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    empleados.ID_EMPLEADO = Convert.ToInt32(lbl_noempleado_eliminar.Text);
                    empleados.EliminarEmpleado();
                    MostrarEmpleados();                 
                }
                txt_Nombre_EE.Clear();
                txt_ApellidoM_EE.Clear();
                txt_ApellidoP_EE.Clear();
                lbl_noempleado_eliminar.Text = "";
            }
        }      
        private void AgregarProductos()
        {
            if (txt_nombre_PR.Text=="")
            {
                errorProvider1.SetError(txt_nombre_PR, "Campo Obligatorio");
                txt_nombre_PR.Focus();
                return;
            }
            if (txt_precio_PR.Text=="")
            {
                errorProvider1.SetError(txt_precio_PR, "Campo Obligatorio");
                txt_precio_PR.Focus();
                return;
            }
            if (txt_unidades_PR.Text=="")
            {
                errorProvider1.SetError(txt_unidades_PR, "Campo Obligatorio");
                txt_unidades_PR.Focus();
                return;
            }
            errorProvider1.SetError(txt_nombre_PR, "");
            errorProvider1.SetError(txt_precio_PR, "");
            errorProvider1.SetError(txt_unidades_PR, "");
            Productos productos = new Productos();
            productos.NOMBRE = txt_nombre_PR.Text;
            productos.ID_PROVEEDOR = Convert.ToInt32(cbx_proveedor_productos.SelectedValue);
            productos.ID_CATEGORIA = Convert.ToInt32(cbx_categoria_producto.SelectedValue);
            productos.PRECIO = Convert.ToDecimal(txt_precio_PR.Text);
            productos.UNIDADES = Convert.ToInt32(txt_unidades_PR.Text);
            productos.AgregarProductos();           
            MostrarProductos();
            CargarCombosProductos();
            txt_nombre_PR.Clear();
            txt_precio_PR.Clear();
            txt_unidades_PR.Clear();
        }
        private void ActualizarProductos()
        {
            if (txt_nombre_PA.Text == "")
            {
                errorProvider1.SetError(txt_nombre_PA, "Campo Obligatorio");
                txt_nombre_PA.Focus();
                return;
            }
            else if (txt_precio_PA.Text == "")
            {
                errorProvider1.SetError(txt_precio_PA, "Campo Obligatorio");
                txt_precio_PA.Focus();
                return;
            }
            else if (txt_unidades_PA.Text == "")
            {
                errorProvider1.SetError(txt_unidades_PR, "Campo Obligatorio");
                txt_unidades_PR.Focus();
                return;
            }
            else if (lbl_codigo_PA.Text=="")
            {
                MessageBox.Show("Debes de buscar un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Productos productos = new Productos();
                if (MessageBox.Show("¿Estás seguro de querer actualizar el producto?", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    productos.ID_PRODUCTO = Convert.ToInt32(lbl_codigo_PA.Text);
                    productos.NOMBRE = txt_nombre_PA.Text;
                    productos.ID_PROVEEDOR = Convert.ToInt32(cbx_Proveedor_PA.SelectedValue);
                    productos.ID_CATEGORIA = Convert.ToInt32(cbx_Categoria_PA.SelectedValue);
                    productos.PRECIO = Convert.ToDecimal(txt_precio_PA.Text);
                    productos.UNIDADES = Convert.ToInt32(txt_unidades_PA.Text);
                    productos.ActualizarProductos();                   
                    MostrarProductos();
                    CargarCombosProductos();
                }
                txt_nombre_PA.Clear();
                txt_precio_PA.Clear();
                txt_unidades_PA.Clear();
                lbl_codigo_PA.Text = "";
            }           
            errorProvider1.SetError(txt_nombre_PA, "");
            errorProvider1.SetError(txt_precio_PA, "");
            errorProvider1.SetError(txt_unidades_PA, "");

        }
        private void BuscarProductoActualizar()
        {
            Conexion conexion = new Conexion();
            SqlCommand comando;
            SqlDataReader leer;
            comando = new SqlCommand("SELECT*FROM Productos WHERE nombre like+'%'+@nombre+'%'", conexion.AbrirConexion());
            comando.Parameters.AddWithValue("@nombre", txt_nombre_PA.Text);
            leer = comando.ExecuteReader();
            if (leer.Read())
            {
            lbl_codigo_PA.Text = leer["id_producto"].ToString();
            txt_nombre_PA.Text = leer["nombre"].ToString();
            cbx_Proveedor_PA.SelectedValue = leer["id_proveedor"].ToString();
            cbx_Categoria_PA.SelectedValue = leer["id_categoria"].ToString();
            txt_precio_PA.Text = leer["precio"].ToString();
             txt_unidades_PA.Text = leer["unidades"].ToString();
                    conexion.CerrarConexion();
            }
            else
            {
               MessageBox.Show("No existe el producto con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void EliminarProductos()
        {
            Productos productos = new Productos();
          
            if (MessageBox.Show("Se eliminara el producto","Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                productos.ID_PRODUCTO = Convert.ToInt32(cbx_producto_eliminar.SelectedValue);
                productos.EliminarProducto();
                MostrarProductos();
                CargarCombosProductos();
            }
        }
        private void BuscarProducto()
        {
            Productos productos = new Productos();
            if (txt_id_producto_B.Text!=""&&txt_nombre_PB.Text!="")
            {
                MessageBox.Show("Debes buscar solo por un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_id_producto_B.Clear();
                txt_nombre_PB.Clear();
            }
            else if (txt_id_producto_B.Text!=""&&txt_nombre_PB.Text=="")
            {
                productos.ID_PRODUCTO = Convert.ToInt32(txt_id_producto_B.Text);
                dataGridView9.DataSource = productos.BuscarProductosID();
            }
            else
            {
                productos.NOMBRE = txt_nombre_PB.Text;
                dataGridView9.DataSource = productos.BuscarProductosNombre();
            }
        }
        private void AgregarClientes()
        {
            if (txt_nombre_CR.Text=="")
            {
                errorProvider1.SetError(txt_nombre_CR, "Campo Obligatorio");
                txt_nombre_CR.Focus();
                return;
            }
            if (txt_apellidoP_CR.Text=="")
            {
                errorProvider1.SetError(txt_apellidoP_CR, "Campo Obligatorio");
                txt_apellidoP_CR.Focus();
                return;
            }
            if (txt_apellidoM_CR.Text=="")
            {
                errorProvider1.SetError(txt_apellidoM_CR, "Campo Obligatorio");
                txt_apellidoM_CR.Focus();
                return;
            }
            if (txt_telefono_CR.MaskFull==false)
            {
                errorProvider1.SetError(txt_telefono_CR, "Información Incompleta");
                txt_telefono_CR.Focus();
                return;
            }
            if (txt_direccion_CR.Text=="")
            {
                errorProvider1.SetError(txt_direccion_CR, "Campo Obligatorio");
                txt_direccion_CR.Focus();
                return;
            }
            errorProvider1.SetError(txt_direccion_CR, "");
            errorProvider1.SetError(txt_telefono_CR, "");
            errorProvider1.SetError(txt_nombre_CR, "");
            errorProvider1.SetError(txt_apellidoP_CR, "");
            errorProvider1.SetError(txt_apellidoM_CR, "");
            Clientes clientes = new Clientes();
            clientes.NOMBRES = txt_nombre_CR.Text;
            clientes.APELLIDO_P = txt_apellidoP_CR.Text;
            clientes.APELLIDO_M = txt_apellidoM_CR.Text;
            clientes.TELEFONO = txt_telefono_CR.Text;
            clientes.DIRECCION = txt_direccion_CR.Text;
            clientes.AgregarClientes();
            MostrarClientes();
            txt_nombre_CR.Clear();
            txt_apellidoP_CR.Clear();
            txt_apellidoM_CR.Clear();
            txt_telefono_CR.Clear();
            txt_direccion_CR.Clear();
        }
        private void ActualizarClientes()
        {
            if (txt_nombre_CA.Text == "")
            {
                errorProvider1.SetError(txt_nombre_CA, "Campo Obligatorio");
                txt_nombre_CA.Focus();
                return;
            }
            else if (txt_apellidoP_CA.Text == "")
            {
                errorProvider1.SetError(txt_apellidoP_CA, "Campo Obligatorio");
                txt_apellidoP_CA.Focus();
                return;
            }
            else if (txt_apellidoM_CA.Text == "")
            {
                errorProvider1.SetError(txt_apellidoM_CA, "Campo Obligatorio");
                txt_apellidoM_CA.Focus();
                return;
            }
            else if (txt_telefono_CA.MaskFull == false)
            {
                errorProvider1.SetError(txt_telefono_CA, "Información Incompleta");
                txt_telefono_CA.Focus();
                return;
            }
            else if (txt_direccion_CA.Text == "")
            {
                errorProvider1.SetError(txt_direccion_CA, "Campo Obligatorio");
                txt_direccion_CA.Focus();
                return;
            }
            else if (lbl_no_cliente_actualizar.Text=="")
            {
                MessageBox.Show("Debes de buscar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Clientes clientes = new Clientes();
                clientes.ID_CLIENTE = Convert.ToInt32(lbl_no_cliente_actualizar.Text);
                clientes.NOMBRES = txt_nombre_CA.Text;
                clientes.APELLIDO_P = txt_apellidoP_CA.Text;
                clientes.APELLIDO_M = txt_apellidoM_CA.Text;
                clientes.TELEFONO = txt_telefono_CA.Text;
                clientes.DIRECCION = txt_direccion_CA.Text;
                if (MessageBox.Show("Se actualizara el cliente", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    clientes.ActualizarCliente();                  
                }
                MostrarClientes();
                lbl_no_cliente_actualizar.Text = "";
                txt_nombre_CA.Clear();
                txt_apellidoP_CA.Clear();
                txt_apellidoM_CA.Clear();
                txt_telefono_CA.Clear();
                txt_direccion_CA.Clear();
            }
            errorProvider1.SetError(txt_direccion_CA, "");
            errorProvider1.SetError(txt_telefono_CA, "");
            errorProvider1.SetError(txt_nombre_CA, "");
            errorProvider1.SetError(txt_apellidoP_CA, "");
            errorProvider1.SetError(txt_apellidoM_CA, "");
        }
        private void EliminarCliente()
        {
            if (lbl_no_cliente_eliminar.Text == "")
            {
                MessageBox.Show("Debes de buscar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Clientes clientes = new Clientes();
                clientes.ID_CLIENTE = Convert.ToInt32(lbl_no_cliente_eliminar.Text);
                if (MessageBox.Show("Se eliminara el cliente", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    clientes.EliminarCliente();                    
                }
                MostrarClientes();
                lbl_no_cliente_eliminar.Text = "";
                txt_nombre_CE.Clear();
                txt_apellidoP_CE.Clear();
                txt_apellidoM_CE.Clear();
            }            
        }
        private void BuscarClientes()
        {
            Clientes clientes = new Clientes();
            if (txt_id_CB.Text!=""&&txt_nombre_CB.Text!=""&&txt_apellidoP_CB.Text!=""||txt_id_CB.Text!=""&&txt_nombre_CB.Text!=""||txt_id_CB.Text!=""&&txt_apellidoP_CB.Text!=""||txt_nombre_CB.Text!=""&&txt_apellidoP_CB.Text!="")
            {
                MessageBox.Show("Debes buscar solo por un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_id_CB.Clear();
                txt_nombre_CB.Clear();
                txt_apellidoP_CB.Clear();
            }
            else if(txt_id_CB.Text!=""&&txt_nombre_CB.Text==""&&txt_apellidoP_CB.Text=="")
            {
                clientes.ID_CLIENTE = Convert.ToInt32(txt_id_CB.Text);
                dataGridView8.DataSource = clientes.BuscarClienteID();
                
            }
            else if (txt_id_CB.Text==""&&txt_nombre_CB.Text!=""&&txt_apellidoP_CB.Text=="")
            {
                clientes.NOMBRES = txt_nombre_CB.Text;
                dataGridView8.DataSource = clientes.BuscarClienteNombre();
                
            }
            else
            {
                clientes.APELLIDO_P = txt_apellidoP_CB.Text;
                dataGridView8.DataSource = clientes.BuscarClienteApellido();
               
            }
        }        
        private void BuscarClientesActualizar()
        {           
            Conexion conexion = new Conexion();
            SqlCommand comando;
            SqlDataReader leer;
            if (txt_nombre_CA.Text != "" && txt_apellidoP_CA.Text != "")
            {
                MessageBox.Show("Debes buscar solo por un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nombre_CA.Clear();
                txt_apellidoP_CA.Clear();
                lbl_no_cliente_actualizar.Text = "";
            }
            else if (txt_nombre_CA.Text != "" && txt_apellidoP_CA.Text == "")
            {
                comando = new SqlCommand("SELECT*FROM Clientes WHERE Nombres like+'%'+@nombres+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@nombres", txt_nombre_CA.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_cliente_actualizar.Text = leer["id_cliente"].ToString();
                    txt_nombre_CA.Text = leer["Nombres"].ToString();
                    txt_apellidoP_CA.Text = leer["apellidoP"].ToString();
                    txt_apellidoM_CA.Text = leer["apellidoM"].ToString();
                    txt_telefono_CA.Text = leer["telefono"].ToString();
                    txt_direccion_CA.Text = leer["direccion"].ToString();
                    conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No existe el cliente con ese número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                comando = new SqlCommand("SELECT*FROM Clientes WHERE apellidoP like+'%'+@apellidoP+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@apellidoP", txt_apellidoP_CA.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_cliente_actualizar.Text = leer["id_cliente"].ToString();
                    txt_nombre_CA.Text = leer["Nombres"].ToString();
                    txt_apellidoP_CA.Text = leer["apellidoP"].ToString();
                    txt_apellidoM_CA.Text = leer["apellidoM"].ToString();
                    txt_telefono_CA.Text = leer["telefono"].ToString();
                    txt_direccion_CA.Text = leer["direccion"].ToString();
                    conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No existe el cliente con ese número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BuscarClientesEliminar()
        {
            Conexion conexion = new Conexion();
            SqlCommand comando;
            SqlDataReader leer;
            if (txt_nombre_CE.Text != "" && txt_apellidoP_CE.Text != "")
            {
                MessageBox.Show("Debes buscar solo por un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nombre_CE.Clear();
                txt_apellidoP_CE.Clear();
                lbl_no_cliente_eliminar.Text = "";
            }
            else if (txt_nombre_CE.Text != "" && txt_apellidoP_CE.Text == "")
            {
                comando = new SqlCommand("SELECT*FROM Clientes WHERE Nombres like+'%'+@nombres+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@nombres", txt_nombre_CE.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_cliente_eliminar.Text = leer["id_cliente"].ToString();
                    txt_nombre_CE.Text = leer["Nombres"].ToString();
                    txt_apellidoP_CE.Text = leer["apellidoP"].ToString();
                    txt_apellidoM_CE.Text = leer["apellidoM"].ToString();
                    conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No existe el cliente con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                comando = new SqlCommand("SELECT*FROM Clientes WHERE apellidoP like+'%'+@apellidoP+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@apellidoP", txt_apellidoP_CE.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_cliente_eliminar.Text = leer["id_cliente"].ToString();
                    txt_nombre_CE.Text = leer["Nombres"].ToString();
                    txt_apellidoP_CE.Text = leer["apellidoP"].ToString();
                    txt_apellidoM_CE.Text = leer["apellidoM"].ToString();
                    conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No existe el cliente con ese apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AgregarProveedores()
        {
            if (txt_nombre_RP.Text == "")
            {
                errorProvider1.SetError(txt_nombre_RP, "Campo Obligatorio");
                txt_nombre_CR.Focus();
                return;
            }
            if (txt_telefono_RP.MaskFull == false)
            {
                errorProvider1.SetError(txt_telefono_RP, "Información Incompleta");
                txt_telefono_CR.Focus();
                return;
            }
            if (txt_compañia_RP.Text=="")
            {
                errorProvider1.SetError(txt_compañia_RP, "Campo Obligatorio");
                txt_compañia_RP.Focus();
                return;
            }
            if (txt_direccion_RP.Text=="")
            {
                errorProvider1.SetError(txt_direccion_RP, "Campo Obligatorio");
                txt_direccion_RP.Focus();
                return;
            }
            if (txt_pais_RP.Text=="")
            {
                errorProvider1.SetError(txt_pais_RP, "Campo Obligatorio");
                txt_pais_RP.Focus();
                return;
            }
            if (txt_ciudad_RP.Text=="")
            {
                errorProvider1.SetError(txt_ciudad_RP, "Campo Obligatorio");
                txt_ciudad_RP.Focus();
                return;
            }
            errorProvider1.SetError(txt_ciudad_RP, "");
            errorProvider1.SetError(txt_pais_RP, "");
            errorProvider1.SetError(txt_nombre_RP, "");
            errorProvider1.SetError(txt_telefono_RP, "");
            errorProvider1.SetError(txt_compañia_RP, "");
            errorProvider1.SetError(txt_direccion_RP, "");
            Proveedores proveedores = new Proveedores();
            proveedores.COMPAÑIA = txt_compañia_RP.Text;
            proveedores.NOMBRE = txt_nombre_RP.Text;
            proveedores.DIRECCION = txt_direccion_RP.Text;
            proveedores.CIUDAD = txt_ciudad_RP.Text;
            proveedores.PAIS = txt_pais_RP.Text;
            proveedores.TELEFONO = txt_telefono_RP.Text;
            proveedores.AgregarProveedores();           
            txt_compañia_RP.Clear();
            txt_nombre_RP.Clear();
            txt_direccion_RP.Clear();
            txt_ciudad_RP.Clear();
            txt_pais_RP.Clear();
            txt_telefono_RP.Clear();
            MostrarProveedores();
            CargarCombosProductos();
        }
        private void ActualizarProveedor()
        {
            if (txt_nombre_AP.Text == "")
            {
                errorProvider1.SetError(txt_nombre_AP, "Campo Obligatorio");
                txt_nombre_AP.Focus();
                return;
            }
            else if (txt_telefono_AP.MaskFull == false)
            {
                errorProvider1.SetError(txt_telefono_AP, "Información Incompleta");
                txt_telefono_AP.Focus();
                return;
            }
            else if (txt_compañia_AP.Text == "")
            {
                errorProvider1.SetError(txt_compañia_AP, "Campo Obligatorio");
                txt_compañia_AP.Focus();
                return;
            }
            else if (txt_direccion_AP.Text == "")
            {
                errorProvider1.SetError(txt_direccion_AP, "Campo Obligatorio");
                txt_direccion_AP.Focus();
                return;
            }
            else if (txt_pais_AP.Text == "")
            {
                errorProvider1.SetError(txt_pais_AP, "Campo Obligatorio");
                txt_pais_AP.Focus();
                return;
            }
            else if (txt_ciudad_AP.Text == "")
            {
                errorProvider1.SetError(txt_ciudad_AP, "Campo Obligatorio");
                txt_ciudad_AP.Focus();
                return;
            }
            else if (lbl_no_proveedor_actualizar.Text=="")
            {
                MessageBox.Show("Debes de buscar un proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Proveedores proveedores = new Proveedores();
                proveedores.ID_PROVEEDOR = Convert.ToInt32(lbl_no_proveedor_actualizar.Text);
                proveedores.COMPAÑIA = txt_compañia_AP.Text;
                proveedores.NOMBRE = txt_nombre_AP.Text;
                proveedores.DIRECCION = txt_direccion_AP.Text;
                proveedores.CIUDAD = txt_ciudad_AP.Text;
                proveedores.PAIS = txt_pais_AP.Text;
                proveedores.TELEFONO = txt_telefono_AP.Text;
                if (MessageBox.Show("Se actualizara el proveedor", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    proveedores.ActualizarProveedores();                  
                    MostrarProveedores();
                    CargarCombosProductos();
                }
                lbl_no_proveedor_actualizar.Text = "";
                txt_compañia_AP.Clear();
                txt_nombre_AP.Clear();
                txt_direccion_AP.Clear();
                txt_ciudad_AP.Clear();
                txt_pais_AP.Clear();
                txt_telefono_AP.Clear();
            }
            errorProvider1.SetError(txt_ciudad_AP, "");
            errorProvider1.SetError(txt_pais_AP, "");
            errorProvider1.SetError(txt_nombre_AP, "");
            errorProvider1.SetError(txt_telefono_AP, "");
            errorProvider1.SetError(txt_compañia_AP, "");
            errorProvider1.SetError(txt_direccion_AP, "");
        }
        private void EliminarProveedor()
        {
            if (lbl_no_proveedor_eliminar.Text=="")
            {
                MessageBox.Show("Debes de buscar al proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Proveedores proveedores = new Proveedores();
                proveedores.ID_PROVEEDOR = Convert.ToInt32(lbl_no_proveedor_eliminar.Text);
                if (MessageBox.Show("Se eliminara el proveedor", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    proveedores.EliminarProveedores();                  
                    MostrarProveedores();
                    CargarCombosProductos();
                }
                lbl_no_proveedor_eliminar.Text = "";
                txt_compañia_EP.Clear();
                txt_nombre_EP.Clear();
            }
            
        }
        private void BuscarProveedores()
        {
            Proveedores proveedores = new Proveedores();
            if (txt_id_BP.Text != "" && txt_nombre_BP.Text != "" && txt_compañia_BP.Text != "" || txt_id_BP.Text != "" && txt_nombre_BP.Text != "" || txt_id_BP.Text != "" && txt_compañia_BP.Text != "" || txt_nombre_BP.Text != "" && txt_compañia_BP.Text != "")
            {
                MessageBox.Show("Debes buscar solo por un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_id_BP.Clear();
                txt_nombre_BP.Clear();
                txt_compañia_BP.Clear();
            }
            else if (txt_id_BP.Text != "" && txt_nombre_BP.Text == "" && txt_compañia_BP.Text == "")
            {
                proveedores.ID_PROVEEDOR = Convert.ToInt32(txt_id_BP.Text);
                dataGridView3.DataSource = proveedores.BuscarProveedorID();

            }
            else if (txt_id_BP.Text == "" && txt_nombre_BP.Text != "" && txt_compañia_BP.Text == "")
            {
                proveedores.NOMBRE = txt_nombre_BP.Text;
                dataGridView3.DataSource = proveedores.BuscarProveedorNombre();

            }
            else
            {
                proveedores.COMPAÑIA = txt_compañia_BP.Text;
                dataGridView3.DataSource = proveedores.BuscarProveedorCompañia();

            }
        }
        private void BuscarProveedoresActualizar()
        {
            Conexion conexion = new Conexion();
            SqlCommand comando;
            SqlDataReader leer;
            if (txt_nombre_AP.Text != "" && txt_compañia_AP.Text != "")
            {
                MessageBox.Show("Debes buscar solo por un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nombre_AP.Clear();
                txt_compañia_AP.Clear();
                lbl_no_proveedor_actualizar.Text = "";
            }
            else if (txt_nombre_AP.Text != "" && txt_compañia_AP.Text == "")
            {
                comando = new SqlCommand("SELECT*FROM Proveedores WHERE nombre like+'%'+@nombre+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@nombre", txt_nombre_AP.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_proveedor_actualizar.Text = leer["id_proveedor"].ToString();
                    txt_compañia_AP.Text = leer["compañia"].ToString();
                    txt_nombre_AP.Text = leer["nombre"].ToString();
                    txt_direccion_AP.Text = leer["direccion"].ToString();
                    txt_ciudad_AP.Text = leer["ciudad"].ToString();
                    txt_pais_AP.Text = leer["pais"].ToString();
                    txt_telefono_AP.Text = leer["telefono"].ToString();
                    comando.Connection = conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No existe el proveedor con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                comando = new SqlCommand("SELECT*FROM Proveedores WHERE compañia like+'%'+@compañia+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@compañia", txt_compañia_AP.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_proveedor_actualizar.Text = leer["id_proveedor"].ToString();
                    txt_compañia_AP.Text = leer["compañia"].ToString();
                    txt_nombre_AP.Text = leer["nombre"].ToString();
                    txt_direccion_AP.Text = leer["direccion"].ToString();
                    txt_ciudad_AP.Text = leer["ciudad"].ToString();
                    txt_pais_AP.Text = leer["pais"].ToString();
                    txt_telefono_AP.Text = leer["telefono"].ToString();
                    comando.Connection = conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No existe esa compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BuscarProveedoresEliminar()
        {
            Conexion conexion = new Conexion();
            SqlCommand comando;
            SqlDataReader leer;
            if (txt_nombre_EP.Text != "" && txt_compañia_EP.Text != "")
            {
                MessageBox.Show("Debes buscar solo por un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbl_no_proveedor_eliminar.Text = "";
                txt_nombre_EP.Clear();
                txt_compañia_EP.Clear();
            }
            else if (txt_nombre_EP.Text != "" && txt_compañia_EP.Text == "")
            {
                comando = new SqlCommand("SELECT*FROM Proveedores WHERE nombre like+'%'+@nombre+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@nombre", txt_nombre_EP.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_proveedor_eliminar.Text = leer["id_proveedor"].ToString();
                    txt_compañia_EP.Text = leer["compañia"].ToString();
                    txt_nombre_EP.Text = leer["nombre"].ToString();
                    comando.Connection = conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No existe el proveedor con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                comando = new SqlCommand("SELECT*FROM Proveedores WHERE compañia like+'%'+@compañia+'%'", conexion.AbrirConexion());
                comando.Parameters.AddWithValue("@compañia", txt_compañia_EP.Text);
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lbl_no_proveedor_eliminar.Text = leer["id_proveedor"].ToString();
                    txt_compañia_EP.Text = leer["compañia"].ToString();
                    txt_nombre_EP.Text = leer["nombre"].ToString();
                    comando.Connection = conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No existe esa compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AgregarCategoria()
        {
            Categorias categorias = new Categorias();
            categorias.NOMBRE = txt_agregar_categoria.Text;
            if (txt_agregar_categoria.Text=="")
            {
                errorProvider1.SetError(txt_agregar_categoria, "Campo Obligatorio");
                txt_agregar_categoria.Focus();
                return;
            }
            errorProvider1.SetError(txt_agregar_categoria, "");
            categorias.AgregarCategoria();         
            CargarCombosProductos();
            
        }
        private void EliminarCategoria()
        {
            Categorias categorias = new Categorias();
            categorias.ID_CATEGORIA = Convert.ToInt32(cbx_eliminar_categoria.SelectedValue);
            if (MessageBox.Show("Se eliminara la categoria","Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                categorias.EliminarCategoria();              
                CargarCombosProductos();
            }
        }
        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tab_Clientes.Visible = false;
            tab_empleados.Visible = false;
            tab_Proveedores.Visible = false;
            tab_productos.Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            tab_Clientes.Visible = true;
            tab_empleados.Visible = false;
            tab_Proveedores.Visible = false;
            tab_productos.Visible = false;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            tab_Clientes.Visible = false;
            tab_empleados.Visible = true;
            tab_Proveedores.Visible = false;
            tab_productos.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            inicio inicio = new inicio();
            inicio.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            tab_Clientes.Visible = false;
            tab_empleados.Visible = false;
            tab_Proveedores.Visible = true;
            tab_productos.Visible = false;
        }

        private void Txt_Nombre_ER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void Txt_ApellidoP_ER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_sueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void Txt_ApellidoM_ER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Txt_NoEmpleado_A_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MostrarEmpleados();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (txt_NoEmpleado.Text != ""&& txt_apellidoE.Text != ""&& txt_name_E.Text != ""|| txt_NoEmpleado.Text != "" && txt_apellidoE.Text != ""|| txt_name_E.Text != "" && txt_apellidoE.Text != ""|| txt_name_E.Text != ""&& txt_NoEmpleado.Text != "")
            {
                MessageBox.Show("Debes buscar solo por un campo","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_NoEmpleado.Clear();
                txt_apellidoE.Clear();
                txt_name_E.Clear();
            }
            else if(txt_NoEmpleado.Text != ""&& txt_apellidoE.Text == "" && txt_name_E.Text == "")
            {
                BuscarEmpleadoID();
            }
            else if(txt_NoEmpleado.Text == "" && txt_apellidoE.Text != "" && txt_name_E.Text == "")
            {
                BuscarEmpleadoApellido();
            }
            else
            {
                BuscarEmpleadoNombre();
            }
        }

        private void Btn_registrar_Click(object sender, EventArgs e)
        {
            AgregarEmpleado();

        }

        private void Btn_buscar_EA_Click(object sender, EventArgs e)
        {
            BuscarEmpleadoActualizar();
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            ModificarEmpleado();
        }

        private void Btn_buscar_EE_Click(object sender, EventArgs e)
        {
            BuscarEmpleadoEliminar();
        }

        private void Btn_Eliminar_Empleado_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }

        private void Btn_agregar_producto_Click(object sender, EventArgs e)
        {
            AgregarProductos();
            MostrarProductos();
            CargarCombosProductos();
        }

        private void Txt_codigo_PA_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_buscar_AP_Click(object sender, EventArgs e)
        {
            BuscarProductoActualizar();
        }

        private void Btn_modificar_producto_Click(object sender, EventArgs e)
        {
            ActualizarProductos();
            CargarCombosProductos();
            MostrarProductos();
        }

        private void Btn_eliminar_producto_Click(object sender, EventArgs e)
        {
            EliminarProductos();
            CargarCombosProductos();
            MostrarProductos();
        }

        private void Btn_mostrar_productos_Click(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void Btn_Buscar_Producto_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void Btn_Registrar_Cl_Click(object sender, EventArgs e)
        {
            AgregarClientes();
            MostrarClientes();
        }

        private void Btn_Actualizar_Cliente_Click(object sender, EventArgs e)
        {
            ActualizarClientes();
            MostrarClientes();
        }

        private void Btn_EliminarCliente_Click(object sender, EventArgs e)
        {
            EliminarCliente();
            MostrarClientes();
        }

        private void Btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void Btn_mostrar_clientes_Click(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void Btn_buscar_CE_Click(object sender, EventArgs e)
        {
            BuscarClientesEliminar();
        }

        private void Btn_buscar_CA_Click(object sender, EventArgs e)
        {
            BuscarClientesActualizar();
        }

        private void Btn_Registrar_P_Click(object sender, EventArgs e)
        {
            AgregarProveedores();
        }

        private void Btn_Actualizar_P_Click(object sender, EventArgs e)
        {
            ActualizarProveedor();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            BuscarProveedoresActualizar();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarProveedor();
        }

        private void Btn_buscar_PA_Click(object sender, EventArgs e)
        {
            BuscarProveedoresEliminar();
        }

        private void Btn_buscar_Proveedores_Click(object sender, EventArgs e)
        {
            BuscarProveedores();
        }

        private void Btn_mostrar_BP_Click(object sender, EventArgs e)
        {
            MostrarProveedores();
        }

        private void Btn_agregar_categoria_Click(object sender, EventArgs e)
        {
            AgregarCategoria();
        }

        private void Btn_eliminar_categoria_Click(object sender, EventArgs e)
        {
            EliminarCategoria();
        }
    }
}
