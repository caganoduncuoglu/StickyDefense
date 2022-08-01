using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stickman : MonoBehaviour
{
    [SerializeField]
    private Transform stickmanPrefab;

   //rivate const float SPEED = 30f;
    public int health = 100;

    public static List<Stickman> stickmanList = new List<Stickman>();

    public static Stickman GetClosestStickman(Vector3 position, float range)
    {
        Stickman closest = null;
        foreach (Stickman stickman in stickmanList)
        {
            if (stickman.IsDead()) continue;

            if (Vector3.Distance(position, stickman.transform.position) <= range)
            {
                if (closest == null)
                {
                    closest = stickman;
                }
                else
                {
                    if (Vector3.Distance(position, stickman.transform.position) < Vector3.Distance(position, closest.transform.position))
                    {
                        closest = stickman;
                    }
                }
            }
        }
        return closest;
    }

    public static Stickman Create(Transform stickmanPrefab, Vector3 position)
    {
        Transform stickmanTransform = Instantiate(stickmanPrefab, position, Quaternion.identity);
        Stickman stickmanHandler = stickmanTransform.GetComponent<Stickman>();
        return stickmanHandler;
    }

    private void Awake()
    {
        stickmanList.Add(this);
        
    }

 
    private bool IsDead()
    {
        return health <= 0;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (IsDead())
            Die();
        
        else
        {
            //Sprite opasitesi azalt
        }
        
        
    }

    private void Die()
    {
        stickmanList.Remove(this);
        Destroy(gameObject);
        GameEvents.StickmanCounter();
        GameEvents.CoinCollectEvent();
        
        if (stickmanList.Count == 0)
        {
            GameEvents.PlayerNotReadyEvent();
        }
    }

    public void Start()
    {
        transform.DOMoveX(1.5f, 4).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOScaleX(-0.15f, 0.2f);
            transform.DOMoveY(-0.3f, 4).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.DOMoveX(-1.5f, 4).SetEase(Ease.Linear).OnComplete(() =>
                {
                    transform.DOScaleX(0.15f, 0.2f);
                    transform.DOMoveY(-2.5f, 4).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        transform.DOMoveX(2.2f, 4).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            Destroy(gameObject);
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
                        });
                    });
                });
            });
        });


    }


}
