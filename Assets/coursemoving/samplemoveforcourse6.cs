using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samplemoveforcourse6 : MonoBehaviour
{
    private float _time;
    List<Vector3> _pos;
    List<float>  _interbal = new List<float>();
    List<float> _length = new List<float>();
    private float fulllength = 0;
    public float fulltime = 40;
    private Vector3 startpos = new Vector3(-0.946f, 1.121f, 0.648f);
    private Vector3 pos1 = new Vector3(-0.691f, 1.121f, 0.648f);
    private Vector3 pos2 = new Vector3(-0.691f, 1.502f, 0.648f);
    private Vector3 pos3 = new Vector3(-0.621f, 1.502f, 0.648f);
    private Vector3 pos4 = new Vector3(-0.621f, 0.817f, 0.648f);
    private Vector3 pos5 = new Vector3(-0.539f, 0.817f, 0.648f);
    private Vector3 pos6 = new Vector3(-0.539f, 1.488f, 0.648f);
    private Vector3 pos7 = new Vector3(-0.465f, 1.488f, 0.648f);
    private Vector3 pos8 = new Vector3(-0.465f, 1.058f, 0.648f);
    private Vector3 pos9 = new Vector3(-0.161f, 1.058f, 0.648f);
    private Vector3 pos10 = new Vector3(-0.161f, 1.13f, 0.648f);
    private Vector3 pos11 = new Vector3(-0.383f, 1.13f, 0.648f);
    private Vector3 pos12 = new Vector3(-0.383f, 1.212f, 0.648f);
    private Vector3 pos13 = new Vector3(-0.162f, 1.212f, 0.648f);
    private Vector3 pos14 = new Vector3(-0.162f, 1.302f, 0.648f);
    private Vector3 pos15 = new Vector3(-0.375f, 1.302f, 0.648f);
    private Vector3 pos16 = new Vector3(-0.375f, 1.382f, 0.648f);
    private Vector3 pos17 = new Vector3(-0.046f, 1.384f, 0.648f);
    private Vector3 pos18 = new Vector3(-0.046f, 0.9394f, 0.648f);
    private Vector3 pos19 = new Vector3(-0.3952f, 0.9394f, 0.648f);
    private Vector3 pos20 = new Vector3(-0.3952f, 0.8452f, 0.648f);
    private Vector3 pos21 = new Vector3(0.248f, 0.8452f, 0.648f);
    private Vector3 pos22 = new Vector3(0.248f, 0.952f, 0.648f);
    private Vector3 pos23 = new Vector3(0.126f, 0.952f, 0.648f);
    private Vector3 pos24 = new Vector3(0.126f, 1.027f, 0.648f);
    private Vector3 pos25 = new Vector3(0.2463f, 1.027f, 0.648f);
    private Vector3 pos26 = new Vector3(0.2463f, 1.111f, 0.648f);
    private Vector3 pos27 = new Vector3(0.1202f, 1.111f, 0.648f);
    private Vector3 pos28 = new Vector3(0.1202f, 1.513f, 0.648f);
    private Vector3 pos29 = new Vector3(0.195f, 1.513f, 0.648f);
    private Vector3 pos30 = new Vector3(0.195f, 1.201f, 0.648f);
    private Vector3 pos31 = new Vector3(0.331f, 1.201f, 0.648f);
    private Vector3 pos32 = new Vector3(0.331f, 1.505f, 0.648f);
    private Vector3 pos33 = new Vector3(0.471f, 1.505f, 0.648f);
    private Vector3 pos34 = new Vector3(0.471f, 1.128f, 0.648f);
    private Vector3 pos35 = new Vector3(0.363f, 1.128f, 0.648f);
    private Vector3 pos36 = new Vector3(0.363f, 0.904f, 0.648f);
    private Vector3 pos37 = new Vector3(0.461f, 0.904f, 0.648f);
    private Vector3 pos38 = new Vector3(0.461f, 0.94f, 0.648f);//
    private Vector3 pos39 = new Vector3(0.629f, 0.94f, 0.648f);//
    private Vector3 pos40 = new Vector3(0.629f, 0.904f, 0.648f);
    private Vector3 pos41 = new Vector3(0.877f, 0.904f, 0.648f);
    private Vector3 pos42 = new Vector3(0.877f, 1.106f, 0.648f);
    private Vector3 pos43 = new Vector3(0.597f, 1.106f, 0.648f);
    private Vector3 pos44 = new Vector3(0.597f, 1.188f, 0.648f);
    private Vector3 pos45 = new Vector3(0.871f, 1.188f, 0.648f);
    private Vector3 pos46 = new Vector3(0.871f, 1.276f, 0.648f);
    private Vector3 pos47 = new Vector3(0.597f, 1.276f, 0.648f);
    private Vector3 pos48 = new Vector3(0.597f, 1.35f, 0.648f);
    private Vector3 pos49 = new Vector3(0.873f, 1.35f, 0.648f);
    private Vector3 pos50 = new Vector3(0.873f, 1.43f, 0.648f);
    private Vector3 pos51 = new Vector3(0.6f, 1.43f, 0.648f);
    private Vector3 pos52 = new Vector3(0.6f, 1.513f, 0.648f);
    private Vector3 pos53 = new Vector3(0.96f, 1.513f, 0.648f);

    private float _timefornext;
    private int _numberpos = 0;
    private float radius1;



    // Start is called before the first frame update
    void OnEnable()
    {
        _interbal.Add(0);
        _interbal.Add(3);
        _pos = new List<Vector3>() { startpos, startpos, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10, pos11, pos12, pos13, pos14, pos15, pos16, pos17, pos18, pos19, pos20, pos21, pos22, pos23, pos24, pos25, pos26, pos27, pos28, pos29, pos30, pos31, pos32, pos33, pos34, pos35, pos36, pos37, pos38, pos39, pos40, pos41, pos42, pos43, pos44, pos45, pos46, pos47, pos48, pos49, pos50, pos51, pos52, pos53, pos53};

        for(int i = 1;i < _pos.Count - 2; i++)
        {
            Vector3 distance = _pos[i + 1] - _pos[i];
            if (i == 39)
            {
                _length.Add(0.2639f);
                fulllength += 0.2639f;
            }
            else
            {
                _length.Add(distance.magnitude);
                fulllength += distance.magnitude;
            }
        }
        for (int i = 0; i < _length.Count; i++)
        {
            _interbal.Add(fulltime * _length[i] / fulllength);
        }
        _interbal.Add(1);
        this.gameObject.transform.position = startpos;
        _timefornext = _interbal[1];
        radius1 = (pos39.x - pos38.x) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (_numberpos > _interbal.Count - 3)
        {
            Destroy(this.gameObject);
        }
        if (_time > _timefornext)
        {
            _numberpos += 1;
            
            _timefornext += _interbal[_numberpos + 1];
        }
         if (_numberpos == 39)
        {
            roundsphere(_pos[_numberpos], _pos[_numberpos + 1], _timefornext - _interbal[_numberpos + 1], _timefornext, radius1, true);
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