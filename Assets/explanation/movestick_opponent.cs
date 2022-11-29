using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoEmbodimentSystem
{
    public class movestick_opponent : MonoBehaviour
    {
        [SerializeField] GameObject theother;
        [SerializeField] start_game_replica _Start_Game_Repllica;
        private bool waitforstart = false;
        private bool move_start = false;
        [SerializeField] GameObject Replica;
        private Vector3 replica_pos;
        private int i = 0;
        // Start is called before the first frame update
        void Start()
        {
            replica_pos = Replica.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (!waitforstart)
            {
                Invoke("movestart", 3.6f);
                waitforstart = true;
            }
            Vector3 pos = this.gameObject.transform.position;
            if (move_start)
            {
                this.transform.position += (replica_pos - pos) / 50;
            }
            if (!_Start_Game_Repllica.downready && i < 41)
            {
                this.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0.015f * (40 - i));
                theother.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0.015f * (40 - i));
                i += 1;
            }

        }
        void movestart()
        {
            move_start = true;
        }

    }
}