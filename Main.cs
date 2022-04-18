using System;

public class Class1
{
	
}
static void Main(string[] args)
{
    using (PlayersContext db = new PlayersContext())
    {

        // получаем объекты из бд и выводим на консоль
        var players = db.Players.ToList();
        Console.WriteLine("Список объектов:");
        foreach (Players u in players)
        {
            Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
        }
    }
}
Ef();


}