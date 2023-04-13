using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player�� �ٿ��� ��
public class RespawnPosition : MonoBehaviour
{
    GameObject startLine;
    public Vector3 respawnPos;

    GameObject problemTiles;

    void Start()
    {
        startLine = GameObject.Find("Line (1)"); // ���۶���
        respawnPos = startLine.transform.position; // ������ ��ġ

        problemTiles = GameObject.Find("ProblemTiles");
    }

    public void Respawn()
    {
        transform.position = respawnPos + new Vector3(0, 1.5f, 0); // ������ ��ġ�� �̵�
        problemTiles.GetComponent<ProblemInst>().DestroyProblem(ProblemHit.correct+1); // ����Ÿ�� ����
        problemTiles.GetComponent<ProblemInst>().InstProblem(ProblemHit.correct+1);  // ����Ÿ�� �����
    }

}
