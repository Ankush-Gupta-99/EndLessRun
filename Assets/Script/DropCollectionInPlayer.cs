using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Android;

public class DropCollectionInPlayer : MonoBehaviour
{
    [SerializeField] TMP_Text CoinDisplay;
    [SerializeField] int coin;
    [SerializeField] SphereCollider collide;
    [SerializeField] Rigidbody rb;
    [SerializeField] Material material;
    AudioSource AudioSource;
    [SerializeField] AudioClip Coin, Speed, Shield, others; 

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        collide=GetComponent<SphereCollider>();
        rb=GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("GoldCoinDrop"))
        {
            AudioSource.clip= Coin;
            AudioSource.Play();
            coin += 30;
            other.gameObject.SetActive(false);
            CoinDisplay.color = Color.yellow;
        }
        if (other.gameObject.CompareTag("SilverCoinDrop"))
        {
            AudioSource.clip = Coin;
            AudioSource.Play();
            coin += 10;
            other.gameObject.SetActive(false);
            CoinDisplay.color = Color.gray;
        }
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            AudioSource.clip = Speed;
            AudioSource.Play();
            other.gameObject.SetActive(false);
            rb.velocity += new Vector3(0, 0, 50);
        }
        if (other.gameObject.CompareTag("GoldenChest"))
        {
            AudioSource.clip = others;
            AudioSource.Play();

            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("WoodenChest"))
        {
            AudioSource.clip = others;
            AudioSource.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Shield"))
        {
            AudioSource.clip = Shield;
            AudioSource.Play();
            material.EnableKeyword("_EMISSION");
            other.gameObject.SetActive(false);
            rb.velocity += new Vector3(0, 0, 20);
            transform.position =new Vector3(transform.position.x, 10 ,transform.position.z);
            collide.isTrigger = true;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            StartCoroutine("trigDes");
        }
        if (other.gameObject.CompareTag("Silvercoin"))
        {
            AudioSource.clip = Coin;
            AudioSource.Play();
            coin += 1;
            other.gameObject.SetActive(false);
            CoinDisplay.color =Color.gray ;
        }
        if (other.gameObject.CompareTag("Goldcoin"))
        {
            AudioSource.clip = Coin;
            AudioSource.Play();
            coin += 3;
            other.gameObject.SetActive(false);
            CoinDisplay.color =Color.yellow ;
        }
        CoinDisplay.SetText("Coin: " + coin);

    }
    IEnumerator trigDes() {
        
        yield return new WaitForSeconds(7);
        material.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.3f);
        material.DisableKeyword("_EMISSION");
        collide.isTrigger = false;
        rb.constraints = RigidbodyConstraints.None;
    }
}
