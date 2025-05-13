using System.Transactions;

class BankAccount {

    public string Name { get; set; }
    public decimal Balance { get; set; }

    public BankAccount (string name, decimal balance) {
        this.Name = name;
        this.Balance = balance;
    }

    public void Deposit(decimal amount) {
    
        Balance += amount;
        Console.WriteLine($"Deposited {amount} to {Name}. New balance: {Balance}");
    }

    public bool Withdraw(decimal amount) {

        if (amount > Balance) {
            Console.WriteLine($"❌ Withdrawal failed for {Name}. Insufficient funds.");
            return false;
        }

        Balance -= amount;
        Console.WriteLine($"Withdrew {amount} from {Name}. New balance: {Balance}");
        return true;
    }

}

interface ITransactionCommand {

    void Execute();
    void Undo();
}

class DepositCommand : ITransactionCommand {

    public BankAccount bankAccount { get; set; }

    public decimal DepositAmount { get; set; }

    public DepositCommand (BankAccount bankAccount, decimal depositAmount) {
        this.bankAccount = bankAccount;
        this.DepositAmount = depositAmount;
    }

    public void Execute() {
        bankAccount.Deposit(DepositAmount);
    }

    public void Undo() {
        bankAccount.Withdraw(DepositAmount);
    }
}

class WithdrawCommand : ITransactionCommand {

    public BankAccount bankAccount { get; set; }

    public decimal DepositAmount { get; set; }

    public bool Executed { get; set; } = false;


    public WithdrawCommand (BankAccount bankAccount, decimal depositAmount) {
        this.bankAccount = bankAccount;
        this.DepositAmount = depositAmount;
    }

    public void Execute() {
        Executed = bankAccount.Withdraw(DepositAmount);
    }

    public void Undo() {
        bankAccount.Deposit(DepositAmount);
    }

}

class TransactionInvoker {

    private Stack<ITransactionCommand> _history = new Stack<ITransactionCommand> ();
    
    public void ExecuteCommand(ITransactionCommand cmd) {
    
        cmd.Execute();
        _history.Push(cmd);
    
    }
    

    public void UndoLast() {

        if (_history.Count > 0) {
            
            ITransactionCommand transactionCommand = _history.Pop();
            if (transactionCommand is WithdrawCommand s && s.Executed) {
                transactionCommand.Undo();
            }

            else {
                Console.WriteLine("Undo: Withdrawal of 0 skipped.");
            } 
               
        }


    }
}