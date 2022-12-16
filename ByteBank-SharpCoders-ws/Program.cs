using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

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
                        Console.Clear();
                        Console.WriteLine("Opção [1]: ");
                        AdicionarConta(contas);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Opção [2]: ");
                        RemoverConta(contas);
                        Console.WriteLine("Lista atualizada: ");
                        Console.WriteLine();
                        MostrarContas(contas);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Opção [3]: ");
                        MostrarContas(contas);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Opção [4]: ");
                        DetalhesDaConta(contas);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Opção [5]: ");
                        Console.WriteLine("Total armazenado no banco: R$" + TotalNoBanco(contas).ToString("F2"));
                        break;
                    case 6:            
                        do
                        {
                            ShowMenuSecundario();
                            option = int.Parse(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    Depositando(contas); 
                                    break;
                                case 2:
                                    Sacando(contas);
                                    break;
                            }
                        } while (option != 4);
                        break;

                }
                Console.WriteLine("--------------------");

            } while (option != 0);
        }

        //Início principal
        static void ShowMenu()
        {
            Console.WriteLine("[1] - Inserir nova conta");
            Console.WriteLine("[2] - Deletar uma conta");
            Console.WriteLine("[3] - Listar contas registradas");
            Console.WriteLine("[4] - Detalhes de uma conta");
            Console.WriteLine("[5] - Total armazenado no banco");
            Console.WriteLine("[6] - Manipular conta");
            Console.WriteLine("[0] - Sair do menu");
            Console.Write("[X] - Digite a opção desejada: ");
        }

        static void AdicionarConta(List<Conta> contas)
        {
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
        static void RemoverConta(List<Conta> contas)
        {
            Console.Write("Qual o ID da conta que você quer deletar? #");
            int procurarId = int.Parse(Console.ReadLine());
            Conta c = contas.Find(x => x.Id == procurarId);
            contas.Remove(c);
            while (c == null)
            {
                Console.Write("Conta inválida, digite novamente o ID: #");
                procurarId = int.Parse(Console.ReadLine());
                c = contas.Find(x => x.Id == procurarId);
                contas.Remove(c);
            }
            Console.WriteLine($"Conta: ID#{c.Id} Removida com sucesso.");
            Console.WriteLine();
        }
        static void MostrarContas(List<Conta> contas)
        {
            foreach (Conta obj in contas)
            {
                Console.WriteLine(obj.ToString());
                Console.WriteLine();
            }
        }

        static void DetalhesDaConta(List<Conta> contas)
        {
            Console.Write("Qual o ID da conta que você quer consultar? #");
            int procurarId = int.Parse(Console.ReadLine());
            Conta c = contas.Find(x => x.Id == procurarId);
            while (c == null)
            {
                Console.Write("Conta inválida, digite novamente o ID: #");
                procurarId = int.Parse(Console.ReadLine());
                c = contas.Find(x => x.Id == procurarId);
            }
            foreach (Conta obj in contas)
            {
                if (obj == c)
                {
                    Console.WriteLine();
                    Console.WriteLine("Detalhes da conta: ");
                    Console.WriteLine(obj.ToString());
                }
            }
        }

        static double TotalNoBanco(List<Conta> contas)
        {
            double soma = 0;
            foreach (Conta obj in contas)
            {
                soma += obj.Saldo;
            }
            return soma;
        }

        // Fim menu principal

        // Início menu secundário

        static void ShowMenuSecundario()
        {
            Console.WriteLine("Opção [6]: ");
            Console.WriteLine("[1] - Depósito");
            Console.WriteLine("[2] - Saque");
            Console.WriteLine("[3] - Transferencia");
            Console.WriteLine("[4] - Voltar para o menu principal");
            Console.Write("[X] - Digite a opção desejada: ");
        }
        static void Depositando(List<Conta> contas)
        {
            Console.WriteLine("Qual o ID da conta que você quer depositar: #");
            int procurarId = int.Parse(Console.ReadLine());
            Conta c = contas.Find(x => x.Id == procurarId);
            while (c == null)
            {
                Console.Write("Conta inválida, digite novamente o ID: #");
                procurarId = int.Parse(Console.ReadLine());
                c = contas.Find(x => x.Id == procurarId);
            }
            Console.Write("Qual o valor do depósito: R$");
            double valor = double.Parse(Console.ReadLine());
            c.Deposito(valor);
            Console.WriteLine($"Depósito de R${valor} efetuado com sucesso! ");
        }

        static void Sacando(List<Conta> contas)
        {
            Console.WriteLine("Qual o ID da conta que você quer depositar: #");
            int procurarId = int.Parse(Console.ReadLine());
            Conta c = contas.Find(x => x.Id == procurarId);
            while (c == null)
            {
                Console.Write("Conta inválida, digite novamente o ID: #");
                procurarId = int.Parse(Console.ReadLine());
                c = contas.Find(x => x.Id == procurarId);
            }
            Console.Write("Qual o valor do depósito: R$");
            double valor = double.Parse(Console.ReadLine());
            c.Saque(valor);
            Console.WriteLine($"Saque de R${valor} efetuado com sucesso! ");
        }

    }
}

