namespace TrackMoney;

public abstract class Transaction
{//Base class to Income and Expense
    public Transaction()
    {
    }
    public Transaction(int id,string title, double amount, DateTime date)
    {
        Id = id;
        Title = title;
        Amount = amount;
        TransactionDate = date;
    }
    public int Id { get; set; }
    public string Title { get; set; } 
    public double Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string TransactionToString(Transaction transaction) 
    {//Converts the Transaction to a string for saving on file
        return $"{Id},{transaction.GetType().ToString()},{Title},{Amount},{TransactionDate}";
    }
    public void Print(string type)
    {//Writes the Transaction to console
        int color = 15;
        if (type == "Income")
        {//Green
            color = 10;
        }
        else if (type =="Expense")
        {//DarkRed
            color = 4;
        }
        Messages.Title($"{Id.ToString().PadRight(5)}{Title.PadRight(15)}{Amount.ToString("c").PadLeft(15)}{TransactionDate.Year.ToString().PadLeft(8)}{TransactionDate.Month.ToString().PadLeft(8)}",color);
    }
    public abstract Transaction TransactionFromString(string transaction);//Creates an object, has to be implemented in the sub classes
}
