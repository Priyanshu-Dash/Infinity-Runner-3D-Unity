using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerImage : MonoBehaviour
{
    private Image image;
    public float duration = 5.0f;
    public float initialWidth = 150f;
    private float elapsedTime;

    void Start()
    {
        elapsedTime = 0.0f;
        image = GetComponent<Image>();
        //initialWidth = image.rectTransform.sizeDelta.x;
        image.rectTransform.sizeDelta = new Vector2(initialWidth, image.rectTransform.sizeDelta.y);

        StartCoroutine(ChangeImageWidth());
    }

    private IEnumerator ChangeImageWidth()
    {
        while (elapsedTime < duration)
        {
            float newWidth = Mathf.Lerp(initialWidth, 0f, elapsedTime / duration);
            image.rectTransform.sizeDelta = new Vector2(newWidth, image.rectTransform.sizeDelta.y);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the final width is the target width
        image.rectTransform.sizeDelta = new Vector2(0f, image.rectTransform.sizeDelta.y);
    }
}
