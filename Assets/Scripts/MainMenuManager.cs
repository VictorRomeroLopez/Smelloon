using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private LevelManager _levelManager;

    void Start()
    {
        _playButton.onClick.AddListener(OnPlayButton);
    }

    void OnPlayButton()
    {
        Time.timeScale = 1;
        StartCoroutine(_levelManager.LevelTimer());
        gameObject.SetActive(false);
    }
}
