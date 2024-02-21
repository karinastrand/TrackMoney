namespace TrackMoney;

public abstract class Transaction
{
    public Transaction()
    {
    }

    public Transaction(string title, double amount, DateTime date)
    {
        Title = title;
        Amount = amount;
        TransactionDate = date;
    }

    public string Title { get; set; } 
    public double Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string TransactionToString(Transaction transaction) 
    {
        return $"{transaction.GetType().ToString()},{Title},{Amount},{TransactionDate}";
    }
    public void Print()
    {
        WriteLine($"{Title} {Amount} {TransactionDate }");
    }
    public abstract Transaction TransactionFromString(string transaction);
}
