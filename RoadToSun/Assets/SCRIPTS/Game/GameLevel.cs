using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.SCRIPTS.Game
{
    public class GameLevel : MonoBehaviour{

		public static GameLevel gameLevel;
        public GameObject[] expectedSequence;
        public GameObject[] currentSequence;


        public bool IsSequencesEqual()
        {
            if (expectedSequence.Length == 0)
			{
				expectedSequence = GameObject.FindGameObjectsWithTag("Ideal");
			}
			
			if(currentSequence.Length == 0)
			{
				currentSequence = GameObject.FindGameObjectsWithTag("Current");
			}

            for(int i = 0; i < expectedSequence.Length; ++i)
            {
                if(expectedSequence[i].GetComponent<Shape>().Direction != currentSequence[i].GetComponent<Shape>().Direction)
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
