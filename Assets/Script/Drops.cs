using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    [SerializeField] GameObject[] DropsList;
    [SerializeField]
    long  waittime;
    private void Start()
    {
        
        StartCoroutine(Spawan());

    }
    IEnumerator Spawan()
    {
        GameObject DropRNow = DropsList[Random.Range(0, DropsList.Length)];
        int y;
        if (DropRNow.CompareTag("Shield") || DropRNow.CompareTag("SpeedBoost"))
        {
            y = 15;
        }
        else
        {
            y = 1;
        }
        waittime += 5;
        yield return new WaitForSeconds(waittime);
        Instantiate(DropRNow, new Vector3(Random.Range(25,120), y, transform.position.z+Random.Range(100,500)), Quaternion.identity);
        StartCoroutine(Spawan());
    }
}
