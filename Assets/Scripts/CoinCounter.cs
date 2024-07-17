using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TMP_Text coinText, highScore;
    public static int coinCount = 0;
    public GameObject highScoreSlogan;

    void Start()
    {
        coinCount = 0;
    }

    void Update()
    {
        coinText.text = coinCount.ToString();
        if(coinCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", coinCount);
            highScoreSlogan.SetActive(true);
        }
    }
}
