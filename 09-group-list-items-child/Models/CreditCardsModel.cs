public class PosDeviceModel
{
    public string DeviceId { get; set; }
    public List<PaymentAccount> PaymentAccounts { get; set; }
    public class PaymentAccount
    {
        public PaymentTypes Type { get; set; }
        public double TotalValue { get; set; }
    }
    public enum PaymentTypes
    {
        Cash = 0,
        CreditCard = 1,
        Currency = 2,
    }
}