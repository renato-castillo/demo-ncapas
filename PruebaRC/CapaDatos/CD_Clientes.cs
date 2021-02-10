using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
        private readonly string cadena = "Server=.; Database=Prueba; Integrated Security=true";

        public List<CE_Clientes> Listar()
        {
            List<CE_Clientes> clientes = new List<CE_Clientes>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarClientes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var cliente = new CE_Clientes();
                            cliente.idCliente = dr.GetInt32(0);
                            cliente.nomCliente = dr.GetString(1);
                            cliente.apeCliente = dr.GetString(2);
                            cliente.fecCliente = dr.GetDateTime(3);

                            clientes.Add(cliente);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
                finally
                {
                    cn.Close();
                }

            }
            return clientes;
        }

        public int Registrar(CE_Clientes cliente)
        {
            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_registrarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nomCliente", cliente.nomCliente);
                    cmd.Parameters.AddWithValue("@apeCliente", cliente.apeCliente);
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public int Eliminar(int idCliente)
        {
            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_eliminarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public int Editar(int idCliente, CE_Clientes cliente)
        {
            cliente.idCliente = idCliente;
            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_editarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);
                    cmd.Parameters.AddWithValue("@nomCliente", cliente.nomCliente);
                    cmd.Parameters.AddWithValue("@apeCliente", cliente.apeCliente);
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}
