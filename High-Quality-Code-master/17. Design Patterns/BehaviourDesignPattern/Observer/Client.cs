using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    public class Client
    {
        private readonly List<ILogger> loggers = new List<ILogger>();

        public void Connect()
        {
            OnLog("Attepting to connect");

            Thread.Sleep(1000);

            OnLog("Connected");

            Thread.Sleep(1000);

            OnLog("Start tranfer");
        }

        public void Subscribe(ILogger logger)
        {
            loggers.Add(logger);
        }

        public void UnSubscribe(ILogger logger)
        {
            loggers.Remove(logger);
        }

        private void OnLog(string text)
        {
            foreach (var logger in loggers)
            {
                logger.Log(text);
            }
        }
    }
}
