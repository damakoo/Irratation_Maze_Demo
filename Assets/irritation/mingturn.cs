using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoEmbodimentSystem
{
    public class mingturn : MonoBehaviour
    {
        [SerializeField] private GameObject stage;
        [SerializeField] private GameObject four;
        public bool fade = false;
        private bool fading = false;
        private bool forfade = false;
        private int stage_now = 0;

        private float transparency = 0;
        private float transparency_time = 0.3f;
        private float fadetime = 0.9f;
        // Start is called before the first frame update
        void Start()
        {
            this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            stage.gameObject.GetComponent<Text>().color = new Color(255, 0, 0, 0);
            four.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            if (fade)
            {
                if (!forfade)
                {
                    stage.gameObject.GetComponent<Text>().text = "STAGE " + stage_now.ToString();
                    forfade = true;
                    Invoke("becomefading", fadetime);
                }

                if (transparency <= 1 && !fading)
                {
                    transparency += Time.deltaTime / transparency_time;
                    stage.gameObject.GetComponent<Text>().color += new Color(0, 0, 0, Time.deltaTime / transparency_time);
                    four.gameObject.GetComponent<Text>().color += new Color(0, 0, 0, Time.deltaTime / transparency_time);

                }

                if (transparency > 0 && fading)
                {
                    transparency -= Time.deltaTime / transparency_time;
                    stage.gameObject.GetComponent<Text>().color -= new Color(0, 0, 0, Time.deltaTime / transparency_time);
                    four.gameObject.GetComponent<Text>().color -= new Color(0, 0, 0, Time.deltaTime / transparency_time);
                }
                else if (transparency < 0.0001f && fading)
                {
                    transparency = 0;
                    fade = false;
                    fading = false;
                    forfade = false;
                }
                this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, transparency);
            }

        }
        void becomefading()
        {
            fading = true;
        }
        void becomefade()
        {
            fade = true;
        }

        public void changestage(float starttime, float _transparency_time, float _fadetime, int _stage)
        {
            Invoke("becomefade", starttime);
            transparency_time = _transparency_time;
            fadetime = _fadetime;
            stage_now = _stage;
        }
    }
}