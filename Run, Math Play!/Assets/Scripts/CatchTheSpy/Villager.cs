using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/**
    @class  : Villager
    @date   : 2022-09-12
    @author : 이기윤
    @brief  : AI처럼 주변을 서성이게 합니다.
    @warning: 주민에게 붙이는 스크립트입니다.
 */

public class Villager : MonoBehaviour
{
    [SerializeField] float _radius = 5.0f;
    [SerializeField] float _speed = 2.0f;
    [SerializeField] float _rotationSpeed = 60.0f;
    
    public bool _isActive = true; // 액티브가 꺼져있을 때는 '회전'만 합니다.

    private Vector3 _origin; // 원점 좌표.
    
    void Awake()
    {
        _origin = transform.position;
    }
    
    void Start()
    {
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        while(gameObject != null)
        {
            yield return StartCoroutine(LookAngleLerpY(Random.Range(0f, 360f)));
            if (_isActive) yield return StartCoroutine(WalkRandomDistance());
        }
    }

    IEnumerator LookAngleLerpY(float yAngle)
    {
        Vector3 startAngle = transform.eulerAngles;
        Vector3 targetAngle = startAngle;
        targetAngle.y = yAngle;

        float angleGap = Mathf.Abs(startAngle.y - targetAngle.y);
        float rotationTime = angleGap / 360 / (_rotationSpeed / 360);
        float t = 0;

        while(t < 1)
        {

            float formula = 0.5f * Mathf.Sin(Mathf.PI*(t-0.5f)) + 0.5f;
            transform.eulerAngles = Vector3.Lerp(startAngle, targetAngle, formula);

            t += Time.deltaTime / rotationTime;
            yield return null;
        }
    }

    IEnumerator WalkRandomDistance()
    {
        float distance = Random.Range(0, _radius/2);
        // 알고리즘: 벡터로 이동하면서 벡터의 크기만큼 distance에서 계속 빼는 식으로
        while (distance > 0 && _isActive)
        {
            Transform tf = transform;
            
            Vector3 moveVec = tf.forward * _speed;
            distance -= moveVec.magnitude;
            float distance_fromOrigin = Vector3.Distance(tf.position, _origin);
            tf.position += moveVec;
            
            if (distance_fromOrigin > _radius)
            {
                yield break;
            }

            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CatchTheSpy.GetInstance._isNearVillager = true;
            CatchTheSpy.GetInstance._nearVillager = this.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CatchTheSpy.GetInstance._isNearVillager = false;
        }
    }
}
