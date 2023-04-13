using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUI : BaseUI
{
    public virtual void Initialize()
    {
        Managers.GetUIManager.SetCanvas(gameObject, false);
    }
}
