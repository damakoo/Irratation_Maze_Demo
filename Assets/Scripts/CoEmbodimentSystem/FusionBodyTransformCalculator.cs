using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class FusionBodyTransformCalculator : MonoBehaviour
    {
        private Transform _hostIkTarget;
        private Transform _clientIkTarget;
        public bool connectionjudge = false;

        [SerializeField] private FusionWeightController _fusionWeightController;
        [SerializeField] private NetworkDiscoveryStarter _networkDiscoveryStarter;
        [SerializeField] private bool _isopponent;

        private Quaternion _previousRotation;
        private Quaternion _currentRotation;
        private Quaternion _currentReversedRotation;

        [SerializeField] private GameObject _realposition;

        collision_judgemnt Collision_Judgemnt;
        GameObject gameobject0;

        private float dynamicchangetime = 3.0f;
        private float hostWeight_dynamic;
        //FusionWeightController fusionweightcontroller;

        private bool _isFirstFrame = true;

        [SerializeField] private BodyPart _bodyPart;
        public BodyPart ThisBodyPart { get { return _bodyPart; } }

        private bool _isFusionStarted;
        private void Start()
        {
            //dynamic1 = GameObject.Find("irritation_system/ROOT2/ROOT2_child/dynamic1").gameObject.GetComponent<dynamiccontrol>();
            //dynamic2 = GameObject.Find("irritation_system/ROOT3/ROOT3_child/dynamic2").gameObject.GetComponent<dynamiccontrol>();
            //fusionweightcontroller = GameObject.Find("CoEmbodimentsystem/WeightShifter").gameObject.GetComponent<FusionWeightController>();
            gameobject0 = GameObject.Find("irritation_system/GameObject");
            Collision_Judgemnt = gameobject0.gameObject.GetComponent<collision_judgemnt>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_fusionWeightController.gameObject.activeSelf)
            {
                if (_hostIkTarget != null && _clientIkTarget != null)
                {
                    if (!connectionjudge)
                    {
                        connectionjudge = true;
                    }
                    CalculateTransform();
                    if (_isFusionStarted)
                    {
                        return;
                    }
                    _isFusionStarted = true;
                    this.GetComponent<WristCorrector>().StartCorrectingWrist();
                }
                else
                {
                    if (!_isFusionStarted)
                    {
                        return;
                    }
                    _isFusionStarted = false;
                    this.GetComponent<WristCorrector>().StopCorrectingWrist();
                }
            }
            else
            {
                if (_isFusionStarted)
                {
                    _isFusionStarted = false;
                    this.GetComponent<WristCorrector>().StopCorrectingWrist();
                }
            }
        }

        public void SetIkTarget(Transform target, bool isHost)
        {
            if (isHost)
            {
                _hostIkTarget = target;
            }
            else
            {
                _clientIkTarget = target;
            }
        }

        private void CalculateTransform()
        {  
                hostWeight_dynamic = 50f;
                

               
                    this.transform.position = (_hostIkTarget.position * (float)hostWeight_dynamic + _clientIkTarget.position * (float)(100 - hostWeight_dynamic)) / 100f;

                    if (_bodyPart == BodyPart.LeftHand || _bodyPart == BodyPart.RightHand)
                    {
                        _currentRotation = Quaternion.Lerp(_clientIkTarget.rotation, _hostIkTarget.rotation, (float)(hostWeight_dynamic / 100f));
                        _currentReversedRotation = Quaternion.AngleAxis(180, _currentRotation * this.transform.forward) * _currentRotation;

                        if (_isFirstFrame)
                        {
                            _previousRotation = _currentRotation;
                            _isFirstFrame = false;
                            this.transform.rotation = _currentRotation;
                        }
                        else
                        {
                            this.transform.rotation = GetNearestQuaternion(_currentRotation, _currentReversedRotation, _previousRotation);
                        }

                        _previousRotation = this.transform.rotation;
                        this.transform.position -= this.transform.forward*0.1f;
                    }
        }

        static public Quaternion GetNearestQuaternion(Quaternion rot1, Quaternion rot2, Quaternion refRot)
        {
            return (Mathf.Abs(Quaternion.Dot(rot1, refRot)) > Mathf.Abs(Quaternion.Dot(rot2, refRot))) ? rot1 : rot2;
        }
    }
}
