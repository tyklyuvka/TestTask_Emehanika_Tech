using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI _scoreTest;

    [SerializeField]
    private ScoreController _scoreController;
    private void Awake() {
        _scoreController.AddScore += SetScoreCount;
    }

    private void SetScoreCount(int scoreCount) {
        _scoreTest.text = scoreCount.ToString();
    }
    private void OnDestroy() {
        _scoreController.AddScore -= SetScoreCount;
    }

}
