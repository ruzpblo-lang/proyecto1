using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class AgregarProductos : Form
    {
        public AppBancaria gestorempresa;
        private List<PrecioProveedor> precioProveedores;
        public AgregarProductos(AppBancaria gestorempresa)
        {
            InitializeComponent();
            this.gestorempresa = gestorempresa;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateData()
        {
            List<PrecioProveedor> listaFiltrada = precioProveedores;
            
            if (cmbProducto.SelectedItem != null && cmbProducto.SelectedItem.ToString() != "Todos")
            {
                string filtroTipo = cmbProducto.SelectedItem.ToString();
                listaFiltrada = listaFiltrada.Where(p => p.Tipo == filtroTipo).ToList();
            }
            if(cmbProveedor.SelectedItem != null && cmbProveedor.SelectedItem.ToString() != "Todos")
            {
                string filtroTipo = cmbProveedor.SelectedItem.ToString();
                listaFiltrada = listaFiltrada.Where(p => p.Proveedor == filtroTipo).ToList();
            }
            dgvAgregarProducto.DataSource = null;
            dgvAgregarProducto.DataSource = listaFiltrada;
            dgvAgregarProducto.Columns["PrecioId"].Visible = false;

            CalcularTodo();
        }

        private void CalcularTodo()
        {
            if (cmbProducto.SelectedItem == null || cmbProducto.SelectedItem.ToString() == "Todos" ||
                cmbProveedor.SelectedItem == null || cmbProveedor.SelectedItem.ToString() == "Todos" ||
                txtCantidad.Text == "") 
            {
                lblTotal.Text = "Total : ";
                    return;
            }

            string tipoSeleccionado = cmbProducto.SelectedItem.ToString();
            string proveedorSeleccionado = cmbProveedor.SelectedItem.ToString();

            var producto = precioProveedores.Where(p => p.Tipo == tipoSeleccionado && p.Proveedor == proveedorSeleccionado).ToList();

            if (producto.Count == 0)
            {
                lblTotal.Text = "Total : 0.0$";
                return;
            }
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double Total = cantidad * producto[0].Precio;

            lblTotal.Text = "Total : $" + Total.ToString("N2"); 
        }

        private void AgregarProductos_Load(object sender, EventArgs e)
        {

            precioProveedores = gestorempresa.MostrarProductosProveedores();
            //dgvAgregarProducto.Columns["PrecioId"].Visible = false;

            cmbProducto.Items.Add("Todos");
            cmbProducto.Items.Add("Garrafon de agua 20L");
            cmbProducto.Items.Add("Paquete de hojas blancas");
            cmbProducto.Items.Add("Folder tamano carta");
            cmbProducto.Items.Add("Plumas color negro");
            cmbProducto.SelectedIndex = 0;
            cmbProveedor.Items.Add("Todos");
            cmbProveedor.Items.Add("Office Depot");
            cmbProveedor.Items.Add("Garrafones del Sureste");
            cmbProveedor.Items.Add("Papelera Yucateca");
            cmbProveedor.SelectedIndex = 0;
            UpdateData();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = cmbProducto.SelectedItem.ToString();
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            var producto = precioProveedores.Where(p => p.Tipo == tipo).ToList();
            decimal totalCompra = cantidad * (decimal)producto[0].Precio;

            double precioBase = gestorempresa.ObtenerSaldo(); 
            if((double)totalCompra > precioBase)
            {
                MessageBox.Show($"operacion no aceptada, debido a que el total de compra: {totalCompra} es superior {precioBase}","operacion cancelada",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch(MessageBox.Show("Confirmas agregar los productos!","Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    //primer elemento de la lista producto
                    gestorempresa.AgregarProducto(producto[0].ObjetoId, cantidad);

                    MessageBox.Show("Producto Agregado!");  
                    precioProveedores = gestorempresa.MostrarProductosProveedores();
                    gestorempresa.RegistrarPagosProducto(producto[0].Tipo, producto[0].Proveedor, totalCompra);
                    UpdateData();
                    break;
                case DialogResult.No:
                    break; 
            }
            
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }
        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            CalcularTodo();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularTodo();
        }
    }
}
