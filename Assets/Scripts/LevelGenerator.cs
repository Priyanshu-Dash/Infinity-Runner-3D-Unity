using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject levelPrefab;
    public int lvlZ = 96;
    public float spwanTime = 5f;
    public GameObject[] characterPrefabs;
    bool creatingLevel = false;

    void Awake()
    {
        Instantiate(characterPrefabs[PlayerPrefs.GetInt("ChosenPlayer", 0)], new Vector3(0, 0.12f, -49), Quaternion.identity);
    }

    void Update()
    {
        if (creatingLevel == false)
        {
            creatingLevel = true;
            StartCoroutine(CreateLevel());
        }
    }

    IEnumerator CreateLevel()
    {
        Instantiate(levelPrefab, new Vector3(2, 0, lvlZ), Quaternion.identity);
        yield return new WaitForSeconds(spwanTime);
        lvlZ += 96;
        creatingLevel = false;
    }
}
