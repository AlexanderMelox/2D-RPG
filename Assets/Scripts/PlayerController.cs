using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {   

    public Rigidbody2D rigidbody;
    public float moveSpeed = 5;
    public Animator animator;

    // creating a reference of this script and calling it instance
    public static PlayerController instance;

    public string areaTransitionName;

    // Start is called before the first frame update
    void Start() {
        // Removes any duplicates of this object when switching scenes
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        // Don't destroy this object when we move into a new area
        DontDestroyOnLoad(gameObject); // gameObject => current game object this script is attached to
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
