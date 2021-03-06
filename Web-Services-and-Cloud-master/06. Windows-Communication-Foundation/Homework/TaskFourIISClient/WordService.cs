﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IWordService")]
public interface IWordService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordService/GetTimesOfMuch", ReplyAction="http://tempuri.org/IWordService/GetTimesOfMuchResponse")]
    int GetTimesOfMuch(string firstWord, string secondWord);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordService/GetTimesOfMuch", ReplyAction="http://tempuri.org/IWordService/GetTimesOfMuchResponse")]
    System.Threading.Tasks.Task<int> GetTimesOfMuchAsync(string firstWord, string secondWord);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IWordServiceChannel : IWordService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class WordServiceClient : System.ServiceModel.ClientBase<IWordService>, IWordService
{
    
    public WordServiceClient()
    {
    }
    
    public WordServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public WordServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public WordServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public WordServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int GetTimesOfMuch(string firstWord, string secondWord)
    {
        return base.Channel.GetTimesOfMuch(firstWord, secondWord);
    }
    
    public System.Threading.Tasks.Task<int> GetTimesOfMuchAsync(string firstWord, string secondWord)
    {
        return base.Channel.GetTimesOfMuchAsync(firstWord, secondWord);
    }
}
