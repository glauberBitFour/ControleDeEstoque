using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleDeEstoque.Web.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {

            var retorno = false;
            using (var conexao = new SqlConnection())
            {
                

                conexao.ConnectionString = @"Data Source= DESKTOP-FN7GCR3\SQLSERVER;Initial Catalog=CONTROLE-ESTOQUE;User Id=Sa;Password=1010";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("select count(*) from usuario where login = '{0}' and senha = '{1}'", login, senha);

                    retorno = ((int)comando.ExecuteScalar() > 0);
                }

            }
            return retorno;

        }
    }
}