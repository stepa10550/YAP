internal class CheckEnteryData
{
    public string GetEnteryString()
    {
        string S;
        do
        {
            S = Console.ReadLine();
            if (S == "") Console.WriteLine("Вы ввели пустую строку, попытайтесь снова\n");
        } while (S == "");
        return S;
    }

    public int GetEnetryInteger()
    {
        int Result = 0;
        bool Check = false;
        do
        {
            string S = Console.ReadLine();
            try
            {
                Result = Convert.ToInt32(S);
                Check = true;
            }
            catch
            {
                Console.WriteLine("Вы ввели не целое число, попытайтесь снова\n");
            }
        } while (!Check);
        return Result;
    }

    public int GetEnteryInteger(int min)
    {
        int Result = 0;
        bool Check = false;
        do
        {
            string S = Console.ReadLine();
            try
            {
                Result = Convert.ToInt32(S);
                if (Result >= min)
                {
                    Check = true;
                }
            }
            catch
            {
                Console.WriteLine("Вы не ввели целое число из заданного диапозона, попытайтесь снова\n");
            }
        } while (!Check);
        return Result;
    }
    public int GetEnteryInteger(int min, int max)
    {
        int Result = 0;
        bool Check = false;
        do
        {
            string S = Console.ReadLine();
            try
            {
                Result = Convert.ToInt32(S);
                if (Result >= min && Result < max) Check = true;
            }
            catch { Console.WriteLine("Вы не ввели целое число из заданного диапозона, попытайтесь снова\n"); }
        } while (!Check);
        return Result;
    }
    public uint GetEnteryUint()
    {
        uint Result = 0;
        bool Check = false;
        do
        {
            string S = Console.ReadLine();
            try
            {
                Result = Convert.ToUInt32(S);
                Check = true;
            }
            catch
            {
                Console.WriteLine("Вы ввели не соответсвующий тип данных, попробуйте снова");
            }
        } while (!Check);
        return Result;
    }
    public uint GetEnteryUint(uint Max)
    {
        uint Result = 0;
        bool Check = false;
        do
        {
            string S = Console.ReadLine();
            try
            {
                Result = Convert.ToUInt32(S);
                if (Result < Max) Check = true;
                else Console.WriteLine("Вы ввели число не из нужного диапозона, попробуйте снова");
            }
            catch
            {
                Console.WriteLine("Вы ввели не соответсвующий тип данных, попробуйте снова");
            }
        } while (!Check);
        return Result;
    }
    public byte GetEnteryByte()
    {
        byte Result = 0;
        bool Check = false;
        do
        {
            string S = Console.ReadLine();
            try
            {
                Result = Convert.ToByte(S);
                Check = true;
            }
            catch
            {
                Console.WriteLine("Вы ввели не соответсвующий тип данных, попробуйте снова");
            }
        } while (!Check);
        return Result;
    }
    public byte GetEnteryByte(byte Max)
    {
        byte Result = 0;
        bool Check = false;
        do
        {
            string S = Console.ReadLine();
            try
            {
                Result = Convert.ToByte(S);
                if (Result < Max) Check = true;
                else Console.WriteLine("Вы ввели число не из нужного диапозона, попробуйте снова");
            }
            catch
            {
                Console.WriteLine("Вы ввели не соответсвующий тип данных, попробуйте снова");
            }
        } while (!Check);
        return Result;
    }
    public double GetEnetryDouble()
    {
        double Result = 0;
        bool Check = false;
        do
        {
            string S = Console.ReadLine();
            try
            {
                Result = Convert.ToDouble(S);
                Check = true;
            }
            catch
            {
                Console.WriteLine("Вы ввели не вещественное число, попытайтесь снова\n");
            }
        } while (!Check);
        return Result;
    }
}


