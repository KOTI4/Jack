using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JackBehaviour : MonoBehaviour
{

    public Button buttonCrouch;
    public Animator animator;
 
    public float speed = 2;
    public float jumpForce = 550;
    private Vector3 startScale;
    private bool isCouching;
    private bool firstKeyCPressed;

    internal int getCoins()
    {
        return coins;
    }

    internal void setCoins(int i)
    {
        coins = i;
    }

    private int indexHeartPick;
    private int indexCoinPick;
    private int indexButtonStand;
    public int coins;

    private int hp;
    public int getHp() { return hp; }
    public void setHp(int value)
    {
        if (value < 0) hp = 0;
        else hp = value;
    }

    private int maxStamina = 1200;
    public int stamina;
    public int getStamina() { return stamina; }
    public void setStamina(int value)
    {
        if (value < 0) stamina = 0;
        else if (value > maxStamina) stamina = maxStamina;
        else stamina = value;
    }

    private int maxSafeForm = 500;
    private int safeForm;
    public int getSafeForm() { return safeForm; }
    public void setSafeForm(int value)
    {
        if (value < 0) safeForm = 0;
        else if (value > maxSafeForm) safeForm = maxSafeForm;
        else safeForm = value;
    }

    public BorderScript rightBorder;
    public BorderScript leftBorder;
    public BottomScript bottom;
    public UpScript up;
    public GameObject doorEnter;
    public SceneSwap sceneManager;

    private float direction = 1;
    public float getDirection() { return direction; }
    public void setDirection(float value) { if (value == 1 || value == -1) direction = value; }



    private Rigidbody2D rb;
    private float dash;
    public bool jump;
    public bool crouch;
    public bool crouchClickFirst;
    public bool ddash;




    // Start is called before the first frame update
    void Start()
    {
        indexButtonStand = 100;
        indexCoinPick = 10;
        indexHeartPick = 10;
        transform.position = doorEnter.transform.position;
        rb = GetComponent<Rigidbody2D>();
        setHp(3);
        setStamina(maxStamina);
        setSafeForm(0);
        startScale = transform.localScale;
        isCouching = false;
        firstKeyCPressed = false;
        coins = 0;
        jump = false;
        crouch = false;
        crouchClickFirst = false;
        ddash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (indexHeartPick > 0) indexHeartPick--;
            if (indexCoinPick > 0) indexCoinPick--;
            if (indexButtonStand > 0) indexButtonStand--;
            if (!isCouching) setStamina(stamina + 5);
            if (isCouching) setStamina(stamina - 20);
            Movement();
            Jump();
            jump = false;
            Dash();
            Crouch();
            //crouchClickFirst = false;
            Trampolines();
            if (getSafeForm() > 0) setSafeForm(--safeForm);
            if (direction == -1) gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if (direction == 1) gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (bottom.isGrounded) animator.SetBool("IsGrounded", true);
            if (!bottom.isGrounded) animator.SetBool("IsGrounded", false);
            if (!rightBorder.getToWall && !leftBorder.getToWall) animator.SetBool("IsNearWall", false);
            if (rightBorder.getToWall || leftBorder.getToWall) animator.SetBool("IsNearWall", true);
            if (isCouching) animator.SetBool("IsCrouch", true);
            if (!isCouching) animator.SetBool("IsCrouch", false);
            if (safeForm == 0) gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            else if (safeForm % 10 == 0)
            {
                if (gameObject.GetComponent<SpriteRenderer>().color == Color.white)
                    gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
                else
                    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            //if (direction == 1) transform.localScale = new Vector3(startScale.x, transform.localScale.y,
            //    transform.localScale.z);
        }
    }

    private void Dash()
    {
        if ((Input.GetKey(KeyCode.X) || ddash) && getStamina() > 100)
        {
            setStamina(stamina - 100);
            if (getStamina() < 300)
                dash = 2;
            else dash = 25;
            //gameObject.GetComponent<TrailRenderer>().enabled = true;
        }
        else
        {
            dash = 0;
            //gameObject.GetComponent<TrailRenderer>().enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage" && getSafeForm() == 0)
        {
            setHp(--hp);
            setSafeForm(maxSafeForm);
        }
        if (collision.gameObject.tag == "Exit") sceneManager.NextScene();
        if (collision.gameObject.CompareTag("Heart") && indexHeartPick == 0)
        {
            Destroy(collision.gameObject);
            setHp(hp + 1);
            indexHeartPick = 10;
        }
        if (collision.gameObject.CompareTag("Coin") && indexCoinPick == 0)
        {
            Destroy(collision.gameObject);
            setCoins(coins + 1);
            indexCoinPick = 10;
        }
        if (collision.gameObject.CompareTag("Button") && indexButtonStand == 0)
        {
            ButtonScript button = collision.gameObject.GetComponent<ButtonScript>();
            button.changeActive();
            indexButtonStand = 100;
        }

    }

    //private void OnCollisionEnter2D(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Heart")
    //    {
    //        collision.gameObject.SetActive(false);
    //        setHp(hp + 1);
    //    }
    //}


    void Movement()
    {
        if (bottom.isGrounded)
        {
            transform.position = transform.position + new Vector3((direction * (speed + dash)) / 100, 0, 0);
            ChangeDirectionIfNeed();
           
        }
        else
        {
            if (!rightBorder.getToWall && !leftBorder.getToWall)
                transform.position = transform.position + new Vector3((direction * (speed + dash)) / 100, 0, 0);
        }
    }



    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || jump)
        {
            if (bottom.isGrounded) rb.AddForce(new Vector2(0, jumpForce));
            else
            {
                if (rightBorder.getToWall || leftBorder.getToWall)
                {
                    ChangeDirectionIfNeed();
                    if (rightBorder.getToWall) rb.AddForce(new Vector2(-150, 400));
                    if (leftBorder.getToWall) rb.AddForce(new Vector2(150, 400));
                }
            }
        }
    }

    private void Crouch()
    {
        //Input.GetKeyDown(KeyCode.C)
        //if ((Input.GetKeyDown(KeyCode.C) || crouchClickFirst) && (getStamina() > 200))
        //{
        //    firstKeyCPressed = true;
        //}
        if ((Input.GetKey(KeyCode.C) || crouch) && (getStamina() > 100) /*&& firstKeyCPressed*/)
        {
            transform.localScale = new Vector3(transform.localScale.x, startScale.y / 2, transform.localScale.z);
            isCouching = true;
        }
        else
        if (!up.getUpWall)
        {
            transform.localScale = new Vector3(transform.localScale.x, startScale.y, transform.localScale.z);
            firstKeyCPressed = false;
            isCouching = false;
        }

    }

    private void ChangeDirectionIfNeed()
    {
        if (rightBorder.getToWall)
        {
            direction = -1;
        }
        if (leftBorder.getToWall)
        {
            direction = 1;
        }
    }

    private void Trampolines()
    {
        if (bottom.isOnTrampoline)
        {
            rb.AddForce(new Vector2(0, 760));
            bottom.isOnTrampoline = false;
        }
    }

    public void JumpButtonOn()
    {
        jump = true;
    }

    public void CrouchButtonUp()
    {
        crouch = false;
    }

    public void CrouchButtonDown()
    {
        crouch = true;
    }

    public void DashButtonUp()
    {
        ddash = false;
    }

    public void DashButtonDown()
    {
        ddash = true;
    }
    //public void CrouchButtonClick()
    //{
    //    crouchClickFirst = true;
    //}
}

