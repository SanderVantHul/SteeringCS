using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.entity
{
    public abstract class MovingEntity : BaseGameEntity
    {
        public Vector2D Velocity { get; set; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }
        
        public Vector2D Heading { get; set; }
        public Vector2D Side { get; set; }

        public SteeringBehaviour SB { get; set; }

        public MovingEntity(Vector2D pos, World w) : base(pos, w)
        {
            Mass = 30;
            MaxSpeed = 150;
            Velocity = new Vector2D();
        }

        public override void Update(float timeElapsed)
        {
            // to do
            Console.WriteLine(ToString());
            
            // calculate steering force
            Vector2D steeringForce = SB.Calculate();

            // Acceleration = Force / Mass
            Vector2D acceleration = steeringForce.divide(Mass);
            
            // Velocity = Acceleration * Time
            Velocity.Add(acceleration.Multiply(timeElapsed));

            // velocity stays within the allowed range
            Velocity.truncate(MaxSpeed);
            
            // update position
            Pos.Add(Velocity.Multiply(timeElapsed));
            
            // update local coordinate space
            if (!(Velocity.LengthSquared() > Double.Epsilon))
            {
                Heading = Velocity.Normalize();

                Side = Heading.Perpendicular();
            }
        }

        public override string ToString()
        {
            return $"{Velocity}";
        }
    }
}
