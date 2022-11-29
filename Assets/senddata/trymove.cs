using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trymove : MonoBehaviour
{
    private float _time = 0;
    private Vector3 defalutpos;

    // Start is called before the first frame update
    void Start()
    {
        defalutpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
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