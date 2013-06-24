using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;

namespace SqEng.Internal.Animation
{

    public enum CollisionType
    {
        Rectangle,
        Triangle
    }

    public class Collision
    {
        public CollisionType @Type;

        private FloatRect frect;
        private Vector2f[] triPoints;

        public Collision(FloatRect fr)
        {
            @Type = CollisionType.Rectangle;
            frect = fr;
        }

        public Collision(Vector2f[] triPoints)
        {
            @Type = CollisionType.Triangle;
            this.triPoints = triPoints;
        }

        public bool CollidingWith(Collision c)
        {
            if (@Type == CollisionType.Rectangle)
            {
                if (c.Type == CollisionType.Rectangle)
                    return Helpers.RectRectCollision(frect, c.frect);
                return Helpers.TriangleRectCollision(c.triPoints, frect);
            }

            if (c.Type == CollisionType.Rectangle)
                return Helpers.TriangleRectCollision(triPoints, c.frect);

            return Helpers.TriangleTriangleCollision(triPoints, c.triPoints);
        }
    }
}
