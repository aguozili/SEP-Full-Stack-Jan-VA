using System;
using ColorBall;

Ball ball = new Ball(33,44,55,5);
ball.BallColor.GrayScale();
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




