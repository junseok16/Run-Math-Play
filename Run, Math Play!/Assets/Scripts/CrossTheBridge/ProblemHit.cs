using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProblemHit : MonoBehaviour// Player�� �ٿ��� ��
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
    public int score = 0;               // ���� ��Ͽ�
    public GameObject scoreboard;       // ���� ��Ͽ�
    TextMeshProUGUI resourceText;       // ���� ��Ͽ�

    static public int correct = 0;// ���� ���� ����   (�ӽ�)
    public bool isDelay;// �� Ÿ�Ͽ� ���ÿ� ��� ��Ȳ�� �ذ��ϱ� ���� ���� ���� ����

    void Start()
    {
        problemTiles = GameObject.Find("ProblemTiles");
        safeZoneTiles = GameObject.Find("SafeZoneTiles");
        anim = GetComponent<Animator>(); // �÷��̾��� �ִϸ�����
       
        _WJMathpid = GameObject.Find("@Managers").GetComponent<WJ_Mathpid>();
        // _WJMathpid.SetLearning();

        _ui = GameObject.Find("@UI");
        _crossTheBridgeProblem = Utilize.FindChild(_ui, "CrossTheBridgeProblemUI", true);
        _crossTheBridgeProblemUI = _crossTheBridgeProblem.GetComponent<CrossTheBridgeProblemUI>();
        scoreboard = GameObject.Find("@UI/CrossTheBridgeProblemUI/Score_Frame/Text_Score");
        resourceText = scoreboard.GetComponent<TextMeshProUGUI>();

        GetProblemContent();// ù ��° ������ ���ϴ�.
    }

    void OnCollisionEnter(Collision other)
    {    // �ε��� ��ü�� �±װ� Problem�̸鼭, �÷��̾��� y�� ��ġ�� ������Ʈ���� ���� ��ġ�ϸ鼭, �÷��̾ ���������� ������ Ÿ���� �߶���Ŵ

        int answerIndex = GetProblemCorrectAnswerIndex();

        if ((gameObject.transform.position.y > other.gameObject.transform.position.y)
            && (anim.GetBool("isJumping") == false))
        {
            //Debug.Log(other.gameObject.tag);
            //Debug.Log("����: " + (answerIndex + 1) + "��");

            if (other.gameObject.tag == "Problem1" || other.gameObject.tag == "Problem2" || other.gameObject.tag == "Problem3")
            { // player�� �浹�� ������Ʈ�� �±װ� Problem 1~3�� ��
                rb = other.gameObject.GetComponent<Rigidbody>(); // player�� �浹�� ������Ʈ�� Rigidbody

                // ���� ����Ÿ�ϰ� �浹���� ��
                if (other.gameObject.tag == "Problem" + $"{ answerIndex + 1 }") // 3������ �� (index+1)��° ������
                {
                    SolveProb();
                }
                else
                {
                    rb.isKinematic = false;  // Rigidbody ��Ȱ��ȭ
                    Managers.GetSoundManager.Play("Wrong_answer"); // ���� ȿ���� ���
                }
            }
        }
    }

    void SolveProb()// ���� ���ο� ���� ����
    {
        Debug.Log("isDelay: " + isDelay);
        if (isDelay == false)// ���� ��
        {
            isDelay = true;
            correct += 1;
            problemTiles.GetComponent<ProblemInst>().DestroyProblem(correct);// ���� Ÿ�� ����
            problemTiles.GetComponent<ProblemInst>().DestoryAnswer(correct); // ���� �ؽ�Ʈ ����
            safeZoneTiles.GetComponent<SafeZoneInst>().InstSafeZone(correct);// ���� Ÿ�� ����
            Managers.GetSoundManager.Play("Correct_answer"); // ���� ȿ���� ���
            Debug.Log("���� ���� ������ " + correct + "�� �Դϴ�.");
            score += 1000; // ���� ����

            if (correct < 16)
            {
                GetProblemContent(); // ���� ���� ��������
            }
            else if (correct == 16)
            {
                correct = 0;
            }
            StartCoroutine(PreventDoubleHit()); // 0.1�� ����
            
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
    

    IEnumerator PreventDoubleHit() // 2���� Ÿ�ϰ� ���ÿ� �浹�� �� correct�� �ѹ��� 2 ������ ���� �����ϴ� �Լ�
    {
        yield return new WaitForSeconds(.1f);
        isDelay = false;
    }

    // �����κ��� ������ �޽��ϴ�.
    public void GetProblemContent()
    {
        // ������ ��� Ǯ���� ���� ������ �� �̻� ������� �ʽ��ϴ�.
        _crossTheBridgeProblemUI.GetCrossTheBridgeProblemContent();
    }

    public int GetProblemCorrectAnswerIndex()
    {
        return _WJMathpid.GetCorrectAnswer();
    }
}
