using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const float ORIGIN_SPEED = 4;

    public static float globalSpeed;
    public static float score;
    public static bool isLive;
    public GameObject uiOver;


    // Start is called before the first frame update
    void Awake()
    {
        isLive = true;

        if (!PlayerPrefs.HasKey("Score"))
            PlayerPrefs.SetFloat("Score", 0);
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
        uiOver.SetActive(true);
        isLive = false;

        float highScore = PlayerPrefs.GetFloat("Score");
        PlayerPrefs.SetFloat("Score", Mathf.Max(highScore, score));

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        score = 0;
        isLive = true;
    }
}
