using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int score = 0;
    private int lives = 3;
    public TMP_Text scoree;
    public TMP_Text livess;
    public TMP_Text gameOver;
    public TMP_Text timerr ;
    private GameObject Player;
    private float timer;
    
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        livess.text = $"Lives: {lives}";
        scoree.text = $"Score: {score}";
        timerr.text = $"Survival Time: {(int)timer}";
        Player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerr.text = $"Survival Time: {(int)timer}";
    }

    public void AddLives(int value)
    {
        lives += value;

        if (lives<=0)
        {
            Debug.Log("Game Over!");
            Destroy(Player);
            lives = 0;
            gameOver.gameObject.SetActive(true);
        }
        livess.text = $"Lives: {lives}";

    }
    public void AddScore(int value)
    {
        score += value;
        scoree.text = $"Score: {score}";
    }
}
