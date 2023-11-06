using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireController : MonoBehaviour {
    public Action<int> ChangeFireAdd;
    public Action<int> ChangeFireDec;
    [SerializeField]
    private UnityEvent ScoreStop;
    [SerializeField]
    private UnityEvent<int> LightView;
    public Action GameOver;
    private int _playerFire;
    [SerializeField]
    private FireChange _fireChange;
    private int _visibleHearts = 7; 
    private int _playerScore;
    private int _lightValue = 14;
    
    private void Start() {
        _fireChange.FireChangeAction += ChekScore;
    }

    private void ChekScore(int fire) {
        _playerFire = fire;
        if (_playerFire > 0 && _visibleHearts != 7) {
            _visibleHearts++;
            _lightValue+=2;
            ChangeFireAdd?.Invoke(_visibleHearts);
        }
        else if (_playerFire < 0) {          
            if (_visibleHearts > 0) {      
            ChangeFireDec?.Invoke(_visibleHearts);
            _visibleHearts-=1;
            _lightValue-=2;
            }

            if (_visibleHearts == 0) {   
                _visibleHearts = 7;
                _lightValue = 14; 
                GameOver?.Invoke();
                ScoreStop.Invoke();
            }
        } 
        LightView.Invoke(_lightValue);
    }

    private void OnDestroy() {
       _fireChange.FireChangeAction -= ChekScore;
    }
}
