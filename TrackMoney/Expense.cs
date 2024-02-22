namespace TrackMoney;
public class Expense : Transaction
{//Sub class to Transaction, describes a transaction where the amount<0
    public Expense()
    {
    }
    public Expense(int id,string title, double amount, DateTime date) : base(id,title, amount, date)
    {
    }
    public override Transaction TransactionFromString(string transaction)
    {//Creates an Expense object from a string
        Expense expense = new Expense();
        try
        {
            string[] transactionParts = transaction.Split(',');
            expense = new Expense(Convert.ToInt32(transactionParts[0]), transactionParts[2], Convert.ToDouble(transactionParts[3]), Convert.ToDateTime(transactionParts[4]));

        }
        catch (FormatException)
        {
            Messages.ErrorMessage("The string had a value which couldn't be converted to the expected format");
        }
        catch (Exception)
        {
            Messages.ErrorMessage("Something is wrong with the string");
        }
        return expense;
    }
}
