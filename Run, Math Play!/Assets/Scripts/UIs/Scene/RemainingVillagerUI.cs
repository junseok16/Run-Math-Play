using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RemainingVillagerUI : SceneUI
{
    private TextMeshProUGUI _textNumber;
    private TextMeshProUGUI _textTime;
    private int _count = 10;
    
    enum Buttons { }
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

        _textNumber = Utilize.FindChild(gameObject, "Text_Number", true).GetComponent<TextMeshProUGUI>();
        _textNumber.text = _count.ToString();
    }

    public void SubtractCount()
    {
        _count --;
        _textNumber.text = _count.ToString();
    }
}