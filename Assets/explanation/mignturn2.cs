using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CoEmbodimentSystem
{
    public class mignturn2 : MonoBehaviour
    {
        [SerializeField] GameObject clear;
        [SerializeField] GameObject thank;
        [SerializeField] GameObject headset;
        [SerializeField] GameObject survey;

        private bool up = true;
        private float i = 0;
        public bool fade2 = false;
        private float transparency = 0;
        private float transparency_time = 0.5f;
        private float fadetime = 0.9f;
        // Start is called before the first frame update

        private void Start()
        {
            this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            clear.gameObject.GetComponent<Text>().color = new Color(255, 0, 0, 0);
            thank.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);
            headset.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);
            survey.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }
        // Update is called once per frame
        void Update()
        {
            if (fade2)
            {
                if (transparency <= 1)
                {
                    transparency += Time.deltaTime / transparency_time;
                }
                if (up)
                {
                    i += 1;
                    if (i > 19)
                    {
                        up = false;
                    }
                }
                else
                {
                    i -= 1;
                    if (i < 1)
                    {
                        up = true;
                    }
                }
                headset.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, i / 20);
                thank.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, transparency);
                clear.gameObject.GetComponent<Text>().color = new Color(255, 0, 0, transparency);
                survey.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, transparency);
                this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, transparency);
            }



        }
    }
}