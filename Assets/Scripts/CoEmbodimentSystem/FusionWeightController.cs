using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace CoEmbodimentSystem
{
    public class FusionWeightController : NetworkBehaviour
    {
        public enum ButtonInput
        {
            GuiButton,

            InclimentButton,

            DeclimentButton,
        }

        private Dictionary<ButtonInput, bool> _buttonInputs = new Dictionary<ButtonInput, bool>();

        public int HostWeightPercentage { get; private set; }

        private int _currentWeight;

        private PlayerCommands _playerCommands;

        [SerializeField] private int _defaultHostWeightPercentage;
        [SerializeField] private GameObject _guiCanvas;
        [SerializeField] private Text _selfWeightValue;

        public enum experimental_condition
        {
            Constant,
            Dynamic,
        }
        public experimental_condition Experimental_Condition;
        collision_judgemnt Collision_Judgemnt;
        GameObject gameobject0;

        void Start()
        {
            //dynamic1 = GameObject.Find("irritation_system/ROOT2/ROOT2_child/dynamic1").gameObject.GetComponent<dynamiccontrol>();
           // dynamic2 = GameObject.Find("irritation_system/ROOT3/ROOT3_child/dynamic2").gameObject.GetComponent<dynamiccontrol>();
            //HostWeightPercentage = _defaultHostWeightPercentage;
            gameobject0 = GameObject.Find("irritation_system/GameObject");
            Collision_Judgemnt = gameobject0.gameObject.GetComponent<collision_judgemnt>();
            _buttonInputs.Add(ButtonInput.GuiButton, false);
            _buttonInputs.Add(ButtonInput.InclimentButton, false);
            _buttonInputs.Add(ButtonInput.DeclimentButton, false);

            _guiCanvas.SetActive(false);

            if (Experimental_Condition.ToString() == "Constant")
            {
                HostWeightPercentage = 50;
            }
            else
            {
                HostWeightPercentage = 70;
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (isServer)
            {
                _currentWeight = HostWeightPercentage;
            }
            else
            {
                _currentWeight = 100 - HostWeightPercentage;
            }

            if (_buttonInputs[ButtonInput.GuiButton])
            {
                _guiCanvas.SetActive(true);

                if (_buttonInputs[ButtonInput.InclimentButton])
                {
                    if (_currentWeight < 100)
                    {
                        _currentWeight++;
                        if (isServer)
                        {
                            _playerCommands.CmdChangeHostWeight(_currentWeight);
                        }
                        else
                        {
                            _playerCommands.CmdChangeHostWeight(100 - _currentWeight);
                        }
                    }
                }
                if (_buttonInputs[ButtonInput.DeclimentButton])
                {
                    if (_currentWeight > 0)
                    {
                        _currentWeight--;
                        if (isServer)
                        {
                            _playerCommands.CmdChangeHostWeight(_currentWeight);
                        }
                        else
                        {
                            _playerCommands.CmdChangeHostWeight(100 - _currentWeight);
                        }
                    }
                }

                _selfWeightValue.text = _currentWeight.ToString();
            }
            else
            {
                _guiCanvas.SetActive(false);
            }
        }

        public void SetButtonInput(ButtonInput buttonInput, bool isPressed)
        {
            _buttonInputs[buttonInput] = isPressed;
        }

        public void ChangeHostWeight(int val)
        {
            HostWeightPercentage = val;
        }

        public void SetPlayerCommands(PlayerCommands playerCommands)
        {
            _playerCommands = playerCommands;
        }
    }
}