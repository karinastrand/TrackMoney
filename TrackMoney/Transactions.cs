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
        Messages.Info("All transactions sorted by year and date");
        List<Transaction> SortedTransactions = TransactionList.OrderBy(transaction=>transaction.TransactionDate.Year).ThenBy(transaction=>transaction.TransactionDate.Month).ToList();
        Functions.ShowSortedTransactions(SortedTransactions);
    }
    public void ShowAllTransactionsDescending()
    {//Sorted by year and then month
        List<Transaction> SortedTransactions = TransactionList.OrderByDescending(transaction => transaction.TransactionDate.Year).ThenByDescending(transaction => transaction.TransactionDate.Month).ToList();
        Messages.Info("All transactions sorted by year and date descending");
        Functions.ShowSortedTransactions(SortedTransactions);
    }
    public void ShowAllTransactionsSortedByTitle()
    {//Sorted by title
        List<Transaction> SortedTransactions = TransactionList.OrderBy(transaction => transaction.Title).ToList();
        Messages.Info("All transactions sorted by title");
        Functions.ShowSortedTransactions(SortedTransactions);
    }
    public void ShowAllTransactionsSortedByTitleDescending()
    {//Sorted by title descending
        List<Transaction> SortedTransactions = TransactionList.OrderByDescending(transaction => transaction.Title).ToList();
        Messages.Info("All transactions sorted by title, descending");
        Functions.ShowSortedTransactions(SortedTransactions);
    }
    public void ShowAllTransactionsSortedByAmount()
    {//Sorted by amount
        List<Transaction> SortedTransactions = TransactionList.OrderBy(transaction => transaction.Amount).ToList();
        Messages.Info("All transactions sorted by amount");
        Functions.ShowSortedTransactions(SortedTransactions);
    }
    public void ShowAllTransactionsSortedByAmountDescending()
    {//Sorted by amount descending
        List<Transaction> SortedTransactions = TransactionList.OrderByDescending(transaction => transaction.Amount).ToList();
        Messages.Info("All transactions sorted by amount descending");
        Functions.ShowSortedTransactions(SortedTransactions); 
    }
    public void ShowIncomes()
    {//Show all Incomes
        WriteLine("Incomes");
        Messages.Title("Id".PadRight(5) + "Titel".PadRight(15) + "Amount".PadRight(15) + "Year".PadLeft(8) + "Month".PadLeft(8),10);
        foreach (Transaction transaction in TransactionList)
        {
            if (Functions.GetType(transaction).ToString().Contains("Income"))
            {
                transaction.Print(Functions.GetType(transaction));
            }
        }
    }
    public void ShowExpenses()
    {//Show all Expenses
        WriteLine("Expenses");
        Messages.Title("Id".PadRight(5) + "Titel".PadRight(15) + "Amount".PadRight(15) + "Year".PadLeft(8) + "Month".PadLeft(8),4);
        foreach (Transaction transaction in TransactionList)
        {
            if (Functions.GetType(transaction).ToString().Contains("Expens"))
            {
                transaction.Print(Functions.GetType(transaction));
            }
        }
    }
    public void AddTransactions()
    {//Adds new transactions until the user writes q
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
            {//Convert input to amount if possible
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
            {//Convert input to a date if possible
                date= Convert.ToDateTime(stringDate);   
            }
            catch (FormatException)
            {
                WriteLine("The date has to be on the format 'yyyy-mm-dd' for example 2024-02-10");
                continue;
            }
            int id = 1;
            if (TransactionList.Count()>0) 
            {//id increases with one everytime a transaction is saved
                id = TransactionList.Max(transaction => transaction.Id) + 1;
            }
            if(amount> 0) 
            {//If it is an Income
                Income income = new Income(id,title,amount,date);
                TransactionList.Add(income);
                Messages.SuccessMessage("The Income is succesfully added");
            }
            else if (amount < 0)
            {//If it is an Expense
                Expense expense = new Expense(id,title, amount, date);
                TransactionList.Add(expense);
                Messages.SuccessMessage("The Expense is succesfully added");
            }
            else 
            {
               Messages.ErrorMessage("Something wrong with the amount, it has to be a number and can not be 0.");
            }
        }
    }
    private int EditTransactions(string message)
    {//Asks for the id of the transaction the user wants to edit
        ShowAllTransactions();
        WriteLine(message+" :");
        string answer = ReadLine();
        int id = 0;
        try
        {//the id has to be an integer and in the TransactionList
            id=Convert.ToInt32(answer);
            if(!Functions.TransactionExists(id,TransactionList)) 
            {
                Messages.ErrorMessage("There is no transaction with that id in your list");
            }
        }
        catch (FormatException)
        {
            Messages.ErrorMessage("The id has to be an integer");
        }
        return id;
    }
    public void ChangeTitle()
    {//Change title
        int id=EditTransactions("Which transaction do you want to change title on? (Write id)");
        if (id>0)    
        {//if the user has chosen an id from the TransactionList
            Transaction transactionToEdit = Functions.GetTransaction(id,TransactionList);
            WriteLine($"Old Title: {transactionToEdit.Title}");
            Write("New Title: ");
            string title = ReadLine();
            transactionToEdit.Title = title;
            Messages.SuccessMessage("The title is changed");
        }
    }
    public void ChangeAmount()
    {//Change amount
        int id = EditTransactions("Which transaction do you want to change amount on? (Write id)");
        if (id > 0)
        {//if the user has chosen an id from the TransactionList
            Transaction transactionToEdit = Functions.GetTransaction(id,TransactionList);
            WriteLine($"Old Amoutn: {transactionToEdit.Amount}");
            Write("New Amount: ");
            string stringAmount = ReadLine();
            double amount;
            try
            {
                amount=Convert.ToDouble(stringAmount);
                transactionToEdit.Amount = amount;
                if ((transactionToEdit.GetType().ToString().Contains("Income") && amount <0)|| (transactionToEdit.GetType().ToString().Contains("Expense") && amount > 0))
                {//if the amount is changed from negative to positive or the other way rount the Object has to be change 
                    ChangeType(id, amount);
                }
                Messages.SuccessMessage("The amount is changed");
            }
            catch (Exception)
            {
                Messages.ErrorMessage("It has to be a number");
            }          
        }
    }
    public void ChangeType(int id, double amount)
    {//If the amount is changed so that an income will be <0 or an expense will be >0 the Transaction has to be changed from an Incomt to an Expense or the other way round
        Transaction transactionToChange = Functions.GetTransaction(id, TransactionList);
        if (transactionToChange.GetType().ToString().Contains("Income"))
        {//An Expense object is created, the old income object is removed from the list and the Expense is added.
            Expense newTransaction = new Expense(transactionToChange.Id, transactionToChange.Title, amount, transactionToChange.TransactionDate);
            TransactionList.Remove(transactionToChange);
            TransactionList.Add(newTransaction);
        }
        else
        {//An Income object is created, the old Expense object is removed from the list and the Income is added.
            Income newTransaction = new Income(transactionToChange.Id, transactionToChange.Title, amount, transactionToChange.TransactionDate);
            TransactionList.Remove(transactionToChange);
            TransactionList.Add(newTransaction);
        }
    }
    public void ChangeDate()
    {//Change TransactionDate
        int id = EditTransactions("Which transaction do you want to change date on? (Write id)");
        if (id > 0)
        {//if the user has chosen an id from the TransactionList
            Transaction transactionToEdit = Functions.GetTransaction(id,TransactionList);
            WriteLine($"Old Date: {transactionToEdit.TransactionDate}");
            Write("New Date (yyyy-mm-dd): ");
            string stringDate = ReadLine();
            try
            {//the input has to be a date
                DateTime transactionDate = Convert.ToDateTime(stringDate);
                transactionToEdit.TransactionDate=transactionDate;
                Messages.SuccessMessage("The transaction date is changed");
            }
            catch (Exception)
            {
                Messages.ErrorMessage("It has to be a date on format 'yyyy-mm-dd' for example '2024-02-28'");
            }   
        }
    }
    public void RemoveTransactions()
    {//Remove a transaction
        int id = EditTransactions("Which transaction do you want to remove? (Write id)");
        if (id > 0)
        {//if the user has chosen an id from the TransactionList
            Transaction transactionToEdit = Functions.GetTransaction(id,TransactionList);
            if(TransactionList.Remove(transactionToEdit))
            {
                Messages.SuccessMessage("The transaction is removed");
            }
            else
            {
                Messages.ErrorMessage("Something went wrong");
            }
        }
    }
    public void GetFromStrings(List<string> transactionStrings)
    {//Converts strings to Transction objects
        foreach (string transactionString in transactionStrings)
        {
            try
            {//the string has to contain five parts seperated by comma (id,Income or Expense, title, amount and transactiondate)
                string[] transactionParts = transactionString.Split(',');
                if (transactionParts[1].Contains("Income"))
                {
                    int id = Convert.ToInt32(transactionParts[0]);
                    Income income = new Income(id, transactionParts[2], Convert.ToDouble(transactionParts[3]), Convert.ToDateTime(transactionParts[4]));
                    TransactionList.Add(income);
                }
                else
                {
                    Expense expense = new Expense(Convert.ToInt32(transactionParts[0]), transactionParts[2], Convert.ToDouble(transactionParts[3]), Convert.ToDateTime(transactionParts[4]));
                    TransactionList.Add(expense);
                }
            }
            catch(FormatException)
            {//id, amount and transactiondate has to have right format
                Messages.ErrorMessage("It was not possible to convert the string to an Transaction due to format issues");
            }
            catch (Exception)
            {//probably not enough parts in the string
                Messages.ErrorMessage("Something wrong with the string, no conversion could be done");
            }
        }
    }
    public void TransactionsToFile()
    {//Converts the Transactions in TransactionList to a list if strings and saves them to a file
        List<string> transactionStrings = new List<string>();
        foreach (Transaction transaction in TransactionList)
        {
            transactionStrings.Add(transaction.TransactionToString(transaction));
        }
        FileHandling fileHandling = new FileHandling(NameOfFile);
        fileHandling.SaveToFile(transactionStrings);
    }   
    public void GetFromFile()
    {//fetches the saved strings from a file and converts the strings to Transaction objects.
        FileHandling fileHandling=new FileHandling(NameOfFile);
        List<string> stringTransactions=fileHandling.ReadFromFile();
        GetFromStrings(stringTransactions);        
    }   
}
