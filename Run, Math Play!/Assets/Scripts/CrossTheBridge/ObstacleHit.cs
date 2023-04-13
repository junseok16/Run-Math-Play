using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 장애물에 붙여야 함
public class ObstacleHit : MonoBehaviour
{
    GameObject player;
    GameObject deadZone;
    public GameObject lifeUI;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        deadZone = GameObject.FindWithTag("DeadZone");
        lifeUI = GameObject.Find("LifeUI");
    }

     void OnCollisionEnter(Collision other)
    { // 공 
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<RespawnPosition>().Respawn(); // 리스폰
            deadZone.GetComponent<DeadZone>().life -= 1; // 목숨 하나 소모
            player.GetComponent<ProblemHit>().score -= 1000; //점수 감소
            lifeUI.GetComponent<LifeUI>().DecreaseLife();
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    { // Swipers & spikeRollers
        if (other.CompareTag("Player"))
        {
            player.GetComponent<RespawnPosition>().Respawn(); // 리스폰
            deadZone.GetComponent<DeadZone>().life -= 1; // 목숨 하나 소모
            player.GetComponent<ProblemHit>().score -= 1000; //점수 감소
            lifeUI.GetComponent<LifeUI>().DecreaseLife();
        }
    }
}
