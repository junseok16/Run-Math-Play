using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour // cannon1에 붙여주어야 함
{
    public GameObject _cannon;
    public GameObject _ball;

    void Start()
    {
        StartCoroutine(CoroutineShoot());
    }

    private IEnumerator CoroutineShoot()
    {
        while (true)
        {
            GameObject projectile = null;
            
            if (gameObject.tag == "Cannon1")
            {
                float directionX = Random.Range(-0.5f, 0.5f);
                projectile = Instantiate(_ball, _cannon.transform.position + new Vector3(0, 0, -4), Quaternion.identity);
                projectile.GetComponent<Rigidbody>().velocity = new Vector3(directionX, 0.5f, -1) * 20f;
            }
            else if (gameObject.tag == "Cannon2")
            {
                float directionX = Random.Range(-0.5f, 0.5f);
                projectile = Instantiate(_ball, _cannon.transform.position + new Vector3(0, 0, -4), Quaternion.identity);
                projectile.GetComponent<Rigidbody>().velocity = new Vector3(directionX, 0.5f, -1) * 20f;
            }
            yield return new WaitForSeconds(5.0f);
            Destroy(projectile);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
