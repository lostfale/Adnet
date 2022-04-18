using System;

public class Class1
{
	public Class1()
	{
        using adnet;
        public static void GetAllCustomers()
        {
            PlayersContext context = new PlayersContext()

            // Извлечь всех заказчиков и отобразить их имена в консоли
            foreach (Player customer in context.Players)
                Console.WriteLine(customer.Name);
        }
    }
}
