using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : PlayerController
    @date   : 2022-08-28
    @author : 탁준석
    @brief  : 플레이어를 이동시키고 애니메이션을 보여줍니다.
    @warning: 이 스크립트는 Player 오브젝트에 붙여주세요.
 */

public class PlayerController : MonoBehaviour
{
    // 플레이어의 상태를 나열합니다.
    public enum State { Move, Jump, Idle, Win, Lose }
    public State _state { get; set; } = State.Idle;
    public Vector2 _direction { get; set; } = Vector2.zero;

    private PlayerStat _stat;
    public Animator _anim = null;
    public bool _isGround = true;// 플레이어가 땅에 있는지 확인할 변수

    void Start()
    {
        _stat = gameObject.GetComponent<PlayerStat>();
        _anim = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        // 플레이어 상태에 따라 움직임과 애니메이션을 변경합니다.
        switch (_state)
        {
            case State.Move:
                UpdateMove();
                break;
            case State.Jump:
                UpdateJump();
                break;
            case State.Idle:
                UpdateIdle();
                break;
        }
    }

    // 플레이어가 이동하는 움직임과 애니메이션을 정의합니다.
    void UpdateMove()
    {
        transform.position += new Vector3(_direction.x, 0, _direction.y) * Time.deltaTime * _stat.MoveSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.y)), 0.2f);
        _anim.SetFloat("Speed", _stat.MoveSpeed);
    }

    // 플레이어가 뛰는 움직임과 애니메이션을 정의합니다.
    void UpdateJump()
    {
        // Player가 땅 위에 있은 경우
        if (_isGround == true)
        {
            _anim.SetBool("isJumping", true);
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _stat.JumpForce, ForceMode.Impulse);
            _isGround = false;
        }
        _state = State.Idle;
    }

    // 플레이어가 가만히 있는 움직임과 애니메이션을 정의합니다.
    void UpdateIdle()
    {
        // 플레이어가 이동하는 애니메이션을 설정합니다.
        _anim.SetFloat("Speed", 0);
        _anim.SetBool("isJumping", false);
    }
    
    // 부딪힌 오브젝트의 태그가 Ground면 isGround를 true로 변경합니다.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Problem"))
        {
            _isGround = true;
            _anim.SetBool("isJumping", false);
        }
    }
}
