using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField] protected int _level;
    [SerializeField] protected int _hp;
    [SerializeField] protected int _maxHp;
    [SerializeField] protected int _attack;
    [SerializeField] protected int _defense;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _jumpForce;

    public int Level { get { return _level; } set { _level = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defense { get { return _defense; } set { _defense = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public float JumpForce { get { return _jumpForce; } set { _jumpForce = value; } }

    private void Start()
    {
        _level = 1;
        _hp = 0;
        _maxHp = 0;
        _attack = 0;
        _defense = 0;
        _moveSpeed = 10;
        _jumpForce = 10;
    }

    public virtual void OnGameStart(Stat stage)
    {
        PlayerStat playerStat = stage as PlayerStat;
        if (playerStat != null)
        {
            // 경험치와 골드를 증가시킵니다.
            playerStat.Exp += 15;
            playerStat.Gold += 15;
        }
    }

    public virtual void OnGameOver(Stat stage)
    {
        PlayerStat playerStat = stage as PlayerStat;
        if (playerStat != null)
        {
            // 경험치와 골드를 증가시킵니다.
            playerStat.Exp += 15;
            playerStat.Gold += 15;
        }
    }
}
