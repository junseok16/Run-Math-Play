using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField] protected int _exp;
    [SerializeField] protected int _gold;

    public int Exp {
        get { return _exp; }
        set 
        { 
            _exp = value;
            int level = Level;

            while (true)
            {
                Data.Exp exp;
                if (Managers.GetDataManager.expDictionary.TryGetValue(level + 1, out exp) == false)
                {
                    break;
                }
                if (_exp < exp.totalExp)
                {
                    break;
                }
                ++level;
            }

            if (level != Level)
            {
                Debug.Log("Player level up!");
                Level = level;
                SetStat(Level);
            }
        }
    }

    public int Gold { get { return _gold; } set { _gold = value; } }

    private void Start()
    {
        _level = 1;
        SetStat(_level);
        _exp = 0;
        _gold = 0;
    }

    public void SetStat(int level)
    {
        Dictionary<int, Data.Exp> dict = Managers.GetDataManager.expDictionary;
        // Data.Stat stat = dict[level];

        _hp = 0;
        _maxHp = 0;
        _attack = 0;
        _defense = 0;
        _moveSpeed = 10;
        _jumpForce = 10;
    }
}
