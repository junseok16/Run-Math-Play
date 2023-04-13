using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 사용법
    1. 객체 생성        
        Timer timer;
        timer = Utilize.GetOrAddComponent<Timer>(this.gameObject);
    2. 타이머 시작       timer.Operate()
    3. 원할 때 마다      timer.GetString() ("00:00" 이런 식으로 string 초 반환해줌.)
    4. 타이머 일시정지       timer.Stop()
*/
public class Timer : MonoBehaviour
{
    private int seconds = 0;
    private bool isOperating = false;

    public void Operate()
    {
        isOperating = true;
        StartCoroutine(LoopTimer());
    }

    public string GetString()
    {
        string minutesStr = (seconds / 60).ToString().PadLeft(2, '0');
        string secondsStr = (seconds % 60).ToString().PadLeft(2, '0');
        
        string form = minutesStr + ":" + secondsStr;
        
        return form;
    }

    public void Stop()
    {
        isOperating = false;
    }

    private IEnumerator LoopTimer()
    {
        while (isOperating && this != null)
        {
            seconds++;
            yield return new WaitForSeconds(1);
        }
    }
}
