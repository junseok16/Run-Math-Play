using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingScene : BaseScene
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.Ranking;
        Managers.GetUIManager.OpenSceneUI<RankingUI>();
    }

    public override void Clear()
    {

    }
}
