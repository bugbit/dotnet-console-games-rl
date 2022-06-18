#region License
/*
MIT License

Copyright (c) 2022 bugbit

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/
#endregion

namespace DotnetConsoleGamesRL.Core;

/// <summary>
/// S: Estate
/// A: Action
/// R:Reward
/// </summary>
public class Environment<S, A, R> : IEnvironment<S, A, R>
{
    private List<IAgent<S, A, R>> Agents = new List<IAgent<S, A, R>>();


    public Vector2 Size { get; protected set; } = new Vector2(80, 25);
    public IRender<S, A, R>? Render { get; set; }
    public S? State { get; protected set; }

    public void AddAgent(IAgent<S, A, R> _agent) => Agents.Add(_agent);
    public virtual void Init() { Reset(); }
    public virtual void Reset() { }
}