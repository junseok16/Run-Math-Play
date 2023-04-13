using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ֹ��� �ٿ��� ��
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
    { // �� 
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<RespawnPosition>().Respawn(); // ������
            deadZone.GetComponent<DeadZone>().life -= 1; // ��� �ϳ� �Ҹ�
            player.GetComponent<ProblemHit>().score -= 1000; //���� ����
            lifeUI.GetComponent<LifeUI>().DecreaseLife();
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    { // Swipers & spikeRollers
        if (other.CompareTag("Player"))
        {
            player.GetComponent<RespawnPosition>().Respawn(); // ������
            deadZone.GetComponent<DeadZone>().life -= 1; // ��� �ϳ� �Ҹ�
            player.GetComponent<ProblemHit>().score -= 1000; //���� ����
            lifeUI.GetComponent<LifeUI>().DecreaseLife();
        }
    }
}
