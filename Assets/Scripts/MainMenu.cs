using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private FloatSO scoreSO;
    [SerializeField]
    private FloatSO waveSO;
    [SerializeField]
    private FloatSO coinSO;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        scoreSO.Value = 0f;
        waveSO.Value = 1f;
        coinSO.Value = 200f;
        Debug.Log("CoinSO : " + coinSO.Value);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Continue()
    {
        Debug.Log("Continued");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log("Score: " + data.score);
        scoreSO.Value = data.score;
        waveSO.Value = data.waveNum;
        coinSO.Value = data.coinCollected;
        
    
    }
}
