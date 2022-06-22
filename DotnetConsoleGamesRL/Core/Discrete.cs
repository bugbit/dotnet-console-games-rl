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

public class Discrete : Space
{
    public int N { get; }
    protected NumPyRandom RandomState;

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public Discrete(int n, Type? dType = null, int seed = -1) : base(new Shape(n), (dType = dType ?? np.float32))
    {
        N = n;

        RandomState = seed != -1 ? np.random.RandomState(seed) : np.random;
    }

    public override NDArray Sample()
    {
        return RandomState.randint(0, N, default);
    }

    public override bool Contains(object ndArray)
    {
        if (ndArray is int i)
        {
            return Contains(i);
        }

        throw new NotSupportedException(ndArray?.ToString() ?? nameof(ndArray));
    }

    public bool Contains(int x)
    {
        return x >= 0 && x < N;
    }

    public bool Contains(Enum x)
    {
        return Contains((int)(object)x);
    }

    public override void Seed(int seed)
    {
        RandomState = np.random.RandomState(seed);
    }

    #region Object Overrides

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return "Discrete" + Shape;
    }

    #endregion
}