using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPosition;
    public float launchForce = 10f;
    public AudioClip shootSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        GameObject.Find("SFX").GetComponent<AudioSource>().PlayOneShot(shootSound);
        GameObject newBall = Instantiate(ballPrefab, spawnPosition.position, spawnPosition.rotation);
        #region Code Tip
        //Rigidbody rb = newBall.GetComponent<Rigidbody>();
        //if (rb != null)
        //{
        //    rb.AddForce(handTransform.forward * launchForce, ForceMode.Impulse);
        //}
        #endregion
        // Better way to do the commpented thing: -
        if (newBall.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.velocity = transform.forward * launchForce;
        }

        if(newBall)
        {
            Destroy(newBall, 3f);
        }
    }
}
