using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecordMenu : MonoBehaviour
{
    public Action MenuButtonClicked;

    [SerializeField]
    private Button _menuButton;

    [SerializeField]
    private TextMeshProUGUI _scoreTest;

    [SerializeField]
    private TextMeshProUGUI _recordTest;
    private int _currentRecord;

    private void Awake() {
        _menuButton.onClick.AddListener(() => MenuButtonClicked?.Invoke());
       ViewStartRecord();
    }

    public void SetScoreCount(int scoreCount) {
        _scoreTest.text = scoreCount.ToString(); 
        ChekRecord(scoreCount);
    }
    private void ChekRecord(int scoreCount) {
        if (_currentRecord <= scoreCount){
            SaveNewRecord(scoreCount);
        }
    }
    private int LoadRecord() {
        if (PlayerPrefs.HasKey("SavedRecord")) {
           return PlayerPrefs.GetInt("SavedRecord"); 
        }
        else return 0;
    }
    private void SaveNewRecord(int scoreCount) {
        _recordTest.text = scoreCount.ToString();
        PlayerPrefs.SetInt("SavedRecord", scoreCount);
        PlayerPrefs.Save();
        _currentRecord = LoadRecord();
    }

    private void ViewStartRecord() {
        _currentRecord = LoadRecord();
        _recordTest.text =  _currentRecord .ToString();
    }
    
    private void OnDestroy() {
       _menuButton.onClick.RemoveListener(() => MenuButtonClicked?.Invoke());
    }
}
