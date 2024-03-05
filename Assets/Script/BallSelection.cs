using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelection : MonoBehaviour
{

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(PlayerPrefs.GetInt("Ball", 0)).gameObject.SetActive(true);
    }
}
