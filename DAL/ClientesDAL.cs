using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;


namespace DAL
{


    public class ClientesDal
    {
        public void incluir(ClienteInformation cliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                //carrrega a string de coneção do SQL Serve
                cn.ConnectionString = "Data Source=DESKTOP-1KP3C9G;Initial Catalog=LOJINHA;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
                //cria objeto cmd para executar comandos
                SqlCommand cmd = new SqlCommand();
                // cmd recebe a string da conexão
                cmd.Connection = cn;
                //define que usaremos Stored Procedurre do SQL Server
                cmd.CommandType = CommandType.StoredProcedure;
                //nome da Stored Procedure que está usada
                cmd.CommandText = "insere_cliente";
                //parâmetro da Stored Procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.VarChar, 100);
                pnome.Value = cliente.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.NVarChar, 100);
                pemail.Value = cliente.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter ptelefone = new SqlParameter("@telefone", System.Data.SqlDbType.NVarChar, 80);
                ptelefone.Value = cliente.Telefone;
                cmd.Parameters.Add(ptelefone);
                cn.Open();
                cmd.ExecuteNonQuery();

                cliente.Codigo = (Int32)cmd.Parameters[0].Value;

            }
            catch (Exception ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Message);


            }
            finally
            {
                cn.Close();
            }                      

        }
        public void Excluir(int codigo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "excluir_cliente";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                Pcodigo.Value = cliente.Codigo;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.VarChar, 100);
                pnome.Value = cliente.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.VarChar, 100);
                pemail.Value = cliente.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter ptelefone = new SqlParameter("@telefone", SqlDbType.VarChar,80);
                ptelefone.Value = cliente.Telefone;
                cmd.Parameters.Add(ptelefone);

                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception("Servidor SQL Erro:" + ex.Message)    

            }
        }




    }
}

