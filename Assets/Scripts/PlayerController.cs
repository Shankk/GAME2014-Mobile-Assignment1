using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject frogSprite;
    private PlayerManager PlayerStats;
    // Movement Buttons
    public Button moveUpBtn;
    public Button moveDownBtn;
    public Button moveLeftBtn;
    public Button moveRightBtn;

    private static readonly float cooldown = 0.25f;
    public bool _isCoolingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = frogSprite.GetComponent<PlayerManager>();
        moveUpBtn.onClick.AddListener(_MoveUp);
        moveDownBtn.onClick.AddListener(_MoveDown);
        moveRightBtn.onClick.AddListener(_MoveRight);
        moveLeftBtn.onClick.AddListener(_MoveLeft);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _MoveRight()
    {
        if (!_isCoolingDown && !PlayerStats._isReseting)
        {
            //PlayerStats.Score += 10;
            frogSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            StartCoroutine(Move(new Vector3(1, 0, 0)));
        }
    }

    private void _MoveLeft()
    {
        if (!_isCoolingDown && !PlayerStats._isReseting)
        {
            //PlayerStats.Score += 10;
            frogSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
            StartCoroutine(Move(new Vector3(-1, 0, 0)));
        }
    }

    private void _MoveUp()
    {
        if (!_isCoolingDown && !PlayerStats._isReseting)
        {
            //PlayerStats.Score += 10;
            frogSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
            StartCoroutine(Move(new Vector3(0, 1, 0)));
        }
    }

    private void _MoveDown()
    {
        if (!_isCoolingDown && !PlayerStats._isReseting)
        {
            //PlayerStats.Score += 10;
            frogSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            StartCoroutine(Move(new Vector3(0, -1, 0)));
        }
    }


    public IEnumerator Move(Vector3 delta)
    {
        _isCoolingDown = true;
        frogSprite.GetComponent<Animator>().SetTrigger("move");

        var start = transform.position;
        var end = start + delta;

        if(end.x > 5 || end.x < -5 || end.y > 7 || end.y < -9)
        {
            transform.position = start;
        }
        else
        {
            PlayerStats.Score += 10;
            var time = 0f;
            while (time < 1f)
            {
                transform.position = Vector3.Lerp(start, end, time);
                time = time + Time.deltaTime / cooldown;
                yield return null;
            }
            transform.position = end;
        }
        _isCoolingDown = false;
        
    }

}
