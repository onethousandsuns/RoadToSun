using System.Collections.Generic;
using SpFLib;
using UnityEngine;

namespace Assets.SpaceFighters.Background
{
    public class ParallaxController : MonoBehaviour
    {
        public float SpeedKoef;
        private Dictionary<string, double> values = new Dictionary<string, double>();

        private GameObject mplayer;
        private GameObject start;
        private GameObject end;
        private GameObject leftBorder;
        private float speed;
        private float auxspeed;

        private int thislayer;

        private void Start()
        {
            master.setLayer("Parallax", gameObject);
            master.setLayer("Top", GameObject.Find("End"));
            mplayer = GameObject.Find("Player");
            start = GameObject.Find("Start");
            end = GameObject.Find("End");
            leftBorder = GameObject.Find("LeftBorder");
            transform.parent = GameObject.Find("Layers").transform;
            if (gameObject.name == "Layer1")
            {
                setZ(-1f);
                speed = Time.deltaTime / (5 * SpeedKoef);
                thislayer = 1;
            }
            if (gameObject.name == "Layer2")
            {
                setZ(-2f);
                speed = Time.deltaTime / 444 * SpeedKoef;
                thislayer = 2;
            }
            if (gameObject.name == "Layer3")
            {
                setZ(-3f);
                speed = Time.deltaTime / 2 * SpeedKoef;
                thislayer = 3;
            }
            if (gameObject.name == "Layer4")
            {
                setZ(-4f);
                speed = Time.deltaTime / 2.7f * SpeedKoef;
                thislayer = 4;
            }
            auxspeed = speed;
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.name == "End")
            {
                var cloud = Instantiate(Resources.Load("Parallax/Type1/" + gameObject.name),
                    new Vector3(start.transform.position.x, start.transform.position.y, transform.position.z),
                    Quaternion.identity) as GameObject;
                cloud.name = gameObject.name;
            }
            if (coll.name == "LeftBorder") Invoke("onDestroy", 10);
        }

        // Update is called once per frame
        private void Update()
        {
            if (mplayer != null)
            {
                setY(thislayer);
                setSpeed(thislayer);
            }
            else
            {
                if (GameObject.Find("Player")) mplayer = GameObject.Find("Player");
            }
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(leftBorder.transform.position.x, leftBorder.transform.position.y, transform.position.z),
                speed);
        }

        private void setZ(float z)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }

        private void setSpeed(int layer)
        {
            if (mplayer != null)
                switch (layer)
                {
                    case 1:
                        speed = auxspeed + mplayer.transform.position.x / 600;
                        break;
                    case 2:
                        speed = auxspeed + mplayer.transform.position.x / 300;
                        break;
                    case 3:
                        speed = auxspeed + mplayer.transform.position.x / 100;
                        break;
                }
            else
                switch (layer)
                {
                    case 1:
                        speed = auxspeed + 3 / 600;
                        break;
                    case 2:
                        speed = auxspeed + 2 / 300;
                        break;
                    case 3:
                        speed = auxspeed + 1 / 100;
                        break;
                }
        }

        private void setY(int layer)
        {
            switch (layer)
            {
                case 1:
                    transform.position = new Vector3(transform.position.x, -mplayer.transform.position.y / 14,
                        transform.position.z);
                    break;
                case 2:
                    transform.position = new Vector3(transform.position.x, -mplayer.transform.position.y / 10,
                        transform.position.z);
                    break;
                case 3:
                    transform.position = new Vector3(transform.position.x, -mplayer.transform.position.y / 9,
                        transform.position.z);
                    break;
                case 4:
                    transform.position = new Vector3(transform.position.x, -mplayer.transform.position.y / 16,
                        transform.position.z);
                    break;
            }
        }

        private void onDestroy()
        {
            Destroy(gameObject);
        }
    }
}
