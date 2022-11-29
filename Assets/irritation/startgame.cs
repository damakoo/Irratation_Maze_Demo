using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CoEmbodimentSystem
{
    public class startgame : MonoBehaviour
    {
        [SerializeField] private GameObject countdown;
        [SerializeField] collision_check _collision_Check;

        GameObject gameobject0;
        //GameObject Timelimit;
        collision_judgemnt Collision_Judgemnt;
        //GameObject Canvas;
        //timelimit TimeLimit;
        private bool up_start = false;
        private float downcount = 0;
        private float changetime = 0.3f;
        private bool _goal = false;
        //[SerializeField] mingturn Mingturn;
        //GameObject Panel;
        private bool starting_game = false;
        private Vector3 initialScale;

        public enum judgment
        {
            START, GOAL,
        }
        public judgment Judgment;
        // Start is called before the first frame update
        void OnEnable()
        {
            gameobject0 = GameObject.Find("irritation_system/GameObject");
            Collision_Judgemnt = gameobject0.gameObject.GetComponent<collision_judgemnt>();
            //Canvas = GameObject.Find("CoEmbodimentSystem/Avatar/Game_engine/Root/pelvis/spine_01/spine_02/spine_03/clavicle_r/upperarm_r/lowerarm_r/hand_r/Canvas");
            //TimeLimit = Canvas.gameObject.GetComponent<timelimit>();
            //Timelimit = GameObject.Find("CoEmbodimentSystem/Avatar/Game_engine/Root/pelvis/spine_01/spine_02/spine_03/clavicle_r/upperarm_r/lowerarm_r/hand_r/Canvas/timelimit");
            //Panel = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor/Canvas/Panel");
            //Mingturn = Panel.gameObject.GetComponent<mingturn>();
            initialScale = countdown.GetComponent<RectTransform>().localScale;
        }


        // Update is called once per frame
        void Update()
        {
            if (up_start && downcount < changetime)
            {
                countdown.GetComponent<Text>().color += new Color(255 * Time.deltaTime / changetime, 0, 0);
                countdown.GetComponent<RectTransform>().localScale += new Vector3(0.005f, 0.005f, 0);
                downcount += Time.deltaTime;
            }
            else if (downcount >= changetime && downcount < changetime * 2)
            {
                countdown.GetComponent<Text>().color = new Color(255 * (1 - Time.deltaTime / changetime), 0, 0);
                countdown.GetComponent<RectTransform>().localScale -= new Vector3(0.005f, 0.005f, 0);
                downcount += Time.deltaTime;
            }
            else
            {
                up_start = false;
                downcount = 0;
                countdown.GetComponent<Text>().color = new Color(0, 0, 0);
                countdown.GetComponent<RectTransform>().localScale = initialScale;
            }
            if (_goal && downcount < changetime)
            {
                countdown.GetComponent<Text>().color += new Color(255 * Time.deltaTime / changetime, 0, 0);
                countdown.GetComponent<RectTransform>().localScale += new Vector3(0.005f, 0.005f, 0);
                downcount += Time.deltaTime;
            }
            else if (downcount >= changetime && downcount < changetime * 2)
            {
                countdown.GetComponent<Text>().color = new Color(255 * (1 - Time.deltaTime / changetime), 0, 0);
                countdown.GetComponent<RectTransform>().localScale -= new Vector3(0.005f, 0.005f, 0);
                downcount += Time.deltaTime;
            }
            if (!Collision_Judgemnt.start_game && Judgment.ToString() == "START" && _collision_Check.collisioned)
            {
                startinggame();
            }
            if(Collision_Judgemnt.start_game && Judgment.ToString() == "GOAL" && _collision_Check.collisioned)
            {
                Collision_Judgemnt.start_game = false;
                Collision_Judgemnt.collision = 0;
                up_start = true;
            }

        }
        void startinggame()
        {
            Collision_Judgemnt.start_game = true;
            up_start = true;
        }
       

    }
}

