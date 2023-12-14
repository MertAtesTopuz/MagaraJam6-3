using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

    public static playerMovement instance;

    [Header("Main Variables")]
    CapsuleCollider2D playerBodyCollider;
    Animator playerAnimator;
    Rigidbody2D playerRigidbody;

    [Header("Movement")]
    [SerializeField] float playerSpeed = 1f;
    public float faceCheck = 1f;
    private bool moveCheck;

    [Header("Jump")]
    public float playerJumpSpeed = 1f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject checkPos;
    [SerializeField] float checkRad;
    bool isGround;
    private bool jumpCheck;

    [Header("Wall")]
    [SerializeField] float wallJumpingDuration = 0.4f;
    [SerializeField] float wallSlidingSpeed = 1f;
    [SerializeField] float wallJumpingTime = 0.2f;
    [SerializeField] Vector2 wallJumpingPower = new Vector2(8f, 16f);
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask wallLayer;

    public bool crouchCheck = false;

    Vector2 movePlayerInput;
    
    bool isWallSliding;
    bool isFacingRight = true;
    bool isWallJumping;
    bool isJumping = false;
    bool isPushing = false;
    float wallJumpingDirection;
    float wallJumpingCounter;

    private void Awake()
    {
        instance = this;
    }

    void Start() {
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        PlayerRun();
        FlipPlayerFace();
        if (isJumping == true) {
            playerAnimator.SetBool("Running", false);
        }
        if (isPushing == true) {
            playerAnimator.SetBool("Running", false);
        }

        if (crouchCheck)
        {
            playerAnimator.SetBool("isVent", true);
        }
        else
        {
            playerAnimator.SetBool("isVent", false);
        }

        WallSlide();
        WallJump();

        if (!isWallJumping) {
            Flip();
        }
    }

    void FixedUpdate() {
        if (!isWallJumping) {
            playerRigidbody.velocity = new Vector2(movePlayerInput.x * playerSpeed, playerRigidbody.velocity.y);
        }

        isGround = Physics2D.OverlapCircle(checkPos.transform.position, checkRad, groundLayer);
    }

    void OnMove(InputValue playerInputValue) {
        movePlayerInput = playerInputValue.Get<Vector2>();
    }

    void OnJump(InputValue playerInputValue) {
        if (playerInputValue.isPressed) {
            if (isGround) {
                playerRigidbody.velocity += new Vector2(0, playerJumpSpeed);
                playerAnimator.SetBool("Jumping", true);               
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Box") {
            playerAnimator.SetBool("Jumping", false);
            isJumping = false;          
        }
        if (collision.gameObject.tag == "Wall") {
            playerAnimator.SetBool("climbWall", true);
            playerAnimator.SetBool("Jumping", false);
        }
        if (collision.gameObject.tag == "Box") {
            playerAnimator.SetBool("pushing", true);
            isPushing = true;
        }
        else
        {
            playerAnimator.SetBool("pushing", false);
            isPushing = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Box") {
            isJumping = true;
        }
        if (collision.gameObject.tag == "Wall") {
            playerAnimator.SetBool("climbWall", false);
        }
        if (collision.gameObject.tag == "Box") {
            playerAnimator.SetBool("pushing", false);
            isPushing = false;
        }
    }

    void FlipPlayerFace() {
        bool playerFlip = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerFlip) {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidbody.velocity.x), 1);
        }
    }

    void PlayerRun() {
        Vector2 playerMovment = new Vector2(movePlayerInput.x * playerSpeed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerMovment;
       bool playerRunning = playerMovment.x != 0f;
       
        if ( crouchCheck == false) {
            playerAnimator.SetBool("Running", playerRunning);
        }

        if (crouchCheck == true)
        {
            playerAnimator.SetBool("isCrouch", playerRunning);
        }
    }

    bool IsWalled() {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    void WallSlide() {
        if (IsWalled() && !isGround && movePlayerInput.x != 0f) {
            isWallSliding = true;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Mathf.Clamp(playerRigidbody.velocity.y, -wallSlidingSpeed, float.MaxValue));
        } else {
            isWallSliding = false;
        }
    }

    void WallJump() {
        if (isWallSliding) {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        } else {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f) {
            isWallJumping = true;
            playerRigidbody.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection) {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    void StopWallJumping() {
        isWallJumping = false;
    }

    void Flip() {
        if (isFacingRight && movePlayerInput.x < 0f || !isFacingRight && movePlayerInput.x > 0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            faceCheck *= -1f;
        }
    }

    public void Die() {
        DisablePlayer();
        StartCoroutine(RestartLvl());
    }

    public void DisablePlayer() {
        playerRigidbody.velocity = Vector2.zero;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawSphere(checkPos.transform.position, checkRad);
    }

    IEnumerator RestartLvl() {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
