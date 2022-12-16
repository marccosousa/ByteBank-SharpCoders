namespace ByteBank
{
    class Conta
    {
        public string Titular { get; set; }
        public string Cpf { get; set; }
        public double Saldo { get; private set; }
        public int Id { get; set; }

        public Conta()
        {
        }

        public Conta(string titular, string cpf, double saldo, int id)
        {
            Titular = titular;
            Cpf = cpf;
            Saldo = saldo;
            Id = id;
        }

        public void Deposito(double valor)
        {
            Saldo += valor;
        }

        public void Saque(double valor)
        {
            Saldo -= valor;
        }

        public override string ToString()
        {
            return $"Conta ID#{Id}\nTitular: {Titular}\nCPF: {Cpf}\nSaldo: {Saldo:F2}";
        }
    }
}
