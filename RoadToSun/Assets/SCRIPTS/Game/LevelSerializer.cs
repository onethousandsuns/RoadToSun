using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Assets.SCRIPTS.Game
{
    public enum ShapeDirection
    {
        None,
        Up,
        Down
    }

    public class LevelSerializer : MonoBehaviour{

        public GameLevel LoadLevel(string filename)
        {
            try
            {
                StreamReader fileStream = new StreamReader(filename, Encoding.Default);
                string[] expectedShapeIdentifiers = fileStream.ReadLine().Split(' ');
                string[] startShapeIdentifiers = fileStream.ReadLine().Split(' ');
                List<Shape> expectedShapes = new List<Shape>(expectedShapeIdentifiers.Length);
                List<Shape> startShapes = new List<Shape>(startShapeIdentifiers.Length);

                for (int i = 0; i < expectedShapeIdentifiers.Length; i++)
                {
                    expectedShapes.Add(CreateShape(expectedShapeIdentifiers[i]));
                    startShapes.Add(CreateShape(startShapeIdentifiers[i]));
                }

                return new GameLevel(expectedShapes, startShapes);
            }
            catch(System.Exception except)
            {
                throw new System.Exception("Error while serialize game level", except);
            }
        }

        private ShapeDirection GetDirection(int directionNum)
        {
            switch(directionNum)
            {
                case 1:
                    return ShapeDirection.Up;
                case 0:
                    return ShapeDirection.Down;
                default:
                    return ShapeDirection.None;
            }
        }

        private Shape CreateShape(string directionStr)
        {
            Shape shape = new Shape();
            shape.Direction = GetDirection(System.Convert.ToInt32(directionStr));
            return shape;
        }
    }
}