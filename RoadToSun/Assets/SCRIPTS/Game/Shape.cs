using System.Collections.Generic;
using UnityEngine;

namespace Assets.SCRIPTS.Game
{
    public class Shape : MonoBehaviour {

        private ShapeDirection _direction;

        public Shape()
        {
            _direction = ShapeDirection.None;
        }

        public Shape(ShapeDirection direction)
        {
            _direction = direction;
        }

        public ShapeDirection Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        public void ChangeDirection()
        {
            _direction = _direction == ShapeDirection.Up ? ShapeDirection.Down : ShapeDirection.Up; 
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