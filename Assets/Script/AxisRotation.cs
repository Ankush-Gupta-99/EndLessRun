using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotation : MonoBehaviour
{
    public int coinsp=144;
    void FixedUpdate()
    {
        if (transform.eulerAngles.y < 360)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, (transform.eulerAngles.y + Time.deltaTime * coinsp), transform.eulerAngles.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,0,transform.eulerAngles.z);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
  /*      Debug.Log("Istriger");*/
        Destroy(gameObject);
    }
}
