using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HomeLand
{


    public class FoxMovement : MonoBehaviour
    {

        public float moveSpeed = 3f;
        public Rigidbody2D rb;
        float xInput;
        bool jump = false;
        bool allowJump = false;
        RaycastHit raycastHit;
        [SerializeField]
        float rayLength = 1f;
        [SerializeField]
        float jumpForce = 7;
        [SerializeField]
        public LayerMask groundLayer;
        public LayerMask EnemyMask;

        Animator animator;
        bool isCrouching = false;
        public static bool isAttacking = false;
        public static bool isKilling = false;
        bool collision1 = false;
        bool collision2 = false;
        public Transform respawnPoint;



        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();


        }


        void Update()
        {
            xInput = Input.GetAxisRaw("Horizontal");
            isCrouching = Input.GetKey(KeyCode.S);
            isAttacking = Input.GetKey(KeyCode.E);
            collision1 = Physics2D.Raycast(transform.position, Vector2.right, 9f, EnemyMask);
            collision2 = Physics2D.Raycast(transform.position, Vector2.left, 9f, EnemyMask);
            isKilling = isAttacking && (collision1 || collision2);
            jump = Input.GetKey(KeyCode.W);
            allowJump = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        }
        void FixedUpdate()
        {
            MovementMethods.Jump(jump, allowJump, jumpForce, rb, animator);
            MovementMethods.Walk(animator, xInput, rb, moveSpeed);
            MovementMethods.Crouch(isCrouching, animator);
            MovementMethods.Attack(isAttacking, animator);

        }
        public void OnTrigger2D(Collider2D other)
        {
            if (other.CompareTag("Trap"))
            {
              MovementMethods.Respawn(rb,respawnPoint);
            }

        }


    }
}
