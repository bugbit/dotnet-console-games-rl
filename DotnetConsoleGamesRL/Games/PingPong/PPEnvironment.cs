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
using System.Linq;
using System.Threading.Tasks;
using DotnetConsoleGamesRL.Core;
using static DotnetConsoleGamesRL.Native.NCurses;

namespace DotnetConsoleGamesRL.Games.PingPong
{
    public class PPEnvironment : Environment<VoidOptions, PPEstado, PPAciones>
    {
        private const int paddleheight = 5;
        private Vector2 size;
        private Paddle[] paddles;
        private Ball ball = new Ball();

        private PPEnvironment(Vector2 _size)
        {
            size = _size;
            paddles = new[]
            {
                new Paddle(),
                new Paddle()
            };
        }

        public override PPEstado Reset(VoidOptions options = default)
        {
            var paddle_y = (size.Y - paddleheight) / 2;

            paddles[0].Position = new Vector2(1, paddle_y);
            paddles[1].Position = new Vector2(size.X - paddle_y;
            ball.Position = new Vector2(size.X / 2, size.Y / 2);

            return new PPEstado();
        }

        public override (PPEstado state, float reward, bool done, IDictionary? info) Step(PPAciones action)
        {
            throw new NotImplementedException();
        }
        public override object? Render(RenderModes mode = RenderModes.None)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            endwin();
        }

        public static PPEnvironment Create()
        {
            var w = initscr();

            return new PPEnvironment(new Vector2(getmaxx(w), getmaxy(w)));
        }
    }
}