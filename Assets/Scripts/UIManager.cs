using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI stickmanCountText =  GameObject.Find("/Canvas/StickCountText").GetComponent<TextMeshProUGUI>();
    public TextMeshProUGUI cointText = GameObject.Find("/Canvas/CoinText").GetComponent<TextMeshProUGUI>();
    public TextMeshProUGUI waveCountText = GameObject.Find("/Canvas/WaveCount").GetComponent<TextMeshProUGUI>();
    
    [SerializeField]
    public Transform towerPrefab;
    [SerializeField]
    public Button readyButton;
    [SerializeField]
    public Button saveButton;

    [SerializeField]
    private FloatSO scoreSO;
    [SerializeField]
    private FloatSO coinSO;
    [SerializeField]
    private FloatSO waveSO;
 
    
    private bool isContinued = false;

    public float stickmanCount;
    public float coinCollected; 
    public float waveCount;
    public static List<Vector3> towerPositionList = new List<Vector3>();
    public static List<int> towerIndexList = new();
    
    private void Awake()
    {
        coinCollected = 200f; // 200 at the start of the game
        waveCount = 1f;
    }
    private void Start()
    {
        towerPositionList.Clear();
        towerIndexList.Clear();
        stickmanCount = scoreSO.Value; // LOAD SCORE
        waveCount = waveSO.Value; // LOAD WAVECOUNT
        coinCollected = coinSO.Value; // LOAD COINCOLLECTED
        stickmanCountText.text = "x" + stickmanCount;
        waveCountText.text = "Wave: " + waveCount;
        cointText.text = coinCollected.ToString();
        towerPositionListCreate();
        GameEvents.IncrementCounter += IncrementStickmanCount;
        GameEvents.CoinCollect += IncrementCoin;
        GameEvents.CoinSpend += SpendCoin;
        GameEvents.WaveCount += DisplayWaveCount;
        GameEvents.SaveGame += SaveButton;
    }
    

    public void DisplayWaveCount()
    {
        waveCountText.text = "Wave: " + waveCount;
        waveCount++;
    }

    public void ReadyButton()
    {
        GameEvents.PlayerReadyEvent();
        readyButton.transform.localScale = new Vector3(0, 0, 0); //disappear button
        saveButton.transform.localScale = new Vector3(0, 0, 0); //disappear button
    }

    public void SaveButton()
    {
        Debug.Log("Save Button Pressed");
        saveButton.onClick.AddListener(() =>  GameEvents.SaveGameEvent());
        
        
        
        // SAVE THE GANE ON EVERY WAVE MANUALLY
        SaveSystem.SavePlayer(this);
    }
    public void IncrementCoin()
    {
        coinCollected += 10;
        cointText.text = coinCollected.ToString();
    }
    
    public void SpendCoin()
    {
        coinCollected -= 200;
        cointText.text = coinCollected.ToString();
    }

    public void IncrementStickmanCount()
    {
        stickmanCount++;
        stickmanCountText.text = "x" + stickmanCount;
    }

    private void OnDisable() // for events
    {
        GameEvents.IncrementCounter -= IncrementStickmanCount;
        GameEvents.CoinCollect -= IncrementCoin;
        GameEvents.CoinSpend -= SpendCoin;
        //GameEvents.SaveGame -= SaveButton;
    }
    
    public void SpawnTower()
    {
        int randomIndex = UnityEngine.Random.Range(0, towerPositionList.Count);

        if (!towerIndexList.Contains(randomIndex) && coinCollected >= 200) // if not enough money or already have tower in that position
        {
            GameEvents.CoinSpendEvent();
            Tower tower = Tower.Create(towerPrefab, towerPositionList[randomIndex]);
            towerIndexList.Add(randomIndex);
        }
        else
        {
            SpawnTower();
        }
        
    }

    private void towerPositionListCreate()
    {
        Vector3 TP1 = GameObject.Find("/TowerPositions/TP1").transform.position;
        Vector3 TP2 = GameObject.Find("/TowerPositions/TP2").transform.position;
        Vector3 TP3 = GameObject.Find("/TowerPositions/TP3").transform.position;
        Vector3 TP4 = GameObject.Find("/TowerPositions/TP4").transform.position;
        Vector3 TP5 = GameObject.Find("/TowerPositions/TP5").transform.position;
        Vector3 TP6 = GameObject.Find("/TowerPositions/TP6").transform.position;
        Vector3 TP7 = GameObject.Find("/TowerPositions/TP7").transform.position;
        Vector3 TP8 = GameObject.Find("/TowerPositions/TP8").transform.position;
        
        towerPositionList.Add(TP1);
        towerPositionList.Add(TP2);
        towerPositionList.Add(TP3);
        towerPositionList.Add(TP4);
        towerPositionList.Add(TP5);
        towerPositionList.Add(TP6);
        towerPositionList.Add(TP7);
        towerPositionList.Add(TP8);
    }
}
