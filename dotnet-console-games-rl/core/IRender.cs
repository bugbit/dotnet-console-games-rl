namespace dotnet_console_games_rl;

/// <summary>
/// S: Estate
/// A: Action
/// R:Reward
/// </summary>
public interface IRender<S, A, R>
{
    void Render(IEnvironment<S, A, R> _render);
}