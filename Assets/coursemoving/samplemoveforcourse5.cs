using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samplemoveforcourse5 : MonoBehaviour
{
    private float _time;
    List<Vector3> _pos;
    private Vector3 startpos = new Vector3(-0.922f, 1.526f, 0.648f);
    private Vector3 pos1 = new Vector3(-0.251f, 1.526f, 0.648f);
    private Vector3 pos2 = new Vector3(-0.251f, 1.404f, 0.648f);
    private Vector3 pos3 = new Vector3(-0.835f, 1.404f, 0.648f);
    private Vector3 pos4 = new Vector3(-0.835f, 1.109f, 0.648f);
    private Vector3 pos5 = new Vector3(-0.747f, 1.109f, 0.648f);
    private Vector3 pos6 = new Vector3(-0.747f, 1.258f, 0.648f);
    private Vector3 pos7 = new Vector3(-0.641f, 1.258f, 0.648f);
    private Vector3 pos8 = new Vector3(-0.641f, 1.111f, 0.648f);
    private Vector3 pos9 = new Vector3(-0.554f, 1.111f, 0.648f);
    private Vector3 pos10 = new Vector3(-0.554f, 1.27f, 0.648f);
    private Vector3 pos11 = new Vector3(-0.438f, 1.27f, 0.648f);
    private Vector3 pos12 = new Vector3(-0.438f, 1.119f, 0.648f);
    private Vector3 pos13 = new Vector3(-0.348f, 1.119f, 0.648f);
    private Vector3 pos14 = new Vector3(-0.348f, 1.254f, 0.648f);
    private Vector3 pos15 = new Vector3(-0.248f, 1.254f, 0.648f);
    private Vector3 pos16 = new Vector3(-0.248f, 0.992f, 0.648f);
    private Vector3 pos17 = new Vector3(-0.719f, 0.992f, 0.648f);
    private Vector3 pos18 = new Vector3(-0.719f, 0.869f, 0.648f);
    private Vector3 pos19 = new Vector3(0.339f, 0.869f, 0.648f);
    private Vector3 pos20 = new Vector3(0.339f, 0.97f, 0.648f);
    private Vector3 pos21 = new Vector3(-0.133f, 0.97f, 0.648f);
    private Vector3 pos22 = new Vector3(-0.133f, 1.266f, 0.648f);
    private Vector3 pos23 = new Vector3(-0.037f, 1.266f, 0.648f);
    private Vector3 pos24 = new Vector3(-0.037f, 1.116f, 0.648f);
    private Vector3 pos25 = new Vector3(0.052f, 1.116f, 0.648f);
    private Vector3 pos26 = new Vector3(0.052f, 1.27f, 0.648f);
    private Vector3 pos27 = new Vector3(0.167f, 1.27f, 0.648f);
    private Vector3 pos28 = new Vector3(0.167f, 1.118f, 0.648f);
    private Vector3 pos29 = new Vector3(0.268f, 1.118f, 0.648f);
    private Vector3 pos30 = new Vector3(0.268f, 1.25f, 0.648f);
    private Vector3 pos31 = new Vector3(0.358f, 1.25f, 0.648f);
    private Vector3 pos32 = new Vector3(0.358f, 1.122f, 0.648f);
    private Vector3 pos33 = new Vector3(0.453f, 1.122f, 0.648f);
    private Vector3 pos34 = new Vector3(0.453f, 1.3957f, 0.648f);
    private Vector3 pos35 = new Vector3(-0.122f, 1.3957f, 0.648f);
    private Vector3 pos36 = new Vector3(-0.122f, 1.508f, 0.648f);
    private Vector3 pos37 = new Vector3(1.147f, 1.508f, 0.648f);
    private Vector3 pos38 = new Vector3(1.147f, 1.4f, 0.648f);
    private Vector3 pos39 = new Vector3(0.5581f, 1.4f, 0.648f);
    private Vector3 pos40 = new Vector3(0.5581f, 1.1068f, 0.648f);
    private Vector3 pos41 = new Vector3(0.6543f, 1.1068f, 0.648f);
    private Vector3 pos42 = new Vector3(0.6543f, 1.2608f, 0.648f);
    private Vector3 pos43 = new Vector3(0.745f, 1.2608f, 0.648f);
    private Vector3 pos44 = new Vector3(0.745f, 1.106f, 0.648f);
    private Vector3 pos45 = new Vector3(0.8396f, 1.106f, 0.648f);
    private Vector3 pos46 = new Vector3(0.8396f, 1.26f, 0.648f);
    private Vector3 pos47 = new Vector3(0.9514f, 1.26f, 0.648f);
    private Vector3 pos48 = new Vector3(0.9514f, 1.104f, 0.648f);
    private Vector3 pos49 = new Vector3(1.0444f, 1.104f, 0.648f);
    private Vector3 pos50 = new Vector3(1.0444f, 1.265f, 0.648f);
    private Vector3 pos51 = new Vector3(1.1468f, 1.265f, 0.648f);
    private Vector3 pos52 = new Vector3(1.1468f, 0.982f, 0.648f);
    private Vector3 pos53 = new Vector3(0.673f, 0.982f, 0.648f);
    private Vector3 pos54 = new Vector3(0.673f, 0.855f, 0.648f);
    private Vector3 pos55 = new Vector3(1.264f, 0.855f, 0.648f);

    float[] _interbal = { 0, 3,3.3f,0.6f,3f,2f,0.8f,1.1f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.6f,2.5f,0.7f,6f,0.7f,2.5f,1.6f,0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f,2f,3f,0.6f,6f, 0.6f, 3f, 2f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.1f, 0.8f, 1.6f, 2.5f, 0.7f,3f, 1f };
    private float _timefornext;
    private int _numberpos = 0;



    // Start is called before the first frame update
    void OnEnable()
    {
        _pos = new List<Vector3>() { startpos, startpos, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10, pos11, pos12, pos13, pos14, pos15, pos16, pos17, pos18, pos19, pos20, pos21, pos22, pos23, pos24, pos25, pos26, pos27, pos28, pos29, pos30, pos31, pos32, pos33, pos34, pos35, pos36, pos37, pos38, pos39, pos40, pos41, pos42, pos43, pos44, pos45, pos46, pos47, pos48, pos49, pos50, pos51, pos52, pos53, pos54, pos55, pos55 };
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