using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DeadZone에 붙여야 함
public class DeadZone : MonoBehaviour
{
    GameObject player;
    public GameObject lifeUI;
    public int life = 3; // 목숨

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        lifeUI = GameObject.Find("LifeUI");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            life -= 1; // 목숨 하나 감소
            player.GetComponent<RespawnPosition>().Respawn(); // 리스폰
            player.GetComponent<ProblemHit>().score -= 1000; //점수 감소
            Debug.Log("남은 목숨: " + life + "개");
            lifeUI.GetComponent<LifeUI>().DecreaseLife();
        }
    }
}
