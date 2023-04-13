using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScene : BaseScene
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.Shop;
        Managers.GetUIManager.OpenSceneUI<ShopUI>();
    }

    public override void Clear()
    {

    }
}
