namespace TrackMoney;
public static class Functions
{//Helpers
    public static string GetType(Transaction transaction)
    {//Checks which sub class the Transaction belongs to
        string type = "";
        if (transaction.GetType().ToString().Contains("Income"))
        {
            type = "Income";
        }
        else if (transaction.GetType().ToString().Contains("Expense"))
        {
            type = "Expense";
        }
        return type;
    }
    public static bool TransactionExists(int id, List<Transaction> transactionList)
    {//Checks if the id is the Id of a Transaction in transactionList
        return transactionList.Exists(transaction => transaction.Id == id);
    }
    public static Transaction GetTransaction(int id, List<Transaction> transactionList)
    {//Fetches the Transaction with id from transactionList
        return transactionList.Where(transaction => transaction.Id == id).FirstOrDefault();
    }
    public static double SumTransactions(List<Transaction> transactionList)
    {//The sum of the differents Transaction amounts in the transactionList
        return transactionList.Sum(transaction => transaction.Amount);
    }
    public static void ShowSortedTransactions(List<Transaction> sortedList)
    {//Writes a list of Transactions to the console
        Messages.Title("Id".PadRight(5) + "Titel".PadRight(15) + "Amount".PadRight(15) + "Year".PadLeft(8) + "Month".PadLeft(8), 9);
        foreach (Transaction transaction in sortedList)
        {//Prints info about a transaction, the color on the console depends on if it is Income(green) or Expense(red)
            transaction.Print(GetType(transaction));
        }
    }
    public static void TransactionsInfo(List<Transaction> transactionList)
    {//The info on the welcome screen
        Messages.Info($"You have currently {SumTransactions(transactionList).ToString("c")} on your account");
    }
}
