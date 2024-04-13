 namespace BankingSystem
 {
    class Bank // implementar validações / criar tabela de erros
    {
        public List<Account> accounts = new List<Account>();
        public Random random = new Random();
        public string databasePath = @"C:\Users\otavi\OneDrive\Área de Trabalho\programming studies\C#\Banking\BankingSystem\database\accounts.txt";

        Validacoes valid = new Validacoes();
        public void CreateAccount()
        {
            Console.Write("Digite o nome do titular da conta: ");
            string name = Console.ReadLine() ?? "";
            if (accounts.Exists(a => a.Name == name))
            {
                Console.WriteLine("Erro! Conta já registrada.");
                return;
            }
            if(valid.ValidName(name)==false)
            {
                return;
            }

            Console.Write("Digite o saldo inicial da conta: ");
            double initialBalance;
            while (!double.TryParse(Console.ReadLine(), out initialBalance) || initialBalance < 0)
            {//refatorar 1
                Console.WriteLine("Saldo inválido! Digite novamente.");
                Console.Write("Digite o saldo inicial da conta: ");
            }

            int accountNumber = random.Next(10000, 100000);
            int agency = random.Next(1000, 10000);

            Console.Write("Digite o CPF do titular da conta: ");
            string cpf = Console.ReadLine() ?? "";

            if(valid.ValidCpf(cpf)==false)
            {
                return;
            }

            var newAccount = new Account(name, accountNumber, agency, cpf, initialBalance);
            accounts.Add(newAccount);

            SaveAccountsToFile();

            Console.WriteLine($"\n\nConta criada com sucesso!\nTitular: {name}\nCpf: {cpf}\nAgencia: {agency}\nNumero da Conta: {accountNumber}\nSaldo: {initialBalance}\n\n");
        }

        private void SaveAccountsToFile()
        {
            using (StreamWriter writer = new StreamWriter(databasePath))
            {
                foreach (var account in accounts)
                {
                    writer.WriteLine($"Name: {account.Name}, CPF: {account.Cpf}, Account Number: {account.AccountNumber}, Agency: {account.Agency}, Balance: {account.Balance}");
                }
            }
        }

        public void AccessAccount()
        {
            Console.Write("Digite o CPF do titular da conta: ");
            string cpf = Console.ReadLine() ?? "";

            Account account = accounts.Find(a => a.Cpf == cpf);
            if (account == null)
            {
                Console.WriteLine("Conta não encontrada!");
                return;
            }

            Console.WriteLine($"\nDADOS DA CONTA>>>\nTitular: {account.Name}\nCpf: {account.Cpf}\nConta: {account.Agency}\nAgencia: {account.AccountNumber}\nSaldo: {account.Balance}");
        }

        public void Deposit()
        {
            Console.Write("Digite o CPF do titular da conta: ");
            string cpf = Console.ReadLine() ?? "";

            Account depositAccount = accounts.Find(a => a.Cpf == cpf);
            if (depositAccount == null)
            {
                Console.WriteLine("Conta não encontrada!");
                return;
            }

            Console.Write("Digite o valor do depósito: ");
            double depositAmount;
            while (!valid.PositiveInput(out depositAmount))
            {
                Console.WriteLine("Valor de depósito inválido! Digite novamente.");
                Console.Write("Digite o valor do depósito: ");
            }

            depositAccount.Deposit(depositAmount);
            SaveAccountsToFile();
        }

        public void Transfer()
    {
        Console.Write("Digite o CPF do titular da conta de origem: ");
        string sourceCpf = Console.ReadLine() ?? "";
        //sourceCpf = valid.accountTransfer(sourceCpf);
        Account sourceAccount = accounts.Find(a => a.Cpf == sourceCpf);
        if (sourceAccount == null)
        {
            Console.WriteLine("Conta de origem não encontrada.");
            return;
        }

        Console.Write("Digite o CPF do titular da conta de destino: ");
        string destinationCpf = Console.ReadLine() ?? "";
        Account destinationAccount = accounts.Find(a => a.Cpf == destinationCpf);
        if (destinationAccount == null)
        {
            Console.WriteLine("Conta de destino não encontrada.");
            return;
        }

        Console.Write("Digite o valor da transferência: ");
        double transferAmount;
        while (!valid.PositiveInput(out transferAmount))
        {
            Console.WriteLine("Valor de transferência inválido! Digite novamente.");
            Console.Write("Digite o valor da transferência: ");
        }

        double updatedBalance = sourceAccount.Transfer(transferAmount, destinationAccount);

        UpdateBalance(sourceAccount, updatedBalance);
    }

    private void UpdateBalance(Account account, double newBalance)
    {
        using (StreamWriter writer = new StreamWriter(databasePath))
        {
            foreach (var count in accounts)
            {
                if (count == account)
                {
                    writer.WriteLine($"Name: {count.Name}, CPF: {count.Cpf}, Account Number: {count.AccountNumber}, Agency: {count.Agency}, Balance: {newBalance}");
                }
                else
                {
                    writer.WriteLine($"Name: {count.Name}, CPF: {count.Cpf}, Account Number: {count.AccountNumber}, Agency: {count.Agency}, Balance: {count.Balance}");
                }
            }
        }
    }

        public void Withdraw()
        {
            Console.Write("Digite o CPF do titular da conta: ");
            string cpf = Console.ReadLine() ?? "";

            Account withdrawAccount = accounts.Find(a => a.Cpf == cpf);
            if (withdrawAccount == null)
            {
                Console.WriteLine("Conta não encontrada!");
                return;
            }

            Console.Write("Digite o valor do saque: ");
            double withdrawAmount;
            while (!valid.PositiveInput(out withdrawAmount))
            {
                Console.WriteLine("Valor de saque inválido! Digite novamente.");
                Console.Write("Digite o valor do saque: ");
            }

            withdrawAccount.Withdraw(withdrawAmount);
            SaveAccountsToFile();
        }

        public void ShowDatabase()
        {
            Console.Write("Digite o CPF do titular da conta: ");
            string cpf = Console.ReadLine() ?? "";
            using (StreamReader reader = new StreamReader(databasePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    foreach (var part in parts)
                    {
                        if (part.Contains(cpf))
                        {
                            Console.WriteLine(line);
                            return;
                        }
                    }
                }
                Console.WriteLine("Conta não encontrada!");
            }
        }
        
    }
 }
 