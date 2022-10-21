using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    public MoneyManaer manager;
    public TextMeshProUGUI moneyText;
    public int sayi;

    private void Update()
    {
       moneyText.text= manager.paralar.Length.ToString();
    }
}
