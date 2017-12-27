using Generador.controlladores;
using Generador.modelos;
using Generador.utilidades;
using Generador.vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generador
{
    public partial class MenuPrincipal : Form
    {
        ProductoController productoController = new ProductoController();
        CategoriasController categoriaController = new CategoriasController();
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoProducto_frm nuevoProducto = new NuevoProducto_frm();
            nuevoProducto.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusquedaAvanzada_frm busquedaForm = new BusquedaAvanzada_frm();
            busquedaForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbTipoComprobante.Text == "Factura")
            {
                VenderFactura_frm factura = new VenderFactura_frm();
                factura.Show();
            }else
            {
                VenderBoleta_frm boleta = new VenderBoleta_frm();
                boleta.Show();
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<ProductoBusqueda> resultado = new List<ProductoBusqueda>();
            List<categoria> categorias = categoriaController.listar_categorias();

            Filtro filtro = new Filtro();
            filtro.nombre = txtBusqueda.Text;
            var productos = productoController.buscar_producto(filtro);

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
    }
}
