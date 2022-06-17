namespace dotnet_console_games_rl;

/// <summary>
/// S: Estate
/// A: Action
/// R:Reward
/// </summary>
public interface IEnvironment<S, A, R>
{
    IRender<S, A, R>? Render { get; set; }
    void AddAgent(IAgent<S, A, R> _agent);
}