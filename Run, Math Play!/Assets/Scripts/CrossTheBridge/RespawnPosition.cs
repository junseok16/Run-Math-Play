using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player에 붙여야 함
public class RespawnPosition : MonoBehaviour
{
    GameObject startLine;
    public Vector3 respawnPos;

    GameObject problemTiles;

    void Start()
    {
        startLine = GameObject.Find("Line (1)"); // 시작라인
        respawnPos = startLine.transform.position; // 리스폰 위치

        problemTiles = GameObject.Find("ProblemTiles");
    }

    public void Respawn()
    {
        transform.position = respawnPos + new Vector3(0, 1.5f, 0); // 저장한 위치로 이동
        problemTiles.GetComponent<ProblemInst>().DestroyProblem(ProblemHit.correct+1); // 문제타일 삭제
        problemTiles.GetComponent<ProblemInst>().InstProblem(ProblemHit.correct+1);  // 문제타일 재생성
    }

}
