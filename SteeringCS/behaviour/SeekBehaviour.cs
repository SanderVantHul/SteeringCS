using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behaviour
{
    class SeekBehaviour : SteeringBehaviour
    {
        public SeekBehaviour(MovingEntity me, MovingEntity target) : base(me, target)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D desiredVelocity = ME.Pos.Sub(Target.Pos);
            desiredVelocity.Normalize();
            return desiredVelocity.Sub(ME.Velocity);

        }
    }
}
