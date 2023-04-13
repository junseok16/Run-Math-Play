using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CollectionUI : SceneUI
{
    enum Buttons { Button_Back, Button_Home }
    enum Texts { }
    enum Images { }
    enum GameObjects { }

    private void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        GameObject buttonBack = GetButton((int)Buttons.Button_Back).gameObject;
        GameObject buttonHome = GetButton((int)Buttons.Button_Home).gameObject;
    }
}
