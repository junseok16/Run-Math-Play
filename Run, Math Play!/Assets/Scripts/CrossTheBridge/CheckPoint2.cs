using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CheckCollider에 붙여야함
public class CheckPoint2 : MonoBehaviour
{
    GameObject player;
    GameObject checkLine1;
    GameObject environment;
    public Vector3 pos;

    void Start()
    {
        player = GameObject.FindWithTag("Player");  // Player
        checkLine1 = GameObject.Find("lineRed2 (1)"); // CheckLine2
        pos = checkLine1.transform.position; // CheckLine2의 위치
        environment = GameObject.Find("Environment"); // Environment
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌 시 
        { // 리스폰 위치를 CheckLine2의 위치로 갱신
            player.GetComponent<RespawnPosition>().respawnPos = pos;
            // 체크포인트 빨간타일을 파란타일로 변경
            environment.GetComponent<CheckPointInst>().ChangeCheckLine2();
        }
    }
}
