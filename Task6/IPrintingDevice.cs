namespace ITTask6
{
    interface IPrintingDevice
    {
        string Name { get; set; }
        
        bool Connect { get; set; }
        
        void Print();
        
        void ConnectDevice();
    }
}