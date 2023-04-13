using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacMan : MonoBehaviour
{
    private TimerUI timerUI;

    private static MacMan _instance = null;
    public static MacMan GetInstance { get => _instance; }

    private void Awake() 
    {
        _instance = this;
        timerUI = Managers.GetUIManager.OpenSceneUI<TimerUI>();
    }

    public void GameClear() 
    {
        var _player = GameObject.Find("@Player").GetComponent<Player>();
        var ui = Managers.GetUIManager.OpenPopupUI<GameClearUI>();
        ui.SetTime(timerUI.timer.GetString());
        ui.SetCorrectWrong(_player.question, _player.correct, _player.wrong);
    }

    public void GameOver() 
    {
        Managers.GetUIManager.OpenPopupUI<GameOverUI>();
    }
}
