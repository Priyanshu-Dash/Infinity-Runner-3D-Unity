using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSequence : MonoBehaviour
{
    public GameObject endScreenPanel;
    public TMP_Text finalScore, highScore;
    public GameObject fadeScreen;

    void Start()
    {
        StartCoroutine(EndSequenceCo());
    }

    IEnumerator EndSequenceCo()
    {
        yield return new WaitForSeconds(2f);
        endScreenPanel.SetActive(true);
        finalScore.text = CoinCounter.coinCount.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        yield return new WaitForSeconds(4f);
        fadeScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Start");
    }
}
