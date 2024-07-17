using UnityEngine;
using System.Collections;

public class ObstacleCollision : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public GameObject levelControl;
    public GameObject blastParticleSystem;
    public AudioSource SFX, BGM;
    public AudioClip deathSound;
    public AudioClip gameoverSound;
    public AudioClip smashSound;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = player.GetComponent<Animator>();
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
        levelControl = GameObject.Find("LevelControl");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            KillPlayer();
        }
        
        if (other.gameObject.CompareTag("Ball"))
        {
            DestroyObstacle(other);
        }

    }

    void KillPlayer()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<BallLauncher>().enabled = false;
        animator.SetBool("isDead", true);
        BGM.Stop();
        SFX.PlayOneShot(deathSound);
        StartCoroutine(PlayGameOverSoundAfterDelay());
        levelControl.GetComponent<EndSequence>().enabled = true;
    }

    void DestroyObstacle(Collider other)
    {
        blastParticleSystem.SetActive(true);
        SFX.PlayOneShot(smashSound);
        Destroy(other.gameObject);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }

    IEnumerator PlayGameOverSoundAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        SFX.PlayOneShot(gameoverSound);
    }
}
