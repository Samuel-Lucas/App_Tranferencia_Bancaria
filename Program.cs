using System;
using System.Collections.Generic;

namespace DIO_bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X") {
                switch(opcaoUsuario) {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Emprestimo();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(listContas.Count == 0) {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for(int i = 0; i < listContas.Count; i++) {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void Sacar()
        {
            Console.Write("Digite o nº da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a sacar: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o nº da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a depositar: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Emprestimo()
        {
            Console.Write("Digite o nº da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor máximo para empréstimo: 9000.00");

            Console.Write("Digite o valor para empréstimo: ");
            double valorEmprestimo = double.Parse(Console.ReadLine());

            listContas[indiceConta].Emprestimo(valorEmprestimo);
        }

        private static void Transferir()
        {
            Console.Write("Digite o nº da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o nº da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a transferir: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void InserirConta() {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta Física ou 2 para conta jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

             Console.Write("Digite o crédito inicial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, //Converte entradaTipoConta para o enum
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("DIO bank a seu dispor !");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Emprestimo");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}