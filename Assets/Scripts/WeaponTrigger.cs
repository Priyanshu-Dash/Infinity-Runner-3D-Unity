using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponTrigger : MonoBehaviour
{
    public float powerUpTime = 5f;
    private GameObject player;
    private BallLauncher ballLauncher;
    private Image timerImage;
    private TimerImage timerImageScript;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ballLauncher = player.GetComponent<BallLauncher>();
        timerImage = GameObject.Find("Timer").GetComponent<Image>();
        timerImageScript = GameObject.Find("Timer").GetComponent<TimerImage>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EnableBallShooting());
        }
    }

    IEnumerator EnableBallShooting()
    {
        ballLauncher.enabled = true;
        timerImage.enabled = true;
        timerImageScript.enabled = true;

        yield return new WaitForSeconds(powerUpTime);
        
        ballLauncher.enabled = false;
        timerImage.enabled = false;
        timerImageScript.enabled = false;
        Debug.Log("Power up time ended");
        Destroy(gameObject);
    }
}
