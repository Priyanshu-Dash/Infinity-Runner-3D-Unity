using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInActive : MonoBehaviour
{
    public GameObject speedText;

    void Awake()
    {
        speedText = GameObject.Find("SpeedText");
    }

    public void SetInactiveAnimatorEvent()
    {
        speedText.GetComponent<Animator>().enabled = false;
        gameObject.SetActive(false);
    }
}
