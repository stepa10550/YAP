using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6q1
{
    internal class Family
    {
        private string surname;

        public Family() { this.surname = "Иванов"; }
        public Family(string surname) { this.surname = surname; }
        public Family(Family A) { this.surname = A.Surname; }
        public string Surname { get { return surname; } set { surname = value; } }
        public override string ToString() { return $"Фамилия семьи: {surname}"; }
        public void addExlametionMark() { this.Surname = $"!!!{this.Surname}"; }
    }
}