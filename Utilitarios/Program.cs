
using System;
using System.Linq;

namespace Utilitarios
{
    internal class Program
    {

        static void Criptografar()
        {
            string senha = string.Empty;
            Console.Write("Digite a senha: ");
            senha = Console.ReadLine();

            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                Console.Write("A senha criptogradada é " + sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static bool ValidaSenha()
        {
            string palavra = string.Empty;
            Console.Write("Digite a palavra: ");
            palavra = Console.ReadLine();

            if (palavra.Trim() == "" || palavra == string.Empty) {
                Console.WriteLine("A senha deve possuir pelo menos 5 caracteres !\n");
                return false;
            }

            // Verifica tamanho
            if (palavra.Length < 5)
            {
                Console.WriteLine("A nova senha deve possuir pelo menos 5 caracteres !\n");
                return false;
            }

            // Deve possuir uma letra maiuscula
            if (!(palavra.Any(c => char.IsLetter(c)) && palavra.Any(c => char.IsUpper(c))))
            {
                Console.WriteLine("A nova senha deve possuir pelo menos 1 letra maiúscula !\n");
                return false;
            }

            // Deve possuir uma letra minuscula
            if (!(palavra.Any(c => char.IsLetter(c)) && palavra.Any(c => char.IsLower(c))))
            {
                Console.WriteLine("A nova senha deve possuir pelo menos 1 letra minúscula !\n");
                return false;
            }

            // Deve possuir pelo menos um número
            if (!(palavra.Any(c => char.IsNumber(c))))
            {
                Console.WriteLine("A nova senha deve possuir pelo menos 1 número !\n");
                return false;
            }

            // Deve possuir pelo menos um caracter especial
            if (palavra.Count(p => !char.IsLetterOrDigit(p)) <= 0)
            {
                Console.WriteLine("A nova senha deve possuir pelo menos 1 caracter especial !\n");
                return false;
            }

            Console.WriteLine("SENHA OK");
            return true;
        }

        static void ComparaLista()
        {
            string[] lista1 = { "NOME 1", "NOME 2", "NOME 3", "NOME 6" };
            string[] lista2 = { "NOME 3", "NOME 4", "NOME 5", "NOME 6" };


            IEnumerable<string> differenceQuery = lista1.Except(lista2);
            IEnumerable<string> differenceQuery2 = lista2.Except(lista1);
            IEnumerable<string> equalsQuery = lista2.Intersect(lista1);

            string valores_lista1 = "";
            foreach (string x in lista1)
            {
                if (valores_lista1 != "")
                    valores_lista1 += ", ";
                valores_lista1 += x;
            }

            string valores_lista2 = "";
            foreach (string x in lista2)
            {
                if (valores_lista2 != "")
                    valores_lista2 += ", ";
                valores_lista2 += x;
            }

            Console.WriteLine("Primeira Lista: " + valores_lista1);
            Console.WriteLine("Segunda Lista: " + valores_lista2);
            Console.WriteLine(" ");
            Console.WriteLine("Valores em ambas as listas:" + string.Join(", ", equalsQuery));
            Console.WriteLine(" ");
            Console.WriteLine("A primeira lista tem de diferente:" + string.Join(", ", differenceQuery));
            Console.WriteLine("A segunda lista tem de diferente:" + string.Join(", ", differenceQuery2));
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("************************************");
            Console.WriteLine("*     ESCOLHA A OPÇÃO DESEJADA:    *");
            Console.WriteLine("************************************");
            Console.WriteLine("* 1-) Comparação entre duas listas *");
            Console.WriteLine("* 2-) Valida senha                 *");
            Console.WriteLine("* 3-) Criptografia MD5             *");
            Console.WriteLine("************************************");

            Console.Write(" > ");
            string opcao = Console.ReadLine();


            switch (opcao) {
                case "1":
                    {
                        ComparaLista();
                        break;
                    }
                case "2":
                    {
                        bool ret = false;
                        while (ret != true)
                        {
                            ret = ValidaSenha();
                        }
                        break;
                    }
                case "3":
                    {
                        Criptografar();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção inválida !");
                        break;
                    }
            
            }
                
        }
   
    }
}
