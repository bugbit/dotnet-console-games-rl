namespace dotnet_console_games_rl;

/// <summary>
/// S: Estate
/// A: Action
/// R:Reward
/// </summary>
public class Environment<S, A, R> : IEnvironment<S, A, R>
{
    private List<IAgent<S, A, R>> agents = new List<IAgent<S, A, R>>();

    public IRender<S, A, R>? Render { get; set; }

    public void AddAgent(IAgent<S, A, R> _agent) => agents.Add(_agent);
}