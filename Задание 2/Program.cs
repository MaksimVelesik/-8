using System;
using System.Collections.Generic;

public class MyStack<T>
{
    private List<T> items = new List<T>();

    public int Count => items.Count;

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Стек пуст.");
        }

        T item = items[Count - 1];
        items.RemoveAt(Count - 1);
        return item;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Стек пуст.");
        }

        return items[Count - 1];
    }
}

public class StackHistory<T>
{
    private MyStack<T> actionStack = new MyStack<T>();

    public void AddAction(T action)
    {
        actionStack.Push(action);
    }

    public T Undo()
    {
        if (actionStack.Count == 0)
        {
            throw new InvalidOperationException("Нет действий для отмены.");
        }

        return actionStack.Pop();
    }

    public T CurrentAction()
    {
        if (actionStack.Count == 0)
        {
            throw new InvalidOperationException("Нет текущих действий.");
        }

        return actionStack.Peek();
    }

    public int ActionCount => actionStack.Count;
}

class Program
{
    static void Main()
    {
        StackHistory<string> history = new StackHistory<string>();

        history.AddAction("Открыть файл");
        history.AddAction("Изменить файл");
        history.AddAction("Сохранить файл");

        Console.WriteLine($"Текущее действие: {history.CurrentAction()}");
        Console.WriteLine($"Количество действий: {history.ActionCount}");

        Console.WriteLine("Отмена действия: " + history.Undo());
        Console.WriteLine($"Текущее действие: {history.CurrentAction()}");
        Console.WriteLine($"Количество действий: {history.ActionCount}");
    }
}