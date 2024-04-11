using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEvent GameOverEvent;
    public UnityEvent RestartEvent;
    public GameObject gameoverPanel;
    public GameObject restartButton;
    // Start is called before the first frame update


    private void Awake()
    {
        instance = this;
    }
    [ContextMenu("Test GameOver")]
    public void GameOver()
    {
        GameOverEvent?.Invoke();
        gameoverPanel.SetActive(true);
        restartButton.SetActive(true);

    }

    public void Restart()
    {
        RestartEvent?.Invoke();
        gameoverPanel.SetActive(false);
        restartButton.SetActive(false);
    }

    public static void AddGameOverEventListener(UnityAction action)
    {
        instance.GameOverEvent.AddListener(action);
    }

    public static void AddRestartEventListener(UnityAction action)
    {
        instance.RestartEvent.AddListener(action);
    }

    public static void RemoveGameOverEventListener(UnityAction action)
    {
        instance.GameOverEvent.RemoveListener(action);
    }

    public static void RemoveRestartEventListener(UnityAction action)
    {

        instance.RestartEvent.RemoveListener(action);
    }
    
}
