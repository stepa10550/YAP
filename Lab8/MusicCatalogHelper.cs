using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

public static class MusicCatalogHelper
{
    private static string filePath = "catalog.dat";
    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public static List<Track> Load()
    {
        if (!File.Exists(filePath)) return new List<Track>();

        try
        {
            byte[] data = File.ReadAllBytes(filePath);
            string json = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<List<Track>>(json, options) ?? new List<Track>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
            return new List<Track>();
        }
    }

    public static void Save(List<Track> tracks)
    {
        try
        {
            string json = JsonSerializer.Serialize(tracks, options);
            byte[] data = Encoding.UTF8.GetBytes(json);
            File.WriteAllBytes(filePath, data);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при сохранении файла: " + ex.Message);
        }
    }

    public static void View(List<Track> tracks)
    {
        if (tracks.Count == 0)
        {
            Console.WriteLine("Каталог пуст.");
            return;
        }

        tracks.ForEach(t => Console.WriteLine(t));
    }

    public static void Add(List<Track> tracks)
    {
        try
        {
            Console.Write("ID: ");
            int id = CheckEnteryData.GetEnteryInteger(0, 10000000);

            Console.Write("Название: ");
            string title = CheckEnteryData.GetEnteryString();

            Console.Write("Исполнитель: ");
            string artist = CheckEnteryData.GetEnteryString();

            Console.Write("Длительность (мин): ");
            double duration = CheckEnteryData.GetEnetryDouble(0, 1000);

            Console.Write("Дата релиза (гггг-мм-дд): ");
            DateTime releaseDate = CheckEnteryData.GetEnetryTime();

            Console.Write("Избранное (y/n): ");
            bool isFavorite = CheckEnteryData.GetEnteryString().ToLower() == "y";

            tracks.Add(new Track(id, title, artist, duration, releaseDate, isFavorite));
            Console.WriteLine("Трек добавлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при добавлении: " + ex.Message);
        }
    }

    public static void Delete(List<Track> tracks)
    {
        Console.Write("Введите ID трека для удаления: ");
        var id = CheckEnteryData.GetEnteryInteger(0, 1000000);
        var track = tracks.FirstOrDefault(t => t.Id == id);
        if (track != null)
        {
            tracks.Remove(track);
            Console.WriteLine("Удалено.");
        }
        else Console.WriteLine("Трек не найден.");
    }

    public static List<Track> GetFavorites(List<Track> tracks)
    {
        return tracks.Where(t => t.IsFavorite).ToList();
    }

    public static List<Track> GetLongTracks(List<Track> tracks, double minDuration = 4.0)
    {
        return tracks.Where(t => t.Duration > minDuration).ToList();
    }

    public static int GetTrackCountByArtist(List<Track> tracks, string artist)
    {
        return tracks.Count(t => t.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase));
    }

    public static double GetAverageTrackDuration(List<Track> tracks)
    {
        return tracks.Any() ? tracks.Average(t => t.Duration) : 0;
    }

}
