using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CheckCollider�� �ٿ�����
public class CheckPoint1 : MonoBehaviour
{
    GameObject player;
    GameObject checkLine1;
    GameObject environment;
    public Vector3 pos;

    void Start()
    {
        player = GameObject.FindWithTag("Player");  // Player
        checkLine1 = GameObject.Find("lineRed1 (1)"); // CheckLine1
        pos = checkLine1.transform.position; // CheckLine1�� ��ġ
        environment = GameObject.Find("Environment"); // Environment
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹 �� 
        { // ������ ��ġ�� CheckLine1�� ��ġ�� ����
            player.GetComponent<RespawnPosition>().respawnPos = pos;
            // üũ����Ʈ ����Ÿ���� �Ķ�Ÿ�Ϸ� ����
            environment.GetComponent<CheckPointInst>().ChangeCheckLine1();
        }
    }
}
