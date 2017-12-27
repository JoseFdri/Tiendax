using Generador.controlladores;
using Generador.modelos;
using Generador.utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generador.vistas
{
    public partial class VenderBoleta_frm : Form
    {
        private BoletaController boletaController;
        private boleta_cab boleta;
        private List<ProductoDetalle> resultado;

        public VenderBoleta_frm()
        {
            InitializeComponent();
            incializar_variables();
        }
        private void incializar_variables()
        {
            boletaController = new BoletaController();
            boleta = new boleta_cab();
            resultado = new List<ProductoDetalle>();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        public void calcular_total()
        {
            decimal? total = 0;
            foreach (var item in resultado)
            {
                total += (item.cantidad * item.precio);
            }
            txtTotal.Text = "S/ " + total;
        }
        private void Vender_frm_Load(object sender, EventArgs e)
        {

        }

        public void listar_detalle_factura(ProductoBusqueda prodct, int cantidad)
        {
            ProductoDetalle item = new ProductoDetalle();
            item.codigo = prodct.codigo;
            item.cantidad = cantidad;
            item.categoria = prodct.categoria;
            item.nombre = prodct.nombre;
            item.precio = prodct.precio;
            item.descripcion = prodct.descripcion;

            resultado.Add(item);

            BindingList<ProductoDetalle> data_binding = new BindingList<ProductoDetalle>(resultado);
            BindingSource data_source = new BindingSource(data_binding, null);
            gridDetalle.DataSource = data_source;
            calcular_total();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            AgregarProducto_frm agregar = new AgregarProducto_frm("boleta");
            agregar.ShowDialog(this);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            boleta.nombre = txtNombre.Text;
            boleta.direccion = txtDireccion.Text;
            boleta.fecha = DateTime.Now;
            if (txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Debes ingresar un nombre");
                return;
            }
            if (resultado.Count == 0)
            {
                MessageBox.Show("Debes agregar productos");
                return;
            }
            int rsp = boletaController.crear_boleta(boleta, resultado);
            if (rsp == 1)
            {
                MessageBox.Show("Se ha emitido la boleta de venta");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            this.Dispose();
        }
    }
}
