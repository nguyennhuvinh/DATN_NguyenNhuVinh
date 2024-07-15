using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pref
{
    public static int coins
    {
        set => PlayerPrefs.SetInt(PrefConsts.COIN_KEY, value);
        get => PlayerPrefs.GetInt(PrefConsts.COIN_KEY,0);
    }

    public static int trigger
    {
        set => PlayerPrefs.SetInt(PrefConsts.TRIGGER_KEY, value);
        get => PlayerPrefs.GetInt(PrefConsts.TRIGGER_KEY, 0);
    }

    public static int HighTime
    {
        set => PlayerPrefs.SetInt(PrefConsts.Time_KEY, value);
        get => PlayerPrefs.GetInt(PrefConsts.Time_KEY, 0);
    }

    public static bool IsEnoughCoints(int coinToCheck)
    {
        return coins >= coinToCheck;
    }

    public static void ClearTrigger()
    {
        PlayerPrefs.DeleteKey(PrefConsts.TRIGGER_KEY);
    }


}
