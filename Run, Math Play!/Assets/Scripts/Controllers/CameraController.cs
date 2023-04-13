using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : CameraController
    @date   : 2022-08-28
    @author : 탁준석
    @brief  : 플레이어를 이동시키고 애니메이션을 보여줍니다.
    @warning: 이 스크립트는 Main Camera 오브젝트에 붙여주세요.
              벽으로 작동하고 싶은 오브젝트는 레이어를 7번 Wall로 변경해주세요.
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
        // 카메라 모드가 쿼터 뷰(Quarter View)인 경우, 벽이 카메라를 가리지 않도록 합니다.
        if (_camera == Define.Camera.QuarterView)
        {
            RaycastHit hit;

            // 플레이어 위치에서 카메라 위치로 발사한 광선이 Wall 레이어를 갖는 오브젝트와 충돌한 경우
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float distance = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * distance;
            }
            // Wall 레이어를 갖는 오브젝트와 충돌하지 않은 경우
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

        // Cross The Bridge 신에서 카메라 위치를 설정합니다.
        if (_camera == Define.Camera.CrossTheBridgeView)
        {
            transform.position = _player.transform.position + _delta;
            // 백 뷰에 알맞는 카메라 위치로 바꿔주세요.
        }
    }

    // 카메라 시점을 쿼터 뷰로 변정합니다.
    public void SetQuarterView(Vector3 delta)
    {
        _camera = Define.Camera.QuarterView;
        _delta = delta;
    }
}