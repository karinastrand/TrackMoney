namespace TrackMoney;
public class UI
{//ToDos userinterface, shows Start Menu and Edit Menu and handles the user's input

    private Transactions transactionHandling = new Transactions("transactions.txt");

    public void Input()
    {
        //Saved Transactions are fetched from files
        transactionHandling.GetFromFile();
        WriteLine("Welcome to TrackMoney");
        //Info about tasks
        transactionHandling.TransactionsInfo();
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
                        //Shows Transactions
                        transactionHandling.ShowAllTransactions();
                        break;
                    }
                case "2":
                    {
                        //Shows Transactions
                        transactionHandling.ShowAllTransactionsSortedByTitle();
                        break;
                    }
                case "3":
                    {
                        //Shows Transactions
                        transactionHandling.ShowAllTransactionsSortedByAmount();
                        break;
                    }

                case "4":
                    {
                        //Shows Transactions
                        transactionHandling.ShowIncomes();
                        break; 
                    }
                
                case "5":
                    {
                        //Shows Transactions
                        transactionHandling.ShowExpenses();
                        break;
                    } 
               case "6":
                    {
                        //Adding new Task
                        transactionHandling.AddTransactions();
                        break;
                    }
               
                case "7":
                    {
                        //Showing Edit menu and handles the user input
                        EditMenuChoise();
                        break;
                    }
                case "8":
                case "9":
                    {
                        //Saves the Tasks and Projests to files
                        transactionHandling.TransactionsToFile();
                        break;
                    }
                default:
                    {
                        //User input has to be an integer between 1 and 8
                        WriteLine("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "9")
            {
                //Exit the program
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
                default:
                    {
                        //The input has to be an integer between 1 and 6
                        WriteLine("You have to choose one of the alternativ in the list");
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

   

