namespace TaskTwoDayOfWeekClient
{
    using System;
    using DayOfWeekServiceReference;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            DayOfWeekServiceClient client = new DayOfWeekServiceClient();

            Console.WriteLine(client.GetDayName(DateTime.Now.AddDays(1)));

            client.Close();
        }
    }
}
