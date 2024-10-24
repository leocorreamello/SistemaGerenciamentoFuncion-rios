using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    internal class Program
    {

        private static List<funcionario> listaDeFuncionarios = new List<funcionario>();

        static void Main(string[] args)
        {

            Console.WriteLine("*******************************");
            Console.WriteLine("* Gerenciador de Funcionários *");
            Console.WriteLine("*******************************");

            while (true)
            {

                //Menu
                Console.WriteLine(@"
1. Adicionar Funcionário
2. Listar Funcionários
3. Buscas Funcionários
4. Calcular Salário Total
5. Aumentar Salário
6. Sair");

                Console.Write("--> ");
                string opcaoUser = Console.ReadLine();


                if (opcaoUser == "1" || opcaoUser == "2" || opcaoUser == "3" || opcaoUser == "4" || opcaoUser == "5" || opcaoUser == "6")
                {
                    if (opcaoUser == "1")
                    {
                        AdicionarFuncionario();
                    }
                    else if (opcaoUser == "2")
                    {
                        ListarFuncionarios();
                    }
                    else if (opcaoUser == "3")
                    {
                        BuscarFuncionarios();
                    }
                    else if (opcaoUser == "4")
                    {
                        CalcularSalario();
                    }
                    else if (opcaoUser == "5")
                    {
                        AumentarSalario();
                    }
                    else if (opcaoUser == "6")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção invalida digite um numero de 1 a 6");
                }
            }

        }

        public static void AdicionarFuncionario()
        {
            funcionario funcionario = new funcionario();
            Console.WriteLine();
            Console.WriteLine("*** Adicionar Funcionário ***");
            Console.WriteLine();
            Console.WriteLine("Digite o nome do funcionário: ");
            Console.Write("--> ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o cargo do funcionário: ");
            Console.Write("--> ");
            string cargo = Console.ReadLine();

            Console.WriteLine("Digite o salário do funcionário: ");
            Console.Write("--> ");
            string salario = Console.ReadLine(); //string para poder fazer a validação

            funcionario.nome = nome;
            funcionario.cargo = cargo;
            funcionario.salario = Convert.ToDouble(salario);

            listaDeFuncionarios.Add(funcionario);
        }

        public static void ListarFuncionarios()
        {
            if (listaDeFuncionarios.Count <= 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("*** Lista de Funcionarios ***");
                Console.WriteLine();
                Console.WriteLine("Total de funcionários cadastrados: " + listaDeFuncionarios.Count);
                Console.WriteLine();
                foreach (var funcionario in listaDeFuncionarios)
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine($"Nome: {funcionario.nome} | Cargo: {funcionario.cargo} | Salário: R${funcionario.salario}");
                }
            }
        }

        public static void BuscarFuncionarios()
        {
            if (listaDeFuncionarios.Count <= 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("*** Buscar Funcionários ***");
                Console.WriteLine();
                Console.WriteLine("Digite o nome do funcionário: ");
                Console.Write("--> ");
                string busca = Console.ReadLine();

                var funcionarioEncontrado = listaDeFuncionarios.FirstOrDefault(f => f.nome.Equals(busca, StringComparison.OrdinalIgnoreCase)); //Copilot Ajudou aqui
                if (funcionarioEncontrado != null)
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine($"Nome: {funcionarioEncontrado.nome} | Cargo: {funcionarioEncontrado.cargo} | Salário: R${funcionarioEncontrado.salario}");
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado.");
                }

            }
        }

        public static void CalcularSalario()
        {
            if (listaDeFuncionarios.Count <= 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("*** Calculo do Salário Total ***");
                Console.WriteLine();
                Console.WriteLine("Total de funcionários cadastrados: " + listaDeFuncionarios.Count);
                Console.WriteLine("Salário total dos funcionários: R$" + listaDeFuncionarios.Sum(f => f.salario));
            }
        }
        
        public static void AumentarSalario()
        {
            if (listaDeFuncionarios.Count <= 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("*** Aumento de Salário ***");
                Console.WriteLine();
                Console.WriteLine("Qual funcionario deseja aumentar o salário?");
                Console.Write("--> ");
                string busca = Console.ReadLine();

                var funcionarioEncontrado = listaDeFuncionarios.FirstOrDefault(f => f.nome.Equals(busca, StringComparison.OrdinalIgnoreCase)); //Copilot Ajudou aqui
                if (funcionarioEncontrado != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Salário atual: R${funcionarioEncontrado.salario}");
                    Console.WriteLine("Digite a porcetagem do aumento: ");
                    Console.Write("--> ");
                    double aumento = Convert.ToDouble(Console.ReadLine());

                    funcionarioEncontrado.salario += funcionarioEncontrado.salario * (aumento / 100);

                    Console.WriteLine("Salário atualizado!");

                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado.");
                }
            }
        }
    }
}
