using System;

namespace DIO_bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Samuel Lucas");

            Console.WriteLine(minhaConta.ToString());
        }
    }
}