using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Finish : MonoBehaviour // Finish Point�� FinishCheckCollider�鿡 �ٿ��־�� ��
{
    public bool isFinished = false;
    GameObject deadZone;

    void Start()
    {
        deadZone = GameObject.FindWithTag("DeadZone");
    }
    void Update()
    {
        if (deadZone.GetComponent<DeadZone>().life <= 0 || // ����� 0 �̵ǰų� �ð��� 2���� ����ϸ�
            GameObject.Find("@UI/TimerUI/Text_Time").GetComponent<TextMeshProUGUI>().text == "02:00") 
        {
            if (!isFinished) // �̹� ���� ������ ��츦 ����
            {    
                isFinished = true;
                Debug.Log("���� ����.");
                GameOver();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFinished)
        {
            isFinished = true;
            Debug.Log("���� Ŭ����.");
            GameClear();
        }
    }

    void GameClear() // ������ �� Ǯ�� FinishLIne�� �����Ͽ� ���� Ŭ����
    {
        CrossTheBridge.GetInstance.GameClear();
    }

    void GameOver() // 3ȸ �̻� ��� or �����ð� �ʰ� �� ��������
    {
        CrossTheBridge.GetInstance.GameOver();
    }
}
