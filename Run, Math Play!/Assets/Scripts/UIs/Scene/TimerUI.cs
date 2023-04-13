using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimerUI : SceneUI
{
    public Timer timer;

    private TextMeshProUGUI _textTime;
    
    enum Buttons { }
    enum Texts { }
    enum Images { }
    enum GameObjects { }

    private void Awake()
    {
        timer = Utilize.GetOrAddComponent<Timer>(this.gameObject);
        timer.Operate();
        _textTime = Utilize.FindChild(gameObject, "Text_Time", true).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Initialize();
        StartCoroutine(run());
    }

    public override void Initialize()
    {
        base.Initialize();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

    }

    private IEnumerator run()
    {
        while (this != null)
        {
            _textTime.text = timer.GetString();
            yield return new WaitForSeconds(1);
        }
    }
}