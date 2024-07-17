using System.Collections;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class PlayerMovement : MonoBehaviour
{
    #region Public Variables
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float maxMove = 3f;
    public float tiltSensitivity = 0.5f;

    [Header("Speedup Settings")]
    public int coinCount1 = 10;
    public int coinCount2 = 20;
    public int coinCount3 = 30;
    public float speed1 = 25f;
    public float speed2 = 30f;
    public float speed3 = 35f;
    public GameObject speedText;
    #endregion

    #region Private Variables
    float initialSpeed;
    bool isComingDown = false, isJumping = false;
    Vector2 touchStart;
    #endregion

    void Awake()
    {
        initialSpeed = moveSpeed;
        speedText = GameObject.Find("SpeedText");
    }

    void Update()
    {
        if (CoinCounter.coinCount > coinCount1 && moveSpeed == initialSpeed)
        {
            moveSpeed = speed1;
            HandleSpeedTextAnimation();
        }

        if (CoinCounter.coinCount > coinCount2 && moveSpeed == speed1)
        {
            moveSpeed = speed2;
            HandleSpeedTextAnimation();
        }

        if (CoinCounter.coinCount > coinCount3 && moveSpeed == speed2)
        {
            moveSpeed = speed3;
            HandleSpeedTextAnimation();
        }

        #region PCControls
        // Move the player forward
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x < maxMove)
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x > -maxMove)
        {
            transform.Translate(-moveSpeed * Time.deltaTime * Vector3.left);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.Space)))
        {
            if (isJumping == false)
            {
                isJumping = true;
                StartCoroutine(Jump());
            }
        }

        if (isJumping == true)
        {
            if (isComingDown == false)
            {
                transform.Translate(jumpForce * Time.deltaTime * Vector3.up);
            }

            if (isComingDown == true)
            {
                transform.Translate(jumpForce * Time.deltaTime * Vector3.down);
            }
        }
        #endregion

        #region MobileTouchControls
        float tilt = Input.acceleration.x * tiltSensitivity;

        // Move the player based on tilt input
        transform.Translate(-moveSpeed * -tilt * Time.deltaTime * Vector3.right);

        // Clamp the player's position within the screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, -maxMove, maxMove);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        //Check for swipe input for jump
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchStart = Input.GetTouch(0).position;
        }

        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 touchEnd = Input.GetTouch(0).position;
            float swipeDistance = touchEnd.y - touchStart.y;

            if (swipeDistance > 0)
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    StartCoroutine(Jump());
                }
            }
        }
        #endregion
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.45f);
        isComingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        isComingDown = false;
        transform.position = new Vector3(transform.position.x, 0.12f , transform.position.z);
    }

    private void HandleSpeedTextAnimation()
    {
        speedText.SetActive(true);
        speedText.GetComponent<Animator>().enabled = true;
        speedText.GetComponent<TextMeshProUGUI>().text = "Speed: " + moveSpeed.ToString();
    }
}
