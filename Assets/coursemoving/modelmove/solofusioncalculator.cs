using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class solofusioncalculator : MonoBehaviour
    {
        [SerializeField] Transform _realpos;
        [SerializeField] Transform _modelpos;
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        [SerializeField] modelmove _modelmove;
        public float fusionrate;
        public int howmanypush = 0;
        public float howlongpush = 0;
        private Quaternion _previousRotation;
        private Quaternion _currentRotation;
        private Quaternion _currentReversedRotation;
        public enum experimental_condition
        {
            Full, Static, Increasing, Decreasing,Nothing,Gakun, Static75, Static25, Decreasing50,Decreasing25, Decreasing75,Decreasing0
        }
        public experimental_condition Experimental_Condition;
        public float course;
        private bool start_changing = false;
        private bool once = false;
        private float _time = 0;
        public float changetime = 30;
        // Start is called before the first frame update
        void Start()
        {

            if (Experimental_Condition.ToString() == "Static")
            {
                fusionrate = 50;
            }
            else if (Experimental_Condition.ToString() == "Increasing")
            {
                fusionrate = 30;
            }
            else if (Experimental_Condition.ToString() == "Decreasing")
            {
                fusionrate = 70;
            }
            else if (Experimental_Condition.ToString() == "Nothing")
            {
                fusionrate = 0;
            }else if(Experimental_Condition.ToString() == "Gakun")
            {
                fusionrate = 70;
            }
            else if (Experimental_Condition.ToString() == "Static25")
            {
                fusionrate = 25;
            }
            else if (Experimental_Condition.ToString() == "Static75")
            {
                fusionrate = 75;
            }
            else
            {
                fusionrate = 100;
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Experimental_Condition.ToString() == "Increasing")
            {
                if(_collision_Judgemnt.readyforgame_me && !once)
                {
                    once = true;
                    Invoke("start_change", 3.0f);
                }
                if (start_changing && fusionrate <= 70)
                {
                    fusionrate += 40 * Time.deltaTime / (_modelmove.fusionlength * 0.02f - 3.0f);
                }
            }
            else if (Experimental_Condition.ToString() == "Decreasing")
            {
                if (_collision_Judgemnt.readyforgame_me && !once)
                {
                    once = true;
                    Invoke("start_change", 3.0f);
                }
                if (start_changing && fusionrate >= 30)
                {
                    fusionrate -= 40 * Time.deltaTime / (_modelmove.fusionlength * 0.02f - 3.0f);
                }
            }else if(Experimental_Condition.ToString() == "Gakun")
            {
                if (_collision_Judgemnt.readyforgame_me && !once)
                {
                    once = true;
                    Invoke("start_change", 3.0f);
                }
                if (start_changing)
                {
                    _time += Time.deltaTime;
                    if(_time > 30 && fusionrate > 30)
                    {
                        fusionrate -= 1;
                    }
                }
            }
            else if (Experimental_Condition.ToString() == "Decreasing50")
            {
                if (_collision_Judgemnt.readyforgame_me && !once)
                {
                    once = true;
                    Invoke("start_change", 3.0f);
                }
                if (start_changing && fusionrate >= 50)
                {
                    fusionrate -= 50 * Time.deltaTime / changetime;
                }
            }
            else if (Experimental_Condition.ToString() == "Decreasing25")
            {
                if (_collision_Judgemnt.readyforgame_me && !once)
                {
                    once = true;
                    Invoke("start_change", 3.0f);
                }
                if (start_changing && fusionrate >= 25)
                {
                    fusionrate -= 75 * Time.deltaTime / changetime;
                }
            }
            else if (Experimental_Condition.ToString() == "Decreasing75")
            {
                if (_collision_Judgemnt.readyforgame_me && !once)
                {
                    once = true;
                    Invoke("start_change", 3.0f);
                }
                if (start_changing && fusionrate >= 75)
                {
                    fusionrate -= 25 * Time.deltaTime / changetime;
                }
            }
            else if (Experimental_Condition.ToString() == "Decreasing0")
            {
                if (_collision_Judgemnt.readyforgame_me && !once)
                {
                    once = true;
                    Invoke("start_change", 3.0f);
                }
                if (start_changing && fusionrate >= 0)
                {
                    fusionrate -= 100 * Time.deltaTime / changetime;
                }
                else if(start_changing)
                {
                    fusionrate = 0;
                }
            }


            this.transform.position = (_realpos.position * fusionrate + _modelpos.position * (100 - fusionrate)) / 100;
            _currentRotation = Quaternion.Lerp(_modelpos.rotation, _realpos.rotation, (float)(fusionrate / 100f));
            _currentReversedRotation = Quaternion.AngleAxis(180, _currentRotation * this.transform.forward) * _currentRotation;
            this.transform.rotation = GetNearestQuaternion(_currentRotation, _currentReversedRotation, _previousRotation);
            _previousRotation = this.transform.rotation;

            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,OVRInput.Controller.LTouch) && _collision_Judgemnt.readyforgame_me )
            {
                howmanypush += 1;
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
                howlongpush += Time.deltaTime;
            }else if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) && _collision_Judgemnt.readyforgame_me)
            {
                howlongpush += Time.deltaTime;
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
            }
            else
            {           
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            }
        }

        static public Quaternion GetNearestQuaternion(Quaternion rot1, Quaternion rot2, Quaternion refRot)
        {
            return (Mathf.Abs(Quaternion.Dot(rot1, refRot)) > Mathf.Abs(Quaternion.Dot(rot2, refRot))) ? rot1 : rot2;
        }
        private void start_change()
        {
            start_changing = true;
        }
    }
}
