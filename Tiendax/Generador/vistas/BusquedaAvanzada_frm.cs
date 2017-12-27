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
    public partial class BusquedaAvanzada_frm : Form
    {
        ProductoController productoController = new ProductoController();
        CategoriasController categoriaController = new CategoriasController();
        List<ProductoBusqueda> resultado = new List<ProductoBusqueda>();
        List<categoria> categorias;
        public BusquedaAvanzada_frm()
        {
            InitializeComponent();
            listar_categorias();
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
            Filtro filtro = new Filtro();
            filtro.idCat = int.Parse(id);
            filtro.nombre = txtNombre.Text;
            filtro.desc = txtDescripcion.Text;

            filtro.precioMin = txtMin.Text.Length > 0 ?  int.Parse(txtMin.Text) : 0;
            if (txtMax.Text.Length > 0)
            {
                filtro.precioMax = int.Parse(txtMax.Text);
            }else
            {
                filtro.precioMax = null;
            }
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            buscar_producto();
        }

        private void cmbCat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            buscar_producto();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            buscar_producto();
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            buscar_producto();
        }

        private void txtMax_TextChanged(object sender, EventArgs e)
        {
            buscar_producto();
        }
    }
}
