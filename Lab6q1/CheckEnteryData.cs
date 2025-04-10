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


