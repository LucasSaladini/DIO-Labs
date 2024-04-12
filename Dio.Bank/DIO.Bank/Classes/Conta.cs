using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Bank.Enum;

namespace DIO.Bank.Conta
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            
            Console.WriteLine("O saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public void JurosPoupanca(double juros, double saldo)
        {
            double valorJuros = juros / 100;
            double saldoAtual = (saldo * valorJuros) + saldo;

            Console.WriteLine("Saldo autal da conta de {0} é {1}", this.Nome, saldoAtual);
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta" + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";

            return retorno;
        }
    }
}