using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossTheBridgeScene : BaseScene
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.CrossTheBridge;

        Managers.SetPlayer = GameObject.Find("@Player").gameObject;
        Managers.GetUIManager.OpenSceneUI<JoystickUI>();
        Managers.GetUIManager.OpenSceneUI<SkillUI>();
        Managers.GetUIManager.OpenSceneUI<PauseButtonUI>();

        Managers.GetUIManager.OpenSceneUI<TimerUI>();
        Managers.GetUIManager.OpenSceneUI<LifeUI>();

        Managers.GetUIManager.OpenPopupUI<CrossTheBridgeProblemUI>();
        Managers.GetSoundManager.Play("bgm_crossthebridge", Define.Sound.BGM);
    }

    public override void Clear()
    {
        
    }
}
