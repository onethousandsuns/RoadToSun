using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.SCRIPTS.Game
{
    public class GameLevel : MonoBehaviour{

        private List<Shape> expectedSequence;
        private List<Shape> currentSequence;

        public GameLevel(List<Shape> expected, List<Shape> start)
        {
            expectedSequence = expected;
            currentSequence = start;
        }

        public bool IsSequencesEqual()
        {
            return expectedSequence.SequenceEqual(currentSequence, new ShapeComparator());
        }

        public void Rotate(int pos)
        {
            currentSequence[pos].ChangeDirection();
            if (pos < currentSequence.Count - 1)
            {
                currentSequence[pos + 1].ChangeDirection();
            }
            else
            {
                currentSequence[pos - 1].ChangeDirection();
            }
        }
    }
}
