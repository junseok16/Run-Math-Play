using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProblemHit : MonoBehaviour// Player에 붙여야 함
{
    WJ_Mathpid _WJMathpid;
    GameObject _ui = null;
    GameObject _crossTheBridgeProblem = null;
    CrossTheBridgeProblemUI _crossTheBridgeProblemUI = null;

    Animator anim;
    Rigidbody rb;
    GameObject problemTiles;
    GameObject safeZoneTiles;
    public GameObject problem;

    float timer;
    public int score = 0;               // 점수 기록용
    public GameObject scoreboard;       // 점수 기록용
    TextMeshProUGUI resourceText;       // 점수 기록용

    static public int correct = 0;// 맞힌 문제 개수   (임시)
    public bool isDelay;// 두 타일울 동시에 밟는 상황을 해결하기 위한 지연 여부 변수

    void Start()
    {
        problemTiles = GameObject.Find("ProblemTiles");
        safeZoneTiles = GameObject.Find("SafeZoneTiles");
        anim = GetComponent<Animator>(); // 플레이어의 애니메이터
       
        _WJMathpid = GameObject.Find("@Managers").GetComponent<WJ_Mathpid>();
        // _WJMathpid.SetLearning();

        _ui = GameObject.Find("@UI");
        _crossTheBridgeProblem = Utilize.FindChild(_ui, "CrossTheBridgeProblemUI", true);
        _crossTheBridgeProblemUI = _crossTheBridgeProblem.GetComponent<CrossTheBridgeProblemUI>();
        scoreboard = GameObject.Find("@UI/CrossTheBridgeProblemUI/Score_Frame/Text_Score");
        resourceText = scoreboard.GetComponent<TextMeshProUGUI>();

        GetProblemContent();// 첫 번째 문제를 냅니다.
    }

    void OnCollisionEnter(Collision other)
    {    // 부딪힌 물체의 태그가 Problem이면서, 플레이어의 y축 위치가 오브젝트보다 높이 위치하면서, 플레이어가 점프중이지 않을때 타일을 추락시킴

        int answerIndex = GetProblemCorrectAnswerIndex();

        if ((gameObject.transform.position.y > other.gameObject.transform.position.y)
            && (anim.GetBool("isJumping") == false))
        {
            //Debug.Log(other.gameObject.tag);
            //Debug.Log("정답: " + (answerIndex + 1) + "번");

            if (other.gameObject.tag == "Problem1" || other.gameObject.tag == "Problem2" || other.gameObject.tag == "Problem3")
            { // player와 충돌한 오브젝트의 태그가 Problem 1~3일 시
                rb = other.gameObject.GetComponent<Rigidbody>(); // player와 충돌한 오브젝트의 Rigidbody

                // 정답 문제타일과 충돌했을 때
                if (other.gameObject.tag == "Problem" + $"{ answerIndex + 1 }") // 3지선다 중 (index+1)번째 선택지
                {
                    SolveProb();
                }
                else
                {
                    rb.isKinematic = false;  // Rigidbody 비활성화
                    Managers.GetSoundManager.Play("Wrong_answer"); // 오답 효과음 출력
                }
            }
        }
    }

    void SolveProb()// 정답 여부에 따라 반응
    {
        Debug.Log("isDelay: " + isDelay);
        if (isDelay == false)// 정답 시
        {
            isDelay = true;
            correct += 1;
            problemTiles.GetComponent<ProblemInst>().DestroyProblem(correct);// 문제 타일 삭제
            problemTiles.GetComponent<ProblemInst>().DestoryAnswer(correct); // 보기 텍스트 삭제
            safeZoneTiles.GetComponent<SafeZoneInst>().InstSafeZone(correct);// 안전 타일 생성
            Managers.GetSoundManager.Play("Correct_answer"); // 정답 효과음 출력
            Debug.Log("맞힌 문제 개수는 " + correct + "개 입니다.");
            score += 1000; // 점수 증가

            if (correct < 16)
            {
                GetProblemContent(); // 다음 문제 가져오기
            }
            else if (correct == 16)
            {
                correct = 0;
            }
            StartCoroutine(PreventDoubleHit()); // 0.1초 지연
            
        }
    }

    void Update()
    {
        if (score < 0)
            score = 0;
        resourceText.text = score.ToString();

        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            score += 10;
            timer = 0;
        }
    }
    

    IEnumerator PreventDoubleHit() // 2개의 타일과 동시에 충돌할 때 correct가 한번에 2 오르는 것을 방지하는 함수
    {
        yield return new WaitForSeconds(.1f);
        isDelay = false;
    }

    // 서버로부터 문제를 받습니다.
    public void GetProblemContent()
    {
        // 문제를 모두 풀었을 때는 문제를 더 이상 출력하지 않습니다.
        _crossTheBridgeProblemUI.GetCrossTheBridgeProblemContent();
    }

    public int GetProblemCorrectAnswerIndex()
    {
        return _WJMathpid.GetCorrectAnswer();
    }
}
