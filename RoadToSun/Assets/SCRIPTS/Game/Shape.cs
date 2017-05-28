using System.Collections.Generic;
using UnityEngine;

namespace Assets.SCRIPTS.Game
{
    public class Shape : MonoBehaviour {

        private ShapeDirection direction;

        public Shape()
        {
            direction = ShapeDirection.None;
        }

        public ShapeDirection Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
            }
        }

        public void ChangeDirection()
        {
            direction = direction == ShapeDirection.Up ? ShapeDirection.Down : ShapeDirection.Up; 
        }
    }

    public class ShapeComparator : IEqualityComparer<Shape>
    {
        public bool Equals(Shape left, Shape right)
        {
            if (Object.ReferenceEquals(left, right))
            {
                return true;
            }
            return left != null && right != null && left.Direction.Equals(right.Direction);
        }

        public int GetHashCode(Shape obj)
        {
            return obj.Direction.GetHashCode();
        }
    }
}