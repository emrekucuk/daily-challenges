internal class ProgramV2
{
    private static void Main(string[] args)
    {
        List<GroupedPosDeviceModel> GroupListItemsChild(List<PosDeviceModel> creditCardList)
        {
            var groupList = new List<GroupedPosDeviceModel>();

            creditCardList.ForEach((creditCard) =>
            {
                var matchedPosDevice = groupList.FirstOrDefault(g => g.DeviceId == creditCard.DeviceId);
                if (matchedPosDevice == null)
                {
                    matchedPosDevice = new GroupedPosDeviceModel() { DeviceId = creditCard.DeviceId };
                    groupList.Add(matchedPosDevice);
                }

                creditCard.PaymentAccounts.ForEach((paymentAccount) =>
                   {
                       if (paymentAccount.Type == PosDeviceModel.PaymentTypes.Cash)
                           matchedPosDevice.CashTotalValue += paymentAccount.TotalValue;
                       if (paymentAccount.Type == PosDeviceModel.PaymentTypes.CreditCard)
                           matchedPosDevice.CreditCardTotalValue += paymentAccount.TotalValue;
                       if (paymentAccount.Type == PosDeviceModel.PaymentTypes.Currency)
                           matchedPosDevice.CurrencyTotalValue += paymentAccount.TotalValue;
                   });
            });

            return groupList;
        }


        List<PosDeviceModel> creditCardsModel = new List<PosDeviceModel>()
        {
            new PosDeviceModel()
            {
                DeviceId = "A1",
                PaymentAccounts = new List<PosDeviceModel.PaymentAccount>()
                {
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Cash, TotalValue = 15.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.CreditCard, TotalValue = 200.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Currency, TotalValue = 15.00 }
                }
            },
            new PosDeviceModel()
            {
                DeviceId = "A1",
                PaymentAccounts = new List<PosDeviceModel.PaymentAccount>()
                {
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Cash, TotalValue = 10.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.CreditCard, TotalValue = 50.00 }
                }
            },
            new PosDeviceModel()
            {
                DeviceId = "A2",
                PaymentAccounts = new List<PosDeviceModel.PaymentAccount>()
                {
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Cash, TotalValue = 100.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.CreditCard, TotalValue = 200.00 }
                }
            },
            new PosDeviceModel()
            {
                DeviceId = "A2",
                PaymentAccounts = new List<PosDeviceModel.PaymentAccount>()
                {
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.CreditCard, TotalValue = 20.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Currency, TotalValue = 50.00 }
                }
            },
            new PosDeviceModel()
            {
                DeviceId = "A3",
                PaymentAccounts = new List<PosDeviceModel.PaymentAccount>()
                {
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Cash, TotalValue = 10.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.CreditCard, TotalValue = 200.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Currency, TotalValue = 15.00 }
                }
            },
            new PosDeviceModel()
            {
                DeviceId = "A3",
                PaymentAccounts = new List<PosDeviceModel.PaymentAccount>()
                {
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Cash, TotalValue = 30.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.CreditCard, TotalValue = 20.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Currency, TotalValue = 150.00 }
                }
            },
            new PosDeviceModel()
            {
                DeviceId = "A3",
                PaymentAccounts = new List<PosDeviceModel.PaymentAccount>()
                {
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.Cash, TotalValue = 100.00 },
                    new PosDeviceModel.PaymentAccount(){ Type = PosDeviceModel.PaymentTypes.CreditCard, TotalValue = 200}
                }
            },
        };


        var groupedList = GroupListItemsChild(creditCardsModel);

        groupedList.ForEach((groupList) =>
        {
            Console.WriteLine($"Device Id: {groupList.DeviceId}");
            Console.WriteLine($"Cash Total Value: {groupList.CashTotalValue}");
            Console.WriteLine($"Credit Card Total Value: {groupList.CreditCardTotalValue}");
            Console.WriteLine($"Currency Total Value: {groupList.CurrencyTotalValue}\n");
        });
    }
}