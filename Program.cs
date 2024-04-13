using System;
using System.Collections.Generic;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            while (true)//refazer menu
            {
                Console.WriteLine("<<<<<SISTEMA BANCARIO>>>>>"); // Refinir as regras de negócio
                Console.WriteLine("1. Criar Conta");
                Console.WriteLine("2. Acessar Conta");
                Console.WriteLine("3. Depositar");
                Console.WriteLine("4. Transferir");
                Console.WriteLine("5. Sacar");
                Console.WriteLine("6. Extrato");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Opção inválida.\nDigite novamente.");
                    continue;
                }

                switch (choice)// implementar um método de pesquisa comum a todas as operaçõs
                {
                    case 1:
                        Console.WriteLine("<<<<<CRIACAO DE CONTAS>>>>>");// Usar get e set
                        bank.CreateAccount();
                        break;
                    case 2:
                        Console.WriteLine("<<<<<ACESSO DE CONTAS>>>>>");
                        bank.AccessAccount();
                        break;
                    case 3:
                        Console.WriteLine("<<<<<DEPOSITO>>>>>");
                        bank.Deposit();
                        break;
                    case 4:
                        Console.WriteLine("\n<<<<TRANSFERENCIA>>>>>");// atualizar o dataBase
                        bank.Transfer();
                        break;
                    case 5:
                        Console.WriteLine("<<<<<SAQUE>>>>>");
                        bank.Withdraw();
                        break;
                    case 6:
                        Console.WriteLine("<<<<<EXTRATO>>>>>");
                        bank.ShowDatabase();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.\nDigite novamente.");
                        break;
                }
            }
        }
    }
}