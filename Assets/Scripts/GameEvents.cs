using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    // OBSERVER PATTERN
    
    public static event Action IncrementCounter;
    public static event Action CoinCollect;
    public static event Action CoinSpend;
    public static event Action PlayerReady;
    public static event Action PlayerNotReady;
    public static event Action SaveGame;
    public static event Action WaveCount;
    public static event Action LoadGame;
    public static void StickmanCounter()
    {
        IncrementCounter?.Invoke();
    }
    
    public static void CoinCollectEvent()
    {
        CoinCollect?.Invoke();
    }
    public static void CoinSpendEvent()
    {
        CoinSpend?.Invoke();
    }
    
    public static void PlayerReadyEvent()
    {
        PlayerReady?.Invoke();
    }
    
    public static void PlayerNotReadyEvent()
    {
        PlayerNotReady?.Invoke();
    }
    
    public static void WaveCountEvent()
    {
        WaveCount?.Invoke();
    }
    
    public static void SaveGameEvent()
    {
        SaveGame?.Invoke();
    }
    
    public static void LoadGameEvent()
    {
        LoadGame?.Invoke();
    }
}
