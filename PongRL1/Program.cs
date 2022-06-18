try
{
    var env = new PPEnvironment();

    DotnetConsoleGamesRL.Native.NCurses.initscr();
    DotnetConsoleGamesRL.Native.NCurses.addstr("HelloWord");
    DotnetConsoleGamesRL.Native.NCurses.refresh();
    DotnetConsoleGamesRL.Native.NCurses.endwin();
    //env.AddAgent
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    System.Diagnostics.Trace.TraceError(ex.ToString());
}