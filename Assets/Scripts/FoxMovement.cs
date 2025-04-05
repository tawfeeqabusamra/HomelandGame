using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HomeLand
{


    public class FoxMovement : MonoBehaviour
    {

        public float moveSpeed = 3f;

        public Rigidbody2D rb;

        [SerializeField]
        public GameObject enemy;
        public GameObject enemy2;
        float xInput;
        bool jump = false;
        bool allowJump = false;
        bool allowJump2 = false;
        RaycastHit raycastHit;
        [SerializeField]
        float rayLength = 1f;
        [SerializeField]
        float jumpForce = 8;
        [SerializeField]
        public LayerMask groundLayer;
        public LayerMask EnemyMask;
        public LayerMask EnemyMask2;
        Animator animator;
        bool isCrouching = false;
        bool isAttaking = false;
        bool isKilling = false;
        bool isKilling2 = false;
        bool collision1 = false;
        bool collision3 = false;
        bool collision4 = false;

        bool collision2 = false;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

        }


        void Update()
        {
            xInput = Input.GetAxisRaw("Horizontal");
            isCrouching = Input.GetKey(KeyCode.LeftControl);
            isAttaking = Input.GetKey(KeyCode.F);
            collision1 = Physics2D.Raycast(transform.position, Vector2.right, 0.8f, EnemyMask);
            collision3 = Physics2D.Raycast(transform.position, Vector2.left, 0.8f, EnemyMask);
            collision4 = Physics2D.Raycast(transform.position, Vector2.left, 0.8f, EnemyMask2);
            collision2 = Physics2D.Raycast(transform.position, Vector2.right, 0.8f, EnemyMask2);
            isKilling = isAttaking && (collision1 || collision3);
            isKilling2 = isAttaking && (collision2 || collision4);
            Debug.Log(collision1);
            Debug.Log(isKilling);
            jump = Input.GetKey(KeyCode.Space);
            allowJump = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
            allowJump2 = Physics2D.Raycast(transform.position, Vector2.right, rayLength, groundLayer);
            if (isKilling)
            {
                Destroy(enemy);

            }
            if (isKilling2)
            {
                Destroy(enemy2);

            }
        }
        void FixedUpdate()
        {
            MovementMethods.Jump(jump, allowJump, allowJump2, jumpForce, rb, animator);
            MovementMethods.Walk(animator, xInput, rb, moveSpeed);
            MovementMethods.Crouch(isCrouching, animator);
            MovementMethods.Attack(isAttaking, animator);


        }



    }
}
