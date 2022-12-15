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

        public override string ToString()
        {
            return $"Conta ID#{Id}\nTitular: {Titular}, CPF: {Cpf}, Saldo: {Saldo:F2}";
        }
    }
}
