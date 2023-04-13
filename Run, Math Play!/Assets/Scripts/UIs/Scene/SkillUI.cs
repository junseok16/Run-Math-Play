using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class SkillUI : SceneUI
{
    // 플레이하고 있는 신입니다.
    private Define.Scene _scene = Define.Scene.Unknown;

    private GameObject player = null;
    enum Buttons { Button_Jump, Button_Talk }

    enum Texts { }

    enum Images { }

    enum GameObjects { }

    TextMeshProUGUI Text_Correct;
    TextMeshProUGUI Text_Wrong;

    // Text correctText;
    // Text wrongText;

    private void Start()
    {
        _scene = Managers.GetSceneManager.BaseScene._scene;
        player = Managers.GetPlayer;
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        GameObject buttonJump = GetButton((int)Buttons.Button_Jump).gameObject;
        GameObject buttonTalk = GetButton((int)Buttons.Button_Talk).gameObject;

        BindEvent(buttonJump, OnButtonJumpClicked, Define.UI.Click);
        BindEvent(buttonTalk, OnButtonTalkClicked, Define.UI.Click);

        if (_scene == Define.Scene.MacMan)
        {
            Text_Correct = GameObject.Find("Correct_Text").GetComponent<TextMeshProUGUI>();
            Text_Wrong = GameObject.Find("Wrong_Text").GetComponent<TextMeshProUGUI>();
        }
    }

    public IEnumerator FadeTextToFullAlpha1()
    {
        Text_Correct.color = new Color(Text_Correct.color.r, Text_Correct.color.g, Text_Correct.color.b, 0);
        while (Text_Correct.color.a < 1.0f)
        {
            Text_Correct.color = new Color(Text_Correct.color.r, Text_Correct.color.g, Text_Correct.color.b, Text_Correct.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroAlpha1());
    }

    public IEnumerator FadeTextToZeroAlpha1()
    {
        Text_Correct.color = new Color(Text_Correct.color.r, Text_Correct.color.g, Text_Correct.color.b, 1);
        while (Text_Correct.color.a > 0.0f)
        {
            Text_Correct.color = new Color(Text_Correct.color.r, Text_Correct.color.g, Text_Correct.color.b, Text_Correct.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
    }

    public IEnumerator FadeTextToFullAlpha2()
    {
        Text_Wrong.color = new Color(Text_Wrong.color.r, Text_Wrong.color.g, Text_Wrong.color.b, 0);
        while (Text_Wrong.color.a < 1.0f)
        {
            Text_Wrong.color = new Color(Text_Wrong.color.r, Text_Wrong.color.g, Text_Wrong.color.b, Text_Wrong.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroAlpha2());
    }

    public IEnumerator FadeTextToZeroAlpha2()
    {
        Text_Wrong.color = new Color(Text_Wrong.color.r, Text_Wrong.color.g, Text_Wrong.color.b, 1);
        while (Text_Wrong.color.a > 0.0f)
        {
            Text_Wrong.color = new Color(Text_Wrong.color.r, Text_Wrong.color.g, Text_Wrong.color.b, Text_Wrong.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
    }




    public void OnButtonJumpClicked(PointerEventData data)
    {
        player.GetComponent<PlayerController>()._state = PlayerController.State.Jump;
    }

    public void OnButtonTalkClicked(PointerEventData data)
    {
        if (_scene == Define.Scene.CatchTheSpy)
        {
            CatchTheSpy cts = CatchTheSpy.GetInstance;
            if (cts != null)
            {
                if (cts._isNearVillager == true)
                {
                    cts.InteractVillager();
                }
            }
        }

        //
        else if (_scene == Define.Scene.CrossTheBridge)
        {
            // CrossTheBridge에서 대화 기능은 필요하지 않습니다.
        }

        //
        else if (_scene == Define.Scene.MacMan)
        {
            if (player.GetComponent<Player>().meetingCoin.tag == "PurpleCoin" || player.GetComponent<Player>().meetingCoin.tag == "RedCoin" ||
                player.GetComponent<Player>().meetingCoin.tag == "BlueCoin" || player.GetComponent<Player>().meetingCoin.tag == "GreenCoin")
            {
                player.GetComponent<Player>().metCoin = player.GetComponent<Player>().meetingCoin;
                player.GetComponent<Player>().meetingCoin.SetActive(false);
            }


            // 다음 문제를 냅니다.
            GameObject _ui = GameObject.Find("@UI");
            MacManProblemUI _macManProblemUI = null;
            GameObject _crossTheBridgeProblem = Utilize.FindChild(_ui, "MacManProblemUI", true);
            _macManProblemUI = _crossTheBridgeProblem.GetComponent<MacManProblemUI>();
            

            // 정답 처리 코드 작성
            // 보라 0, 빨강 1, 파랑 2, 초록 3
            int answerIndex = GetProblemCorrectAnswerIndex();
            Debug.Log(answerIndex);

            Debug.Log("[SkillUI.cs] 문제 정답 인덱스는 " + $" { answerIndex } 입니다.");

            string answerCoin = null;
            switch (answerIndex)
            {
                case 0:
                    answerCoin = "PurpleCoin";
                    break;
                case 1:
                    answerCoin = "RedCoin";
                    break;
                case 2:
                    answerCoin = "BlueCoin";
                    break;
                case 3:
                    answerCoin = "GreenCoin";
                    break;
            }

            // 답이 맞았을 경우
            if (answerCoin == player.GetComponent<Player>().metCoin.tag)
            {
                player.GetComponent<Player>().question++;
                player.GetComponent<Player>().correct++;
                player.GetComponent<Player>().score += 3000;
                StartCoroutine(FadeTextToFullAlpha1());
                Managers.GetSoundManager.Play("correct_answer");

                for (int i = 0; i < 234; i++)
                {
                    GameObject.Find("Environment/Coin/Cubie (" + i + ")").SetActive(true);
                }
                GameObject go = GameObject.Find("RandomCoinMaker");
                go.GetComponent<RandomAnswer>().MakeRandomCoin();
                player.GetComponent<Player>().metCoin = null;

                _macManProblemUI.GetMacManProblemContent();
            }

            // 답이 틀렸을 경우
            else
            {
                player.GetComponent<Player>().wrong++;
                Debug.Log("Worng!!");
                player.GetComponent<Player>().score -= (3000 * player.GetComponent<Player>().question);
                Managers.GetSoundManager.Play("wrong_answer");
                StartCoroutine(FadeTextToFullAlpha2());
            }

        }
    }

    public int GetProblemCorrectAnswerIndex()
    {
        WJ_Mathpid _WJMathpid = GameObject.Find("@Managers").GetComponent<WJ_Mathpid>();
        return _WJMathpid.GetCorrectAnswer();
    }
}
