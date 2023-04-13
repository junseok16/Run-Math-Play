using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SafeZoneTiles에 붙여주어야 함
public class SafeZoneInst : MonoBehaviour
{
    public GameObject safeZone1;
    public GameObject safeZone6;
    public GameObject safeZone11;
    public GameObject safeZoneTiles;

    void Start()
    {
        safeZoneTiles = GameObject.Find("SafeZoneTiles");
    }

    public void InstSafeZone(int n)
    {
        safeZone1 = Resources.Load<GameObject>("Prefabs/CrossTheBridge/SafeZone_1");
        safeZone6 = Resources.Load<GameObject>("Prefabs/CrossTheBridge/SafeZone_6");
        safeZone11 = Resources.Load<GameObject>("Prefabs/CrossTheBridge/SafeZone_11");

        if(n <= 5)
        {
            GameObject safeZone1clone = Instantiate(safeZone1, new Vector3(0, ((n - 1) % 5) * (float)1.5, ((n - 1) % 5) * 13), Quaternion.identity);
            safeZone1clone.transform.parent = safeZoneTiles.transform;
            safeZone1clone.name = "SafeZoneTile" + n;
        }
        if (5 < n && n <= 10)
        {
            GameObject safeZone6clone = Instantiate(safeZone6, new Vector3(0, ((n - 1) % 5) * (float)1.5, ((n - 1) % 5) * 13), Quaternion.identity);
            safeZone6clone.transform.parent = safeZoneTiles.transform;
            safeZone6clone.name = "SafeZoneTile" + n;
        }
        if (10 < n && n <= 15)
        {
            GameObject safeZone11clone = Instantiate(safeZone11, new Vector3(0, ((n - 1) % 5) * (float)1.5, ((n - 1) % 5) * 13), Quaternion.identity);
            safeZone11clone.transform.parent = safeZoneTiles.transform;
            safeZone11clone.name = "SafeZoneTile" + n;
        }
        if(n == 16)
        {
            GameObject safeZone11clone = Instantiate(safeZone11, new Vector3(0, (float)7.5, 65), Quaternion.identity);
            safeZone11clone.transform.parent = safeZoneTiles.transform;
            safeZone11clone.name = "SafeZoneTile" + n;
        }
    }
}
