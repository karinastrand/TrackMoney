namespace TrackMoney;

public class Menu
{//The Menus 
    public static void ShowStartMenu()
    {//Start Menu
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("Pick an option");
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("(1) Show Transactions");
        WriteLine("(2) Add new Transactions");
        WriteLine("(3) Edit");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("(4) Save");
        WriteLine("(5) Save and Quit");
        ResetColor();
    }
    
    public static void ShowEditMenu()
    {//Edit Menu
        ForegroundColor=ConsoleColor.Magenta;
        WriteLine("Pick an option");
        ForegroundColor = ConsoleColor.Yellow;  
        WriteLine("(1) Change Transaction Title");
        WriteLine("(2) Change Amount");
        WriteLine("(3) Change Date");
        WriteLine("(4) Remove Transaction");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("(5) Quit");
        ResetColor();
    }
    public static void ShowShowMenu()
    {
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("Pick an option");
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("(1) All transactions sorted by year and month");
        WriteLine("(2) All transactions sorted by year and month, descending");
        ForegroundColor=ConsoleColor.Cyan;
        WriteLine("(3) All transactions sorted by title");
        WriteLine("(4) All transactions sorted by title, descending");
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("(5) All transactions sorted by amount");
        WriteLine("(6) All transactions sorted by amount, descending");
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("(7) Incomes");
        ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("(8) Expenses");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("(9) Quit");
    }
         
}
