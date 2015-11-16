namespace TaskThreeWordsServiceLibrary
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IWordService
    {
        [OperationContract]
        int GetTimesOfMuch(string firstWord, string secondWord);
    }
}
