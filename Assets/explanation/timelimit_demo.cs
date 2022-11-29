using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CoEmbodimentSystem
{
    public class timelimit_demo : MonoBehaviour
    {
        [SerializeField]
        private Sprite sprite_green;

        [SerializeField]
        private Sprite sprite_red;

        public float limit_demo;

        [SerializeField]
        private float time_limit;


        [SerializeField]
        private GameObject limit;

        public bool collision_demo = false;
        public int time_collision = 0;

        private bool timeloss = false;
        private bool enoughtime = true;
        public bool demostart = false;
        // Start is called before the first frame update
        void Start()
        {
            limit_demo = time_limit;
        }

        // Update is called once per frame
        void Update()
        {
            if (demostart)
            {
                if (limit_demo > 0)
                {
                    limit_demo -= Time.deltaTime;
                    limit.GetComponent<Text>().text = "TIME: " + limit_demo.ToString("f1");
                    this.gameObject.GetComponent<Image>().fillAmount -= Time.deltaTime / time_limit;
                    if (limit_demo < 5 && enoughtime)
                    {
                        limit.gameObject.GetComponent<Text>().color = new Color(255f, 0, 0);
                        this.gameObject.GetComponent<Image>().sprite = sprite_red;
                        enoughtime = false;
                    }
                }
            }
            if (collision_demo)
            {
                changered();
                limit_demo -= 1.0f;
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                if (limit_demo > 6.0f)
                {
                    Invoke("changeblack", 1.0f);
                }
                Invoke("vib", 1.0f);
                collision_demo = false;
            }
        }

        private void changeblack()
        {
            limit.gameObject.GetComponent<Text>().color = new Color(0, 0, 0);
        }
        private void changered()
        {
            limit.gameObject.GetComponent<Text>().color = new Color(255f, 0, 0);
        }
        void vib()
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
    }
}