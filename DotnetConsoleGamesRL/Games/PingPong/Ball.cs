using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetConsoleGamesRL.Games.PingPong;

public class Ball
{
    public Vector2 Position { get; set; }
    public Vector2 Direction { get; set; }
    public float Velocity { get; set; }
}