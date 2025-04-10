using Lab6q1;
internal class Program
{
    private static void Main(string[] args)
    {
        CheckEnteryData check = new CheckEnteryData();
        Family family1 = new Family();
        Console.WriteLine($"Конструктор по умолчанию: {family1.ToString()}");
        Console.WriteLine("Введите новую фамилию для первой семьи: ");
        family1.Surname = check.GetEnteryString();
        Console.WriteLine($"Изменение поля surname с помощью метода set " +
                          $"и вывод с помошью метода set: {family1.Surname}");
        Family family2 = new Family("Вшивков");
        Console.WriteLine($"Конструктор с заданным параметром: {family2.ToString()}");
        Family family3 = family1;
        Console.WriteLine($"Конструктор копирования: {family3.ToString()}");
        family1.addExlametionMark();
        Console.WriteLine($"добавление трёх восклицательных знков в начало: {family1.ToString()}\n\n");

        Member member1 = new Member();
        Console.WriteLine($"Конструктор по умолчанию: {member1.ToString()}");
        Console.WriteLine($"Метод возврата инициалов: {member1.Initials()}");
        member1.BecomeMember(family1);
        Console.WriteLine($"Метод становления членом семьи {member1.ToString()}");
        Console.WriteLine("Введите имя нового члена семьи: ");
        string name = check.GetEnteryString();
        Console.WriteLine("Введите фамилию нового члена семьи: ");
        string surname = check.GetEnteryString();
        Member member2 = new Member(name, surname);
        Console.WriteLine($"Конструктор с заданными параметрами: {member2.ToString()}");
        Member member3 = member2;
        Console.WriteLine($"Конструктор копирования: {member3.ToString()}");
        Console.WriteLine("Введите новое имя для третьего члена семьи: ");
        member3.Name = check.GetEnteryString();
        Console.WriteLine("Введтие новую фамилию для третьего члена семьи: ");
        member3.Surname = check.GetEnteryString();
        Console.WriteLine("Вывод и ввод имени и фамилии с помощью методов get и set" +
                         $"{member3.Name} {member3.Surname}");
        member3.addExlametionMark();
        Console.WriteLine($"Использование родительского метода в потомке: {member3.ToString()}");
    }
}