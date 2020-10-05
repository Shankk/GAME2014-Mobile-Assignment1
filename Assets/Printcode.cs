using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Printcode : MonoBehaviour
{

    public delegate int Del(int arg1);
    public event Del evt;
    public int Callback(int arg)
    {
        Debug.Log("Hello");
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        evt = Callback;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))

        {

            evt.Invoke(5);

        }
    }

}
