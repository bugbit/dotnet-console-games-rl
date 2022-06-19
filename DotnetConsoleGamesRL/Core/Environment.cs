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
public class Environment<S, A> : IEnvironment<S, A, float>
{
    //private List<IAgent<S, A, float>> Agents = new List<IAgent<S, A, float>>();


    public IRender<S, A, float>? Render { get; set; }
    public virtual S GetState() => default(S);

    //public void AddAgent(IAgent<S, A, float> _agent) => Agents.Add(_agent);
    public virtual void Init() { Reset(); }
    public virtual void Done() { }
    public virtual void Reset() { }
}