using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : LoginScene.cs
    @date   : 2022-09-02
    @author : Ź�ؼ�
    @brief  : LoginScene���� ������ �� UI�� ȣ���մϴ�.
    @warning: ���ο� ���� ���� ������ [�� �̸� + Scene.cs] ��ũ��Ʈ�� �����ϰ� MonoBehavior ��� BaseScene�� ��ӹ޾ƾ� �մϴ�.
 */

public class LoginScene : BaseScene// BaseScene Ŭ������ ��ӹ޽��ϴ�.
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.Login;

        // �̰��� ����ڿ��� ������ �� UI�� ȣ�����ּ���.

        // ����ڿ��� �׻� ������ �� UI�� OpenSceneUI<>()�� ȣ���մϴ�.
        // ex. Managers.GetUIManager.OpenSceneUI<LoginUI>();
        Managers.GetUIManager.OpenSceneUI<LoginUI>();

        // �˾����� ���� �� �ִ� UI�� OpenPopupUI<>()�� ȣ���մϴ�.
        // ex. Managers.GetUIManager.OpenPopupUI<...UI>();
    }

    public override void Clear()
    {

    }
}
