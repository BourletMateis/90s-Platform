using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace controlleur 
{
    public class Controlleur : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float speed = 7f;
        public float jumpForce = 8f;
        [SerializeField]
        private bool isGrounded;
        public float groundCheckDistance = 0.5f;
        public Animator animator;
        public SpriteRenderer SpriteRenderer;

        private bool canDash = true;
        private bool isDashing;
        private float dashCooldown = 1f;
        float teleportDistance = 3f;

        [SerializeField]
        public bool doubleJump = false;
        private int jumpCount = 0;

        [SerializeField] private TrailRenderer tr;

        private Vector3 originalScale;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            originalScale = transform.localScale;
        }

        void Update()
        {
            CheckGroundStatus();
            Movement();
        }

        private void FixedUpdate()
        {
            if (isDashing)
            {
                return;
            }
        }

        void Movement()
        {
            float moveX = 0f;
            float moveY = rb.velocity.y;

            if (isDashing)
            {
                return;
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveX = speed;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                moveX = -speed;
            }

            if (isGrounded)
            {
                jumpCount = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded || (doubleJump && jumpCount < 1))
                {
                    moveY = jumpForce;
                    jumpCount++;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(Dash());
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);
            }
            else
            {
                transform.localScale = originalScale;
            }

            rb.velocity = new Vector2(moveX, moveY);
            Flip(rb.velocity.x);
            float characterVelocity = Mathf.Abs(rb.velocity.x);
            animator.SetFloat("Speed", characterVelocity);
        }

        private void CheckGroundStatus()
        {
            CapsuleCollider2D capsuleCollider = GetComponent<CapsuleCollider2D>();
            Vector2 raycastOriginCenter = (Vector2)transform.position;
            Vector2 raycastOriginLeft = raycastOriginCenter - new Vector2(capsuleCollider.size.x / 2, 0);
            Vector2 raycastOriginRight = raycastOriginCenter + new Vector2(capsuleCollider.size.x / 2, 0);

            float adjustedDistance = groundCheckDistance + groundCheckDistance; 
            LayerMask groundLayer = LayerMask.GetMask("Ground"); 

            bool hitCenter = Physics2D.Raycast(raycastOriginCenter, Vector2.down, adjustedDistance, groundLayer);
            bool hitLeft = Physics2D.Raycast(raycastOriginLeft, Vector2.down, adjustedDistance, groundLayer);
            bool hitRight = Physics2D.Raycast(raycastOriginRight, Vector2.down, adjustedDistance, groundLayer);

            isGrounded = hitCenter || hitLeft || hitRight;
        }


        private IEnumerator Dash()
        {
            canDash = false;
            isDashing = true;
            float direction;

            if (Input.GetKey(KeyCode.D))
                direction = 1f;
            else if (Input.GetKey(KeyCode.Q))
                direction = -1f;
            else
                direction = transform.localScale.x > 0 ? 1f : -1f;

            tr.emitting = true;

            Vector3 dashTargetPosition = transform.position + new Vector3(direction * teleportDistance, 0f, 0f);

            RaycastHit2D wallHit = Physics2D.Raycast(transform.position, new Vector2(direction, 0f), teleportDistance, LayerMask.GetMask("Walls"));
            if (wallHit.collider != null)
            {
                dashTargetPosition = wallHit.point;
            }

            RaycastHit2D groundHit = Physics2D.Raycast(transform.position, new Vector2(direction, 0f), teleportDistance, LayerMask.GetMask("Ground"));
            if (groundHit.collider != null)
            {
                dashTargetPosition = groundHit.point;
            }

            transform.position = dashTargetPosition;

            yield return new WaitForSeconds(0f);
            tr.emitting = false;
            isDashing = false;
            yield return new WaitForSeconds(dashCooldown);
            canDash = true;
        }



        void Flip(float _velocity)
        {
            if (_velocity > 0.1f)
            {
                SpriteRenderer.flipX = false;
            }
            else if (_velocity < -0.1f)
            {
                SpriteRenderer.flipX = true;
            }
        }
    }
}
