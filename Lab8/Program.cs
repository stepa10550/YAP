using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Track> catalog = MusicCatalogHelper.Load();

        while (true)
        {
            var temp = Console.GetCursorPosition();
            Console.SetCursorPosition(0, 0);
            while (Console.GetCursorPosition().Top <= temp.Top)
                for (int i = 0; i < Console.BufferWidth; i++)
                    Console.Write(" ");
            Console.SetCursorPosition(0, 0);
            // очистка консоли для вывода нового текста

            Console.WriteLine("\n=== Каталог Музыки ===");
            Console.WriteLine("1. Показать каталог");
            Console.WriteLine("2. Добавить трек");
            Console.WriteLine("3. Удалить трек");
            Console.WriteLine("4. Запросы");
            Console.WriteLine("5. Сохранить и выйти");

            Console.Write("Выбор: ");
            string choice = CheckEnteryData.GetEnteryString();

            switch (choice)
            {
                case "1":
                    MusicCatalogHelper.View(catalog);
                    Console.WriteLine("Нажмите Enter, чтобы закрыть вывод каталога треков");
                    Console.ReadLine();
                    break;
                case "2":
                    MusicCatalogHelper.Add(catalog);
                    break;
                case "3":
                    MusicCatalogHelper.Delete(catalog);
                    break;
                case "4":
                    ShowQueries(catalog);
                    Console.WriteLine("Нажмите Enter, чтобы закрыть окно запросов");
                    Console.ReadLine();
                    break;
                case "5":
                    MusicCatalogHelper.Save(catalog);
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    static void ShowQueries(List<Track> catalog)
    {
        var temp = Console.GetCursorPosition();
        Console.SetCursorPosition(0, 0);
        while (Console.GetCursorPosition().Top <= temp.Top)
            for (int i = 0; i < Console.BufferWidth; i++)
                Console.Write(" ");
        Console.SetCursorPosition(0, 0);
        // очистка консоли для вывода нового текста

        Console.WriteLine("\n--- Запросы ---");
        Console.WriteLine("1. Показать избранные треки");
        Console.WriteLine("2. Показать треки > 4 мин");
        Console.WriteLine("3. Кол-во треков по исполнителю");
        Console.WriteLine("4. Средняя длительность треков");

        Console.Write("Выбор: ");
        string choice = CheckEnteryData.GetEnteryString();

        switch (choice)
        {
            case "1":
                var favorites = MusicCatalogHelper.GetFavorites(catalog);
                if (favorites.Count == 0)
                    Console.WriteLine("Избранных треков не найдено.");
                else
                    favorites.ForEach(Console.WriteLine);
                break;

            case "2":
                var longTracks = MusicCatalogHelper.GetLongTracks(catalog);
                if (longTracks.Count == 0)
                    Console.WriteLine("Нет треков длительностью более 4 минут.");
                else
                    longTracks.ForEach(Console.WriteLine);
                break;

            case "3":
                Console.Write("Введите имя исполнителя: ");
                string artist = CheckEnteryData.GetEnteryString();
                int count = MusicCatalogHelper.GetTrackCountByArtist(catalog, artist);
                Console.WriteLine($"У исполнителя {artist} найдено {count} трек(ов).");
                break;

            case "4":
                double avg = MusicCatalogHelper.GetAverageTrackDuration(catalog);
                Console.WriteLine($"Средняя длительность треков: {avg:F2} минут.");
                break;

            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }
}
