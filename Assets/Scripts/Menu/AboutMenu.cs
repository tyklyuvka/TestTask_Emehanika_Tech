using System;
using UnityEngine;
using UnityEngine.UI;
public class AboutMenu : MonoBehaviour
{
    public Action MenuButtonClicked;
    [SerializeField]
    private Button _menuButton;
    private void Awake() {
        _menuButton.onClick.AddListener(() => MenuButtonClicked?.Invoke());
    }

    private void OnDestroy() {
        _menuButton.onClick.RemoveListener(() => MenuButtonClicked?.Invoke());
    }
}