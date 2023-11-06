using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Action PlayButtonClicked;
    public Action AboutButtonClicked;
    public Action QuitButtonClicked;

    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private Button _aboutButton;
    [SerializeField]
    private Button _quitButton;

    private void Awake() {
        _playButton.onClick.AddListener(() => PlayButtonClicked?.Invoke());
        _aboutButton.onClick.AddListener(() => AboutButtonClicked?.Invoke());
        _quitButton.onClick.AddListener(() => QuitButtonClicked?.Invoke());
    }

    private void OnDestroy() {
        _playButton.onClick.RemoveListener(() => PlayButtonClicked?.Invoke());
        _aboutButton.onClick.RemoveListener(() => AboutButtonClicked?.Invoke());
        _quitButton.onClick.RemoveListener(() => QuitButtonClicked?.Invoke());
    }
}