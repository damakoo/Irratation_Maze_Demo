using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samplemoveforcourse3 : MonoBehaviour
{
    private float _time;
    List<Vector3> _pos;
    private Vector3 startpos = new Vector3(-0.89f, 1.605f, 0.648f);
    private Vector3 pos1 = new Vector3(-0.7f, 1.605f, 0.648f);
    private Vector3 pos2 = new Vector3(-0.7f, 1.502f, 0.648f);
    private Vector3 pos3 = new Vector3(-0.605f, 1.502f, 0.648f);
    private Vector3 pos4 = new Vector3(-0.605f, 1.411f, 0.648f);
    private Vector3 pos5 = new Vector3(-0.404f, 1.411f, 0.648f);
    private Vector3 pos6 = new Vector3(-0.404f, 1.689f, 0.648f);
    private Vector3 pos7 = new Vector3(-0.304f, 1.689f, 0.648f);
    private Vector3 pos8 = new Vector3(-0.304f, 1.294f, 0.648f);
    private Vector3 pos9 = new Vector3(-0.7022f, 1.294f, 0.648f);
    private Vector3 pos10 = new Vector3(-0.7022f, 0.8023f, 0.648f);
    private Vector3 pos11 = new Vector3(-0.606f, 0.8023f, 0.648f);
    private Vector3 pos12 = new Vector3(-0.606f, 1.1226f, 0.648f);
    private Vector3 pos13 = new Vector3(-0.5035f, 1.1226f, 0.648f);
    private Vector3 pos14 = new Vector3(-0.5035f, 0.8021f, 0.648f);
    private Vector3 pos15 = new Vector3(-0.3947f, 0.8021f, 0.648f);
    private Vector3 pos16 = new Vector3(-0.3947f, 1.134f, 0.648f);
    private Vector3 pos17 = new Vector3(-0.297f, 1.134f, 0.648f);
    private Vector3 pos18 = new Vector3(-0.297f, 0.794f, 0.648f);
    private Vector3 pos19 = new Vector3(0.034f, 0.794f, 0.648f);
    private Vector3 pos20 = new Vector3(0.034f, 1.204f, 0.648f);
    private Vector3 pos21 = new Vector3(0.034f, 1.593f, 0.648f);
    private Vector3 pos22 = new Vector3(0.6854f, 1.593f, 0.648f);
    private Vector3 pos23 = new Vector3(0.6854f, 1.405f, 0.648f);
    private Vector3 pos24 = new Vector3(0.3085f, 1.405f, 0.648f);
    private Vector3 pos25 = new Vector3(0.3085f, 1.288f, 0.648f);
    private Vector3 pos26 = new Vector3(0.684f, 1.288f, 0.648f);
    private Vector3 pos27 = new Vector3(0.684f, 1.191f, 0.648f);
    private Vector3 pos28 = new Vector3(0.398f, 1.191f, 0.648f);
    private Vector3 pos29 = new Vector3(0.398f, 1f, 0.648f);
    private Vector3 pos30 = new Vector3(0.692f, 1f, 0.648f);
    private Vector3 pos31 = new Vector3(0.692f, 0.888f, 0.648f);
    private Vector3 pos32 = new Vector3(0.4f, 0.888f, 0.648f);
    private Vector3 pos33 = new Vector3(0.4f, 0.7975f, 0.648f);
    private Vector3 pos34 = new Vector3(0.839f, 0.7975f, 0.648f);
    private Vector3 pos35 = new Vector3(0.839f, 1.587f, 0.648f);
    private Vector3 pos36 = new Vector3(0.9464f, 1.587f, 0.648f);
    private Vector3 pos37 = new Vector3(0.9464f, 0.803f, 0.648f);
    private Vector3 pos38 = new Vector3(1.153f, 0.803f, 0.648f);
    float[] _interbal = { 0, 3, 1f, 0.7f, 0.7f, 0.7f, 0.9f, 1.5f, 0.5f, 1.8f, 1.8f, 1.8f, 0.6f, 1.6f, 0.6f, 1.6f, 0.6f, 1.6f, 0.6f, 1.6f, 1.6f, 2f, 2f, 2.6f, 0.9f, 1.6f, 0.8f, 1.6f, 0.8f, 1.4f, 1.1f, 1.3f,0.9f, 1.3f, 0.9f, 2f, 3.5f, 0.5f, 3.5f, 1.2f, 1f };
    private float _timefornext;
    private int _numberpos = 0;
    private float radius1;
    private float radius2;

    // Start is called before the first frame update
    void OnEnable()
    {
        _pos = new List<Vector3>() { startpos, startpos, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10, pos11, pos12, pos13, pos14, pos15, pos16, pos17, pos18, pos19, pos20, pos21, pos22, pos23, pos24, pos25, pos26, pos27, pos28, pos29, pos30, pos31, pos32, pos33, pos34, pos35, pos36, pos37, pos38, pos38};
        this.gameObject.transform.position = startpos;
        _timefornext = _interbal[1];
        radius1 = (pos20.y - pos19.y)/2;
        radius2 = (pos21.y - pos20.y)/2;

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

        if(_numberpos == 20)
        {
            roundsphere(_pos[_numberpos], _pos[_numberpos + 1], _timefornext - _interbal[_numberpos + 1], _timefornext,radius1,false);
        }
        else if(_numberpos == 21)
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
    void roundsphere(Vector3 _startpos,Vector3 _endpos, float _starttime, float _endtime, float _radius,bool _clockwise)
    {
        float theta = (_time - _starttime) * Mathf.PI / (_endtime - _starttime);

        if (_clockwise)
        {
            this.transform.position = (_endpos + _startpos) / 2 + _radius * new Vector3(Mathf.Sin(theta * (-1)), Mathf.Cos(theta * (-1)) * (-1), 0);
        }
        else
        {
            this.transform.position = (_endpos + _startpos) / 2 + _radius * new Vector3(Mathf.Sin(theta), Mathf.Cos(theta) * (-1), 0);
        }
        
    }
}