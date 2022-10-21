using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI finishInfo;
    public GameObject finishScreen;
    BoxCollider box;
    MoneyManaer moneyManaer;
    CollectCoin collectCoin;
    public Transform hedef;
    public float zaman, geri;
    public bool isDead;

    void Start()
    {
        // transform.DOMove(hedef.position, zaman);
        box = GetComponent<BoxCollider>();
        moneyManaer = GetComponent<MoneyManaer>();
        collectCoin = GetComponent<CollectCoin>();
    }
    private void Update()
    {
        transform.Translate(transform.forward * zaman * Time.deltaTime);
        if(isDead)
        {
            box.enabled = false;
            moneyManaer.animator.SetBool("isDead", true);
            this.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if(moneyManaer.paralar.Length>0)
            {
                transform.Translate(transform.forward * -geri * Time.deltaTime);
                collectCoin.sayi -= 2;
                for (moneyManaer.index = 0; moneyManaer.index < 2; moneyManaer.index++)
                {
                    Destroy(moneyManaer.paralar[moneyManaer.index]);
                }
            }
            else if (moneyManaer.paralar.Length <= 0)
            {
                isDead = true;
            }
        }
        
    }
    void Finish()
    {
        moneyManaer.animator.SetTrigger("idle");
        zaman = 0;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("1x"))
        {
            finishScreen.SetActive(true);
            finishInfo.text = "1x";
        }
        if (other.gameObject.CompareTag("2x"))
        {
            finishScreen.SetActive(true);
            finishInfo.text = "2x";
            Finish();

        }
        if (other.gameObject.CompareTag("3x"))
        {
            finishScreen.SetActive(true);
            finishInfo.text = "3x";
            Finish();


        }
        if (other.gameObject.CompareTag("4x"))
        {
            finishScreen.SetActive(true);
            finishInfo.text = "4x";
            Finish();


        }
        if (other.gameObject.CompareTag("5x"))
        {
            finishScreen.SetActive(true);
            finishInfo.text = "5x";
            Finish();


        }
    }




}
