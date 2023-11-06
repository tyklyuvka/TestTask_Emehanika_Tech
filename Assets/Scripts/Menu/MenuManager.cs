using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private MainMenu _mainMenu;
    [SerializeField]
    private AboutMenu _aboutMenu;

    [SerializeField]
    private RecordMenu _recordMenu;

    [SerializeField]
    private GameObject _gameScreen;
    
    [SerializeField]
    private FireController _fireController;

    private void Awake() {
        _mainMenu.PlayButtonClicked += StartGame;
        _mainMenu.AboutButtonClicked += ShowSettingsMenu;
        _mainMenu.QuitButtonClicked += QuitGame;
        _recordMenu.MenuButtonClicked += ShowMainMenu;
        _aboutMenu.MenuButtonClicked += ShowMainMenu;
        _fireController.GameOver += ShowRecordMenu;
    }

    private void ShowSettingsMenu() {
        _mainMenu.gameObject.SetActive(false);
        _aboutMenu.gameObject.SetActive(true);
    }

    private void ShowMainMenu() {
        _mainMenu.gameObject.SetActive(true);
        _aboutMenu.gameObject.SetActive(false);
        _recordMenu.gameObject.SetActive(false);
    }

    private void StartGame() {
        _mainMenu.gameObject.SetActive(false);
        _gameScreen.gameObject.SetActive(true);
        _recordMenu.gameObject.SetActive(false);
    }

    private void ShowRecordMenu() {
        _gameScreen.gameObject.SetActive(false);
        _recordMenu.gameObject.SetActive(true);
    }

    private void OnDestroy() {
        _mainMenu.PlayButtonClicked -= StartGame;
        _mainMenu.AboutButtonClicked -= ShowSettingsMenu;
        _aboutMenu.MenuButtonClicked -= ShowMainMenu;
        _recordMenu.MenuButtonClicked -= ShowMainMenu;
        _fireController.GameOver -= ShowRecordMenu;
    }

    private void QuitGame() {
        Application.Quit();
    }
}