using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecylinderfor1 : MonoBehaviour
{
    private float _time = 0;
    Vector3 defalutpos;
    public float _timedelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        defalutpos = this.transform.position;
        _time = _timedelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (_time % 3 < 1.5f)
        {
            this.transform.position = defalutpos + new Vector3(0.06f * (_time % 3), 0, 0);
        }
        else
        {
            this.transform.position = defalutpos + new Vector3(0.06f * (3 - _time % 3), 0, 0);
        }
    }
}
