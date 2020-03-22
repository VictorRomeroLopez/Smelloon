using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryMenuManager : MonoBehaviour
{
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _back;
    [SerializeField] private BoxManager _boxManager;
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private LevelManager levelManager;

    void Start()
    {
        _resetButton.onClick.AddListener(ResetButtonPressed);
        _back.onClick.AddListener(BackButtonPressed);
    }

    void ResetButtonPressed()
    {
        Time.timeScale = 1;
        _boxManager.ResetBoxes();
        levelManager.OnReset();
        gameObject.SetActive(false);
    }

    void BackButtonPressed()
    {
        levelManager.OnReset();
        _mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
