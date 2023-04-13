using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : LoginScene.cs
    @date   : 2022-09-02
    @author : 탁준석
    @brief  : LoginScene에서 보여야 할 UI를 호출합니다.
    @warning: 새로운 신을 만들 때마다 [신 이름 + Scene.cs] 스크립트를 생성하고 MonoBehavior 대신 BaseScene을 상속받아야 합니다.
 */

public class LoginScene : BaseScene// BaseScene 클래스를 상속받습니다.
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.Login;

        // 이곳에 사용자에게 보여야 할 UI를 호출해주세요.

        // 사용자에게 항상 보여야 할 UI는 OpenSceneUI<>()로 호출합니다.
        // ex. Managers.GetUIManager.OpenSceneUI<LoginUI>();
        Managers.GetUIManager.OpenSceneUI<LoginUI>();

        // 팝업으로 없앨 수 있는 UI는 OpenPopupUI<>()로 호출합니다.
        // ex. Managers.GetUIManager.OpenPopupUI<...UI>();
    }

    public override void Clear()
    {

    }
}
