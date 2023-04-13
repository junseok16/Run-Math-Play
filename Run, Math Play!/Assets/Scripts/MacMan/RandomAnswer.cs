using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomAnswer : MonoBehaviour
{
    public List<int> randomNum = new List<int>();
    public Material[] materials = new Material[4];
    public string[] tags = new string[4];// { "PurpleCoin", "RedCoin", "BlueCoin", "GreenCoin" };
    public void MakeRandomCoin()
    {
        int[] randomNumbers = MakeRandomNumbers(4);
        int[] rndCoinNum = MakeRandomNumbers(234);

        for (int i = 1; i < 234; i++)
        {
            GameObject coin = GameObject.Find("Coin/Cubie (" + rndCoinNum[i] + ")");
            coin.GetComponent<MeshRenderer>().material = materials[4];
            coin.tag = "Coin";
        }

        for (int i = 0; i < randomNumbers.Length; i++)
        {
            GameObject coin = GameObject.Find("Coin/Cubie (" + rndCoinNum[i] + ")");
            coin.GetComponent<MeshRenderer>().material = materials[randomNumbers[i]];
            coin.tag = tags[randomNumbers[i]];
        }

        /*for (int i = 0; i < 4; i++)
        {
            int randCoin = Random.Range(1, 235 - i);
            rndCoinNum[i] = randCoin;
            int rand = Random.Range(0, 4 - i);
            rndNum[i] = randomNum[rand];
            randomNum.RemoveAt(rand);
        }

        GameObject coin1 = GameObject.Find("Coin/Cubie (" + rndCoinNum[0] + ")");
        GameObject coin2 = GameObject.Find("Coin/Cubie (" + rndCoinNum[1] + ")");
        GameObject coin3 = GameObject.Find("Coin/Cubie (" + rndCoinNum[2] + ")");
        GameObject coin4 = GameObject.Find("Coin/Cubie (" + rndCoinNum[3] + ")");

        coin1.GetComponent<MeshRenderer>().material = materials[rndNum[0]];
        coin1.tag = tags[rndNum[0]];
        coin2.GetComponent<MeshRenderer>().material = materials[rndNum[1]];
        coin2.tag = tags[rndNum[1]];
        coin3.GetComponent<MeshRenderer>().material = materials[rndNum[2]];
        coin3.tag = tags[rndNum[2]];
        coin4.GetComponent<MeshRenderer>().material = materials[rndNum[3]];
        coin4.tag = tags[rndNum[3]];*/
    }

    public static int[] MakeRandomNumbers(int maxValue, int randomSeed = 0)
    {
        return MakeRandomNumbers(0, maxValue, randomSeed);
    }

    public static int[] MakeRandomNumbers(int minValue, int maxValue, int randomSeed = 0)
    {
        if (randomSeed == 0)
            randomSeed = (int)DateTime.Now.Ticks;

        List<int> values = new List<int>();
        for (int v = minValue; v < maxValue; v++)
        {
            values.Add(v);
        }

        int[] result = new int[maxValue - minValue];
        System.Random random = new System.Random(Seed: randomSeed);
        int i = 0;
        while (values.Count > 0)
        {
            int randomValue = values[random.Next(0, values.Count)];
            result[i++] = randomValue;

            if (!values.Remove(randomValue))
            {
                // Exception
                break;
            }
        }

        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        tags[0] = "PurpleCoin";
        tags[1] = "RedCoin";
        tags[2] = "BlueCoin";
        tags[3] = "GreenCoin";

        /*int[] randomNumbers = MakeRandomNumbers(4);
        for (int i = 0; i < randomNumbers.Length; i++)
        {
            Debug.Log(randomNumbers[i]);
        }*/
        MakeRandomCoin();



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
