using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject homeFrog;
    
    public void ShowFrog(bool showfrog)
    {
        homeFrog.SetActive(showfrog);
    }
}
