namespace TrackMoney;

public class Menu
{//The Menus 
    public static void ShowStartMenu()
    {//Start Menu
        WriteLine("Pick an option");
        WriteLine("(1) Show Transaction List");
        WriteLine("(2) Show Incomes");
        WriteLine("(3) Show Expenses");
        WriteLine("(4) Add new Transactions");
        WriteLine("(5) Edit");
        WriteLine("(6) Save");
        WriteLine("(7) Save and Quit");
    }
    
    public static void ShowEditMenu()
    {//Edit Menu
        WriteLine("Pick an option");
        ForegroundColor=ConsoleColor.Blue;
        WriteLine("(1) Change Transaction Title");
        WriteLine("(2) Change Type");
        WriteLine("(3) Change Amount");
        WriteLine("(4) Change Date");
        WriteLine("(5) Remove Transaction");
        WriteLine("(6) Quit");
    }
}
