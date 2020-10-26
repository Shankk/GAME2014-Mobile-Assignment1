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
    public bool _inRiver = false;
    public bool _isLanding = false;
    public bool _isReseting = false;
    public int Lives;
    public int Score;
    public int Timer;
    public int ResetTime;
    public int frogsSaved;
    public float Threshold;
    public float horizontalSpeed = 0f;

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
        switch(collision.tag)
        {
            case "vehicle":
                Debug.Log("I Hit A Vehicle!");
                _isDead = true;
                break;
            case "floating":
                Debug.Log("Im On Floating Object!");
                _isLanding = true;
                if (collision.GetComponent<ObstacleController>().isMovingLeft == true)
                {
                    horizontalSpeed = -collision.GetComponent<ObstacleController>().horizontalSpeed;
                }
                else
                {
                    horizontalSpeed = collision.GetComponent<ObstacleController>().horizontalSpeed;
                }
                break;
            case "river":
                Debug.Log("I Am In The River!");
                _inRiver = true;
                _isLanding = false;
                break;
            case "Finish":
                FrogIsHome(collision.gameObject);
                Score += 50;
                frogsSaved++;
                if(frogsSaved > 0)
                {
                    Score += 1000;

                    SceneManager.LoadScene("StartScene");
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "floating":
                Debug.Log("Im Not On Floating Object!");
                if (_isLanding == false)
                {
                    horizontalSpeed = 0;
                }
                _isLanding = false;
                break;
            case "river":
                Debug.Log("I Am NOT In The River!");
                _inRiver = false;
                break;
        }
    }

    private void _ResetPlayerPos()
    {
        _isReseting = true;
        Lives -= 1;
        Timer = ResetTime;
        Threshold = 0;
        _isDead = false;
    }

    void FrogIsHome(GameObject go)
    {
        _isReseting = true;
        Timer = ResetTime;
        Threshold = 0;
        go.GetComponent<Goal>().ShowFrog(true);
    }
}
