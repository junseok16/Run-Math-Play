using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossTheBridge : MonoBehaviour
{
    private TimerUI timerUI;

    private static CrossTheBridge _instance = null;
    public static CrossTheBridge GetInstance { get => _instance; }

    private void Awake() 
    {
        _instance = this;
        timerUI = Managers.GetUIManager.OpenSceneUI<TimerUI>();
    }

    public void GameClear() 
    {
        var ui = Managers.GetUIManager.OpenPopupUI<GameClearUI>();
        ui.SetTime(timerUI.timer.GetString());
        ui.SetAccuracy(100);
    }

    public void GameOver() 
    {
        Managers.GetUIManager.OpenPopupUI<GameOverUI>();
    }
}
