using System;
using System.Collections.Generic;

public interface ICache<T>
{
    void Add(T item);
    IEnumerable<T> GetAll();
    void Clear();
}

public class MemoryCache<T> : ICache<T>
{
    private List<T> cache = new List<T>();

    public void Add(T item)
    {
        cache.Add(item);
    }

    public IEnumerable<T> GetAll()
    {
        return cache;
    }

    public void Clear()
    {
        cache.Clear();
    }
}

class Program
{
    static void Main()
    {
        ICache<string> stringCache = new MemoryCache<string>();

        stringCache.Add("Первый элемент");
        stringCache.Add("Второй элемент");
        stringCache.Add("Третий элемент");

        Console.WriteLine("Элементы в кэше:");
        foreach (var item in stringCache.GetAll())
        {
            Console.WriteLine(item);
        }

        stringCache.Clear();
        Console.WriteLine("Кэш очищен.");

        Console.WriteLine($"Количество элементов в кэше после очистки: {stringCache.GetAll().Count()}");
    }
}