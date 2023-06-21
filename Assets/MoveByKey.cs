using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    public CharacterController characterController;
    public float movingSpeed;
    public float jumpHeight = 5f;
    public bool dkJump;
    private void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            dkJump = true;
            Debug.Log("ground");
        }
    }

    //public void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("ground"))
    //    {
    //        dkJump = false;
    //    }
    //}


    private void OnMove()
    {
        
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * hInput + transform.forward * vInput;
        characterController.SimpleMove(direction * movingSpeed);
    }

    private void OnJump()
    {
        if (dkJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                dkJump = false;
                Vector3 onJump = new Vector3(0, jumpHeight, 0);
                characterController.Move(onJump);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnJump();

    }
    private void FixedUpdate()
    {

    }
}
