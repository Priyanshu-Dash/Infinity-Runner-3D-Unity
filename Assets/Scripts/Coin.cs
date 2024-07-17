using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public AudioSource audioSource;
    public AudioClip coinSound;

    void Start()
    {
        audioSource.clip = coinSound;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (audioSource)
            {
                audioSource.Play();
                CoinCounter.coinCount++;
            }
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
