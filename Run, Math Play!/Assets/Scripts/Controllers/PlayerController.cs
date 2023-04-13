using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : PlayerController
    @date   : 2022-08-28
    @author : Ź�ؼ�
    @brief  : �÷��̾ �̵���Ű�� �ִϸ��̼��� �����ݴϴ�.
    @warning: �� ��ũ��Ʈ�� Player ������Ʈ�� �ٿ��ּ���.
 */

public class PlayerController : MonoBehaviour
{
    // �÷��̾��� ���¸� �����մϴ�.
    public enum State { Move, Jump, Idle, Win, Lose }
    public State _state { get; set; } = State.Idle;
    public Vector2 _direction { get; set; } = Vector2.zero;

    private PlayerStat _stat;
    public Animator _anim = null;
    public bool _isGround = true;// �÷��̾ ���� �ִ��� Ȯ���� ����

    void Start()
    {
        _stat = gameObject.GetComponent<PlayerStat>();
        _anim = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        // �÷��̾� ���¿� ���� �����Ӱ� �ִϸ��̼��� �����մϴ�.
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

    // �÷��̾ �̵��ϴ� �����Ӱ� �ִϸ��̼��� �����մϴ�.
    void UpdateMove()
    {
        transform.position += new Vector3(_direction.x, 0, _direction.y) * Time.deltaTime * _stat.MoveSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.y)), 0.2f);
        _anim.SetFloat("Speed", _stat.MoveSpeed);
    }

    // �÷��̾ �ٴ� �����Ӱ� �ִϸ��̼��� �����մϴ�.
    void UpdateJump()
    {
        // Player�� �� ���� ���� ���
        if (_isGround == true)
        {
            _anim.SetBool("isJumping", true);
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _stat.JumpForce, ForceMode.Impulse);
            _isGround = false;
        }
        _state = State.Idle;
    }

    // �÷��̾ ������ �ִ� �����Ӱ� �ִϸ��̼��� �����մϴ�.
    void UpdateIdle()
    {
        // �÷��̾ �̵��ϴ� �ִϸ��̼��� �����մϴ�.
        _anim.SetFloat("Speed", 0);
        _anim.SetBool("isJumping", false);
    }
    
    // �ε��� ������Ʈ�� �±װ� Ground�� isGround�� true�� �����մϴ�.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Problem"))
        {
            _isGround = true;
            _anim.SetBool("isJumping", false);
        }
    }
}
