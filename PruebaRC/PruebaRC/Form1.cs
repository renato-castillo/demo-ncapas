using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaRC
{
    public partial class Form1 : Form
    {
        private readonly CN_Clientes obj = new CN_Clientes();
        public Form1()
        {
            InitializeComponent();
        }

        void MostrarClientes()
        {
            tblClientes.DataSource = obj.ListarClientes();
        }

        void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CE_Clientes cliente = new CE_Clientes();
            cliente.nomCliente = txtNombres.Text;
            cliente.apeCliente = txtApellidos.Text;
            obj.Registrar(cliente);
            Mensaje("Registro agregado correctamente");
            MostrarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CE_Clientes cliente = new CE_Clientes();
            cliente.idCliente = Convert.ToInt32(txtId.Text);
            cliente.nomCliente = txtNombres.Text;
            cliente.apeCliente = txtApellidos.Text;
            obj.Editar(cliente.idCliente, cliente);
            Mensaje("Registro editado correctamente");
            MostrarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            obj.Eliminar(id);
            Mensaje("Registro eliminado correctamente");
            MostrarClientes();
        }

        private void tblClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = tblClientes.CurrentRow;
            if (filaSeleccionada != null)
            {
                txtId.Text = filaSeleccionada.Cells[0].Value.ToString();
                txtNombres.Text = filaSeleccionada.Cells[1].Value.ToString();
                txtApellidos.Text = filaSeleccionada.Cells[2].Value.ToString();
            }
        }
    }
}
