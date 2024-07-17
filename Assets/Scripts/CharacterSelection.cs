using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    private int selectedCharacterIndex = 0;

    public void SelectNextCharacter()
    {
        // Hide the current character
        characterPrefabs[selectedCharacterIndex].SetActive(false);

        // Increment the selected index
        selectedCharacterIndex = (selectedCharacterIndex + 1) % characterPrefabs.Length;

        // Show the newly selected character
        characterPrefabs[selectedCharacterIndex].SetActive(true);
    }

    public void SelectPreviousCharacter()
    {
        // Hide the current character
        characterPrefabs[selectedCharacterIndex].SetActive(false);

        // Decrement the selected index
        selectedCharacterIndex = (selectedCharacterIndex - 1 + characterPrefabs.Length) % characterPrefabs.Length;

        // Show the newly selected character
        characterPrefabs[selectedCharacterIndex].SetActive(true);
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("ChosenPlayer", selectedCharacterIndex);
        SceneManager.LoadScene("Game");
    }
}
