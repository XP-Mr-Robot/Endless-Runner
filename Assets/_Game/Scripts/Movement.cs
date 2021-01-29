using System;
using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
[System.Serializable]
public enum SIDE { Left, Mid, Right }

public class Movement: MonoBehaviour
{
    Animator anim;

    public AudioClip audioSalto;

    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    [HideInInspector]
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    public float XValue;
    private CharacterController m_char;
    public float JumpPower = 71f;
    private float x; 
    private float y;
    public float SpeedDodge;
    public bool InJump;
    public bool InRoll;
    public float FwdSpeed = 70f;
    private float ColHeight;
    private float ColCenterY;
    internal float RollCounter;

    //these two will help us know what exactly is a swipe
    public float maxSwipeTime;//0.5
    public float minSwipeDistance;//100


    //these three will help us know how long did our swipe took
    private float startTime;
    private float endTime;
    private float swipeTime;//this will be compared with maxTime;


    //these three will help us know how long the swipe is
    private Vector2 swipeStartPos;
    private Vector2 swipeEndPos;
    private float swipeDistance;//this will be compared with minSwipeDistance;
    void Start()
    {
        m_char = GetComponent<CharacterController>();
        transform.position = Vector3.zero;
        ColHeight = m_char.height;
        ColCenterY = m_char.center.y;

        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {


        PlayerMovement();
        Jump();
        Roll();
        SwipeTest();
    }
    void PlayerMovement()
    {
       

        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        SwipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);


        if (SwipeLeft && !InRoll)
        {
            Debug.Log("Izquierda");
            if (m_Side == SIDE.Mid)
            {
                NewXPos = -XValue;
                m_Side = SIDE.Left;
            }

            else if (m_Side == SIDE.Right)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;

            }
        }

        if (SwipeRight && !InRoll)
        {
            Debug.Log("Derecha");

            if (m_Side == SIDE.Mid)
            {
                NewXPos = XValue;
                m_Side = SIDE.Right;

            }

            else if (m_Side == SIDE.Left)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;

            }
        }
        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, FwdSpeed * Time.deltaTime);
        x = Mathf.Lerp(x, NewXPos, Time.deltaTime * SpeedDodge);
        m_char.Move(moveVector);
    }

    void SwipeTest()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;//this will see when we started touching the screen
                swipeStartPos = touch.position;//where we have started touching the screen
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;//the time when we left th screen
                swipeEndPos = touch.position;//the position when we left the screen

                swipeTime = endTime - startTime;//this will calculate how long our swip took
                swipeDistance = (swipeEndPos - swipeStartPos).magnitude; //this will calculate how long our swipe is

                if (swipeTime < maxSwipeTime && swipeDistance > minSwipeDistance)
                {//here if we swipe fast and long enough then it will be a swipe
                    Debug.Log("swipe");
                    SwipeControl();
                }
            }
        }
    }
    void SwipeControl()
    {
        Vector2 distance = swipeEndPos - swipeStartPos;
        float xDistance = Mathf.Abs(distance.x);
        float yDistance = Mathf.Abs(distance.y);


        if (xDistance > yDistance)
        {

            Debug.Log("horizontal swipe");

            if (distance.x < 0 && !InRoll)
            {
                Debug.Log("Izquierda");
                if (m_Side == SIDE.Mid)
                {
                    NewXPos = -XValue;
                    m_Side = SIDE.Left;
                }

                else if (m_Side == SIDE.Right)
                {
                    NewXPos = 0;
                    m_Side = SIDE.Mid;

                }
            }
            if (distance.x > 0 && !InRoll)
            {
                Debug.Log("Derecha");

                if (m_Side == SIDE.Mid)
                {
                    NewXPos = XValue;
                    m_Side = SIDE.Right;

                }

                else if (m_Side == SIDE.Left)
                {
                    NewXPos = 0;
                    m_Side = SIDE.Mid;

                }

            }
          
        }
        if (xDistance < yDistance)//if you are swiping up or down
        {
            Debug.Log("vertical swipe");
           
            if (m_char.isGrounded)
            {
                if (distance.y > 0)
                {
                    Debug.Log("Arriba");
                    y = JumpPower;
                    InJump = true;
                    anim.SetTrigger("IsJumping");

                    AudioSource.PlayClipAtPoint(audioSalto, transform.position,2f);
                }
                if (distance.y < 0)
                {
                    
                        Debug.Log("Abajo");
                        RollCounter = 0.5f;
                        y -= 10f;
                        m_char.center = new Vector3(0, ColCenterY/2f, 0);
                        m_char.height = ColHeight/2f;
                        InRoll = true;
                        InJump = false;
                        anim.SetTrigger("Agachao");
                    
                }
            }

            else 
            {
                y -= JumpPower * 2 * Time.deltaTime;
                InJump = false;
            }

        }


       

       
        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, FwdSpeed * Time.deltaTime);
        x = Mathf.Lerp(x, NewXPos, Time.deltaTime * SpeedDodge);
        m_char.Move(moveVector);
    }

    public void Jump()
    {
        if(m_char.isGrounded)
        {
            if (SwipeUp)
            {
                Debug.Log("Arriba");
                y = JumpPower;
                InJump = true;
                anim.SetTrigger("IsJumping");

                AudioSource.PlayClipAtPoint(audioSalto, transform.position);
            }

        }
        else
        {
            y -= JumpPower * 2 * Time.deltaTime;
            InJump = false;

        }
    }
    public void Roll()
    {
        RollCounter -= Time.deltaTime;
        if (RollCounter <= 0f)
        {
            RollCounter = 0f;
            m_char.center = new Vector3(0, ColCenterY, 0);
            m_char.height = ColHeight;
            InRoll = false; 
        }

        if (SwipeDown)
        {
            Debug.Log("Abajo");
            RollCounter = 0.5f;
            y -= 10f;
            m_char.center = new Vector3(0, ColCenterY/2f, 0);
            m_char.height = ColHeight/2f;
            InRoll = true;
            InJump = false;
            anim.SetTrigger("Agachao");
        }
    }
}
