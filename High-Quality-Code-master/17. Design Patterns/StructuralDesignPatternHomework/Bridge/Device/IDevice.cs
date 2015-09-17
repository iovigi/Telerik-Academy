namespace Device
{
    public interface  IDevice
    {
        IOperationSystem OperationSystem { get; set; }

        void Start();
    }
}
