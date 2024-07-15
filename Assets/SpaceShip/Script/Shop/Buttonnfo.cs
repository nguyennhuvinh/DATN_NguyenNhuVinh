using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttonnfo : MonoBehaviour
{
    public int SkinId;
    public GameObject Skin_prefab;
    public Button ButtonSelected;
    public Button ButtonBuy;
    public TMP_Text Cost;
    public int price;
    public bool Isbuy;
    public Outline outline;

    private void Start()
    {
        ButtonSelected.onClick.AddListener(OnSelect);
        ButtonBuy.onClick.AddListener(OnBuy);

        if (Isbuy)
        {
            Cost.text = "Bought";
            ButtonBuy.interactable = false;
        }
    }

    private void OnSelect()
    {
        if (Isbuy)
        {
            ShopManager.Instance.SelectItem(this);
        }
    }

    private void OnBuy()
    {
        if (Pref.IsEnoughCoints(price))
        {
            Pref.coins -= price;
            Isbuy = true;
            ButtonBuy.interactable = false;
            Cost.text = "Bought";
            ShopManager.Instance.UpdateUI();
        }
    }

    public void SetOutline(bool enabled)
    {
        outline.enabled = enabled;
    }
}
