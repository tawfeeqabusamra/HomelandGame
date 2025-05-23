using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetBool("jump" , true  );
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
        public static void Attack(bool isAttacking, Animator animator)
        {
            animator.SetBool("Attack", isAttacking);

        }
        public static void Respawn(Rigidbody2D rb, Transform resbawnPoint)
        {
            rb.transform.position = resbawnPoint.position;

        }
    }

}

