using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace testes.Models
{
    public class TesteData
    {
        public int Id { get; set; }
        public Date Data { get; set; }



        public static List<TesteData> RecuperarLista()
        {

            var retorno = new List<TesteData>();
            using (var conexao = new SqlConnection())
            {


                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;

                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from Teste_data order by Id";
                    var reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        retorno.Add(new TesteData
                        {
                            Id = (int)reader["Id"],
                            Data = (Date)reader["Data"]

                        });

                    }
                }

            }

            return retorno;
        }
    }
}