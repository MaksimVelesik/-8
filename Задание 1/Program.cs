using System;
using System.Collections.Generic;

public class Page
{
    public string Url { get; set; }
    public string Title { get; set; }

    public Page(string url, string title)
    {
        Url = url;
        Title = title;
    }

    public override string ToString()
    {
        return $"{Title} ({Url})";
    }
}

public class BrowserHistory
{
    private Stack<Page> history = new Stack<Page>();
    private Stack<Page> forwardStack = new Stack<Page>();

    public void VisitPage(string url, string title)
    {
        var page = new Page(url, title);
        history.Push(page);
        forwardStack.Clear();
    }

    public Page GoBack()
    {
        if (history.Count > 1)
        {
            var currentPage = history.Pop();
            forwardStack.Push(currentPage);
            return history.Peek();
        }
        return null;
    }

    public Page GoForward()
    {
        if (forwardStack.Count > 0)
        {
            var page = forwardStack.Pop();
            history.Push(page);
            return page;
        }
        return null;
    }

    public void ShowHistory()
    {
        Console.WriteLine("История посещенных страниц:");
        foreach (var page in history)
        {
            Console.WriteLine(page);
        }
    }
}

class Program
{
    static void Main()
    {
        BrowserHistory browserHistory = new BrowserHistory();

        browserHistory.VisitPage("https://example.com", "Example");
        browserHistory.VisitPage("https://openai.com", "OpenAI");
        browserHistory.VisitPage("https://github.com", "GitHub");

        browserHistory.ShowHistory();

        Console.WriteLine("\nНазад:");
        var previousPage = browserHistory.GoBack();
        Console.WriteLine(previousPage != null ? previousPage.ToString() : "Нет страниц для возврата.");

        Console.WriteLine("\nВперед:");
        var nextPage = browserHistory.GoForward();
        Console.WriteLine(nextPage != null ? nextPage.ToString() : "Нет страниц для перехода вперед.");

        Console.WriteLine("\nОбновленная история:");
        browserHistory.ShowHistory();
    }
}