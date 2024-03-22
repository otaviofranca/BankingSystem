namespace BankingSystem{
  class Bank {
    private List<Account> accounts = new List<Account>();

    public void CreateAccount() {
        Console.Write("Digite o nome do titular da conta: ");
        string name = Console.ReadLine() ?? "";
        if (String.IsNullOrWhiteSpace(name)) {
            Console.WriteLine("Nome invalido.");
            return;
        }
        if (accounts.Exists(a => a.Name == name)) {
            Console.WriteLine("Erro!!!!!!!!!!!\nConta já <<<registrada>>>.");
            return;
        }
        
        Console.Write("Digite o saldo inicial da conta: ");
        double initialBalance;
        while (!double.TryParse(Console.ReadLine(), out initialBalance) || initialBalance < 0) {
            Console.WriteLine("Saldo inválido!.\nDigite novamente.");
            Console.WriteLine("Digite o saldo inicial da conta: ");
        }

        var newAccount = new Account(name, initialBalance);
        accounts.Add(newAccount);
        Console.WriteLine("Conta criada com sucesso");
    }

    public Account AccessAccount() 
    {
        Console.WriteLine("Digite o nome do titular da conta: ");
        string? name = Console.ReadLine();
        Account? account = accounts.Find(a => a.Name == name);
        if (account == null) 
        {
            throw new Exception("Titular da conta não encontrado.");
        }
    return account;
    }

  }
}
