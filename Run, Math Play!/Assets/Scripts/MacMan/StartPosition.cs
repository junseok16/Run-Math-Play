using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player�� �ٿ��� ��
public class StartPosition : MonoBehaviour
{
    public Vector3 respawnPos;

    void Start()
    {
        respawnPos = new Vector3(10f, 1.5f, 0f);
        transform.position = respawnPos;
    }
}
