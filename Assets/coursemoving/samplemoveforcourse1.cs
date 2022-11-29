using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samplemoveforcourse1 : MonoBehaviour
{
    private float _time;
    List<Vector3> _pos;
    private Vector3 startpos = new Vector3(-0.846f, 1.153f, 0.648f);
    private Vector3 pos1 = new Vector3(-0.64f, 1.153f, 0.648f);
    private Vector3 pos2 = new Vector3(-0.631f, 1.573f, 0.648f);
    private Vector3 pos3 = new Vector3(-0.558f, 1.573f, 0.648f);
    private Vector3 pos4 = new Vector3(-0.558f, 0.817f, 0.648f);
    private Vector3 pos5 = new Vector3(-0.475f, 0.817f, 0.648f);
    private Vector3 pos6 = new Vector3(-0.475f, 1.572f, 0.648f);
    private Vector3 pos7 = new Vector3(-0.402f, 1.573f, 0.648f);
    private Vector3 pos8 = new Vector3(-0.402f, 1.086f, 0.648f);
    private Vector3 pos9 = new Vector3(-0.105f, 1.086f, 0.648f);
    private Vector3 pos10 = new Vector3(-0.105f, 1.163f, 0.648f);
    private Vector3 pos11 = new Vector3(-0.311f, 1.163f, 0.648f);
    private Vector3 pos12 = new Vector3(-0.311f, 1.259f, 0.648f);
    private Vector3 pos13 = new Vector3(-0.102f, 1.259f, 0.648f);
    private Vector3 pos14 = new Vector3(-0.102f, 1.354f, 0.648f);
    private Vector3 pos15 = new Vector3(-0.295f, 1.354f, 0.648f);
    private Vector3 pos16 = new Vector3(-0.295f, 1.438f, 0.648f);
    private Vector3 pos17 = new Vector3(0.017f, 1.438f, 0.648f);
    private Vector3 pos18 = new Vector3(0.017f, 0.934f, 0.648f);
    private Vector3 pos19 = new Vector3(-0.33f, 0.934f, 0.648f);
    private Vector3 pos20 = new Vector3(-0.33f, 0.832f, 0.648f);
    private Vector3 pos21 = new Vector3(0.503f, 0.832f, 0.648f);
    private Vector3 pos22 = new Vector3(0.503f, 0.94f, 0.648f);
    private Vector3 pos23 = new Vector3(0.1572f,0.94f , 0.648f);
    private Vector3 pos24 = new Vector3(0.1572f, 1.4381f, 0.648f);
    private Vector3 pos25 = new Vector3(0.488f, 1.4381f, 0.648f);
    private Vector3 pos26 = new Vector3(0.488f, 1.3589f, 0.648f);
    private Vector3 pos27 = new Vector3(0.273f, 1.3589f, 0.648f);
    private Vector3 pos28 = new Vector3(0.273f, 1.2638f, 0.648f);
    private Vector3 pos29 = new Vector3(0.488f, 1.2638f, 0.648f);
    private Vector3 pos30 = new Vector3(0.488f, 1.1697f, 0.648f);
    private Vector3 pos31 = new Vector3(0.2711f, 1.1697f, 0.648f);
    private Vector3 pos32 = new Vector3(0.2711f, 1.0756f, 0.648f);
    private Vector3 pos33 = new Vector3(0.58f, 1.0756f, 0.648f);
    private Vector3 pos34 = new Vector3(0.58f, 1.5825f, 0.648f);
    private Vector3 pos35 = new Vector3(0.65f, 1.5825f, 0.648f);
    private Vector3 pos36 = new Vector3(0.65f, 0.81f, 0.648f);
    private Vector3 pos37 = new Vector3(0.732f, 0.81f, 0.648f);
    private Vector3 pos38 = new Vector3(0.732f, 1.582f, 0.648f);
    private Vector3 pos39 = new Vector3(0.8032f, 1.582f, 0.648f);
    private Vector3 pos40 = new Vector3(0.8032f, 1.148f, 0.648f);
    private Vector3 pos41 = new Vector3(1f, 1.148f, 0.648f);
    float[] _interbal = { 0, 3, 1.8f, 2.7f, 0.6f, 4f, 0.6f, 4f, 0.5f, 2.6f, 2f, 0.6f, 1.3f, 0.5f, 1.3f, 0.5f, 1.5f, 0.6f, 2.5f, 2.8f, 1.8f, 0.6f, 4.5f,0.6f,1.8f,2.8f,2.5f,0.6f,1.5f,0.5f,1.3f,0.5f,1.3f,0.6f,2f,2.6f,0.5f,4f,0.6f,4f,0.6f,2.7f,1.8f,1f };
    private float _timefornext;
    private int _numberpos = 0;



    // Start is called before the first frame update
    void OnEnable()
    {
        _pos = new List<Vector3>() { startpos, startpos, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10, pos11, pos12, pos13, pos14, pos15, pos16, pos17, pos18, pos19, pos20, pos21, pos22, pos23, pos24, pos25, pos26, pos27, pos28, pos29, pos30, pos31, pos32, pos33, pos34, pos35, pos36, pos37, pos38, pos39, pos40, pos41,pos41 };
        this.gameObject.transform.position = startpos;
        _timefornext = _interbal[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > _timefornext)
        {
            _numberpos += 1;
            if (_numberpos + 1 > _interbal.Length)
            {
                Destroy(this.gameObject);
            }
            _timefornext += _interbal[_numberpos + 1];
        }

        movesphere(_pos[_numberpos], _pos[_numberpos + 1], _timefornext - _interbal[_numberpos + 1], _timefornext);

        _time += Time.deltaTime;

    }

    void movesphere(Vector3 _startpos, Vector3 _endpos, float _starttime, float _endtime)
    {
        this.transform.position = (_endpos * (_time - _starttime) + _startpos * (_endtime - _time)) / (_endtime - _starttime);
    }
}
