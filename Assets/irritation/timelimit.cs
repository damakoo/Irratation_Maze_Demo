using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoEmbodimentSystem
{
    public class timelimit : MonoBehaviour
    {
        GameObject ChildObject;

        [SerializeField]
        private Sprite sprite_green;

        [SerializeField]
        private Sprite sprite_red;

        public Image image;

        GameObject gameobject0;
        collision_judgemnt Collision_Judgemnt;


        public float limit = 30;
        public float time_limit;
        private bool timeloss = false;
        private bool enoughtime = true;


        // Start is called before the first frame update
        void Start()
        {
            ChildObject = transform.GetChild(0).gameObject;
            ChildObject.GetComponent<Text>().text = "TIME: " + limit.ToString("f1");
            gameobject0 = GameObject.Find("irritation_system/GameObject");
            Collision_Judgemnt = gameobject0.gameObject.GetComponent<collision_judgemnt>();
            image = this.GetComponent<Image>();


        }

        // Update is called once per frame
        void Update()
        {
            if (Collision_Judgemnt.collision == 1 && timeloss == false && Collision_Judgemnt.start_game)
            {
                limit -= 1;
                timeloss = true;
                Invoke("notcollision", 0.1f);
            }

            if (Collision_Judgemnt.start_game)
            {
                if (limit > 0)
                {
                    limit -= Time.deltaTime;
                    ChildObject.GetComponent<Text>().text = "TIME: " + limit.ToString("f1");
                    this.gameObject.GetComponent<Image>().fillAmount -= Time.deltaTime / time_limit;
                    if (limit < 5 && enoughtime)
                    {
                        ChildObject.gameObject.GetComponent<Text>().color = new Color(255f, 0, 0);
                        image.sprite = sprite_red;
                        enoughtime = false;
                    }
                }
            }
            else
            {
                if (limit > 5 && enoughtime == false)
                {
                    ChildObject.gameObject.GetComponent<Text>().color = new Color(0, 0, 0);
                    image.sprite = sprite_green;
                    enoughtime = true;
                }

            }
            if (limit < 0)
            {
                limit = 0;
                ChildObject.GetComponent<Text>().text = "TIME: 0.00";
                this.gameObject.GetComponent<Image>().fillAmount = 0;
            }
        }
        void notcollision()
        {
            if (Collision_Judgemnt.collision == 0)
            {
                timeloss = false;
            }
            else
            {
                Invoke("notcollision", 0.1f);
            }
        }
    }
}