using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LifeUI : SceneUI
{
    private int _life = 3;
    private GameObject[] ImageLife = new GameObject[3];

    enum Buttons { }
    enum Texts { }
    enum Images { Image_Life01, Image_Life02, Image_Life03 }
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

        ImageLife[0] = GetImage((int)Images.Image_Life01).gameObject;
        ImageLife[1] = GetImage((int)Images.Image_Life02).gameObject;
        ImageLife[2] = GetImage((int)Images.Image_Life03).gameObject;
    }

    public void DecreaseLife()
    {
        _life--;
        switch(_life)
        {
            case 2:
                ImageLife[0].SetActive(false);
                break;
            case 1:
                ImageLife[1].SetActive(false);
                break;
            case 0:
                ImageLife[2].SetActive(false);
                break;
        }
    }
}