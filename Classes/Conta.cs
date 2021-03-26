using System;

namespace DIO_bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)  // Instanciando os atributos
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        // Métodos

        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if((this.Saldo - valorSaque) < (this.Credito * -1)) {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public bool Emprestimo(double valorEmprestimo)
        {
            // Validação do limite para empréstimo
            if(valorEmprestimo > 9000) {
                Console.WriteLine("Ultrapassou o limite do empréstimo");
                return false;
            }

            this.Saldo += valorEmprestimo;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia)) {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito + " | ";
            return retorno;
        }
    }
}