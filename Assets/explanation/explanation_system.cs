using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class explanation_system : MonoBehaviour
    {
        public bool changing = false;
        private int exp_number = 1;
        GameObject explanation1;
        GameObject explanation2;
        [SerializeField] GameObject hitstick;
        [SerializeField] GameObject hitstick_opponent;
        [SerializeField] GameObject _avatar;
        [SerializeField] GameObject _sphere;
        GameObject gameobject0;
        collision_judgemnt Collision_Judgement;

        // Start is called before the first frame update
        void Awake()
        {
            explanation1 = GameObject.Find("Explanation/Explanation1");
            explanation2 = GameObject.Find("Explanation/Explanation2");
            explanation2.SetActive(false);
            //hitstick.SetActive(false);
            hitstick_opponent.SetActive(false);
            _avatar.SetActive(false);
            //canvas.SetActive(false);
            gameobject0 = GameObject.Find("irritation_system/GameObject");
            Collision_Judgement = gameobject0.gameObject.GetComponent<collision_judgemnt>();
            _sphere.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (changing)
            {
                changing = false;
                if (exp_number == 1)
                {
                    explanation1.SetActive(false);
                    explanation2.SetActive(true);
                    
                }
                else if (exp_number == 2)
                {
                    explanation2.SetActive(false);
                    Invoke("appear",2.0f);
                    Collision_Judgement.finish_explanation = true;
                }
                exp_number += 1;
            }
        }
        public void nextstage()
        {
            changing = true;
        }
        public void jumptonext(float jumptime)
        {
            Invoke("nextstage", jumptime);
        }
        private void appear()
        {
            _avatar.SetActive(true);
            hitstick_opponent.SetActive(true);
        }
    }
}