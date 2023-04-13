using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Finish : MonoBehaviour // Finish Point의 FinishCheckCollider들에 붙여주어야 함
{
    public bool isFinished = false;
    GameObject deadZone;

    void Start()
    {
        deadZone = GameObject.FindWithTag("DeadZone");
    }
    void Update()
    {
        if (deadZone.GetComponent<DeadZone>().life <= 0 || // 목숨이 0 이되거나 시간이 2분이 경과하면
            GameObject.Find("@UI/TimerUI/Text_Time").GetComponent<TextMeshProUGUI>().text == "02:00") 
        {
            if (!isFinished) // 이미 게임 끝났을 경우를 방지
            {    
                isFinished = true;
                Debug.Log("게임 종료.");
                GameOver();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFinished)
        {
            isFinished = true;
            Debug.Log("게임 클리어.");
            GameClear();
        }
    }

    void GameClear() // 문제를 다 풀고 FinishLIne에 도달하여 게임 클리어
    {
        CrossTheBridge.GetInstance.GameClear();
    }

    void GameOver() // 3회 이상 사망 or 남은시간 초과 시 게임종료
    {
        CrossTheBridge.GetInstance.GameOver();
    }
}
