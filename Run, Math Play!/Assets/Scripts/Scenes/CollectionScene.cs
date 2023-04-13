using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionScene : BaseScene
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.Collection;
        Managers.GetUIManager.OpenSceneUI<CollectionUI>();
    }

    public override void Clear()
    {
        
    }
}
