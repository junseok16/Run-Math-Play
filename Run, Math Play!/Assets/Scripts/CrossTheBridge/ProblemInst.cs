using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ProblemTiles에 붙여주어야 함
public class ProblemInst : MonoBehaviour
{
    public GameObject problem1;
    public GameObject problem6;
    public GameObject problem11;
    public GameObject problemTiles;

    void Start()
    {
        problemTiles = GameObject.Find("ProblemTiles");
    }

    public void InstProblem(int n) // n번째 문제타일이 생성됨.
    {
        problem1 = Resources.Load<GameObject>("Prefabs/CrossTheBridge/Problem_1");
        problem6 = Resources.Load<GameObject>("Prefabs/CrossTheBridge/Problem_6");
        problem11 = Resources.Load<GameObject>("Prefabs/CrossTheBridge/Problem_11");

        if (n <= 5)
        {
            GameObject problem1clone = Instantiate(problem1, new Vector3(0, ((n-1)%5) * (float)1.5, ((n-1)%5) * 13), Quaternion.identity);
            problem1clone.transform.parent = problemTiles.transform;
            problem1clone.name = "ProblemTile" + n;
        }
        if (5 < n && n <= 10)
        {
            GameObject problem6clone = Instantiate(problem6, new Vector3(0, ((n-1)%5) * (float)1.5, ((n-1)%5) * 13), Quaternion.identity);
            problem6clone.transform.parent = problemTiles.transform;
            problem6clone.name = "ProblemTile" + n;
        }
        if (10 < n && n <= 15)
        {
            GameObject problem11clone = Instantiate(problem11, new Vector3(0, ((n-1)%5) * (float)1.5, ((n-1)%5) * 13), Quaternion.identity);
            problem11clone.transform.parent = problemTiles.transform;
            problem11clone.name = "ProblemTile" + n;
        }
        if (n == 16)
        {
            GameObject safeZone11clone = Instantiate(problem11, new Vector3(0, (float)7.5, 65), Quaternion.identity);
            safeZone11clone.transform.parent = problemTiles.transform;
            safeZone11clone.name = "ProblemTile" + n;
        }
    }

    public void DestroyProblem(int j)
    {
        GameObject correctProb = GameObject.Find("ProblemTile" + j);
        Destroy(correctProb); // 타일 삭제
    }

    public void DestoryAnswer(int j)
    {
        GameObject answerTexts = GameObject.Find("Answer" + j);
        Destroy(answerTexts); // 보기 삭제
    }
}
