namespace BankingSystem
{
    class Account
    {
        public string Name { get; }      // implementar senha após refatorar      
        public int AccountNumber { get; }
        public int Agency { get; }
        public string Cpf { get; }
        public double Balance { get; private set; }

        public Account(string name, int number, int agency, string cpf, double initialBalance)
        {
            Name = name;
            AccountNumber = number;
            Agency = agency;
            Cpf = cpf;
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Depósito realizado com sucesso!\nSaldo: {Balance}");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Saldo insuficiente!");
                return;
            }
            if (amount > 0)
            {
                Balance -= amount;
                Console.WriteLine($"Saque realizado com sucesso.\nSaldo: {Balance}");
            }
        }

        public double Transfer(double amount, Account destination)
        {
            if (this == destination)
            {
                Console.WriteLine("A conta de origem é a mesma que a de destino!");
                 return -9999;
            }
            if (amount > Balance)
            {
                Console.WriteLine("Saldo insuficiente!");
                return -9999;
            }
            if (amount > 0)
            {
                Balance -= amount;
                destination.Deposit(amount);
                Console.WriteLine($"Transferência realizada com sucesso!");
            }
            return Balance;
        }
    }
}
    