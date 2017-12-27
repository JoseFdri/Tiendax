using Generador.controlladores;
using Generador.modelos;
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
    public partial class NuevoProducto_frm : Form
    {
        CategoriasController categoriaController = new CategoriasController();
        ProductoController productoController = new ProductoController();
        public NuevoProducto_frm()
        {
            InitializeComponent();
            listar_categorias();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void listar_categorias()
        {
            var categorias = categoriaController.listar_categorias();
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
        public void limpiar_campos()
        {
            txtNombre.Text = "";
            txtDesc.Text = "";
            txtPrecio.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            producto product = new producto();
            comboBoxItem item = cmbCat.SelectedItem as comboBoxItem;
            var id = item.Value;
            string codigo = productoController.generar_codigo();

            product.codigo = codigo;
            product.nombre = txtNombre.Text;
            product.descripcion = txtDesc.Text;
            product.idCategoria = Int32.Parse(item.Value);
            Debug.WriteLine(product.idCategoria);
            product.precio = Decimal.Parse(txtPrecio.Text);
            int rsp = productoController.crearProducto(product);
            string txtMensaje = string.Empty;
            if (rsp == 1)
            {
                txtMensaje = "Registro Exitoso";
                limpiar_campos();
            }else
            {   
                txtMensaje = "Error al registrar";
            }
            MessageBox.Show(txtMensaje);
        }
    }
}
