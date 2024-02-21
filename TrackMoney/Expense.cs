
namespace TrackMoney
{
    public class Expense : Transaction
    {
        public Expense(string title, double amount, DateTime date) : base(title, amount, date)
        {
        }

        public override Transaction TransactionFromString(string transaction)
        {
            string[] transactionParts = transaction.Split(',');
            Expense expense = new Expense(transactionParts[0], Convert.ToDouble(transactionParts[1]), Convert.ToDateTime(transactionParts[2]));
            return expense;
        }
    }
}
