using ByteBank_SharpCoders_ws.Entities;
using System;

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
                Console.Clear();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Opção [1]: ");
                        AdicionarConta(contas);
                        break;

                    case 2:
                        Console.WriteLine("Opção [2]: ");
                        RemoverConta(contas);
                        Console.WriteLine("Lista atualizada: ");
                        Console.WriteLine();
                        MostrarContas(contas);
                        break;

                    case 3:
                        Console.WriteLine("Opção [3]: ");
                        MostrarContas(contas);
                        break;
                    case 4:
                        Console.WriteLine("Opção [4]: ");
                        DetalhesDaConta(contas);
                        break;
                    case 5:
                        Console.WriteLine("Opção [5]: ");
                        Console.WriteLine($"Total armazenado no banco: R${TotalNoBanco(contas):F2}");
                        break;
                    case 6:
                        do
                        {
                            ShowMenuSecundario();
                            option = int.Parse(Console.ReadLine());
                            Console.WriteLine();
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
            Random numAleatorioParaConta = new Random();
            int numConta = numAleatorioParaConta.Next(1000, 9000);
            Console.WriteLine($"O número da sua conta será: #{numConta}");
            contas.Add(new Conta(nome, cpf, saldo, numConta));
            Console.WriteLine($"Parabéns {nome}!!, bem-vindo ao ByteBank!");
        }
        
        static void RemoverConta(List<Conta> contas)
        {
            Console.Write("Qual o número da conta que você quer deletar? #");
            int procurarConta = int.Parse(Console.ReadLine());
            Conta c = contas.Find(x => x.NumConta == procurarConta);
            contas.Remove(c);
            while (c == null)
            {
                Console.Write("Conta inválida, digite novamente o número: #");
                procurarConta = int.Parse(Console.ReadLine());
                c = contas.Find(x => x.NumConta == procurarConta);
                contas.Remove(c);
            }
            Console.WriteLine($"Conta número #{c.NumConta} Removida com sucesso.");
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
            Console.Write("Qual o número da conta que você quer consultar? #");
            int procurarConta = int.Parse(Console.ReadLine());
            Conta c = contas.Find(x => x.NumConta == procurarConta);
            while (c == null)
            {
                Console.Write("Conta inválida, digite novamente o número: #");
                procurarConta = int.Parse(Console.ReadLine());
                c = contas.Find(x => x.NumConta == procurarConta);
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
            Console.Write("Qual o número da conta que você quer depositar: #");
            int procurarConta = int.Parse(Console.ReadLine());
            Conta c = contas.Find(x => x.NumConta == procurarConta);
            while (c == null)
            {
                Console.Write("Conta inválida, digite novamente o ID: #");
                procurarConta = int.Parse(Console.ReadLine());
                c = contas.Find(x => x.NumConta == procurarConta);
            }
            Console.Write("Qual o valor do depósito: R$");
            double valor = double.Parse(Console.ReadLine());
            c.Deposito(valor);
            Console.WriteLine($"Depósito de R${valor:F2} efetuado com sucesso para {c.Titular}! ");
            Console.WriteLine();
            Console.WriteLine(c.ToString());
            Console.WriteLine();
        }
        
        static void Sacando(List<Conta> contas)
        {
            Console.Write("Qual o número da conta que você quer fazer o saque: #");
            int procurarConta = int.Parse(Console.ReadLine());
            Conta c = contas.Find(x => x.NumConta == procurarConta);
            while (c == null)
            {
                Console.Write("Conta inválida, digite novamente o ID: #");
                procurarConta = int.Parse(Console.ReadLine());
                c = contas.Find(x => x.NumConta == procurarConta);
            }
            Console.Write("Qual o valor do saque: R$");
            double valor = double.Parse(Console.ReadLine());
            c.Saque(valor);
            Console.WriteLine($"Saque de R${valor:F2} efetuado com sucesso da conta de {c.Titular} ");
            Console.WriteLine();
            Console.WriteLine(c.ToString());
            Console.WriteLine();

        }

    }
}

