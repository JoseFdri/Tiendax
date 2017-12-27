using Generador.controlladores;
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
    public partial class Login_frm : Form
    {
        public Login_frm()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            SesionController sesionController = new SesionController();
            var rsp = sesionController.iniciar_sesion(txtUsuario.Text, txtPassword.Text);
            if (rsp == 1)
            {
                MessageBox.Show("Bienvenido");
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Error en las credenciales");
            }

        }
    }
}
