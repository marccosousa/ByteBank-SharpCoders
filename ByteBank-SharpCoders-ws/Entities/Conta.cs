namespace ByteBank_SharpCoders_ws.Entities
{
    class Conta
    {
        public string Titular { get; set; }
        public string Cpf { get; set; }
        public double Saldo { get; private set; }
        public int NumConta { get; set; }

        public Conta()
        {
        }

        public Conta(string titular, string cpf, double saldo, int numConta)
        {
            Titular = titular;
            Cpf = cpf;
            Saldo = saldo;
            NumConta = numConta;
        }

        public void Deposito(double valor)
        {
            Saldo += valor;
        }

        public void Saque(double valor)
        {
            Saldo -= valor;
        }

        public void Transferencia(Conta contaOrigem, Conta contaDestino, double valor)
        {
            contaOrigem.Saldo -= valor;
            contaDestino.Saldo += valor; 
        }

        public override string ToString()
        {
            return $"Conta Número #{NumConta}\nTitular: {Titular}\nCPF: {Cpf}\nSaldo: {Saldo:F2}";
        }
    }
}
