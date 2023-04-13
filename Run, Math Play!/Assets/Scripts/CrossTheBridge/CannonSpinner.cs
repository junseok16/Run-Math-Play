using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cannon에 붙여주어야 함
public class CannonSpinner : MonoBehaviour 
{
    void Update()
    {
        //CannonSpin();
    }

    void CannonSpin()
    {
        if (gameObject.tag == "Cannon1")
        {
            transform.eulerAngles = new Vector3(0, -Mathf.PingPong(Time.time * 15, 35) + 260, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, Mathf.PingPong(Time.time * 15, 35) + 280, 0);
        }
    }
}
