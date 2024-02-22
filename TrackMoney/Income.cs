namespace TrackMoney
{
    public class Income : Transaction
    {//A subclass to Transaction, it descriobes an transaction with an amount>0
        public Income()
        {
        }
        public Income(int id,string title, double amount, DateTime date) : base(id, title, amount, date)
        {
        }
        public override Transaction TransactionFromString(string transaction)
        {//Creates an Income objedt from a string
            Income income = new Income();
            try
            {
                string[] transactionParts = transaction.Split(',');
                income = new Income(Convert.ToInt32(transactionParts[0]), transactionParts[2], Convert.ToDouble(transactionParts[3]), Convert.ToDateTime(transactionParts[4]));
                
            }
            catch (FormatException)
            {
                Messages.ErrorMessage("The string had a value which couldn't be converted to the expected format");
            }
            catch(Exception) 
            {
                Messages.ErrorMessage("Something is wrong with the string");               
            }
            return income;
        }
    }
}
