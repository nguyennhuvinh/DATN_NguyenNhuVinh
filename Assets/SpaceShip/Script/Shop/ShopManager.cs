using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    public List<SkinInfo> items;
    public Transform skinSpawnPoint;
    public SkinInfo selectedItem;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetFirstSkinAsPurchased();
        LoadPurchasedSkins();
        LoadSelectedSkin();
        UpdateUI();
        SpawnSelectedSkin();
    }

    private void SetFirstSkinAsPurchased()
    {
        if (items.Count > 0 && !items[0].Isbuy)
        {
            items[0].Isbuy = true;
            items[0].Cost.text = "Bought";
            PlayerPrefs.SetInt("Skin_" + items[0].SkinId, 1);
            PlayerPrefs.Save();
        }
    }

    private void LoadPurchasedSkins()
    {
        foreach (var item in items)
        {
            item.LoadPurchaseState();
        }
    }

    private void LoadSelectedSkin()
    {
        int selectedSkinId = PlayerPrefs.GetInt("SelectedSkinId", -1);
        Debug.Log("Loaded SelectedSkinId: " + selectedSkinId);

        if (selectedSkinId == -1 || !items.Exists(item => item.SkinId == selectedSkinId))
        {
            SelectItem(items[0]);
            Debug.Log("Selected first skin: " + items[0].SkinId);
        }
        else
        {
            SkinInfo selectedItem = items.Find(item => item.SkinId == selectedSkinId);
            SelectItem(selectedItem);
            Debug.Log("Selected saved skin: " + selectedItem.SkinId);
        }
    }

    public void SelectItem(SkinInfo item)
    {
        if (selectedItem != null)
        {
            selectedItem.SetOutline(false);
        }
        selectedItem = item;
        selectedItem.SetOutline(true);

        PlayerPrefs.SetInt("SelectedSkinId", item.SkinId);
        PlayerPrefs.Save();
        Debug.Log("Saved SelectedSkinId: " + item.SkinId);

        SpawnSelectedSkin();
    }

    public void UpdateUI()
    {
        foreach (var item in items)
        {
            item.UpdateButtonState();
        }
    }

    public void SpawnSelectedSkin()
    {
        if (selectedItem == null || selectedItem.Skin_prefab == null || skinSpawnPoint == null)
        {
            Debug.LogError("Cannot spawn skin: " +
                (selectedItem == null ? "Selected item is null" :
                (selectedItem.Skin_prefab == null ? "Skin prefab is null" : "Spawn point is null")));
            return;
        }

        if (GameController.Instance.Player_Prefab != null)
        {
            Destroy(GameController.Instance.I_Player);
        }

        GameController.Instance.Player_Prefab = Instantiate(selectedItem.Skin_prefab, MapController.Instance.playerSpawnPoint.position, Quaternion.identity);
        GameController.Instance.I_Player = GameController.Instance.Player_Prefab;

        Debug.Log("Spawned skin: " + selectedItem.SkinId);
    }
}