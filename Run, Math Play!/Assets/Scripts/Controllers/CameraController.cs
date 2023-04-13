using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : CameraController
    @date   : 2022-08-28
    @author : Ź�ؼ�
    @brief  : �÷��̾ �̵���Ű�� �ִϸ��̼��� �����ݴϴ�.
    @warning: �� ��ũ��Ʈ�� Main Camera ������Ʈ�� �ٿ��ּ���.
              ������ �۵��ϰ� ���� ������Ʈ�� ���̾ 7�� Wall�� �������ּ���.
 */

public class CameraController : MonoBehaviour
{
    [SerializeField] Define.Camera _camera = Define.Camera.QuarterView;
    [SerializeField] Vector3 _delta = new Vector3(0.0f, 4.0f, -8.0f);
    [SerializeField] GameObject _player = null;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        // ī�޶� ��尡 ���� ��(Quarter View)�� ���, ���� ī�޶� ������ �ʵ��� �մϴ�.
        if (_camera == Define.Camera.QuarterView)
        {
            RaycastHit hit;

            // �÷��̾� ��ġ���� ī�޶� ��ġ�� �߻��� ������ Wall ���̾ ���� ������Ʈ�� �浹�� ���
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float distance = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * distance;
            }
            // Wall ���̾ ���� ������Ʈ�� �浹���� ���� ���
            else
            {
                transform.position = _player.transform.position + _delta;
                //transform.LookAt(_player.transform);
            }
        }

        if (_camera == Define.Camera.MacManView)
        {
            transform.position = _player.transform.position + _delta;
            transform.LookAt(_player.transform);
        }

        // Cross The Bridge �ſ��� ī�޶� ��ġ�� �����մϴ�.
        if (_camera == Define.Camera.CrossTheBridgeView)
        {
            transform.position = _player.transform.position + _delta;
            // �� �信 �˸´� ī�޶� ��ġ�� �ٲ��ּ���.
        }
    }

    // ī�޶� ������ ���� ��� �����մϴ�.
    public void SetQuarterView(Vector3 delta)
    {
        _camera = Define.Camera.QuarterView;
        _delta = delta;
    }
}