namespace LinkedList.Sample
{
    using System;
    using System.Collections.Generic;
    using log4net;
    using log4net.Config;

    public class Sample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Sample));

        public static void Main(string[] args)
        {
            try
            {
                XmlConfigurator.Configure();

                Log.Info("Init list");
                IList<int> list = new LinkedList.LinkedList<int>();

                Log.Info("Add 50 item to list");
                for (int i = 0; i < 50; i++)
                {
                    Log.Info("Add value " + i);
                    list.Add(i);
                }

                var value = list[1];
                Log.Info("value of item with index 1 is " + value);
                Console.WriteLine(value);
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
            }
        }
    }
}
