using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rigidbody2D;

    private float speed = 7f;
    private float jumpForce = 8f;

    private float moveInput;
    private float defaultSpeed;
    private float defaultJumpForce;

    //
    private Button mobileButtonJump;
    private Joystick mobileJoystick;
    //

    //
    private void Start()
    {
        FindJoystick();
        FindMobileButtonJump();
    }
    //

    //
    private void FindJoystick()
    {
        GameObject mobileJoystickObject = GameObject.FindGameObjectWithTag("ui_Joystick");

        if (Application.isMobilePlatform == false)
        {
            mobileJoystickObject.gameObject.SetActive(false);
        }

        mobileJoystick = mobileJoystickObject ? mobileJoystickObject.GetComponent<Joystick>() : null;
    }
    //

    //
    private void FindMobileButtonJump()
    {
        GameObject mobileButtonJumpObject = GameObject.FindGameObjectWithTag("ui_ButtonJump");

        if (Application.isMobilePlatform == false)
        {
            mobileButtonJumpObject.gameObject.SetActive(false);
        }

        if (mobileButtonJumpObject)
        {
            mobileButtonJump = mobileButtonJumpObject.GetComponent<Button>();
            mobileButtonJump.onClick.AddListener(() =>
            {
                Jump();
            });
        }
    }


    public void SetJumpForce(float _jumpForce)
    {
        jumpForce = _jumpForce;
    }

    public void SetDefaultJumpForce()
    {
        jumpForce = defaultJumpForce;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public void SetDefaultSpeed()
    {
        speed = defaultSpeed;
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        defaultSpeed = speed;
        defaultJumpForce = jumpForce;
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = MoveVelocity();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private Collider2D Ground()
    {
        return Physics2D.OverlapCircle(groundPoint.position, .01f, groundLayer);
    }

    private void Jump()
    {
        if(Ground())
        {
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }
    }

    private Vector2 MoveVelocity()
    {
            moveInput = Application.isMobilePlatform ?
            mobileJoystick.Horizontal :
            Input.GetAxis("Horizontal");

  //      moveInput = mobileJoystick.Horizontal;

        return new Vector2(moveInput * speed, rigidbody2D.velocity.y);
    }
}

