using System;
using System.Collections.Generic;
namespace BankingSystem{
  class Program {
    static void Main(string[] args) {
        Bank bank = new Bank();
        
        int choice;
        
        while(true){
            Console.WriteLine("<<<<<SISTEMA BANCARIO>>>>>");
            Console.WriteLine("1. Criar Conta");
            Console.WriteLine("2. Acessar Conta");
            Console.WriteLine("3. Depositar ");
            Console.WriteLine("4. Transferir");
            Console.WriteLine("5. Sacar");

            choice = int.Parse(Console.ReadLine());

            switch(choice){
                case 1:
                    Console.WriteLine("<<<<<CRIACAO DE CONTAS>>>>>");
                    bank.CreateAccount();
                    break;
                case 2:
                    Console.WriteLine("<<<<<ACESSO DE CONTAS>>>>>");
                    Account account = bank.AccessAccount();
                    if (account != null) {
                        Console.WriteLine($"Conta encontrada :)\nSaldo: {account.Balance}");
                    } else {
                        Console.WriteLine("Conta nao encontrada!");
                    }
                    break;
                case 3:
                    Console.WriteLine("<<<<<DEPOSITO>>>>>");
                    Account depositAccount = bank.AccessAccount();
                    if (depositAccount != null) {
                        Console.WriteLine("Digite o valor do deposito: ");
                        double depositAmount = double.Parse(Console.ReadLine());
                        depositAccount.Deposit(depositAmount);
                    } else {
                        Console.WriteLine("Conta não encontrada!");
                    }
                    break;
                case 4:
                    Console.WriteLine("\n<<<<TRANSFERENCIA>>>>>");
                    Account sourceAccount = bank.AccessAccount();
                    if (sourceAccount != null) {
                        Console.WriteLine("Digite o nome da conta de destino:");
                        Account destinationAccount = bank.AccessAccount();
                        if (destinationAccount != null) {
                            Console.WriteLine("Digite o valor da transferencia: ");
                            double transferAmount = double.Parse(Console.ReadLine());
                            sourceAccount.Transfer(transferAmount, destinationAccount);
                        } else {
                            Console.WriteLine("Conta de destino não encontrada!");
                        }
                    } else {
                        Console.WriteLine("Conta de origem não encontrada.");
                    }
                    break;
                case 5:
                    Console.WriteLine("<<<<<SAQUE>>>>>");
                    Account withdrawAccount = bank.AccessAccount();
                    if (withdrawAccount != null) {
                        Console.WriteLine("Digite o valor do saque: ");
                        double withdrawAmount = double.Parse(Console.ReadLine());
                        withdrawAccount.Withdraw(withdrawAmount);
                    } else {
                        Console.WriteLine("Conta não encontrada!");
                    }
                    break;
                default:
                    Console.WriteLine("Opção invalida.\nDigite novamente.");
                    break;
            }
        }
    }
  }

}
