using System.Text;
interface IAttack
{
    void Attack();
}

interface IHeal
{
    void Heal();
}

class Warrior : IAttack
{
    public void Attack()
    {
        Console.WriteLine("Воин атакует мечом!");
    }
}

class Mage : IAttack, IHeal
{
    public void Attack()
    {
        Console.WriteLine("Маг бросает огненный шар!");
    }
    public void Heal()
    {
        Console.WriteLine("Маг хилит!");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        object[] characters = { new Warrior(), new Mage() };
        Console.WriteLine("Все атакующие персонажи: ");
        foreach (var character in characters)
        {
            if (character is IAttack attacker)
            {
                attacker.Attack();
            }
        }
        Console.WriteLine("Все лечащие персонажи: ");
        foreach (var character in characters)
        {
            if (character is IHeal healer)
            {
                healer.Heal();
            }
        }
    }
}
