using ByteBank_SharpCoders_ws.Entities;
using System;
using System.Diagnostics.Metrics;

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
                Console.Clear(); 
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
                        MostrarContas(contas);
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
                        Conta contaLogada = Login(contas);
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(contaLogada);
                            Console.WriteLine($"O que vamos fazer hoje, {contaLogada.Titular}?");
                            Console.WriteLine();
                            ShowMenuSecundario();
                            option = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Depósito: ");
                                    Depositando(contaLogada); 
                                    break;
                                case 2:
                                    Console.WriteLine("Saque: ");
                                    Sacando(contaLogada);
                                    break;
                                case 3:
                                    Console.WriteLine("Transferência: ");
                                    Transferindo(contas, contaLogada);
                                    break; 
                            }
                            Console.WriteLine("Digite qualquer tecla para voltar ao menu anterior...");
                            Console.ReadKey();
                        } while (option != 4);
                        break;
                }               
                Console.WriteLine("Digite qualquer tecla para voltar ao menu anterior...");
                Console.ReadKey();
            } while (option != 0);
            Console.WriteLine("Obrigado por utilizar o ByteBank! Até logo!");
        }

        //Início menu principal
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
            Console.Write("Crie uma senha: ");
            string senha = Console.ReadLine();
            Console.Write("Digite o depósito inicial: ");
            double saldo = double.Parse(Console.ReadLine());
            Random numAleatorioParaConta = new Random();
            int numConta = numAleatorioParaConta.Next(1000, 9000);
            Console.WriteLine($"O número da sua conta será: #{numConta}");
            contas.Add(new Conta(nome, cpf, senha, saldo, numConta));
            Console.WriteLine($"Parabéns {nome}!! Bem-vindo ao ByteBank!");
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
            Console.WriteLine("Contas: ");
            foreach (Conta obj in contas)
            {              
                Console.WriteLine("#" + obj.NumConta.ToString());
            }
            Console.WriteLine();
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

        static Conta Login(List<Conta> contas)
        { 
            foreach (Conta obj in contas)
            {
                Console.WriteLine($"Número da conta: #{obj.NumConta}\nTitular:{obj.Titular}");
                Console.WriteLine();
            }
            Conta c; 
            do
            {
                Console.WriteLine("Digite o número da conta que você quer manipular: ");
                int numContaLogin = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a sua senha: ");
                string senhaLogin = Console.ReadLine();
                c = contas.Find(x => x.NumConta == numContaLogin && x.Senha == senhaLogin);
                if (c == null)
                {
                    Console.WriteLine("Número da conta ou senha inválidos. Tente novamente.");
                    Console.WriteLine();
                }
            } while (c == null); 
            return c; // Retorna a conta que o usuário se logou. 
        }

        static void ShowMenuSecundario()
        {
            Console.WriteLine("Opção [6]: ");
            Console.WriteLine("[1] - Depósito");
            Console.WriteLine("[2] - Saque");
            Console.WriteLine("[3] - Transferencia");
            Console.WriteLine("[4] - Voltar para o menu principal");
            Console.Write("[X] - Digite a opção desejada: ");
        }

        static void Depositando(Conta contaLogada)
        {
            Console.Write("Qual o valor do depósito: R$");
            double valor = double.Parse(Console.ReadLine());
            contaLogada.Deposito(valor);
            Console.WriteLine($"Depósito de R${valor:F2} efetuado com sucesso para {contaLogada.Titular}! ");
        }
        
        static void Sacando(Conta contaLogada)
        {
            Console.Write("Qual o valor do saque: R$");
            double valor = double.Parse(Console.ReadLine());
            contaLogada.Saque(valor);
            Console.WriteLine($"Saque de R${valor:F2} efetuado com sucesso de {contaLogada.Titular}");
        }

        static void Transferindo (List<Conta> contas, Conta contaLogada)
        {
            Conta contaOrigem = contaLogada;
            Console.WriteLine();
            foreach (Conta obj in contas)
            {
                Console.WriteLine($"Número da conta: #{obj.NumConta}\nTitular:{obj.Titular}");
                Console.WriteLine();
            }
            Console.Write("Digite o número da conta de destino: #");
            int procurarConta = int.Parse(Console.ReadLine());
            Conta contaDestino = contas.Find(x => x.NumConta == procurarConta);
            Console.WriteLine();
            while (contaDestino == null)
            {
                Console.Write("Conta inválida, digite novamente o número da conta: #");
                procurarConta = int.Parse(Console.ReadLine());
                contaDestino = contas.Find(x => x.NumConta == procurarConta);
            }
            while (contaDestino == contaOrigem)
            {
                Console.Write("A Conta de destino não pode ser a mesma da origem.\nDigite novamente o número da conta: #");
                procurarConta = int.Parse(Console.ReadLine());
                contaDestino = contas.Find(x => x.NumConta == procurarConta);
                if (contaDestino == null)
                {
                    Console.Write("Conta inválida, digite novamente o número da conta: #");
                    procurarConta = int.Parse(Console.ReadLine());
                    contaDestino = contas.Find(x => x.NumConta == procurarConta);
                }
            }
            Console.Write("Digite o valor: R$");
            double valorTransferencia = double.Parse(Console.ReadLine());
            contaDestino.Transferencia(contaOrigem, contaDestino, valorTransferencia);
            Console.WriteLine("Transferência realizada com sucesso!");
            Console.WriteLine();
            Console.WriteLine($"CONTA ORIGEM: Número #{contaOrigem.NumConta}\nTitular: {contaOrigem.Titular}");
            Console.WriteLine();
            Console.WriteLine($"CONTA DESTINO: Número #{contaDestino.NumConta}\nTitular: {contaDestino.Titular}");
            Console.WriteLine();
            Console.WriteLine($"VALOR: {valorTransferencia:F2}");
            Console.WriteLine();
        }

        // Fim menu secundário

    }
}

