using System.Text;
interface IAccountOperations
{
    void Deposit(decimal amount);
    void Wirhdraw(decimal amount);
}

interface ITransfer
{
    void Transfer(BankAccount targetAccount, decimal amount);
}

class BankAccount : IAccountOperations, ITransfer
{
    public decimal Balance { get; set; }
    public BankAccount(decimal balance = 0)
    {
        Balance = balance;
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма должна быть положительной");
        } else
        {
            Balance += amount;
            Console.WriteLine($"Внесено: {amount}. Новый баланс: {Balance}");
        }
    }
    public void Wirhdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма должна быть положительной");
        }
        else if(amount > Balance) 
        {
            Console.WriteLine("На счете недостаточно средств");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"Снято: {amount}. Новый баланс: {Balance}");
        }
    }
    public void Transfer(BankAccount targetAccount, decimal amount)
    {
        if (targetAccount == null)
        {
            Console.WriteLine("Вы не ввели аккаунт!");
        }
        Console.WriteLine($"Происходит попытка перевода на сумму {amount} со счета {this.GetHashCode()} на счет {targetAccount.GetHashCode()}");
        Wirhdraw (amount);
        targetAccount.Deposit(amount);
        Console.WriteLine($"Перевод выполнен успешно. Переведено: {amount}");
    }
    public override string ToString()
    {
      return $"Баланс счёта: {this.GetHashCode()} : {Balance}";
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
      var account = new BankAccount(1000);
      var account2 = new BankAccount(500);
        Console.WriteLine("Начальные состояния счетов: ");
        Console.WriteLine(account);
        Console.WriteLine(account2);
        Console.WriteLine("----");

      account.Transfer(account2, 345);
        Console.WriteLine("----");

        Console.WriteLine("Новые состояние счетов: ");
        Console.WriteLine(account);
        Console.WriteLine(account2);
        Console.WriteLine("----");

    }
}