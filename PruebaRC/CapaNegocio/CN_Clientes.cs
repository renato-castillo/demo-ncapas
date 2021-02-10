using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        CD_Clientes dataAccess = new CD_Clientes();

        public List<CE_Clientes> ListarClientes()
        {
            return dataAccess.Listar();
        }

        public int Registrar(CE_Clientes cliente)
        {
            return dataAccess.Registrar(cliente);
        }

        public int Eliminar(int idCliente)
        {
            return dataAccess.Eliminar(idCliente);
        }

        public int Editar(int idCliente, CE_Clientes cliente)
        {
            return dataAccess.Editar(idCliente, cliente);
        }

    }
}
