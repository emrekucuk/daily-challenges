public class PosDeviceModel
{
    public string DeviceId { get; set; }
    public List<PaymentAccount> PaymentAccounts { get; set; }
    public class PaymentAccount
    {
        public string Type { get; set; }
        public double TotalValue { get; set; }
    }
}