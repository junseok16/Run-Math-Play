using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @date   : 2022-09-16
    @author : 이기윤
    @brief  : '스파이를 잡아라' 게임 매니저겸 스크립트
    @warning: 싱글톤입니다. CatchTheSpy.GetInstance 로 접근. (CatchTheSpy 씬 내에서만 사용 가능)
 */
public class CatchTheSpy : MonoBehaviour
{
    [SerializeField] GameObject _villagersObj;
    [SerializeField] GameObject _prisonsObj;

    // 게임이 종료돼었을 때 서버로 데이터를 보내는 변수
    WJ_Mathpid _WJMathpid;

    // 주민과 상호작용이 가능한 위치인지 아닌지 판단하는 변수.
    public bool _isNearVillager = false;
    public GameObject _nearVillager = null;
    public RemainingVillagerUI _remainingVillagerUI;

    private int _completeCount = 0;
    private int _failCount = 0;
    private int _prisonIdx = 0;
    private int _accuracy = 100; // 실패할 때 마다 10% 감소
    private TimerUI timerUI;
    private LifeUI lifeUI;
    

    private static CatchTheSpy _instance = null;
    public static CatchTheSpy GetInstance
    {
        get => _instance;
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        timerUI = Managers.GetUIManager.OpenSceneUI<TimerUI>();
        lifeUI = Managers.GetUIManager.OpenSceneUI<LifeUI>();
        _remainingVillagerUI = Managers.GetUIManager.OpenSceneUI<RemainingVillagerUI>();
    }

    // 현재 '가까운 주민' 으로 저장된 주민과 상호작용을 시도합니다.
    public void InteractVillager()
    {
        var villagerInteractionUI = Managers.GetUIManager.OpenPopupUI<VillagerInteractionUI>();
        villagerInteractionUI._targetVillager = _nearVillager;
        _isNearVillager = false;
        _nearVillager = null;
        
        int rand = Random.Range(1, 101);

        // 30% 확률로 스파이가 됩니다.
        if (rand <= 30)
        {
            villagerInteractionUI._isSpy = true;
        }
    }

    public void IncreaseFailCount()
    {
        lifeUI.DecreaseLife();
        _accuracy -= 10;
        // 3번 실패 시 게임을 종료합니다.
        if(++_failCount >= 3)
        {
            FinishGame(false);
        }
    }
    public void IncreaseCompleteCount()
    {
        // 주민 모두와 상호작용하면 게임을 종료합니다.
        if(++_completeCount >= 10)
        {
            FinishGame(true);
        }
    }

    public Vector3 GetPositionNextPrison()
    {
        GameObject[] prisons = Utilize.FindChildren(_prisonsObj);
        Vector3 pos = prisons[_prisonIdx++].transform.position;
        return pos;
    }

    private void FinishGame(bool isWin)
    {
        // 서버로 데이터를 전송합니다.
        _WJMathpid = GameObject.Find("@Managers").GetComponent<WJ_Mathpid>();
        _WJMathpid.OnLearningResult();

        if (isWin)
        {
            // 게임 클리어 화면 띄우고, 걸린 시간/정확도 입력함.
            var ui = Managers.GetUIManager.OpenPopupUI<GameClearUI>();
            ui.SetTime(timerUI.timer.GetString());
            ui.SetAccuracy(_accuracy);
        }
        else
        {
            Managers.GetUIManager.OpenPopupUI<GameOverUI>();
        }
    }
}
