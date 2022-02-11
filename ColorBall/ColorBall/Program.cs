using System;
using ColorBall;

Ball ball = new Ball();
ball.BallColor = new Color(2, 3, 5);
Console.WriteLine("Alpha: " + ball.BallColor.Alpha);
ball.BallColor.GetGrayScale();
ball.Size = 14;
Console.WriteLine("The size is " + ball.Size);
ball.Throw();
ball.Throw();
ball.Throw();
Console.WriteLine("The throw count is " + ball.ThrowCount);
Console.WriteLine("Let's pop the ball and throw two times");
ball.Pop();
ball.Throw();
ball.Throw();
Console.WriteLine("After poping, the throw count is still " + ball.ThrowCount);




