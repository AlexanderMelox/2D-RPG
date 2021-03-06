using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {   

    public Rigidbody2D rigidbody;
    public float moveSpeed = 5;
    public Animator animator;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // set the velocity of the player to the wasd movement key
        rigidbody.velocity = new Vector2(horizontal, vertical) * moveSpeed;

        // updates the animator with the velocity of the rigidbody
        animator.SetFloat("moveX", rigidbody.velocity.x);
        animator.SetFloat("moveY", rigidbody.velocity.y);

        /** 
         * if the player has moved either up, down, left or right 
         * => update the lastMoveX and lastMoveY 
         * */
        if (horizontal == 1 || horizontal == -1 || vertical == 1 || vertical == -1) {
            animator.SetFloat("lastMoveX", horizontal);
            animator.SetFloat("lastMoveY", vertical);
        }
    }
}
