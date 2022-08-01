using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System .Serializable]
public class PlayerData
{
   public float score;
   public float waveNum;
   public float coinCollected;

   public PlayerData(UIManager uiManager)
   {
      score = uiManager.stickmanCount;
      waveNum = uiManager.waveCount;
      coinCollected = uiManager.coinCollected;
   }

}
