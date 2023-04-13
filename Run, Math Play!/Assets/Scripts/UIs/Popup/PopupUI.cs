using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : BaseUI
{
    public virtual void Initialize()
    {
        Managers.GetUIManager.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopupUI()
    {
        Managers.GetUIManager.ClosePopupUI(this);
    }
}
