using System.Globalization;
using BankingSystem;

public class Validacoes
{
        
        public bool ValidCpf(string cpf)// validar quantidade de sobrenomes
        {
                if (cpf == null || cpf.Length != 11)
                {
                        Console.WriteLine("Invalid CPF");
                        return false;
                }

                foreach (char c in cpf)
                {
                        if (c < '0' || c > '9')
                        {
                                Console.WriteLine("only numbers are allowed");
                                return false;
                        }
                }

                return true;
        }

        public bool ValidName(string name)
        {
                if(name == null || name.Length > 60)
                {
                        Console.WriteLine("Invalid name");
                        return false;
                }
                foreach( char c in name)
                {
                        if((c>='a' && c<='z') || (c>='A' && c<='Z'))
                        {       
                                return true;
                        }else
                        {
                                Console.WriteLine("Invalid name");
                                return false;
                        }
                }
        
                return true;
        }

        public bool PositiveInput(out double value)
        {
            if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
            {
                return true;
            }
            return false;
        }
        /*  public string accountTransfer(string accountNumber)
        {
                if(accountNumber == null)
                {
                        Console.WriteLine("Account no exists!");
                        return "NoExists";
                }
                return accountNumber;
        }*/
}       
      
