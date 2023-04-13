using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickUI : SceneUI
{
    [SerializeField, Range(100.0f, 200.0f)] private float handleRange = 130.0f;
    GameObject _player = Managers.GetPlayer;
    GameObject _directionFrame = null;
    GameObject _focus0 = null;
    GameObject _focus1 = null;
    GameObject _focus2 = null;
    GameObject _focus3 = null;
    GameObject _handle = null;

    enum Buttons { }// 버튼 UI
    enum Texts { }// 텍스트 UI
    enum Images// 이미지 UI
    {
        DirectionFrame, Focus_0, Focus_1, Focus_2, Focus_3, Handle
    }

    enum GameObjects { }// 게임 오브젝트

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

        _directionFrame = GetImage((int)Images.DirectionFrame).gameObject;
        _focus0 = GetImage((int)Images.Focus_0).gameObject;
        _focus1 = GetImage((int)Images.Focus_1).gameObject;
        _focus2 = GetImage((int)Images.Focus_2).gameObject;
        _focus3 = GetImage((int)Images.Focus_3).gameObject;
        _handle = GetImage((int)Images.Handle).gameObject;

        BindEvent(_directionFrame, OnBeginDirectionFrameDragged, Define.UI.BeginDrag);
        BindEvent(_directionFrame, OnDirectionFrameDragged, Define.UI.Drag);
        BindEvent(_directionFrame, OnEndDirectionFrameDragged, Define.UI.EndDrag);

        _focus0.SetActive(false);
        _focus1.SetActive(false);
        _focus2.SetActive(false);
        _focus3.SetActive(false);
    }

    public void OnBeginDirectionFrameDragged(PointerEventData data)
    {
        // 사용자가 터치한 위치에 레버(핸들러)가 놓일 위치를 구합니다.
        Vector2 direction = data.position - _directionFrame.GetComponent<RectTransform>().anchoredPosition;
        
        // 레버(핸들러)가 방향 프레임 밖으로 벗어나지 못하도록 합니다.
        Vector2 clampedDirection = direction.magnitude < handleRange ? direction : direction.normalized * handleRange;
        _handle.GetComponent<RectTransform>().anchoredPosition = clampedDirection;

        // GameObject player = Managers.GetPlayer;
        // player.GetComponent<PlayerController>()._state = PlayerController.State.Move;
    }

    public void OnDirectionFrameDragged(PointerEventData data)
    {
        // 사용자가 터치한 위치에 레버(핸들러)가 놓일 위치를 구합니다.
        Vector2 direction = data.position - _directionFrame.GetComponent<RectTransform>().anchoredPosition;
        
        // 레버(핸들러)가 방향 프레임 밖으로 벗어나지 못하도록 합니다.
        Vector2 clampedDirection = direction.magnitude < handleRange ? direction : direction.normalized * handleRange;
        _handle.GetComponent<RectTransform>().anchoredPosition = clampedDirection;

        // 플레이어의 상태를 Move로 변경합니다.
        _player.GetComponent<PlayerController>()._state = PlayerController.State.Move;
        _player.GetComponent<PlayerController>()._direction = clampedDirection.normalized;

        // 레버 위치에 따라 포커스 이미지를 활성화합니다.
        float handlerX = clampedDirection.x;
        float handlerY = clampedDirection.y;

        _focus0.SetActive(false);
        _focus1.SetActive(false);
        _focus2.SetActive(false);
        _focus3.SetActive(false);

        if (handlerX > 0 && handlerY > 0)       { _focus0.SetActive(true); }
        else if (handlerX < 0 && handlerY > 0)  { _focus3.SetActive(true); }
        else if (handlerX < 0 && handlerY < 0)  { _focus2.SetActive(true); }
        else if (handlerX > 0 && handlerY < 0)  { _focus1.SetActive(true); }
    }

    public void OnEndDirectionFrameDragged(PointerEventData data)
    {
        _focus0.SetActive(false);
        _focus1.SetActive(false);
        _focus2.SetActive(false);
        _focus3.SetActive(false);
        _handle.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        // 플레이어의 상태를 Idle로 변경합니다.
        _player.GetComponent<PlayerController>()._state = PlayerController.State.Idle;
        _player.GetComponent<PlayerController>()._direction = Vector2.zero;
    }
}
