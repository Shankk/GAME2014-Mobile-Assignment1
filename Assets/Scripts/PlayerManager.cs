using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI LivesTMP;
    public TextMeshProUGUI ScoreTMP;
    public TextMeshProUGUI TimerTMP;

    public bool _isDead = false;
    public bool _isReseting = false;
    public int Lives;
    public int Score;
    public int Timer;
    public int ResetTime;
    public float Threshold;

    // Start is called before the first frame update
    void Start()
    {
        LivesTMP.SetText("LIVES: " + Lives);
        ScoreTMP.SetText("SCORE: " + "\n" + Score);
        TimerTMP.SetText("TIME: " + Timer);
    }

    // Update is called once per frame
    void Update()
    {
        LivesTMP.SetText("LIVES: " + Lives);
        ScoreTMP.SetText("SCORE: " + "\n" + Score);
        TimerTMP.SetText("TIME: " + Timer);
        PlayerTimer();
    }

    
    void PlayerTimer()
    {
        if(_isReseting)
        {
            transform.position = new Vector3(-0.5f, -7.5f, 0);
        }
        if(Timer > 0)
        {
            Threshold += Time.deltaTime;
            if (Threshold > 1)
            {
                Timer--;
                Threshold -= 1;
                _isReseting = false;
            }
        }

        if(_isDead || Timer < 1)
        {
            if(Lives > 0)
            {
                _ResetPlayerPos();
            }
            else
            {
                SceneManager.LoadScene("GameOverScene");
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "vehicle")
        {
            Debug.Log("I Hit A Vehicle!");
            _isDead = true;
        }
        if(collision.tag == "river")
        {
            Debug.Log("I Drowned in the River!");
            _isDead = true;
        }
    }

    private void _ResetPlayerPos()
    {
        _isReseting = true;
        Lives -= 1;
        Timer = ResetTime;
        _isDead = false;
    }

}
