using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewScene : BaseScene
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.Review;
        Managers.GetUIManager.OpenSceneUI<ReviewUI>();
    }

    public override void Clear()
    {

    }
}
