using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectInstanciate : MonoBehaviour
{
    [SerializeField] GameObject[] Insta;
    /*
        [SerializeField] GameObject[] trees;
        Vector3 treePos;

        IEnumerable TreePos()
        {
            yield return null;
            treePos=new Vector3();
        }

        IEnumerator TreeGenerator()
        {
            yield return null;r
            Instantiate(trees[Random.Range(0,trees.Length)],treePos,Quaternion.identity);
        }*/
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(Insta[Random.Range(0,Insta.Length)], transform.position+new Vector3(0,0,2393), Quaternion.identity);
        }
    }
}
