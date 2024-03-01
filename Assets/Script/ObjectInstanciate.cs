using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectInstanciate : MonoBehaviour
{
    [SerializeField] GameObject[] Insta;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(Insta[Random.Range(0,Insta.Length)], transform.position+new Vector3(0,0,2399), Quaternion.identity);
        }
    }
}
