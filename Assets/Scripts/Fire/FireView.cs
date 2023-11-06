using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FireView : MonoBehaviour
{
    [SerializeField]
    private Transform _heartPanel;
    private Image[] _cellImages;
    [SerializeField]
    private Sprite _decrementSprite;
    [SerializeField]
    private Sprite _addSprite;
    [SerializeField]
    private FireController _fireController;

    private void Start()
    {
        _fireController.ChangeFireAdd += ViewFireAdd;
        _fireController.ChangeFireDec += ViewFireDec;
        _fireController.GameOver += FireStartState;
        _cellImages = _heartPanel.GetComponentsInChildren<Image>();
    }

    private void ViewFireAdd(int scoreCount)
    { 
        _cellImages[scoreCount].sprite = _addSprite;  
    }
    private void ViewFireDec(int scoreCount)
    {
        _cellImages[scoreCount].sprite = _decrementSprite;
    }

    private void FireStartState() {
        foreach (Image image in _cellImages)
            image.sprite = _addSprite;  
    }

    private void OnDestroy() {
        _fireController.ChangeFireAdd -= ViewFireAdd;
        _fireController.ChangeFireDec -= ViewFireDec;
         _fireController.GameOver -= FireStartState;
    }
}
