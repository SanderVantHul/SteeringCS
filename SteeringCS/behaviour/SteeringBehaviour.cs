using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS
{
    public abstract class SteeringBehaviour
    {
        public MovingEntity ME { get; set; }
        public MovingEntity Target { get; set; }
        public abstract Vector2D Calculate();

        public SteeringBehaviour(MovingEntity me, MovingEntity target)
        {
            ME = me;
            Target = target;
        }
    }
}
