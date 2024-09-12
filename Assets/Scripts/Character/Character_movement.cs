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

    Animator animator;
    float moveXstand;
    float moveYstand;


    
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        if (moveX!=0 || moveY != 0)
        {
            Animate(moveX, moveY,1);
            moveXstand = moveX; 
            moveYstand = moveY;
            Debug.Log(moveXstand+" "+ moveYstand);
       
        }
        else
        {
            Animate(moveXstand, moveYstand, 0);

        }

    }

    private void FixedUpdate()
    {
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        
    }
    void Animate(float moveX,float moveY,int layer)
    {
      
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);
        switch (layer)
        {
            case 0:animator.SetLayerWeight(0, 1);
                animator.SetLayerWeight(1, 0);
                break;
            case 1:
                animator.SetLayerWeight(1, 1);
                animator.SetLayerWeight(0, 1);
                break;

        }
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);
    }
}
