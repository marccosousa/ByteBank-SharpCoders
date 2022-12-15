using System.Collections.Generic;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            List<Conta> contas = new List<Conta>();
            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());
                Console.WriteLine("--------------------");

                switch (option)
                {
                    case 1:
                        AdicionarContas(contas);
                        break;

                    case 2:
                        Console.WriteLine("Opção [2]: ");
                        Console.Write("Qual o ID da conta que você quer deletar? #");
                        int procurarId = int.Parse(Console.ReadLine());
                        int indexParaSerRemovido = contas.FindIndex(x => x.Id == procurarId);
                        contas.RemoveAt(indexParaSerRemovido);
                        break;

                    case 3:
                        Console.WriteLine("Opção [3]: ");
                        MostrarContas(contas); 
                        break;

                }
                Console.WriteLine("--------------------");

            } while (option != 0);
        }

        static void ShowMenu()
        {
            Console.WriteLine("[1] - Inserir novo usuário");
            Console.WriteLine("[2] - Deletar um usuário");
            Console.WriteLine("[3] - Listar contas registradas");
            Console.WriteLine("[4] - Detalhes de um usuário");
            Console.WriteLine("[5] - Total armazenado no banco");
            Console.WriteLine("[6] - Manipular conta");
            Console.WriteLine("[0] - Sair do menu");
            Console.Write("[X] - Digite a opção desejada: ");
        }

        static void AdicionarContas(List<Conta> contas)
        {
            Console.WriteLine("Opção [1]: ");
            Console.WriteLine($"Digite os dados da nova conta:");
            Console.Write("Titular: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Digite o saldo: ");
            double saldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o ID desejado: ");
            int id = int.Parse(Console.ReadLine());
            contas.Add(new Conta(nome, cpf, saldo, id));
            Console.WriteLine("Parabéns, bem-vindo!");
        }
        static void MostrarContas(List<Conta> contas)
        {
            foreach (Conta c in contas)
            {
                Console.WriteLine(c.ToString());
                Console.WriteLine();
            }
        }

    }
}

