class Program {
    public static void Main(String[] args) {
        
        // var billing = new BillingSupport();
        // var tech = new TechnicalSupport();
        // var general = new GeneralSupport();

        // billing.SetNext(tech).SetNext(general);

        // var ticket1 = new SupportTikcet("billing", "Refund for last month's invoice.");
        // var ticket2 = new SupportTikcet("technical", "App crashes when I login.");
        // var ticket3 = new SupportTikcet("shipping", "My package hasn't arrived.");
        // var ticket4 = new SupportTikcet("unknown", "I need help but don’t know who to ask.");

        // billing.Handle(ticket1);
        // billing.Handle(ticket2);
        // billing.Handle(ticket3);
        // billing.Handle(ticket4);

        // var account = new BankAccount("John", 1000);

        // var deposit = new DepositCommand(account, 200);
        // var withdraw = new WithdrawCommand(account, 150);
        // var invalidWithdraw = new WithdrawCommand(account, 5000);
        // var invalid = new WithdrawCommand(account,30000);

        // var invoker = new TransactionInvoker();
        // invoker.ExecuteCommand(deposit);
        // invoker.ExecuteCommand(withdraw);
        // invoker.ExecuteCommand(invalidWithdraw);
        // invoker.ExecuteCommand(invalid);

        // invoker.UndoLast(); // undo invalid withdraw
        // invoker.UndoLast(); // undo withdraw

        // Console.WriteLine("✅ Final balance: " + account.Balance);

        // var profile = new EmployeeProfile("Anna", 40000, "Junior Developer");

        // // Save initial version
        // var v1 = profile.CreateMemento();

        // profile.Promote("Mid Developer", 60000);
        // var v2 = profile.CreateMemento();

        // profile.Promote("Senior Developer", 80000);
        // Console.WriteLine("🟢 Current: " + profile);

        // // Reset to v2 (Mid Developer)
        // profile.Restore(v2);
        // Console.WriteLine("🟡 Restored to Mid: " + profile);

        // // Reset to v1 (Junior Developer)
        // profile.Restore(v1);
        // Console.WriteLine("🔵 Restored to Junior: " + profile);

        // var agency = new NewsAgency();

        // var alice = new Subscriber("Alice");
        // var bob = new Subscriber("Bob");
        // var chris = new Subscriber("Chris");

        // // Subscriptions
        // agency.Subscribe(NewsCategory.Tech, alice.ReceiveTech);
        // agency.Subscribe(NewsCategory.Politics, alice.ReceivePolitics);

        // agency.Subscribe(NewsCategory.Sports, bob.ReceiveSports);
        // agency.Subscribe(NewsCategory.Tech, bob.ReceiveTech);

        //  agency.Subscribe(NewsCategory.Politics, chris.ReceivePolitics);

        // // Publishing news
        // agency.Publish(NewsCategory.Tech, "🧠 AI Beats Human in Chess Again");
        // agency.Publish(NewsCategory.Politics, "🗳 New Election Date Announced");
        // agency.Publish(NewsCategory.Sports, "⚽ Local Team Wins Championship");

        // // Alice unsubscribes from Politics
        // agency.Unsubscribe(NewsCategory.Politics, alice.ReceivePolitics);

        // agency.Publish(NewsCategory.Politics, "🏛 Parliament Passes New Law");

        var user = new User("john", "123@45", "+374999999", "face-data");

        var authService = new AuthService(new PasswordAuthStrategy());
        bool isPasswordAuthSuccess = authService.Authenticate(user);

        authService.SetStrategy(new OtpAuthStrategy());
        bool isOtpAuthSuccess = authService.Authenticate(user);

        authService.SetStrategy(new FaceIdAuthStrategy());
        bool isFaceAuthSuccess = authService.Authenticate(user);


    }
}