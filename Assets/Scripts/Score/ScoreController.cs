using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    public Action<int> AddScore;

    private int _playerScore;
    [SerializeField]
    private RoadGenerator _roadGenerator;

    private void Awake() {
        _roadGenerator.PlayerRun += ChekScore;
    }

    private void ChekScore(int score) {
        _playerScore = score;
        AddScore?.Invoke(_playerScore);
    }

    private void OnDestroy() {
        _roadGenerator.PlayerRun -= ChekScore;
    }
}
