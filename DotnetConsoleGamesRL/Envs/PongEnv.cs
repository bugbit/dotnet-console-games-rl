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

namespace DotnetConsoleGamesRL.Envs;

using DotnetConsoleGamesRL.Core;
using NumSharp;
using System.Collections;

internal class PongEnv : Env<VoidOptions>
{
    private float Paddle1X;
    private float Paddle2X;

    public PongEnv()
    {
        // Angle limit set to 2 * theta_threshold_radians so failing observation is still within bounds  
        //var high = np.array(x_threshold * 2, float.MaxValue, theta_threshold_radians * 2, float.MaxValue);
        var high = np.array(1, float.MaxValue);
        ActionSpace = new Discrete(2);
        ObservationSpace = new Box((-1 * high), high, np.float32);

        Metadata = new Dictionary<string, object>() { ["render.modes"] = new[] { "human", "rgb_array" }, ["video.frames_per_second"] = 50 };
    }

    public override NDArray Reset(VoidOptions options = default)
    {
        throw new NotImplementedException();
    }
    public override object? Render(RenderModes mode = RenderModes.None)
    {
        throw new NotImplementedException();
    }

    public override (NDArray state, float reward, bool done, IDictionary? info) Step(int action)
    {
        throw new NotImplementedException();
    }
    public override void Close()
    {
        throw new NotImplementedException();
    }
}
