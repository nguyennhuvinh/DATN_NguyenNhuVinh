using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinInfo : MonoBehaviour
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
        LoadPurchaseState();
        ButtonSelected.onClick.AddListener(OnSelect);
        ButtonBuy.onClick.AddListener(OnBuy);
        UpdateButtonState();
    }

    public void LoadPurchaseState()
    {
        Isbuy = PlayerPrefs.GetInt("Skin_" + SkinId, 0) == 1;
        Debug.Log("Loaded purchase state for Skin " + SkinId + ": " + Isbuy);
    }

    public void UpdateButtonState()
    {
        if (Isbuy)
        {
            Cost.text = "Bought";
            
        }
        else
        {

            Cost.text = "Bought";
            Cost.text = price.ToString();
            ButtonBuy.interactable = Pref.IsEnoughCoints(price);
        }
    }

    private void OnSelect()
    {
        ShopManager.Instance.SelectItem(this);
    }

    private void OnBuy()
    {
        if (Pref.IsEnoughCoints(price))
        {
            Pref.coins -= price;
            Isbuy = true;
            PlayerPrefs.SetInt("Skin_" + SkinId, 1);
            PlayerPrefs.Save();
            UpdateButtonState();
            ShopManager.Instance.UpdateUI();
            ShopManager.Instance.SelectItem(this);
            Debug.Log("Bought and selected Skin " + SkinId);
        }
    }

    public void SetOutline(bool enabled)
    {
        outline.enabled = enabled;
    }
}