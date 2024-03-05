using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField] GameObject Main;
    [SerializeField] GameObject events;
    [SerializeField] GameObject Wspawn;
    [SerializeField] GameObject GSpawn;
    [SerializeField] TMP_Text Coin;
    [SerializeField] GameObject Clic;
    [SerializeField] GameObject misr;
    bool click;
    AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
        Time.timeScale = 1;
        check();
        
    }

    void check()
    {
        if ((PlayerPrefs.GetInt("WCreat", 0) > 0) || (PlayerPrefs.GetInt("GCreat", 0) > 0))
        {
            events.SetActive(true);
            Main.SetActive(false);
            StartCoroutine("Ev");
        }
        else
        {
            events.SetActive(false);
            Main.SetActive(true);
        }
    }
    public void clicked()
    {
        click = true;
        check();
    }
    bool isclicked()
    {
        if (click)
        {
            click= false;
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator Ev()
    {
        yield return new WaitForSeconds(1);
        GameObject ins;
        int coin;
        if (PlayerPrefs.GetInt("WCreat") > 0)
        {
            PlayerPrefs.SetInt("WCreat", PlayerPrefs.GetInt("WCreat") - 1);
            ins=Instantiate(Wspawn);
            ins.GetComponent<Animator>().Play("WoodenBox");
            coin = Random.Range(0, 100);
            Coin.SetText(coin.ToString());
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) + coin);
            misr.GetComponent<Animator>().Play("CoinAdd");
            AS.Play();
        }
        else if (PlayerPrefs.GetInt("GCreat") > 0)
        {
            PlayerPrefs.SetInt("GCreat", PlayerPrefs.GetInt("GCreat") - 1);
            ins=Instantiate(GSpawn);
            ins.GetComponent<Animator>().Play("GoldenCrate");
            coin = Random.Range(100, 500);
            Coin.SetText(coin.ToString());
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) + coin);
            misr.GetComponent<Animator>().Play("CoinAdd");
            AS.Play();
        }
        else
        {
            ins = null;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        Clic.SetActive(true);
        yield return new WaitUntil(isclicked);
        Destroy(ins);
        Clic.SetActive(false);
        StartCoroutine(Ev());
    }

}
