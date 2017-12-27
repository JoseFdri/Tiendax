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
    public partial class VenderFactura_frm : Form
    {
        private FacturaController facturaController;
        private factura_cab factura;
        private List<ProductoDetalle> resultado;

        public VenderFactura_frm()
        {
            InitializeComponent();
            incializar_variables();
        }
        private void incializar_variables()
        {
            facturaController = new FacturaController();
            factura = new factura_cab();
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

        public void listar_detalle_factura( ProductoBusqueda prodct, int cantidad )
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
        private void button1_Click(object sender, EventArgs e)
        {
            AgregarProducto_frm agregar = new AgregarProducto_frm("factura");
            agregar.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            factura.ruc = txtRuc.Text;
            factura.direccion = txtDireccion.Text;
            factura.razon_social = txtRazonSocial.Text;
            factura.fecha = DateTime.Now;
            if (txtRuc.Text.Length != 11)
            {
                MessageBox.Show("El número RUC solo debe contener 12 caracteres");
                return;
            }
            if (resultado.Count == 0)
            {
                MessageBox.Show("Debes agregar productos");
                return;
            }
            int rsp = facturaController.crear_factura(factura, resultado);
            if(rsp == 1)
            {
                MessageBox.Show("Se ha emitido la factura");
            }else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            this.Dispose();
        }
    }
}
