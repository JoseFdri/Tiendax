using Generador.controlladores;
using Generador.modelos;
using Generador.utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generador.vistas
{
    public partial class AgregarProducto_frm : Form
    {   
        ProductoController productoController = new ProductoController();
        CategoriasController categoriaController = new CategoriasController();
        List<categoria> categorias;
        Filtro filtro = new Filtro();
        List<ProductoBusqueda> resultado = new List<ProductoBusqueda>();
        public string tipo_comprobante { get; set; }

        public AgregarProducto_frm(string tipo_comprobante)
        {
            InitializeComponent();
            listar_categorias();
            this.tipo_comprobante = tipo_comprobante;
        }
        public void listar_categorias()
        {
            categorias = categoriaController.listar_categorias();
            List<comboBoxItem> comboItems = new List<comboBoxItem>();

            foreach (var categoria in categorias)
            {
                comboBoxItem item = new comboBoxItem();
                item.Text = categoria.descripcion;
                item.Value = categoria.idCategoria.ToString();
                comboItems.Add(item);
            }
            cmbCat.DisplayMember = "Text";
            cmbCat.ValueMember = "Value";
            cmbCat.DataSource = comboItems;
        }
        public void buscar_producto()
        {
            resultado.Clear();
            comboBoxItem item = cmbCat.SelectedItem as comboBoxItem;
            var id = item.Value;
            filtro.idCat = int.Parse(id);
            filtro.nombre = txtNombre.Text;
            filtro.desc = txtDescripcion.Text;
            filtro.limit = 1;
            List<producto> productos = new List<producto>();
            productos = productoController.buscar_producto(filtro);

            foreach (var product in productos)
            {
                ProductoBusqueda productoBusqueda = new ProductoBusqueda();
                productoBusqueda.codigo = product.codigo;
                productoBusqueda.descripcion = product.descripcion;
                productoBusqueda.nombre = product.nombre;
                productoBusqueda.precio = product.precio;
                productoBusqueda.categoria = categorias
                                                .Where(x => x.idCategoria == product.idCategoria)
                                                .Select(a => a.descripcion)
                                                .Single();
                resultado.Add(productoBusqueda);
            }
            BindingList<ProductoBusqueda> data_binding = new BindingList<ProductoBusqueda>(resultado);
            BindingSource data_source = new BindingSource(data_binding, null);
            gridBusqueda.DataSource = data_source;
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            buscar_producto();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            buscar_producto();
        }

        private void cmbCat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            buscar_producto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            var cantidad = txtCantidad.Text.Length == 0 ? 1 : Int32.Parse(txtCantidad.Text);
            if(tipo_comprobante == "factura")
            {
                VenderFactura_frm vender_factura = (VenderFactura_frm)this.Owner;
                vender_factura.listar_detalle_factura(resultado.Single(), cantidad);
            }else
            {
                VenderBoleta_frm vender_boleta = (VenderBoleta_frm)this.Owner;
                vender_boleta.listar_detalle_factura(resultado.Single(), cantidad);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
