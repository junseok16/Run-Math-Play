using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScene : BaseScene
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.Reward;
        Managers.GetUIManager.OpenSceneUI<RewardUI>();
    }

    public override void Clear()
    {

    }
}
