using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DeadZone�� �ٿ��� ��
public class DeadZone : MonoBehaviour
{
    GameObject player;
    public GameObject lifeUI;
    public int life = 3; // ���

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        lifeUI = GameObject.Find("LifeUI");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            life -= 1; // ��� �ϳ� ����
            player.GetComponent<RespawnPosition>().Respawn(); // ������
            player.GetComponent<ProblemHit>().score -= 1000; //���� ����
            Debug.Log("���� ���: " + life + "��");
            lifeUI.GetComponent<LifeUI>().DecreaseLife();
        }
    }
}
