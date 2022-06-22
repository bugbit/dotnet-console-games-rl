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

public abstract class Space
{
    public Shape Shape { get; protected set; }
    public Type? DType { get; protected set; }

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    protected Space(Shape shape, Type? dType)
    {
        Shape = shape;
        DType = dType;
    }

    public abstract NDArray Sample();
    public abstract bool Contains(object ndArray);
    public abstract void Seed(int seed);
}