List<CreditCardsModel> GroupListItemsChild(List<CreditCardsModel> creditCardList)
{
    var groupList = new List<CreditCardsModel>();

    creditCardList.ForEach((creditCard) =>
    {
        var matched = groupList.FirstOrDefault(g => g.DeviceId == creditCard.DeviceId);
        if (matched == null)
        {
            groupList.Add(creditCard);

            creditCard.PaymentAccounts.ForEach((paymentAccount) =>
            {
                var childList = new List<CreditCardsModel.PaymentAccount>();
                var matchedChild = childList.FirstOrDefault(c => c.Type == paymentAccount.Type);

                if (matchedChild == null)
                    childList.Add(paymentAccount);
                else
                    matchedChild.TotalValue += paymentAccount.TotalValue;
            });

        }
        else
        {
            creditCard.PaymentAccounts.ForEach((paymentAccount) =>
           {
               var matchedChild = matched.PaymentAccounts.FirstOrDefault(c => c.Type == paymentAccount.Type);
               if (matchedChild == null)
                   matched.PaymentAccounts.Add(paymentAccount);
               else
                   matchedChild.TotalValue += paymentAccount.TotalValue;
           });
        }
    });

    return groupList;
}


List<CreditCardsModel> creditCardsModel = new List<CreditCardsModel>()
{
    new CreditCardsModel()
    {
        DeviceId = "A1",
        PaymentAccounts = new List<CreditCardsModel.PaymentAccount>()
        {
            new CreditCardsModel.PaymentAccount(){Type="Cash",TotalValue=15.00},
            new CreditCardsModel.PaymentAccount(){Type="Credit Card",TotalValue=200.00},
            new CreditCardsModel.PaymentAccount(){Type="Currency",TotalValue=15.00}
        }
    },
    new CreditCardsModel()
    {
        DeviceId = "A1",
        PaymentAccounts = new List<CreditCardsModel.PaymentAccount>()
        {
            new CreditCardsModel.PaymentAccount(){Type="Cash",TotalValue=10.00},
            new CreditCardsModel.PaymentAccount(){Type="Credit Card",TotalValue=20.00}
        }
    },
    new CreditCardsModel()
    {
        DeviceId = "A2",
        PaymentAccounts = new List<CreditCardsModel.PaymentAccount>()
        {
            new CreditCardsModel.PaymentAccount(){Type="Cash",TotalValue=100.00},
            new CreditCardsModel.PaymentAccount(){Type="Credit Card",TotalValue=200.00}
        }
    },
    new CreditCardsModel()
    {
        DeviceId = "A2",
        PaymentAccounts = new List<CreditCardsModel.PaymentAccount>()
        {
            new CreditCardsModel.PaymentAccount(){Type="Credit Card",TotalValue=20.00},
            new CreditCardsModel.PaymentAccount(){Type="Currency",TotalValue=50.00}
        }
    },
     new CreditCardsModel()
    {
        DeviceId = "A3",
        PaymentAccounts = new List<CreditCardsModel.PaymentAccount>()
        {
            new CreditCardsModel.PaymentAccount(){Type="Cash",TotalValue=10.00},
            new CreditCardsModel.PaymentAccount(){Type="Credit Card",TotalValue=200.00},
            new CreditCardsModel.PaymentAccount(){Type="Currency",TotalValue=15.00}
        }
    },
    new CreditCardsModel()
    {
        DeviceId = "A3",
        PaymentAccounts = new List<CreditCardsModel.PaymentAccount>()
        {
            new CreditCardsModel.PaymentAccount(){Type="Cash",TotalValue=30.00},
            new CreditCardsModel.PaymentAccount(){Type="Credit Card",TotalValue=20.00},
            new CreditCardsModel.PaymentAccount(){Type="Currency",TotalValue=150.00}
        }
    },
    new CreditCardsModel()
    {
        DeviceId = "A3",
        PaymentAccounts = new List<CreditCardsModel.PaymentAccount>()
        {
            new CreditCardsModel.PaymentAccount(){Type="Cash",TotalValue=100.00},
            new CreditCardsModel.PaymentAccount(){Type="Credit Card",TotalValue=200}
        }
    },
};

var groupsList = GroupListItemsChild(creditCardsModel);

groupsList.ForEach((groupList) =>
{
    System.Console.WriteLine($"Device Id: {groupList.DeviceId}");
    groupList.PaymentAccounts.ForEach((paymentAccount) =>
    {
        System.Console.WriteLine($"Type: {paymentAccount.Type}, Total Value: {paymentAccount.TotalValue}");
    });
});
