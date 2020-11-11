using System;
using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
[System.Serializable]
public enum SIDE { Left, Mid, Right }

public class Movement: MonoBehaviour
{


    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    [HideInInspector]
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    public float XValue;
    private CharacterController m_char;
    public float JumpPower = 70f;
    private float x; 
    private float y;
    public float SpeedDodge;
    public bool InJump;
    public bool InRoll;
    public float FwdSpeed = 70f;
    private float ColHeight;
    private float ColCenterY;
    internal float RollCounter;

    void Start()
    {
        m_char = GetComponent<CharacterController>();
        transform.position = Vector3.zero;
        ColHeight = m_char.height;
        ColCenterY = m_char.center.y;
    }

    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        SwipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);


        if (SwipeLeft && !InRoll)
        {
            Debug.Log("Izquierda");
            if(m_Side == SIDE.Mid)
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
        Vector3 moveVector = new Vector3(x - transform.position.x, y*Time.deltaTime, FwdSpeed*Time.deltaTime);
        x = Mathf.Lerp(x, NewXPos, Time.deltaTime*SpeedDodge);
        m_char.Move(moveVector);
        Jump();
        Roll();
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
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Boost")
        {
            FwdSpeed = 90f;
        }
    }
}
