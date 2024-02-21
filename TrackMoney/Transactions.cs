using System.Data.Common;
using System.Linq.Expressions;
using System.Transactions;

namespace TrackMoney;

public class Transactions
{
    public Transactions()
    {
    }
    public Transactions(string nameOfFile)
    {
        NameOfFile = nameOfFile;
    }
    public string NameOfFile { get; set; } = "transactions.txt";
    public List<Transaction> TransactionList { get; set; } = new List<Transaction>();

    public void ShowAllTransactions()
    {
        foreach (Transaction transaction in TransactionList) 
        {
            transaction.Print();
        }
    }
    public void ShowIncomes()
    {
        foreach (Transaction transaction in TransactionList)
        {
            if(transaction.GetType().ToString().Contains("Income"))
            transaction.Print();
        }
    }
    public void ShowExpenses()
    {
        foreach (Transaction transaction in TransactionList)
        {
            if (transaction.GetType().ToString().Contains("Expense"))

                transaction.Print();
        }
    }
    public void AddTransactions()
    {
        while(true)
        {
            WriteLine("Add transactions write q when you want to quit: ");
            Write("Title: ");
            string title = ReadLine();
            if (title.ToLower().Trim() == "q")
            {
                break;
            }
            Write("Add amount, if it is an expense write - before the amount: ");
            double amount;
            string stringAmount= ReadLine();
            try
            {
                amount = Convert.ToDouble(stringAmount);
            }
            catch (FormatException)
            {
                Console.WriteLine("The amount has to be an number");
                continue;
            }
            DateTime date;
            Console.Write("Date (yyyy-mm-dd): ");
            string stringDate= ReadLine();
            try
            {
                date= Convert.ToDateTime(stringDate);   
            }
            catch (FormatException)
            {
                WriteLine("The date has to be on the format 'yyyy-mm-dd' for example 2024-02-10");
                continue;
            }
            if(amount> 0) 
            {
                Income income = new Income(title,amount,date);
                TransactionList.Add(income);

            }
            else if (amount < 0)
            {
                Expense expense = new Expense(title, amount, date);
                TransactionList.Add(expense);
            }
            else 
            {
               WriteLine("Something wrong with the amount");
            }
        }
        

    }
    
    public void EditTransactions()
    {

    }
    public void ChangeTitle()
    {

    }
    public void ChangeType()
    {

    }
    public void ChangeAmount()
    {

    }
    public void ChangeDate()
    {

    }
    public void RemoveTransactions()
    {

    }
    public void TransactionsToStringList()
    {


    }
    public void GetFromStrings(List<string> transactionStrings)
    {
        foreach (string transactionString in transactionStrings)
        {
            string[] transactionParts= transactionString.Split(',');
            if (transactionParts[0].Contains("Income"))
            {
                Income income=new Income(transactionParts[1], Convert.ToDouble(transactionParts[2]), Convert.ToDateTime(transactionParts[3]));
                TransactionList.Add(income);
            }
            else
            {
                Expense expense = new Expense(transactionParts[1], Convert.ToDouble(transactionParts[2]), Convert.ToDateTime(transactionParts[3]));
                TransactionList.Add(expense);
            }
            

        }
    }
    public void TransactionsToFile()
    {
        List<string> transactionStrings = new List<string>();
        foreach (Transaction transaction in TransactionList)
        {
            transactionStrings.Add(transaction.TransactionToString(transaction));
        }
        SaveToFile(transactionStrings);
    }
    public void TransactionsInfo()
    {

    }
    public void SaveToFile(List<string> stringTransactions)
    {
        FileHandling fileHandling = new FileHandling(NameOfFile);
        fileHandling.SaveToFile(stringTransactions);
    }
    public void GetFromFile()
    {
        FileHandling fileHandling=new FileHandling(NameOfFile);
        List<string> stringTransactions=fileHandling.ReadFromFile();
        GetFromStrings(stringTransactions);
        
    }
}
