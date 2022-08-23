List<User> oldUsersList = new List<User>()
{
    new User(){Id=1,Name="Ali", Adress= "Istanbul"},
    new User(){Id=2,Name="Veli", Adress= "Istanbul"},
    new User(){Id=3,Name="Omer", Adress= "Ankara"},
    new User(){Id=4,Name="Yavuz", Adress= "Ankara"}
};

List<User> newUsersList = new List<User>()
{
    new User(){Id=1,Name="Ali", Adress= "Istanbul"},
    new User(){Id=2,Name="Veli", Adress= "Istanbul"},
    // new User(){Id=3,Name="Omer", Adress= "Ankara"},
    new User(){Id=4,Name="Yavuz", Adress= "Izmir"},
    new User(){Id=5,Name="Hamza", Adress= "Ankara"}
};

ListsDifference(oldUsersList, newUsersList);

void ListsDifference(List<User> oldList, List<User> newList)
{
    var newUsers = newList.Where(n => !oldList.Any(o => o.Id == n.Id)).ToList();
    var existUsers = newList.Where(n => oldList.Any(o => o.Id == n.Id)).ToList();
    var deleteUsers = oldList.Where(n => !newList.Any(o => o.Id == n.Id)).ToList();

    System.Console.WriteLine($"Created Users:");
    newUsers.ForEach((newUser) =>
    {
        System.Console.WriteLine($"{newUser.Id}, {newUser.Name}, {newUser.Adress}");

        /* 
        Database Add
        context.User.Add(newUser);
        */
    });

    System.Console.WriteLine($"\nUpdated Users:");
    existUsers.ForEach((newUser) =>
     {
         System.Console.WriteLine($"{newUser.Id}, {newUser.Name}, {newUser.Adress}");

         /* 
         Database Update
         var oldUser = oldList.FirstOrDefault(o => o.Id == newUser.Id);
         oldUser.Name = newUser.Name;
         oldUser.Adress = newUser.Adress;

        context.User.Update(existUser);
        */
     });

    System.Console.WriteLine($"\nDeleted Users:");
    deleteUsers.ForEach((deleteUser) =>
    {
        System.Console.WriteLine($"{deleteUser.Id}, {deleteUser.Name}, {deleteUser.Adress}");

        /*
        Database Delete
        context.User.Remove(deleteUser);
        */
    });

    /*
    Database Save Changes
    await context.SaveChangesAsync(); 
    */
}