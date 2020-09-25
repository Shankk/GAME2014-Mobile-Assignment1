using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnEventBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBtnBehavior()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void TutorialBtnBehavior()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ReturnBtnBehavior()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ExitBtnBehavior()
    {
        Application.Quit();
    }
}
