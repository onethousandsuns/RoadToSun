using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.SCRIPTS.Game
{
    public class GameLevel : MonoBehaviour{

		public static GameLevel gameLevel;
        public GameObject[] expectedSequence;
        public GameObject[] currentSequence;

        GameObject[] FindObsWithTag(string tag)
        {
            GameObject[] foundObs = GameObject.FindGameObjectsWithTag(tag);
            System.Array.Sort(foundObs, CompareObNames);
            return foundObs;
        }


        int CompareObNames(GameObject x, GameObject y)
        {
            return x.name.CompareTo(y.name);
        }

        public bool IsSequencesEqual()
        {
            if (expectedSequence.Length == 0)
			{
				expectedSequence = FindObsWithTag("Ideal");
			}
			
			if(currentSequence.Length == 0)
			{
				currentSequence = FindObsWithTag("Current");
			}

            for(int i = 0; i < expectedSequence.Length; ++i)
            {
                ShapeDirection first = expectedSequence[i].GetComponent<Shape>().Direction;
                ShapeDirection second = currentSequence[i].GetComponentInChildren<Shape>(false).Direction;
                if (first != second)
                {
                    return false;
                }
            }
			
            return true;
        }
		
		void Start()
		{
			gameLevel = this;
		}
    }
}
