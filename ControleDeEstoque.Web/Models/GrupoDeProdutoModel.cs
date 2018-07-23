using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleDeEstoque.Web.Models
{
    public class GrupoDeProdutoModel
    {



        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
  



        public static List<GrupoDeProdutoModel> RecuperarLista()
        {

            var retorno = new List<GrupoDeProdutoModel>();
            using (var conexao = new SqlConnection())
            {


                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;

                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from GrupoDeProduto order by DataCadastro";
                    var reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        retorno.Add(new GrupoDeProdutoModel
                        {
                            Id = (int)reader["Id"],
                            Nome = (string)reader["Nome"],
                            Ativo = (bool)reader["Ativo"],
                            DataCadastro = (DateTime)reader["DataCadastro"]




                        });

                    }
                }

            }

            return retorno;
        }

        public static GrupoDeProdutoModel RecuperarPeloId(int id)
        {

            GrupoDeProdutoModel retorno = null;

            using (var conexao = new SqlConnection())
            {


                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString; conexao.Open();


                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from GrupoDeProduto where (Id = @id)";
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    var reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        retorno = new GrupoDeProdutoModel
                        {
                            Id = (int)reader["Id"],
                            Nome = (string)reader["Nome"],
                            Ativo = (bool)reader["Ativo"]

                        };

                    }
                }

            }
            return retorno;
        }


        public static bool ExcluirPeloId(int id)
        {
            var retorno = false;


            if (RecuperarPeloId(id) != null)
            {

                using (var conexao = new SqlConnection())
                {


                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString; conexao.Open();


                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = "delete from GrupoDeProduto where (Id = @id)";
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        retorno = (comando.ExecuteNonQuery() > 0);


                    }

                }

            }
            return retorno;
        }



        public int SalvarGrupoProduto()
        {
            var retorno = 0;
            var model = RecuperarPeloId(this.Id);

            using (var conexao = new SqlConnection())
            {


                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    if (model == null)
                    {


                        //Apos inserir retorno o ultimo id inserido
                        comando.CommandText = "insert into GrupoDeProduto (Nome,Ativo,DataCadastro) values (@nome,@ativo,@dataCadastro); select convert(int,scope_identity())";
                        comando.Parameters.Add("@nome",SqlDbType.VarChar).Value = this.Nome;
                        comando.Parameters.Add("@ativo", SqlDbType.VarChar).Value = (this.Ativo ? 1 : 0);
                        comando.Parameters.Add("@dataCadastro", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");


                        retorno = (int)comando.ExecuteScalar();
                    }
                    else
                    {
                        comando.CommandText = "update GrupoDeProduto set Nome=@nome,Ativo=@ativo where Id = @id";
                           


                        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = this.Nome;
                        comando.Parameters.Add("@ativo", SqlDbType.VarChar).Value = (this.Ativo ? 1 : 0);
                        comando.Parameters.Add("@id",SqlDbType.Int).Value = this.Id;


                        if (comando.ExecuteNonQuery() > 0)
                        {
                            retorno = this.Id;
                        }


                    }
                }
                return retorno;
            }

        }
    }
}