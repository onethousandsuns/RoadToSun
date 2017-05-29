using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.SCRIPTS.Game
{
    public class GameLevel : MonoBehaviour{

        private List<Shape> _expectedSequence;
        private List<Shape> _currentSequence;

        private List<Shape> ExpectedSequence
        {
            get { return _expectedSequence; }
            set { _expectedSequence = value; }
        }

        private List<Shape> CurrentSequence
        {
            get { return _currentSequence; }
            set { _currentSequence = value; }
        }

        public GameLevel(List<Shape> expected, List<Shape> start)
        {
            _expectedSequence = expected;
            _currentSequence = start;
        }

        public bool IsSequencesEqual()
        {
            return _expectedSequence.SequenceEqual(_currentSequence, new ShapeComparator());
        }

        public void Rotate(int pos)
        {
            _currentSequence[pos].ChangeDirection();
            if (pos < _currentSequence.Count - 1)
            {
                _currentSequence[pos + 1].ChangeDirection();
            }
            else
            {
                _currentSequence[pos - 1].ChangeDirection();
            }
        }
    }
}
