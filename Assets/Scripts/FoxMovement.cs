using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HomeLand
{


    public class FoxMovement : MonoBehaviour
    {

        public float moveSpeed = 5f;

        public Rigidbody2D rb;

        [SerializeField]
        public GameObject enemy;
        float xInput;
        bool jump = false;
        bool allowJump = false;
        RaycastHit raycastHit;
        [SerializeField]
        float rayLength = 1f;
        [SerializeField]
        float jumpForce = 20;
        [SerializeField]
        public LayerMask groundLayer;
        public LayerMask EnemyMask;
        Animator animator;

        bool isCrouching = false;
        bool isAttaking = false;
        bool isKilling = false;
        bool collision = false;

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
            collision = Physics2D.Raycast(transform.position, Vector2.right, 0.7f, EnemyMask);
            isKilling = isAttaking && collision;
            Debug.Log(collision);
            Debug.Log(isKilling);
            jump = Input.GetKey(KeyCode.Space);
            allowJump = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
            if (isKilling)
            {
                Destroy(enemy);

            }
        }
        void FixedUpdate()
        {
            MovementMethods.Jump(jump, allowJump, jumpForce, rb, animator);
            MovementMethods.Walk(animator, xInput, rb, moveSpeed);
            MovementMethods.Crouch(isCrouching, animator);
            MovementMethods.Attack(isAttaking, animator);


        }



    }
}
