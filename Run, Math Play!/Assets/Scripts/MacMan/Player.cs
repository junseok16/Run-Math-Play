using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject meetingCoin = null;      // 현재 옆에 있는 코인
    public GameObject metCoin = null;          // 먹은 코인
    public int score = 0;               // 점수 기록용
    public GameObject scoreboard;       // 점수 기록용
    TextMeshProUGUI resourceText;       // 점수 기록용


    public int question = 1;
    public int correct = 0;
    public int wrong = 0;
    bool flag = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Managers.GetSoundManager.Play("coin_pickup");
            Debug.Log("Meet Coin");
            score += 100;
            meetingCoin = collision.gameObject;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "PurpleCoin" || collision.gameObject.tag == "RedCoin"
            || collision.gameObject.tag == "BlueCoin" || collision.gameObject.tag == "GreenCoin")
        {
            meetingCoin = collision.gameObject;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 nowPosition = gameObject.transform.position;
            
            if (nowPosition.x <= 66 && nowPosition.z <= 36)
            {
                respawn(new Vector3(138, 0, 72));
                score -= (1000 * question);
            }
            else if (nowPosition.x <= 66 && nowPosition.z > 36)
            {
                respawn(new Vector3(138, 0, 0));
                score -= (1000 * question);
            }
            else if (nowPosition.x > 66 && nowPosition.z > 36)
            {
                respawn(new Vector3(-6, 0, 0));
                score -= (1000 * question);
            }
            else if (nowPosition.x > 66 && nowPosition.z <= 36)
            {
                respawn(new Vector3(-6, 0, 72));
                score -= (1000 * question);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "PurpleCoin" || collision.gameObject.tag == "RedCoin" 
            || collision.gameObject.tag == "BlueCoin" || collision.gameObject.tag == "GreenCoin")
        {
            meetingCoin = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GameObject.Find("@UI/MacManProblemUI/Score_Frame/Text_Score");
        resourceText = scoreboard.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        resourceText.text = score.ToString();
        if (!flag)
        {
            if (GameObject.Find("@UI/TimerUI/Text_Time").GetComponent<TextMeshProUGUI>().text == "02:00")
            {
                GameObject.Find("Enemy").SetActive(false);
                GameObject.Find("@UI/MacManProblemUI/Score_Frame").SetActive(false);
                GameObject.Find("@UI/MacManProblemUI/Question_Frame").SetActive(false);
                GameObject.Find("@UI/TimerUI").SetActive(false);
                flag = true;
                GameObject.Find("@MacMan").GetComponent<MacMan>().GameClear();                
            }
        }

        if (!flag)
        {
            if (score < 0)
            {
                score = 0;
                GameObject.Find("Enemy").SetActive(false);
                GameObject.Find("@UI/MacManProblemUI/Score_Frame").SetActive(false);
                GameObject.Find("@UI/MacManProblemUI/Question_Frame").SetActive(false);
                GameObject.Find("@UI/TimerUI").SetActive(false);
                flag = true;
                GameObject.Find("@MacMan").GetComponent<MacMan>().GameOver();
            }
        }
    }

    void respawn(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }
}
