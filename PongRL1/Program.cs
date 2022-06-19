using static DotnetConsoleGamesRL.Native.NCurses;

try
{
    var env = PPEnvironment.Create();
    var e0 = env.Reset();

    // initscr();
    // addstr("HelloWord");
    // refresh();
    // endwin();
    //env.AddAgent
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    System.Diagnostics.Trace.TraceError(ex.ToString());
}