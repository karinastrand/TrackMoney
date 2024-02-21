
namespace TrackMoney
{
    public class Income : Transaction
    {
        public Income(string title, double amount, DateTime date) : base(title, amount, date)
        {
        }

        public override Transaction TransactionFromString(string transaction)
        {
            string[] transactionParts = transaction.Split(',');
            Income income = new Income(transactionParts[0], Convert.ToDouble(transactionParts[1]), Convert.ToDateTime(transactionParts[2]));
            return income;
        }
    }
}
