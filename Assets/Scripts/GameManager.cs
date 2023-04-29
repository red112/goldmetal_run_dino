using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const float ORIGIN_SPEED = 4;

    public static float globalSpeed;
    public static float score;
    public static bool isLive;
    public GameObject uiOver;


    // Start is called before the first frame update
    void Start()
    {
        isLive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLive)
            return;

        score += Time.deltaTime * 2;
        globalSpeed = ORIGIN_SPEED + score * 0.01f;
        //Debug.Log("Score - " + score + ", Speed - " + globalSpeed);
    }

    public void GameOver()
    {
        //uiOver.SetActive(true);
        isLive = false;

    }
}
