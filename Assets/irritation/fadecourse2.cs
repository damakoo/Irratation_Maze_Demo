using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadecourse2 : MonoBehaviour
{
    [SerializeField] GameObject _gameObject1;
    [SerializeField] GameObject _gameObject2;
    [SerializeField] GameObject _gameObject3;
    [SerializeField] GameObject _gameObject4;
    [SerializeField] GameObject _gameObject5;
    [SerializeField] GameObject _gameObject6;
    [SerializeField] GameObject _gameObject7;
    [SerializeField] GameObject _gameObject8;
    [SerializeField] GameObject _gameObject9;
    [SerializeField] GameObject _gameObject10;
    [SerializeField] GameObject _gameObject11;
    // Start is called before the first frame update
    private void OnEnable()
    {
        _gameObject1.gameObject.SetActive(false);
        _gameObject2.gameObject.SetActive(false);
        _gameObject3.gameObject.SetActive(false);
        _gameObject4.gameObject.SetActive(false);
        _gameObject5.gameObject.SetActive(false);
        _gameObject6.gameObject.SetActive(false);
        _gameObject7.gameObject.SetActive(false);
        _gameObject8.gameObject.SetActive(false);
        _gameObject9.gameObject.SetActive(false);
        _gameObject10.gameObject.SetActive(false);
        _gameObject11.gameObject.SetActive(false);
    }
}
