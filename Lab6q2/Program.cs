using Lab6q2;

internal class Program
{
    private static void Main(string[] args)
    {
        CheckEnteryData check = new CheckEnteryData();
        Console.WriteLine("Введите количество рублей в первую кучу денег: ");
        uint Rubles1 = check.GetEnteryUint();
        Console.WriteLine("Введите количество копеек в первую кучу денег (меньше ста): ");
        byte Kopeks1 = check.GetEnteryByte(100);
        Money money1 = new Money(Rubles1, Kopeks1);
        Console.WriteLine($"{money1.ToString()}");
        Console.WriteLine("Введите количество копеек, которое хотите добавить: ");
        Money money2 = money1.AddKopeks(check.GetEnteryUint());
        Console.WriteLine($"Первая куча денег: {money2.ToString()}");
        money1--;
        Console.WriteLine($"Результат работы оператора --:{money1.ToString()}");
        money1++;
        Console.WriteLine($"Результат работы оператора ++:{money1.ToString()}");
        Console.WriteLine("Введите количество рублей для второй кучи денег:");
        uint Rubles2 = check.GetEnteryUint();
        Console.WriteLine("Введите количество копеек для второй кучи денег (меньше ста): ");
        byte Kopeks2 = check.GetEnteryByte(100);
        Money money3 = new Money(Rubles2, Kopeks2);
        Money money4 = money2 + money3;
        Money money5 = money3 + money2;
        Money money6 = money2 - money3;
        Money money7 = money3 - money2;
        Console.WriteLine(
            $"Вторая куча денег: {money3.ToString()}\n" +
            $"Результат сложения первой и второй кучи денег: {money4.ToString()}\n" +
            $"Результат сложения второй и первой кучи денег: {money5.ToString()}\n" +
            $"Результат вычитания первой и второй кучи денег: {money6.ToString()}\n" +
            $"Результат вычитания второй и первой кучи денег: {money7.ToString()}\n");
        uint Rubles3 = (uint)money3;
        double Kopeks3 = money3;
        Console.WriteLine(
            $"Результат преобразований второй кучи денег в тип uint {Rubles3}\n" +
            $"Результат преобразования второй кучи денег в тип double {Kopeks3}\n");
    }
}