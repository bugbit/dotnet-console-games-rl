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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetConsoleGamesRL.Games.PingPong;

public struct PPEstado : IEquatable<PPEstado>
{
    public Vector2 PosPlayer1 { get; set; }
    public Vector2 DirPlayer1 { get; set; }
    public Vector2 PosPlayer2 { get; set; }
    public Vector2 DirPlayer2 { get; set; }
    public Vector2 PosBall { get; set; }
    public Vector2 VelBall { get; set; }

    public bool Equals(PPEstado other)
        => PosPlayer1 == other.PosPlayer1 && DirPlayer1 == other.DirPlayer1
        && PosPlayer2 == other.PosPlayer2 && DirPlayer2 == other.DirPlayer2
        && PosBall == other.PosBall && VelBall == other.VelBall;

    public override bool Equals([NotNullWhen(true)] object? obj) => (obj is PPEstado e) && Equals(e);

    public override int GetHashCode()
        => (PosPlayer1, DirPlayer1, PosPlayer2, DirPlayer2, PosBall, VelBall).GetHashCode();
}