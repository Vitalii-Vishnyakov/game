using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    
    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController controller;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundedCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    public AudioSource soundStep;
    public AudioClip sound;
    private Animator anim;
    private float delta = 0;
    public GameObject boy;
    public GameObject girl;


    private void Start()

    {
        if (PlayerPrefs.GetString("pers") == "boy")
        {
            girl.SetActive(false);
        }
        else {
        
            boy.SetActive(false);
        }
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        //soundStep = GetComponent<AudioSource>();

    }
    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Attack();
        }
    }
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundedCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float movex = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(movex, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
       
        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Idle()
    {
        //anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);

        anim.SetFloat("speed",0);
    }
    private void Walk()
    {
        //Debug.Log("walk");


        moveSpeed = walkSpeed;
        //anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        delta += Time.deltaTime;
        if (delta > 0.6f)
        {
            soundStep.PlayOneShot(sound);
            delta = 0;
        }

        anim.SetFloat("speed", 0.5f);

    }
    private void Run()
    {
        moveSpeed = runSpeed;
        //anim.SetFloat("Speed", 1,0.1f,Time.deltaTime);
        delta += Time.deltaTime;
        //Debug.Log("run");

        if (delta > 0.4f)
        {
            soundStep.PlayOneShot(sound);
            delta = 0;
        }

        anim.SetFloat("speed", 1);


    }
    private void Jump()
    {
        
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
    private void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
