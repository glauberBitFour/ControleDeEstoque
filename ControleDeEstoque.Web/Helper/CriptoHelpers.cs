using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ControleDeEstoque.Web
{
    public  static class CriptoHelpers
    {

        //toda classe de criptografia trabalha com bits
        public static string HashMd5(string val)
        {
            var bytes = Encoding.ASCII.GetBytes(val);
            var Md5 = MD5.Create();
            var hash = Md5.ComputeHash(bytes);
            var retorno = string.Empty;
            for(int i =0; i < hash.Length; i++)
            {

                //usando o x2 ele converte para hexadecimal, para ser a propria representação do MD5
                retorno += hash[i].ToString("x2");
            }

            return retorno;
        }
    }
}