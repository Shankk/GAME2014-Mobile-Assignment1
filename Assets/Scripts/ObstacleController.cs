using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// BackgroundController.cs
/// Brian Viverios STU# 101209942 Last Modified 10/21/2020
/// Program Description: Controls the background objects of the scene, this gives the side scrolling illusion.
/// The Background will scroll to the end of their threshold and then teleport to their original location.
/// Last Revision: Rearranged The movement to be horizontal instead of vertical to match Landscape mode.
/// 
/// </summary>


public class ObstacleController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    public float horizontalReset;
    public float verticalPos;
    public bool isMovingLeft;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        if(isMovingLeft)
        {
            transform.position = new Vector3(horizontalReset, verticalPos);
        }
        else
        {
            transform.position = new Vector3(-horizontalReset, verticalPos);
        }
    }

    private void _Move()
    {
        if(isMovingLeft)
        {
            transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
        }
        else
        {
            transform.position -= new Vector3(-horizontalSpeed, 0.0f) * Time.deltaTime;
        }
       
    }

    private void _CheckBounds()
    {
        
        if(isMovingLeft)
        {
            if (transform.position.x <= -horizontalBoundary)
            {
                _Reset();
            }
        }
        else
        {
            if (transform.position.x >= horizontalBoundary)
            {
                _Reset();
            }
        }
           
    }

}

