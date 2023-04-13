// 1. using ������ ��� �����ؼ� �ٿ��ֽ��ϴ�.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/**
    @class  : SampleSceneUI
    @date   : 2022-09-02
    @author : Ź�ؼ�
    @brief  : �� UI ��ũ��Ʈ ���ø� �����ֱ� ���� �ۼ��߽��ϴ�.
    @warning: �ּ����� ó���� �κ��� �о�� ���� �ۼ��ϼ���.
 */

public class SampleSceneUI : SceneUI
{
    // 2. Monobehavior ��� SceneUI�� ��ӹް� SampleScene�� �ִ� ��� UI�� ��Ȯ�� �̸��� �׸񸶴� �����ؼ� �������ּ���.
    enum Buttons { }// ��ư UI
    enum Texts { }// �ؽ�Ʈ UI
    enum Images { }// �̹��� UI
    enum GameObjects { }// ���� ������Ʈ

    // �ʿ��ϸ� enum Sliders�� �߰����ּ���.

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

        // 3. enum�� ������ �̸����� ���� �̸��� ���� UI ������Ʈ�� ã�Ƽ� �� ������Ʈ�� ���� ������Ʈ�� �ҷ��ɴϴ�. 
        // ex. GameObject go1 = GetButton((int)Buttons. ...).gameObject;    <- ... ��ư UI ������Ʈ�� ���� ������Ʈ�� �ҷ��ɴϴ�.
        // ex. GameObject go2 = GetText((int)Texts. ...).gameObject;        <- ... �ؽ�Ʈ UI ������Ʈ�� ���� ������Ʈ�� �ҷ��ɴϴ�.
        // ex. GameObject go3 = GetImage((int)Images. ...).gameObject;      <- ... �̹��� UI ������Ʈ�� ���� ������Ʈ�� �ҷ��ɴϴ�.

        // 4. UI�� ��ȣ�ۿ����� ��, ����Ǿ�� �ϴ� �޼��带 �����մϴ�.
        // ex. BindEvent(���� ������Ʈ, ������ �Լ�, UI�� �� ��ȣ�ۿ�);
        // ex. BindEvent(go1, OnButtonClicked, Define.UI.Click);           <- go1 ��ư�� Ŭ������ ��, OnButtonClicked �޼��尡 ����˴ϴ�.
        // ex. BindEvent(go3, OnImageDragged, Define.UI.Drag);             <- go3 �̹����� �巡������ ��, OnImageDragged �޼��尡 ����˴ϴ�.

    }

    // 5. UI�� ��ȣ�ۿ����� �� ������ �޼���� �̰��� �������ּ���.
    public void OnButtonClicked(PointerEventData data)
    {
        // ex. ������ �ø��ϴ�.
    }

    public void OnImageDragged(PointerEventData data)
    {
        // ex. �̹����� ���콺�� ���󰩴ϴ�.
    }
}
