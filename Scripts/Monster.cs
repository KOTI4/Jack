using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 1;
    public BorderScript rightBorder;
    public BorderScript leftBorder;
    public BorderScript rightBotBorder;
    public BorderScript leftBotBorder;

    private float direction = 1;
    public float getDirection() { return direction; }
    public void setDirection(float value) { if (value == 1 || value == -1) direction = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            Movement();
            if (direction == -1) gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if (direction == 1) gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Movement()
    {
        transform.position = transform.position + new Vector3((direction * (speed)) / 100, 0, 0);
        ChangeDirectionIfNeed();
    }

    private void ChangeDirectionIfNeed()
    {
        if (rightBorder.getToWall || !rightBotBorder.getToWall) direction = -1;
        if (leftBorder.getToWall || !leftBotBorder.getToWall) direction = 1;
    }
}
