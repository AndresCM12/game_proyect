using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    //vector para la gravedad dinamica / para velocidad de salto
    public Vector3 gravity;
    public Vector3 jumpSpeed;

    //variable para saber si estamos en el piso
    bool isGrounded = false;

    Rigidbody rb;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        Physics.gravity = gravity;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = jumpSpeed;
            isGrounded = false;
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);

        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position += new Vector3(8, 0, 0) * Time.deltaTime;
            animator.SetBool("isRunning", true);
            rb.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isRunning", false);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isRunning", false);

        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.position += new Vector3(-8, 0, 0) * Time.deltaTime;
            animator.SetBool("isRunning", true);
            rb.transform.rotation = Quaternion.Euler(0, -90, 0);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", false);
    }
}
