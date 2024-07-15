using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public List<Buttonnfo> items;
    public Transform skinSpawnPoint;

    public Buttonnfo selectedItem;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SelectItem(items[0]);
        UpdateUI();
    }

    public void SelectItem(Buttonnfo item)
    {
        if (selectedItem != null)
        {
            selectedItem.SetOutline(false);
        }

        selectedItem = item;
        selectedItem.SetOutline(true);

        if (selectedItem.Isbuy)
        {
            SpawnSelectedSkin();
        }
    }

    public void UpdateUI()
    {
        foreach (var item in items)
        {
            item.ButtonBuy.interactable = !item.Isbuy && Pref.IsEnoughCoints(item.price);
        }
    }

    public void SpawnSelectedSkin()
    {
        if (selectedItem.Skin_prefab == null || skinSpawnPoint == null) return;

        // Destroy existing skin
        if (GameController.Instance.Player_Prefab != null)
        {
            Destroy(GameController.Instance.I_Player);
        }

        // Instantiate new skin
        GameController.Instance.Player_Prefab = Instantiate(selectedItem.Skin_prefab, MapController.Instance.playerSpawnPoint.position, Quaternion.identity);
        //GameController.Instance.I_Player.transform.SetParent(skinSpawnPoint);
        GameController.Instance.I_Player = GameController.Instance.Player_Prefab;
    }
}
