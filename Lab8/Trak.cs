[Serializable]
public class Track
{
    private int id;
    private string title;
    private string artist;
    private double duration;
    private DateTime releaseDate;     
    private bool isFavorite;         

    public int Id
    {
        get
        { 
            return id;
        }
        set
        {
            try
            {
                id = value;
            }
            catch
            {
                Console.WriteLine("Введённое значение не является целым числом");
                Environment.Exit(1);
            }
        }
    }

    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            try
            {
                title = value;
            }
            catch
            {
                Console.WriteLine("Введённое значение является пустой строкой");
                Environment.Exit(1);
            }
        }
    }

    public string Artist
    {
        get
        {
            return artist;
        }
        set
        {
            try
            {
                title = value;
            }
            catch
            {
                Console.WriteLine("Введённое значение является пустой строкой");
                Environment.Exit(1);
            }
        }
    }

    public double Duration
    {
        get
        {
            return duration;
        }
        set
        {
            try
            {
                if (value < 0) throw new Exception("Длительность трека не может быть отрицательной");
                duration = value;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex}");
                Environment.Exit(1);
            }
        }
    }

    public bool IsFavorite
    {
        get
        {
            return isFavorite;
        }
        set
        {
            try 
            {
                isFavorite = value;
            }
            catch
            {
                Console.WriteLine("Получаемое значение не является логическим"); 
                Environment.Exit(1);
            }
        }
    }

    public DateTime ReleaseDate
    {
        get
        {
            return releaseDate;
        }
        set
        {
            try
            {
                releaseDate = value;
            }
            catch
            {
                Console.WriteLine("Получаемое значение не является датой");
                Environment.Exit(1);
            }
        }
    }

    public Track(int id, string title, string artist, double duration, DateTime releaseDate, bool isFavorite)
    {
        this.id = id;
        this.title = title;
        this.artist = artist;
        this.duration = duration;
        this.releaseDate = releaseDate;
        this.isFavorite = isFavorite;
    }

    public override string ToString()
    {
        return $"[{Id}] {Title} - {Artist} ({Duration} мин) " +
            $"| Релиз: {ReleaseDate.ToShortDateString()} |" +
            $"Избранное: {(IsFavorite ? "Да" : "Нет")}";
    }
}
