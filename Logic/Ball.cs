﻿using System;

namespace BallSimulator.Logic
{
    public class Ball
    {
        public int Radius { get; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }

        public Ball(int radius, int posX, int posY, float speedX, float speedY)
            : this(radius, new Vector2(posX, posY), new Vector2(speedX, speedY))
        { }

        public Ball(int radius, Vector2 position, Vector2 speed)
        {
            Radius = radius;
            Position = position;
            Speed = speed;
        }

        public void Move(Vector2 xBoundry, Vector2 yBoundry, float strength = 1f)
        {
            if (!strength.Between(0f, 1f)) throw new ArgumentException("Strenght must be between 0 and 1!", nameof(strength));

            Position += Speed * strength;

            if (!Position.X.Between(xBoundry.X, xBoundry.Y))
            {
                Speed = new Vector2(-Speed.X, Speed.Y);
            }
            if (!Position.Y.Between(yBoundry.X, yBoundry.Y))
            {
                Speed = new Vector2(Speed.X, -Speed.Y);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Ball ball &&
                   Radius == ball.Radius &&
                   Position == ball.Position &&
                   Speed == ball.Speed;
        }
    }
}