using static DotnetConsoleGamesRL.Native.NCurses;

try
{
    var env = new PPEnvironment();

    initscr();
    addstr("HelloWord");
    refresh();
    endwin();
    //env.AddAgent
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    System.Diagnostics.Trace.TraceError(ex.ToString());
}