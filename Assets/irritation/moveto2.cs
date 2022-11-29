using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoEmbodimentSystem
{
    public class moveto2 : MonoBehaviour
    {
        private bool up_start = false;
        private float downcount = 0;
        private float changetime = 0.3f;
        private bool once = false;
        [SerializeField] GameObject _gameObject1;
        [SerializeField] GameObject _gameObject2;
        [SerializeField] GameObject _gameObject3;
        [SerializeField] GameObject _gameObject4;
        [SerializeField] GameObject _gameObject5;
        [SerializeField] GameObject _gameObject6;
        [SerializeField] GameObject _gameObject7;
        [SerializeField] GameObject _gameObject8;
        [SerializeField] GameObject _gameObject9;
        [SerializeField] GameObject _gameObject10;
        [SerializeField] GameObject _gameObject11;

        [SerializeField] GameObject _gameObjecta;
        [SerializeField] GameObject _gameObjectb;
        [SerializeField] GameObject _gameObjectc;
        [SerializeField] GameObject _gameObjectd;
        [SerializeField] GameObject _gameObjecte;
        [SerializeField] GameObject _gameObjectf;
        [SerializeField] samplemoveforcourse6_2 _samplemove;

        [SerializeField] collision_judgemnt _collision_Judgemnt;
        [SerializeField] GameObject _goal;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (up_start && downcount < changetime)
            {
                _goal.GetComponent<Text>().color += new Color(255 * Time.deltaTime / changetime, 0, 0);
                _goal.GetComponent<RectTransform>().localScale += new Vector3(0.005f, 0.005f, 0);
                downcount += Time.deltaTime;
            }
            else if (up_start && downcount >= changetime && downcount < changetime * 2)
            {
                _goal.GetComponent<Text>().color = new Color(255 * (1 - Time.deltaTime / changetime), 0, 0);
                _goal.GetComponent<RectTransform>().localScale -= new Vector3(0.005f, 0.005f, 0);
                downcount += Time.deltaTime;
            }
            if(!once && _samplemove._numberpos == 22)
            {
                once = true;
                Invoke("changeto2", 2.0f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "hitstick" && _collision_Judgemnt.start_game == true)
            {
                up_start = true;
            }
        }

        private void changeto2()
        {
            _gameObject1.gameObject.SetActive(true);
            _gameObject2.gameObject.SetActive(true);
            _gameObject3.gameObject.SetActive(true);
            _gameObject4.gameObject.SetActive(true);
            _gameObject5.gameObject.SetActive(true);
            _gameObject6.gameObject.SetActive(true);
            _gameObject7.gameObject.SetActive(true);
            _gameObject8.gameObject.SetActive(true);
            _gameObject9.gameObject.SetActive(true);
            _gameObject10.gameObject.SetActive(true);
            _gameObject11.gameObject.SetActive(true);

            _gameObjecta.gameObject.SetActive(false);
            _gameObjectb.gameObject.SetActive(false);
            _gameObjectc.gameObject.SetActive(false);
            _gameObjectd.gameObject.SetActive(false);
            _gameObjecte.gameObject.SetActive(false);
            _gameObjectf.gameObject.SetActive(false);
        }
    }
}
