namespace TaskOneDayOfWeek
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayOfWeekService
    {

        [OperationContract]
        string GetDayName(DateTime time);
    }
}
