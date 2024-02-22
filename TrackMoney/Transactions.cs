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
    {//Sorted by year and then month
        List<Transaction> SortedTransactions = TransactionList.OrderBy(transaction=>transaction.TransactionDate.Year).ThenBy(transaction=>transaction.TransactionDate.Month).ToList();
        WriteLine("All transactions");
        WriteLine("Id".PadRight(5)+"Titel".PadRight(15)+"Amount".PadRight(15)+"Year".PadLeft(8)+"Month".PadLeft(8));
        foreach (Transaction transaction in SortedTransactions) 
        {
            transaction.Print();
        }
    }
    public void ShowAllTransactionsSortedByTitle()
    {
        List<Transaction> SortedTransactions = TransactionList.OrderBy(transaction => transaction.Title).ToList();

        WriteLine("All transactions");
        WriteLine("Id".PadRight(5) + "Titel".PadRight(15) + "Amount".PadRight(15) + "Year".PadLeft(8) + "Month".PadLeft(8));
        foreach (Transaction transaction in SortedTransactions)
        {
            transaction.Print();
        }
    }
    public void ShowAllTransactionsSortedByAmount()
    {
        List<Transaction> SortedTransactions = TransactionList.OrderBy(transaction => transaction.Amount).ToList();

        WriteLine("All transactions");
        WriteLine("Id".PadRight(5) + "Titel".PadRight(15) + "Amount".PadRight(15) + "Year".PadLeft(8) + "Month".PadLeft(8));
        foreach (Transaction transaction in SortedTransactions)
        {
            transaction.Print();
        }
    }
    public void ShowIncomes()
    {
        WriteLine("Incomes");
        WriteLine("Id".PadRight(5) + "Titel".PadRight(15) + "Amount".PadRight(15) + "Year".PadLeft(8) + "Month".PadLeft(8));
        foreach (Transaction transaction in TransactionList)
        {
            if(transaction.GetType().ToString().Contains("Income"))
            transaction.Print();
        }
    }
    public void ShowExpenses()
    {
        WriteLine("Expenses");
        WriteLine("Id".PadRight(5) + "Titel".PadRight(15) + "Amount".PadRight(15) + "Year".PadLeft(8) + "Month".PadLeft(8));
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
            int id = 1;
            if (TransactionList.Count()>0) 
            {
                id = TransactionList.Max(transaction => transaction.Id) + 1;
            }
            if(amount> 0) 
            {
                Income income = new Income(id,title,amount,date);
                TransactionList.Add(income);

            }
            else if (amount < 0)
            {
                Expense expense = new Expense(id,title, amount, date);
                TransactionList.Add(expense);
            }
            else 
            {
               WriteLine("Something wrong with the amount");
            }
        }
        

    }
    
    public int EditTransactions(string message)
    {
        ShowAllTransactions();
        WriteLine(message+" :");
        string answer = ReadLine();
        int id = 0;
        try
        {
            id=Convert.ToInt32(answer);
            if(!TransactionExists(id)) 
            {
                WriteLine("There is no transaction with that id in your list");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("The id has to be an integer");
        }
        return id;
        

    }
    public void ChangeTitle()
    {
        int id=EditTransactions("Which transaction do you want to change title on? (Write id)");
        if (id>0)    
        {
            Transaction transactionToEdit = GetTransaction(id);
            WriteLine($"Old Title: {transactionToEdit.Title}");
            Write("New Title: ");
            string title = ReadLine();
            transactionToEdit.Title = title;
        }
        
    }
    public void ChangeType(int id, double amount)
    {
        Transaction transactionToChange = GetTransaction(id);
       
        if (transactionToChange.GetType().ToString().Contains("Income"))
        {
            Expense newTransaction= new Expense(transactionToChange.Id,transactionToChange.Title, amount, transactionToChange.TransactionDate);
            TransactionList.Remove(transactionToChange);
            TransactionList.Add(newTransaction);
        }
        else 
        {
            Income newTransaction = new Income(transactionToChange.Id, transactionToChange.Title, amount, transactionToChange.TransactionDate);
            TransactionList.Remove(transactionToChange);
            TransactionList.Add(newTransaction);
        }
        
    }
    public void ChangeAmount()
    {
        int id = EditTransactions("Which transaction do you want to change amount on? (Write id)");
        if (id > 0)
        {
            Transaction transactionToEdit = GetTransaction(id);
            WriteLine($"Old Amoutn: {transactionToEdit.Amount}");
            Write("New Amount: ");
            string stringAmount = ReadLine();
            double amount;
            try
            {
                amount=Convert.ToDouble(stringAmount);
                transactionToEdit.Amount = amount;
                if ((transactionToEdit.GetType().ToString().Contains("Income") && amount <0)|| (transactionToEdit.GetType().ToString().Contains("Expense") && amount > 0))
                {
                    ChangeType(id, amount);
                }

            }
            catch (Exception)
            {
                WriteLine("It has to be a number");
            }
            
        }
    }
    public void ChangeDate()
    {
        int id = EditTransactions("Which transaction do you want to change date on? (Write id)");
        if (id > 0)
        {
            Transaction transactionToEdit = GetTransaction(id);
            WriteLine($"Old Date: {transactionToEdit.TransactionDate}");
            Write("New Date: ");
            string stringDate = ReadLine();
            try
            {
                DateTime transactionDate = Convert.ToDateTime(stringDate);
                transactionToEdit.TransactionDate=transactionDate;
            }
            catch (Exception)
            {
                Console.WriteLine("It has to be a date on format 'yyyy-mm-dd' for example '2024-02-28'");
            }
            
        }
    }
    public void RemoveTransactions()
    {
        int id = EditTransactions("Which transaction do you want to remove? (Write id)");
        if (id > 0)
        {
            Transaction transactionToEdit = GetTransaction(id);
            if(TransactionList.Remove(transactionToEdit))
            {
                WriteLine("The transaction is removed");
            }
            else
            {
                WriteLine("Something went wrong");

            }
        }
    }
   
    public void GetFromStrings(List<string> transactionStrings)
    {
        foreach (string transactionString in transactionStrings)
        {
            string[] transactionParts= transactionString.Split(',');
            if (transactionParts[1].Contains("Income"))
            {
                int id = Convert.ToInt32(transactionParts[0]);
                Income income=new Income(id,transactionParts[2], Convert.ToDouble(transactionParts[3]), Convert.ToDateTime(transactionParts[4]));
                TransactionList.Add(income);
            }
            else
            {
                Expense expense = new Expense(Convert.ToInt32(transactionParts[0]),transactionParts[2], Convert.ToDouble(transactionParts[3]), Convert.ToDateTime(transactionParts[4]));
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
        WriteLine($"You have currently {SumTransactions().ToString("c")} on your account");
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
    public bool TransactionExists(int id)
    {
        return TransactionList.Exists(transaction=>transaction.Id==id);
    }
    public Transaction GetTransaction(int id)
    {
        return TransactionList.Where(transaction=>transaction.Id==id).FirstOrDefault();      
    }
    public double SumTransactions()
    {
        return TransactionList.Sum(transaction=>transaction.Amount);
    }
}
