List<CreditCardsModel> GroupListItems(List<CreditCardsModel> creditCardsList)
{
    var groupList = new List<CreditCardsModel>();

    creditCardsList.ForEach((creditCard) =>
    {
        var matched = groupList.FirstOrDefault(t => t.DeviceId == creditCard.DeviceId);
        if (matched == null)
            groupList.Add(creditCard);
        else
            matched.TotalValue += creditCard.TotalValue;
    });
    return groupList;
}

List<CreditCardsModel> creditCardsModels = new List<CreditCardsModel>(){
    new CreditCardsModel() { DeviceId = "A1", TotalValue = 20.00 },
    new CreditCardsModel() { DeviceId = "A1", TotalValue = 5.00 },
    new CreditCardsModel() { DeviceId = "A3", TotalValue = 15.00 },
    new CreditCardsModel() { DeviceId = "A2", TotalValue = 10.00 },
    new CreditCardsModel() { DeviceId = "A2", TotalValue = 100.00 },
    new CreditCardsModel() { DeviceId = "A2", TotalValue = 50.00 }
};

var groupList = GroupListItems(creditCardsModels);

groupList.ForEach((group) =>
{
    System.Console.WriteLine($"Devide Id: {group.DeviceId}, Total Value: {group.TotalValue}");
});