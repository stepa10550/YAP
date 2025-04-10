using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace Lab6q2
{
    internal class Money
    {
        private uint rubles;
        private byte kopeks;

        public Money() { }

        public Money(uint rubles, byte kopeks)
        {
            if (kopeks >= 100)
            {
                Console.WriteLine("Копеек больше 100");
                Environment.Exit(-1);
            }
            this.rubles = rubles;
            this.kopeks = kopeks;
        }

        public Money(Money money)
        {
            this.rubles = money.rubles;
            this.kopeks = money.kopeks;
        }

        public byte Kopeks 
        { 
            get { return kopeks; } 
            set 
            {
                if (kopeks < 100 && kopeks > 0) { this.kopeks = value; return; }
                if (kopeks >= 100) Console.WriteLine("Копеек больше 100");
                if (kopeks < 0) Console.WriteLine("Копеек не может быть меньше 0");
                Environment.Exit(-1);
            } 
        }
        public uint Rubles 
        { 
            get { return rubles; } 
            set 
            {
                if (kopeks < 0)
                {
                    Console.WriteLine("Копеек больше 100");
                    Environment.Exit(-1);
                }
                this.rubles = value; 
            } 
        }
        public static Money operator +(Money m1, Money m2)
        {
            int resultKopeks = m1.Kopeks + m2.Kopeks;
            uint resultRubles = m1.Rubles + m2.Rubles + (uint)(resultKopeks / 100);
            return new Money(resultRubles, (byte)(resultKopeks % 100));
        }

        public static Money operator -(Money a, Money b)
        {
            int Result = 100 * (int)(a.Rubles - b.Rubles) + (a.Kopeks - b.Kopeks);
            if (Result < 0) return new Money(0, 0);
            return new Money((uint)(Result / 100), (byte)(Result % 100));
        }

        public static explicit operator uint(Money a)
        {
            return a.Rubles;
        }

        public static implicit operator double(Money b)
        {
            return b.Kopeks / 100.0;
        }

        public static Money operator ++(Money a)
        {
            a.kopeks++;
            a.Rubles += (uint)a.Kopeks / 100;
            a.kopeks %= 100;
            return a;
        }

        public static Money operator --(Money a)
        {
            if (a.kopeks > 0) a.kopeks--;
            else if (a.Rubles > 0)
            {
                a.rubles--;
                a.kopeks = 99;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{this.Rubles} рублей {this.Kopeks} копеек";
        }

        public Money AddKopeks(uint Kopeks)
        {
            uint Result = 100*this.rubles + this.Kopeks + Kopeks;
            return new Money(Result / 100, (byte)(Result % 100));
        }
    }
}
