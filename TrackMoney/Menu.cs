namespace TrackMoney;

public class Menu
{//The Menus 
    public static void ShowStartMenu()
    {//Start Menu
        WriteLine("Pick an option");
        WriteLine("(1) Show Transaction List");
        WriteLine("(2) Show Transaction List Sorted By Title");
        WriteLine("(3) Show Transaction List Sorted By Amount");
        WriteLine("(4) Show Incomes");
        WriteLine("(5) Show Expenses");
        WriteLine("(6) Add new Transactions");
        WriteLine("(7) Edit");
        WriteLine("(8) Save");
        WriteLine("(9) Save and Quit");
    }
    
    public static void ShowEditMenu()
    {//Edit Menu
        WriteLine("Pick an option");
        WriteLine("(1) Change Transaction Title");
        WriteLine("(2) Change Amount");
        WriteLine("(3) Change Date");
        WriteLine("(4) Remove Transaction");
        WriteLine("(5) Quit");
    }
}
