using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samplemoveforcourse4 : MonoBehaviour
{
    private float _time;
    List<Vector3> _pos;
    private Vector3 startpos = new Vector3(-0.76f, 1.517f, 0.648f);
    private Vector3 pos1 = new Vector3(-0.3713f, 1.517f, 0.648f);
    private Vector3 pos2 = new Vector3(-0.3713f, 1.4419f, 0.648f);
    private Vector3 pos3 = new Vector3(-0.6368f, 1.4419f, 0.648f);
    private Vector3 pos4 = new Vector3(-0.6368f, 1.3641f, 0.648f);
    private Vector3 pos5 = new Vector3(-0.3802f, 1.3641f, 0.648f);
    private Vector3 pos6 = new Vector3(-0.3802f, 1.2783f, 0.648f);
    private Vector3 pos7 = new Vector3(-0.6395f, 1.2783f, 0.648f);
    private Vector3 pos8 = new Vector3(-0.6395f, 1.1907f, 0.648f);
    private Vector3 pos9 = new Vector3(-0.374f, 1.1907f, 0.648f);
    private Vector3 pos10 = new Vector3(-0.374f, 1.1183f, 0.648f);
    private Vector3 pos11 = new Vector3(-0.6467f, 1.1183f, 0.648f);
    private Vector3 pos12 = new Vector3(-0.6467f, 0.909f, 0.648f);
    private Vector3 pos13 = new Vector3(-0.4115f, 0.909f, 0.648f);
    private Vector3 pos14 = new Vector3(-0.4115f, 0.943f, 0.648f);//
    private Vector3 pos15 = new Vector3(-0.2568f, 0.943f, 0.648f);
    private Vector3 pos16 = new Vector3(-0.2568f, 0.9028f, 0.648f);
    private Vector3 pos17 = new Vector3(-0.1361f, 0.9028f, 0.648f);
    private Vector3 pos18 = new Vector3(-0.1361f, 1.1146f, 0.648f);
    private Vector3 pos19 = new Vector3(-0.2433f, 1.1146f, 0.648f);
    private Vector3 pos20 = new Vector3(-0.2433f, 1.5095f, 0.648f);
    private Vector3 pos21 = new Vector3(-0.1083f, 1.5095f, 0.648f);
    private Vector3 pos22 = new Vector3(-0.1083f, 1.1989f, 0.648f);
    private Vector3 pos23 = new Vector3(0.0315f, 1.1989f, 0.648f);
    private Vector3 pos24 = new Vector3(0.0315f, 1.5046f, 0.648f);
    private Vector3 pos25 = new Vector3(0.1084f, 1.5046f, 0.648f);
    private Vector3 pos26 = new Vector3(0.1084f, 1.1139f, 0.648f);
    private Vector3 pos27 = new Vector3(-0.026f, 1.1139f, 0.648f);
    private Vector3 pos28 = new Vector3(-0.026f, 1.027f, 0.648f);
    private Vector3 pos29 = new Vector3(0.1128f, 1.027f, 0.648f);
    private Vector3 pos30 = new Vector3(0.1128f, 0.9546f, 0.648f);
    private Vector3 pos31 = new Vector3(-0.0213f, 0.9546f, 0.648f);
    private Vector3 pos32 = new Vector3(-0.0213f, 0.8429f, 0.648f);
    private Vector3 pos33 = new Vector3(0.3479f, 0.8429f, 0.648f);
    private Vector3 pos34 = new Vector3(0.3479f, 0.9529f, 0.648f);
    private Vector3 pos35 = new Vector3(0.2263f, 0.9529f, 0.648f);
    private Vector3 pos36 = new Vector3(0.2263f, 1.0325f, 0.648f);
    private Vector3 pos37 = new Vector3(0.3541f, 1.0325f, 0.648f);
    private Vector3 pos38 = new Vector3(0.3541f, 1.1094f, 0.648f);
    private Vector3 pos39 = new Vector3(0.2245f, 1.1094f, 0.648f);
    private Vector3 pos40 = new Vector3(0.2245f, 1.5152f, 0.648f);
    private Vector3 pos41 = new Vector3(0.2996f, 1.5152f, 0.648f);
    private Vector3 pos42 = new Vector3(0.2996f, 1.198f, 0.648f);
    private Vector3 pos43 = new Vector3(0.438f, 1.198f, 0.648f);
    private Vector3 pos44 = new Vector3(0.438f, 1.507f, 0.648f);
    private Vector3 pos45 = new Vector3(0.583f, 1.507f, 0.648f);
    private Vector3 pos46 = new Vector3(0.583f, 1.1155f, 0.648f);
    private Vector3 pos47 = new Vector3(0.4632f, 1.1155f, 0.648f);
    private Vector3 pos48 = new Vector3(0.4632f, 0.902f, 0.648f);
    private Vector3 pos49 = new Vector3(0.581f, 0.902f, 0.648f);
    private Vector3 pos50 = new Vector3(0.581f, 0.9431f, 0.648f);//
    private Vector3 pos51 = new Vector3(0.7554f, 0.9431f, 0.648f);
    private Vector3 pos52 = new Vector3(0.7554f, 0.8984f, 0.648f);
    private Vector3 pos53 = new Vector3(0.9816f, 0.8984f, 0.648f);
    private Vector3 pos54 = new Vector3(0.9816f, 1.1113f, 0.648f);
    private Vector3 pos55 = new Vector3(0.71f, 1.1113f, 0.648f);
    private Vector3 pos56 = new Vector3(0.71f, 1.1953f, 0.648f);
    private Vector3 pos57 = new Vector3(0.9791f, 1.1953f, 0.648f);
    private Vector3 pos58 = new Vector3(0.9791f, 1.2766f, 0.648f);
    private Vector3 pos59 = new Vector3(0.7091f, 1.2766f, 0.648f);
    private Vector3 pos60 = new Vector3(0.7091f, 1.3525f, 0.648f);
    private Vector3 pos61 = new Vector3(0.971f, 1.3525f, 0.648f);
    private Vector3 pos62 = new Vector3(0.971f, 1.4329f, 0.648f);
    private Vector3 pos63 = new Vector3(0.7055f, 1.4329f, 0.648f);
    private Vector3 pos64 = new Vector3(0.7055f, 1.5169f, 0.648f);
    private Vector3 pos65 = new Vector3(1.0631f, 1.5169f, 0.648f);



    float[] _interbal = { 0, 3,1.8f,0.7f,1.5f,0.7f,1.5f,0.7f,1.5f,0.7f,1.5f,0.7f,1.5f,1.5f,1.3f,0.3f,1.6f,0.3f,0.8f,1f,0.8f,2f,1f,2f,1f,2f,0.8f,2f,0.9f,0.6f,1f,0.7f,1.2f,0.7f,1.5f,0.6f,0.9f,0.5f,0.9f,0.5f,0.9f,2f,0.6f,2f,1f,2f,1f,2f,1.2f,1.2f,1.2f,0.3f,2f,0.3f,1.6f,1.6f,1.5f,0.5f, 1.5f, 0.5f, 1.5f, 0.5f, 1.5f, 0.5f, 1.5f, 0.5f, 1.9f, 1f};
    private float _timefornext;
    private int _numberpos = 0;
    private float radius1;
    private float radius2;



    // Start is called before the first frame update
    void OnEnable()
    {
        _pos = new List<Vector3>() { startpos, startpos, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10, pos11, pos12, pos13, pos14, pos15, pos16, pos17, pos18, pos19, pos20, pos21, pos22, pos23, pos24, pos25, pos26, pos27, pos28, pos29, pos30, pos31, pos32, pos33, pos34, pos35, pos36, pos37, pos38, pos39, pos40, pos41, pos42, pos43, pos44, pos45, pos46, pos47, pos48, pos49, pos50, pos51, pos52, pos53, pos54, pos55, pos56, pos57, pos58, pos59, pos60, pos61, pos62, pos63, pos64, pos65, pos65};
        this.gameObject.transform.position = startpos;
        _timefornext = _interbal[1];
        radius1 = (pos15.x - pos14.x)/2;
        radius2 = (pos51.x - pos50.x)/2;
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

        if (_numberpos == 15)
        {
            roundsphere(_pos[_numberpos], _pos[_numberpos + 1], _timefornext - _interbal[_numberpos + 1], _timefornext, radius1, true);
        }else if(_numberpos == 51)
        {
            roundsphere(_pos[_numberpos], _pos[_numberpos + 1], _timefornext - _interbal[_numberpos + 1], _timefornext, radius2, true);
        }
        else
        {
            movesphere(_pos[_numberpos], _pos[_numberpos + 1], _timefornext - _interbal[_numberpos + 1], _timefornext);
        }

        _time += Time.deltaTime;

    }

    void movesphere(Vector3 _startpos, Vector3 _endpos, float _starttime, float _endtime)
    {
        this.transform.position = (_endpos * (_time - _starttime) + _startpos * (_endtime - _time)) / (_endtime - _starttime);
    }
    void roundsphere(Vector3 _startpos, Vector3 _endpos, float _starttime, float _endtime, float _radius, bool _clockwise)
    {
        float theta = (_time - _starttime) * Mathf.PI / (_endtime - _starttime);

        if (_clockwise)
        {
            this.transform.position = (_endpos + _startpos) / 2 + _radius * new Vector3(Mathf.Cos(theta) * (-1), Mathf.Sin(theta), 0);
        }
        else
        {
            this.transform.position = (_endpos + _startpos) / 2 + _radius * new Vector3(Mathf.Cos(theta) * (-1), Mathf.Sin(theta) * (-1), 0);
        }

    }
}