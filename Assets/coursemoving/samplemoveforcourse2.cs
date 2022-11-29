using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samplemoveforcourse2 : MonoBehaviour
{
    private float _time;
    List<Vector3> _pos;
    private Vector3 startpos = new Vector3(-0.928f, 0.829f, 0.648f);
    private Vector3 pos1 = new Vector3(-0.731f, 0.829f, 0.648f);
    private Vector3 pos2 = new Vector3(-0.731f, 1.481f, 0.648f);
    private Vector3 pos3 = new Vector3(-0.642f, 1.481f, 0.648f);
    private Vector3 pos4 = new Vector3(-0.642f, 0.851f, 0.648f);
    private Vector3 pos5 = new Vector3(-0.54f, 0.851f, 0.648f);
    private Vector3 pos6 = new Vector3(-0.54f, 1.548f, 0.648f);
    private Vector3 pos7 = new Vector3(0.036f, 1.548f, 0.648f);
    private Vector3 pos8 = new Vector3(0.036f, 1.4659f, 0.648f);
    private Vector3 pos9 = new Vector3(-0.441f, 1.4659f, 0.648f);
    private Vector3 pos10 = new Vector3(-0.441f, 1.377f, 0.648f);
    private Vector3 pos11 = new Vector3(0.0366f, 1.377f, 0.648f);
    private Vector3 pos12 = new Vector3(0.0366f, 0.921f, 0.648f);
    private Vector3 pos13 = new Vector3(-0.357f, 0.921f, 0.648f);
    private Vector3 pos14 = new Vector3(-0.357f, 1.017f, 0.648f);
    private Vector3 pos15 = new Vector3(-0.063f, 1.017f, 0.648f);
    private Vector3 pos16 = new Vector3(-0.063f, 1.267f, 0.648f);
    private Vector3 pos17 = new Vector3(-0.453f, 1.267f, 0.648f);
    private Vector3 pos18 = new Vector3(-0.453f, 0.8361f, 0.648f);
    private Vector3 pos19 = new Vector3(0.6203f, 0.8361f, 0.648f);
    private Vector3 pos20 = new Vector3(0.6203f, 1.271f, 0.648f);
    private Vector3 pos21 = new Vector3(0.2335f, 1.271f, 0.648f);
    private Vector3 pos22 = new Vector3(0.2335f, 1.0341f, 0.648f);
    private Vector3 pos23 = new Vector3(0.5177f, 1.0341f, 0.648f);
    private Vector3 pos24 = new Vector3(0.5177f, 0.9205f, 0.648f);
    private Vector3 pos25 = new Vector3(0.13f, 0.9205f, 0.648f);
    private Vector3 pos26 = new Vector3(0.13f, 1.368f, 0.648f);
    private Vector3 pos27 = new Vector3(0.6208f, 1.368f, 0.648f);
    private Vector3 pos28 = new Vector3(0.6208f, 1.4619f, 0.648f);
    private Vector3 pos29 = new Vector3(0.1386f, 1.4619f, 0.648f);
    private Vector3 pos30 = new Vector3(0.1386f, 1.5498f, 0.648f);
    private Vector3 pos31 = new Vector3(0.7144f, 1.5498f, 0.648f);
    private Vector3 pos32 = new Vector3(0.7144f, 0.83f, 0.648f);
    private Vector3 pos33 = new Vector3(0.8147f, 0.83f, 0.648f);
    private Vector3 pos34 = new Vector3(0.8147f, 1.479f, 0.648f);
    private Vector3 pos35 = new Vector3(0.9f, 1.479f, 0.648f);
    private Vector3 pos36 = new Vector3(0.9f, 0.832f, 0.648f);
    private Vector3 pos37 = new Vector3(1.069f, 0.832f, 0.648f);

    float[] _interbal = { 0, 3, 0.8f, 4.3f, 0.6f, 4.4f, 0.6f, 4.4f, 3.2f, 0.6f, 3.2f, 0.6f, 3.2f, 3.2f, 3.2f, 0.6f, 1.8f, 1.8f, 2.6f, 2.5f, 4.5f, 2.5f, 2.6f, 1.8f, 1.8f, 0.6f, 3.2f, 3.2f, 3.2f, 0.6f, 3.2f, 0.6f, 3.2f, 4.4f, 0.6f, 4.4f, 0.6f, 4.3f, 0.8f, 1f };
    private float _timefornext;
    private int _numberpos = 0;



    // Start is called before the first frame update
    void OnEnable()
    {
        _pos = new List<Vector3>() { startpos, startpos, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10, pos11, pos12, pos13, pos14, pos15, pos16, pos17, pos18, pos19, pos20, pos21, pos22, pos23, pos24, pos25, pos26, pos27, pos28, pos29, pos30, pos31, pos32, pos33, pos34, pos35, pos36, pos37, pos37 };
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
