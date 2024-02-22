namespace TrackMoney;
public static class Messages
{//Different kind of messages
    public static void ErrorMessage(string message)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(message);
        ResetColor();
    }
    public static void SuccessMessage(string message)
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine(message);
        ResetColor();
    }
    public static void Title(string message,int color)
    {//Title will have different colors depending on what will be shownErr
        ForegroundColor = (ConsoleColor)color;
        WriteLine(message);
        ResetColor();
    }
    public static void Info(string message)
    {
        ForegroundColor = ConsoleColor.Blue;
        WriteLine(message);
        ResetColor();
    }
}
