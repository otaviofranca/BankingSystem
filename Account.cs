namespace BankingSystem{
  class Account {
    public string Name { get; } 
    public double Balance { get; private set; }

    public Account(string name, double initialBalance)
    {
        initialBalance =0;
        Name = name;
        Balance = initialBalance;
    }

    public void Deposit(double amount) 
    {
        if(amount>0)
        {
            Balance += amount;
            Console.WriteLine($"Deposito realizado com sucesso!\nSaldo: {Balance}");
        }
        
    }

    public void Withdraw(double amount) 
    {
        if (amount > Balance)
        {
            Console.WriteLine("Saldo insuficiente!");
            return;
        }
        if(amount>0)
        {
            Balance -= amount;
            Console.WriteLine($"Saque realizado com sucesso.\nSaldo: {Balance}");
        }
    }

    public void Transfer(double amount, Account destination) 
    {
        if (this == destination) {
            Console.WriteLine("A conta de origem eh a mesma que a de destino!");
            return;
        }
        if (amount > Balance) {
            Console.WriteLine("Saldo insuficiente!");
            return;
        }
        if(amount>0)
        {
            Balance -= amount;
            destination.Deposit(amount);
            Console.WriteLine($"Transferencia realizada com sucesso!");
        }
    }
  }
}
