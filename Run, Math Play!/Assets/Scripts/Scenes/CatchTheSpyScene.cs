using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTheSpyScene : BaseScene
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.CatchTheSpy;

        Dictionary<int, Data.Exp> expDict = Managers.GetDataManager.expDictionary;

        Managers.SetPlayer = GameObject.Find("@Player").gameObject;
        Managers.GetUIManager.OpenSceneUI<JoystickUI>();
        Managers.GetUIManager.OpenSceneUI<SkillUI>();
        Managers.GetUIManager.OpenSceneUI<PauseButtonUI>();
        Managers.GetSoundManager.Play("bgm_catchthespy", Define.Sound.BGM);
    }

    public override void Clear()
    {
        
    }
}
