using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpyFeedbackUI : PopupUI
{
    private TextMeshProUGUI _text;
    enum Buttons { }

    enum Texts { }

    enum Images { }

    enum GameObjects { }

    private void Awake()
    {
        _text = Utilize.FindChild(gameObject, "Text", true).GetComponent<TextMeshProUGUI>();
    }

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
        
        StartCoroutine(WaitAndFade());
    }

    IEnumerator WaitAndFade()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        while (_text.color.a > 0)
        {
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a - 0.04f);
            yield return null;
        }
        Managers.GetUIManager.ClosePopupUI(this);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void SetColor(Color color)
    {
        _text.color = color;
    }
}
