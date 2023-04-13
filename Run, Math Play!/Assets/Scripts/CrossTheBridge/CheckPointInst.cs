using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Environment 에 달아주어야 함
public class CheckPointInst : MonoBehaviour
{
    public GameObject checkLine1; // 빨간 체크라인1
    public GameObject checkLine2; // 빨간 체크라인2
    public GameObject checkComplete1; // 파란 체크포인트1
    public GameObject checkComplete2; // 파란 체크포인트2
    public GameObject checkPoint1; // 체크포인트 지역1
    public GameObject checkPoint2; // 체크포인트 지역2

    void Start()
    {
        checkLine1 = GameObject.Find("CheckLine1");
        checkLine2 = GameObject.Find("CheckLine2");
        checkPoint1 = GameObject.Find("CheckPoint 1"); // 체크포인트 지역1
        checkPoint2 = GameObject.Find("CheckPoint 2"); // 체크포인트 지역2
    }

    public void ChangeCheckLine1()  // 빨간타일1 삭제, 파란타일1 생성
    {
        if(GameObject.Find("CheckComplete1(Clone)") == null)
        {
            checkComplete1 = Resources.Load<GameObject>("Prefabs/CrossTheBridge/CheckComplete1");
            GameObject checkComplete1clone = Instantiate(checkComplete1);
            checkComplete1clone.transform.parent = checkPoint1.transform;
        }
        Destroy(checkLine1);
    }
    public void ChangeCheckLine2() // 빨간타일2 삭제, 파란타일2 생성
    {
        if (GameObject.Find("CheckComplete2(Clone)") == null)
        {
            checkComplete2 = Resources.Load<GameObject>("Prefabs/CrossTheBridge/CheckComplete2");
            GameObject checkComplete2clone = Instantiate(checkComplete2);
            checkComplete2clone.transform.parent = checkPoint2.transform;
        }
         Destroy(checkLine2);
    }
}
