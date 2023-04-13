// 1. using 선언문을 모두 복사해서 붙여넣습니다.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/**
    @class  : SampleSceneUI
    @date   : 2022-09-02
    @author : 탁준석
    @brief  : 신 UI 스크립트 예시를 보여주기 위해 작성했습니다.
    @warning: 주석으로 처리된 부분을 읽어보고 따라서 작성하세요.
 */

public class SampleSceneUI : SceneUI
{
    // 2. Monobehavior 대신 SceneUI를 상속받고 SampleScene에 있는 모든 UI의 정확한 이름을 항목마다 구분해서 나열해주세요.
    enum Buttons { }// 버튼 UI
    enum Texts { }// 텍스트 UI
    enum Images { }// 이미지 UI
    enum GameObjects { }// 게임 오브젝트

    // 필요하면 enum Sliders를 추가해주세요.

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

        // 3. enum에 나열된 이름으로 같은 이름을 가진 UI 컴포넌트를 찾아서 이 컴포넌트가 붙은 오브젝트를 불러옵니다. 
        // ex. GameObject go1 = GetButton((int)Buttons. ...).gameObject;    <- ... 버튼 UI 컴포넌트가 붙은 오브젝트를 불러옵니다.
        // ex. GameObject go2 = GetText((int)Texts. ...).gameObject;        <- ... 텍스트 UI 컴포넌트가 붙은 오브젝트를 불러옵니다.
        // ex. GameObject go3 = GetImage((int)Images. ...).gameObject;      <- ... 이미지 UI 컴포넌트가 붙은 오브젝트를 불러옵니다.

        // 4. UI와 상호작용했을 때, 실행되어야 하는 메서드를 설정합니다.
        // ex. BindEvent(게임 오브젝트, 실행할 함수, UI와 할 상호작용);
        // ex. BindEvent(go1, OnButtonClicked, Define.UI.Click);           <- go1 버튼을 클릭했을 때, OnButtonClicked 메서드가 실행됩니다.
        // ex. BindEvent(go3, OnImageDragged, Define.UI.Drag);             <- go3 이미지를 드래그했을 때, OnImageDragged 메서드가 실행됩니다.

    }

    // 5. UI와 상호작용했을 때 실행할 메서드는 이곳에 정의해주세요.
    public void OnButtonClicked(PointerEventData data)
    {
        // ex. 점수를 올립니다.
    }

    public void OnImageDragged(PointerEventData data)
    {
        // ex. 이미지가 마우스를 따라갑니다.
    }
}
