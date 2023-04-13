using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Environment �� �޾��־�� ��
public class CheckPointInst : MonoBehaviour
{
    public GameObject checkLine1; // ���� üũ����1
    public GameObject checkLine2; // ���� üũ����2
    public GameObject checkComplete1; // �Ķ� üũ����Ʈ1
    public GameObject checkComplete2; // �Ķ� üũ����Ʈ2
    public GameObject checkPoint1; // üũ����Ʈ ����1
    public GameObject checkPoint2; // üũ����Ʈ ����2

    void Start()
    {
        checkLine1 = GameObject.Find("CheckLine1");
        checkLine2 = GameObject.Find("CheckLine2");
        checkPoint1 = GameObject.Find("CheckPoint 1"); // üũ����Ʈ ����1
        checkPoint2 = GameObject.Find("CheckPoint 2"); // üũ����Ʈ ����2
    }

    public void ChangeCheckLine1()  // ����Ÿ��1 ����, �Ķ�Ÿ��1 ����
    {
        if(GameObject.Find("CheckComplete1(Clone)") == null)
        {
            checkComplete1 = Resources.Load<GameObject>("Prefabs/CrossTheBridge/CheckComplete1");
            GameObject checkComplete1clone = Instantiate(checkComplete1);
            checkComplete1clone.transform.parent = checkPoint1.transform;
        }
        Destroy(checkLine1);
    }
    public void ChangeCheckLine2() // ����Ÿ��2 ����, �Ķ�Ÿ��2 ����
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
