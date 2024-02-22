namespace TrackMoney;

public abstract class Transaction
{
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
    {
        return $"{Id},{transaction.GetType().ToString()},{Title},{Amount},{TransactionDate}";
    }
    public void Print()
    {
        WriteLine($"{Id.ToString().PadRight(5)}{Title.PadRight(15)}{Amount.ToString("c").PadLeft(15)}{TransactionDate.Year.ToString().PadLeft(8)}{TransactionDate.Month.ToString().PadLeft(8)}");
    }
    public abstract Transaction TransactionFromString(string transaction);
}
