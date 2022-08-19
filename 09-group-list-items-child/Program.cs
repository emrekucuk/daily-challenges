List<GroupedPosDeviceModel> GroupListItemsChild(List<PosDeviceModel> creditCardList)
{
    var groupList = new List<GroupedPosDeviceModel>();

    creditCardList.ForEach((creditCard) =>
    {
        var temp = new GroupedPosDeviceModel();
        var matched = groupList.FirstOrDefault(g => g.DeviceId == creditCard.DeviceId);
        if (matched == null)
        {
            temp.DeviceId = creditCard.DeviceId;
            creditCard.PaymentAccounts.ForEach((paymentAccount) =>
            {
                if (paymentAccount.Type == PosDeviceModel.PaymentTypes.Cash)
                    temp.CashTotalValue += paymentAccount.TotalValue;
                if (paymentAccount.Type == PosDeviceModel.PaymentTypes.CreditCard)
                    temp.CreditCardTotalValue += paymentAccount.TotalValue;
                if (paymentAccount.Type == PosDeviceModel.PaymentTypes.Currency)
                    temp.CurrencyTotalValue += paymentAccount.TotalValue;
            });
            matched = temp;
            groupList.Add(matched);

        }
        else
        {
            creditCard.PaymentAccounts.ForEach((paymentAccount) =>
            {
                if (paymentAccount.Type == PosDeviceModel.PaymentTypes.Cash)
                    temp.CashTotalValue += paymentAccount.TotalValue;
                if (paymentAccount.Type == PosDeviceModel.PaymentTypes.CreditCard)
                    temp.CreditCardTotalValue += paymentAccount.TotalValue;
                if (paymentAccount.Type == PosDeviceModel.PaymentTypes.Currency)
                    temp.CurrencyTotalValue += paymentAccount.TotalValue;
            });
        }
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
    System.Console.WriteLine($"Device Id: {groupList.DeviceId}");
    System.Console.WriteLine($"Cash Total Value: {groupList.CashTotalValue}");
    System.Console.WriteLine($"Credit Card Total Value: {groupList.CreditCardTotalValue}");
    System.Console.WriteLine($"Currency Total Value: {groupList.CurrencyTotalValue}\n");
});
