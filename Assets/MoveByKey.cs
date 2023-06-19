using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    public CharacterController characterController;
    public float movingSpeed;
    public float jumpHeight;
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
        }
    }
    private void OnMove()
    {
        float jInput = Input.GetAxis("Jump");
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * hInput + transform.forward * vInput;
        characterController.SimpleMove(direction * movingSpeed);
        if (dkJump)
        {
            if (jInput > 0)
            {
                transform.position = new Vector3(transform.position.x, jumpHeight + movingSpeed * Time.deltaTime, transform.position.z);
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

    }
}
