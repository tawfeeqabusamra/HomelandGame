using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace HomeLand
{
    public static class MovementMethods 
    {
        public static void Jump(bool jump, bool allowJump, float jumpForce, Rigidbody2D rb, Animator animator)
        {
            if (jump && allowJump)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.Play("Player_Jumping");
            }


        }
        public static void Walk(Animator animator, float xInput, Rigidbody2D rb, float moveSpeed)
        {
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
            animator.SetBool("isWalking", xInput != 0);
            if (xInput > 0)
            {
                rb.transform.localScale = new Vector2(1, 1);

            }
            else if (xInput < 0)
            {
                rb.transform.localScale = new Vector2(-1, 1);
            }
            


        }

        public static void Crouch(bool isCrouching, Animator animator)
        {
            animator.SetBool("isCrouching", isCrouching);
        }
        public static void Attack(bool isAttaking, Animator animator)
        {
            animator.SetBool("Attack", isAttaking);

        }
      


    }

}

