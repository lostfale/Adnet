using System.Data.SqlClient;
using System;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using adnet;

static void adonet1()
{
    Console.WriteLine("AdoNetDEmo");
    var connection = new SqlConnection(@"Server = WIN-ODHAFDQSSPK; Database = Players; Trusted_Connection = True;");
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = "select Name,Name_Team from Players e join Team  on e.TeamID=Team.Id";
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Name={reader.GetString(0)} Name_Team={reader.GetString(1)}");

    }
    reader.Close();
    connection.Close();

}
static void adonet2()
{
    Console.WriteLine("список игроков, отсортированных по названию своей команды, далее по цене контракта.");
    var connection = new SqlConnection(@"Server = WIN-ODHAFDQSSPK; Database = Players; Trusted_Connection = True;");
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = "Select p.Id,p.Name,p.Price , t.Name_Team from Players p  inner join Team t on   p.TeamID=t.Id order by Name_Team,Price";
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Id={reader.GetInt32(reader.GetOrdinal("Id"))} - Name={reader.GetString(reader.GetOrdinal("Name"))} - Price={reader.GetDecimal(reader.GetOrdinal("Price"))} - Name_Team={reader.GetString(reader.GetOrdinal("Name_Team"))}");

    }
    reader.Close();
    connection.Close();

}
adonet2();

static void adonet3()
{
    Console.WriteLine("список игроков, отсортированных по успешности своего контракта ");
    var connection = new SqlConnection(@"Server = WIN-ODHAFDQSSPK; Database = Players; Trusted_Connection = True;");
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = "Select p.Id,p.Name,p.Price,p.Age   from Players p inner join Team t on TeamID=t.Id order by Price/(Age-18)";
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Id={reader.GetInt32(reader.GetOrdinal("Id"))} - Name={reader.GetString(reader.GetOrdinal("Name"))} - Price={reader.GetDecimal(reader.GetOrdinal("Price"))} - Age={reader.GetInt32(reader.GetOrdinal("Age"))} ");

    }
    reader.Close();
    connection.Close();

}
adonet3();
static void adonet4()
{
    Console.WriteLine("список игроков с контрактом ниже среднего по базе  ");
    var connection = new SqlConnection(@"Server = WIN-ODHAFDQSSPK; Database = Players; Trusted_Connection = True;");
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = "Select *from Players p Where Price<(Select AVG(Price) as d from Players)";
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Id={reader.GetInt32(reader.GetOrdinal("Id"))} - Name={reader.GetString(reader.GetOrdinal("Name"))} - Price={reader.GetDecimal(reader.GetOrdinal("Price"))}  ");

    }
    reader.Close();
    connection.Close();

}
adonet4();

static void adonet5()
{
    Console.WriteLine("удалить игрока с минимальной стоимостью контракта  ");
    var connection = new SqlConnection(@"Server = WIN-ODHAFDQSSPK; Database = Players; Trusted_Connection = True;");
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = "Delete from Players  Where  Price in (Select MIn(Price)  from Players)";
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Id={reader.GetInt32(reader.GetOrdinal("Id"))} - Name={reader.GetString(reader.GetOrdinal("Name"))} - Price={reader.GetDecimal(reader.GetOrdinal("Price"))}  ");

    }
    reader.Close();
    connection.Close();

}
static void adonet6()
{
    Console.WriteLine("уценить контракт с максимальным знaчением ");
    var connection = new SqlConnection(@"Server = WIN-ODHAFDQSSPK; Database = Players; Trusted_Connection = True;");
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = "Update  Players set Players.Price=Price-(Price*0.1) from Players p where p.Price in (Select Max(Price)from Players)";
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Id={reader.GetInt32(reader.GetOrdinal("Id"))} - Name={reader.GetString(reader.GetOrdinal("Name"))} - Price={reader.GetDecimal(reader.GetOrdinal("Price"))}  ");

    }
    reader.Close();
    connection.Close();

}
adonet6();
adonet2();
static void adonet7()
{
    Console.WriteLine("Вывести пары: {команда, средний возраст игрока}, использовать группировку (GroupBy, Average)");
    var connection = new SqlConnection(@"Server = WIN-ODHAFDQSSPK; Database = Players; Trusted_Connection = True;");
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = "Select Name_Team,Avg(Age) as AverageAge from  Players p  inner join Team t on   p.TeamID=t.Id group by Name_Team;";
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"NameTeam={reader.GetString(reader.GetOrdinal("Name_Team"))} - Age={reader.GetInt32(reader.GetOrdinal("AverageAge"))}  ");

    }
    reader.Close();
    connection.Close();

}
adonet7();




int i = 1;
while (i > 0)
    {

        Console.WriteLine("\t1 - вывести всех");
        Console.WriteLine("\t2 - Добавить 9 игроков  в базу");
        Console.WriteLine("\t3 - Успешность контракта по формуле ");
        Console.WriteLine("\t4 - Контракт ниже срежнего по базе ");
        Console.WriteLine("\t5 - Извлечь игрока с максимальной стоимостью контракта, уценить контракт на 10%.");
        Console.WriteLine("\t6 - Удаление игрока с минимальной стоимостью контракта");
    Console.WriteLine("\t7 -Сортировка по контракту и команде ");
    Console.WriteLine("\t8 -Groupby ");

    switch (Console.ReadLine())
        {
            case "1":
                PrintFull();
                break;
            case "2":
                Add();
                break;
            case "3":
                SortSuccess();
                break;
            case "4":
                AvarageMin();
                break;
            case "5":
                MaxPrice();
                break;
            case "6":
                MinPricePerson();
                break;
        case "7":
            SortOrder();
            break;
        case "8":
            adonet7();
                break;





    }
    }

    static void PrintFull() 
{
    adnet.PlayersContext db = new PlayersContext();

    //// Извлечь всех заказчиков и отобразить их имена в консоли
    //foreach (Player customer in db.Players)
    //    Console.WriteLine(customer.Name);
    var players = db.Players.ToList();
    foreach (Player u in players)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}-{u.Price}-{u.TeamId}");
    }
}


void SortOrder() 
{
    adnet.PlayersContext db = new PlayersContext();
    var players = db.Players.OrderBy(x => x.Price).OrderBy(x => x.TeamId)
        .Join(db.Teams, x => x.TeamId, t => t.Id,
        (x, t) => new
        {
            Id = x.Id,
            Name = x.Name,
            Price=x.Price,
            Age = x.Age,
            Team = t.NameTeam
        });
    foreach (var x in players)
    {
        Console.WriteLine("{0}.{1} - {2}-{3}-{4}", x.Id, x.Name, x.Price,x.Age,x.Team);
    }

}



void Add()
    {
    adnet.PlayersContext db = new PlayersContext();
        Player pl1 = new Player { Name = "Frolov", Age = 33, Price = 33000, TeamId = 2 };
        Player pl2 = new Player { Name = "Maselov", Age = 21, Price = 38000, TeamId = 2 };
        Player pl3 = new Player { Name = "Aselov", Age = 28, Price = 29000, TeamId = 1 };
        Player pl4 = new Player { Name = "Levos", Age = 20, Price = 69000, TeamId = 1 };
        Player pl5 = new Player { Name = "Refo", Age = 28, Price = 29000, TeamId = 3 };
        Player pl6 = new Player { Name = "Merst", Age = 19, Price = 19000, TeamId = 3 };
        Player pl7=new Player { Name = "Kedre", Age = 29, Price = 190000, TeamId = 3 };
        Player pl8 = new Player { Name = "Lebae", Age = 31, Price = 160000, TeamId = 2 };
        Player pl9= new Player { Name = "Tof", Age = 22, Price = 120000, TeamId = 1 };


        //if (Check(pl1))
            db.Players.Add(pl1);
        db.Players.Add(pl2);
        db.Players.Add(pl3);
        db.Players.Add(pl4);
        db.Players.Add(pl5);
        db.Players.Add(pl6);
        db.Players.Add(pl7);
    db.Players.Add(pl8);
    db.Players.Add(pl9);
    db.SaveChanges();
   
    }


//Add();

//PrintFull();

void SortSuccess()//успешность 
{
    adnet.PlayersContext db = new PlayersContext();
    
    var player= from p in db.Players
                 orderby p.Price/(p.Age-18)                 
                 select p;
    foreach (Player p in player)
        Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);


}
void AvarageMin()//контракт ниже среднего
{
    adnet.PlayersContext db = new PlayersContext();
    
    decimal Avarage= db.Players.Average(p => p.Price);
    foreach (Player p in db.Players.Where(p => p.Price < Avarage))
    {
        Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);
    }
    

}
//AvarageMin();
           



void MaxPrice () //уценка контракта на 10%
{
    adnet.PlayersContext db = new PlayersContext();
   decimal max= db.Players.Max(p => p.Price);
       
    foreach (Player p in db.Players) 
    {
        if (p.Price==max) 
        {
            p.Price= p.Price - p.Price * 10 / 100;
            

        }

    }
    db.SaveChanges();
    PrintFull();

}
//MaxPrice();
void MinPricePerson ()//удаление с мин стоимостью
{
    adnet.PlayersContext db = new PlayersContext();
    decimal min = db.Players.Min(p => p.Price);

    foreach (Player p in db.Players)
    {
        if (p.Price == min)
        {

            db.Players.Remove(p);

        }

    }
    db.SaveChanges();
    PrintFull();

}
//void group()
//{
//    adnet.PlayersContext db = new PlayersContext();

    

//}



//MinPricePerson();


