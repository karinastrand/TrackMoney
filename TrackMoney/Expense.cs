
namespace TrackMoney
{
    public class Expense : Transaction
    {
        public Expense(int id,string title, double amount, DateTime date) : base(id,title, amount, date)
        {
        }

        public override Transaction TransactionFromString(string transaction)
        {
            string[] transactionParts = transaction.Split(',');
            Expense expense = new Expense(Convert.ToInt32(transactionParts[0]),transactionParts[2], Convert.ToDouble(transactionParts[3]), Convert.ToDateTime(transactionParts[4]));
            return expense;
        }
    }
}
