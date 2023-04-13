using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMover : MonoBehaviour //SpikeRoller�� �پ����
{
    public float minX;
    public float maxX;
    public float moveSpeed = 3.5f;
    int sign = -1;

    void Start()
    {
        if (gameObject.name == "spikeRoller2")
            sign = 1;
        minX = transform.position.x - 8f;
        maxX = transform.position.x + 8f;
    }
    void Update()
    { // �̵� ����
        transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);
        if(transform.position.x <= minX ||
            transform.position.x >= maxX)
        {
            sign = -sign;
        }
    }
}
