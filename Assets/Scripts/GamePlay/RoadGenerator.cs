using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class RoadGenerator : MonoBehaviour
{
    public Action<int> PlayerRun; 
    private Animator _animator;
    bool isRunning= false;
    [SerializeField]
    private UnityEvent<int> ViewGameScore;
    [SerializeField]
    private GameObject _roadPie;
    [SerializeField]
    private GameObject _player;
    private List<GameObject> _roads = new List<GameObject>();
    private int _speed=0;
    [SerializeField]
    private int _maxSpeed = 1;
    [SerializeField]
    private int _maxRoadCount=6;
    private int _score = 0;
    
    private void Awake ()
    {
        _animator= _player.GetComponent<Animator>();
    }
    private void Start()
    {
        PoolManager.Instance.Preload(_roadPie,10);
        ResetLevel();   
    }

    private void Update()
    {
        if (_speed == 0) return;

        foreach (GameObject road in _roads)
        {
            road.transform.position -= new Vector3(0, 0, _speed * Time.deltaTime);
        }

        if (_roads[0].transform.position.z < -6)
        {
            PoolManager.Instance.Despawn(_roads[0]);
            _roads.RemoveAt(0);
            CreateNextRoad();
        }
    }

    private void CreateNextRoad()
    {
        Vector3 position = Vector3.zero;
        if (_roads.Count > 0)
        { 
            position= _roads[_roads.Count-1].transform.position + new Vector3(0,0,4.025f);
        }
        //GameObject pie = Instantiate(_roadPie, position, Quaternion.identity);
        GameObject pie = PoolManager.Instance.Spawn(_roadPie, position, Quaternion.identity);
        pie.transform.SetParent(transform);
        _roads.Add(pie);
    }
    public void StartLevel()
    {
        _speed = _maxSpeed;
        isRunning = true;
        _animator.SetBool("isRunning",isRunning);
        StartCoroutine(CheckValue());
    }

    public void ResetLevel()
    {
        isRunning=false;
        _speed = 0;
        _animator.SetBool("isRunning",isRunning);
        while (_roads.Count > 0)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }
        for (int i=0; i<_maxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }

    private IEnumerator CheckValue()
    {
       while (isRunning){
            yield return new WaitForSeconds(1f); 
            _score++;
            PlayerRun?.Invoke(_score);
        }
        
    }  
    public void StopScore()
    {
        isRunning = false;
        ViewGameScore.Invoke(_score);
        _score=0;
        _speed=0;
        _animator.SetBool("isRunning",isRunning);
        PlayerRun?.Invoke(_score);
        
    }
}
