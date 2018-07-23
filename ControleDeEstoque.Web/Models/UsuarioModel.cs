using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleDeEstoque.Web.Models
{
    public class UsuarioModel
    {
        private static object sqlDbType;

        public static bool ValidarUsuario(string login, string senha)
        {

            var retorno = false;
            using (var conexao = new SqlConnection())
            {


                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    //usando dessa forma vc fica exposto a ataque de sql injection
                    //comando.CommandText = string.Format("select count(*) from usuario where login = '{0}' and senha = '{1}'", login,CriptoHelpers.HashMd5(senha));


                    comando.CommandText = "select count(*) from usuario where login = @login and senha = @senha";
                    comando.Parameters.Add("@login",SqlDbType.VarChar).Value = login;
                    comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = CriptoHelpers.HashMd5(senha);

                    
                    retorno = ((int)comando.ExecuteScalar() > 0);
                }
               

            }
            return retorno;

        }
    }
}