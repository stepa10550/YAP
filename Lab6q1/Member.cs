using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6q1
{
    internal class Member : Family
    {
        private string name;

        public Member() 
        { 
            this.name = "Иван";
            this.Surname = "Иванов";
        }
        public Member (string name) 
        { 
            this.name = name; 
            this.Surname = "Иванов";
        }

        public Member(string name, string surname)
        {
            this.name = name;
            this.Surname = surname;
        }

        public Member (Member A) 
        { 
            this.name = A.Name; 
            this.Surname = A.Surname;
        }

        public string Name { get { return name; } set { this.name = value; } }

        public override string ToString()
        {
            return $"Имя и фамилия члена семьи: {Name} {Surname}";
        }

        public string Initials()
        {
            return $"{Surname[0]}.{Name[0]}.";
        }

        public void BecomeMember(Family family)
        {
            this.Surname = family.Surname;
        }
    }
}

/*
 Разработать класс с одним строковым полем. Создать конструктор копирования. Разработать
метод, приписывающий к полю в начало три знака восклицания. Перегрузить метод ToString()
для формирования строки из полей класса. Реализовать дочерний класс (его содержание
предложить самостоятельно и описать в решении: какой содержательный смысл имеют поля;
реализовать конструкторы; предложить и реализовать 2-3 метода). Протестировать все
конструкторы и другие методы базового и дочернего классов.
 */