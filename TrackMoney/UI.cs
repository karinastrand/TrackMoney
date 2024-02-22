namespace TrackMoney;
public class UI
{//TrackMoney's userinterface, shows Start Menu and Edit Menu and handles the user's input

    private Transactions transactionHandling = new Transactions("transactions.txt");

    public void Input()
    {
        //Saved Transactions are fetched from a file
        transactionHandling.GetFromFile();
        WriteLine("Welcome to TrackMoney");
        //Info about transactions
        Functions.TransactionsInfo(transactionHandling.TransactionList);
        MenuChoise();
    }
    public  void MenuChoise()
    {//Shows the start menu and takes care of the user's answer
        while (true)
        {
            Menu.ShowStartMenu();
            string menuChoise = ReadLine();
            switch (menuChoise)
            {
                case "1":
                    {
                        //Shows the Show transactions menu and handles the user input
                        ShowMenuChoise();
                        break;
                    }
               case "2":
                    {
                        //Adding new Task
                        transactionHandling.AddTransactions();
                        break;
                    }
                case "3":
                    {
                        //Shows the Edit menu and handles the user input
                        EditMenuChoise();
                        break;
                    }
                case "4":
                case "5":
                    {
                        //Saves the Tasks and Projests to files
                        transactionHandling.TransactionsToFile();
                        break;
                    }
                default:
                    {
                        //User input has to be an integer between 1 and 5
                        Messages.ErrorMessage("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "5")
            {
                //Exit the program
                break;
            }
        }
    }

    public void ShowMenuChoise()
    {//Shows the ShowMenu and takes care of user input
        while (true)
        {
            Menu.ShowShowMenu();
            string menuChoise = ReadLine();
            switch (menuChoise)
            {
                case "1":
                    {   //Lists all Transactions sorted by year and then months
                        transactionHandling.ShowAllTransactions();
                        break;
                    }
                case "2":
                    {
                        //Lists all Transactions sorted by year and then months descending
                        transactionHandling.ShowAllTransactionsDescending();
                        break;
                    }
                case "3":
                    {
                        //Lists all Transactions sorted by title
                        transactionHandling.ShowAllTransactionsSortedByTitle();
                        break;
                    }

                case "4":
                    {
                        //Lists all Transactions sorted by title descending
                        transactionHandling.ShowAllTransactionsSortedByTitleDescending();
                        break;
                    }
                case "5":
                    {
                        //Lists all Transactions sorted by amount
                        transactionHandling.ShowAllTransactionsSortedByAmount();
                        break;
                    }
                case "6":
                    {
                        //Lists all Transactions sorted by amount descending
                        transactionHandling.ShowAllTransactionsSortedByAmountDescending();
                        break;
                    }
                case "7":
                    {
                        //Lists Incomes
                        transactionHandling.ShowIncomes();
                        break;
                    }
                case "8":
                    {
                        //Lists Expenses
                        transactionHandling.ShowExpenses();
                        break;
                    }
                case "9":
                    {
                        //Quit 
                        break;
                    }

                default:
                    {
                        //The input has to be an integer between 1 and 9
                        Messages.ErrorMessage("You have to choose one of the alternativ in the list");
                        break;
                    }

            }
            if (menuChoise == "9")
            {
                //Exiting the Edit Menu
                break;
            }
        }
    }

    public void EditMenuChoise()
    {//Shows the Edit Menu and takes care of user input
        while (true)
        {
            Menu.ShowEditMenu();
            string menuChoise = ReadLine();
            switch (menuChoise)
            {
                case "1":
                    {   //Change Project Title
                        transactionHandling.ChangeTitle();
                        break;
                    }
                case "2":
                    {
                        //Change Project Description
                        transactionHandling.ChangeAmount();
                        break;
                    }
                case "3":
                    {
                        //Removing Projects
                        transactionHandling.ChangeDate();
                        break;
                    }
               
                case "4":
                    {
                        //Removing Tasks
                        transactionHandling.RemoveTransactions();
                        break;
                    }  
                case "5":
                {
                    //Quit 
                    break;
                }
                default:
                    {
                        //The input has to be an integer between 1 and 5
                        Messages.ErrorMessage("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "5")
            {
                //Exiting the Edit Menu
                break;
            }
        }
    }   
}

   

