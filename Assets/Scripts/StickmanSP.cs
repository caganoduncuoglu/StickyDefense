using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class StickmanSP : MonoBehaviour
{
    
    [SerializeField]
    private Transform stickmanPrefab;
    [SerializeField]
    private Image pencilImage;
    [SerializeField]
    private FloatSO waveSO;

    public float waveNumber;
    public float waveSize;
    
    public float spawnTimerMax;
    private float spawnTimer;
    public bool isPlayerReady;

    private void Start()
    {
        waveNumber = waveSO.Value;
        spawnTimerMax = 1f - waveNumber * 0.1f;
        waveSize = waveNumber * 10f;
        GameEvents.PlayerReady += Ready;
        GameEvents.PlayerNotReady += NotReady;
    }
    
    public void Ready()
    {
        isPlayerReady = true;
    }
    
    public void NotReady()
    {
        isPlayerReady = false;
        Button ReadyButton = GameObject.Find("/Canvas/ReadyButton").GetComponent<Button>();
        ReadyButton.transform.localScale = new Vector3(1, 1, 1);
        Button SaveButton = GameObject.Find("/Canvas/SaveButton").GetComponent<Button>();
        SaveButton.transform.localScale = new Vector3(1, 1, 1);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isPlayerReady)
        {
            StartCoroutine(SpawnStickman());
            isPlayerReady = false;
            waveNumber++; // Next wave
            spawnTimerMax -= .1f; // Decrease spawn timer to increase difficulty
            GameEvents.WaveCountEvent();
        }

    }
    
    IEnumerator SpawnStickman()
    {
        pencilImage.transform.DOMoveY(2.55f, 0.5f).SetLoops((int)waveSize*2, LoopType.Yoyo); // wave size *2 for each stickman
        
        for (int i = 0; i < waveSize; i++)
        {
            if (spawnTimer <= 0)
            {
                Stickman stickman = Stickman.Create(stickmanPrefab, transform.position);
                yield return new WaitForSeconds(spawnTimerMax);
            }
            
        }
    }
}
    
   

