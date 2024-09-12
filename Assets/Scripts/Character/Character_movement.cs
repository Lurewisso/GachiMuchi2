using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    CharacterController characterController;
    Vector2 moveDirection;
    float moveX;
    float moveY;
    
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        
    }

    private void FixedUpdate()
    {
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
