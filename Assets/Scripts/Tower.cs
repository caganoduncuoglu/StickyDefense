//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
public class Tower : MonoBehaviour
{
    [SerializeField]
    public Transform projectilePrefab;
    [SerializeField]
    private GameObject shootPositionObject;
    public Vector3 shootPosition;
    public float range;
    private float shootTimerMax;
    private float shootTimer;


    private void Awake()
    {
        shootPosition = shootPositionObject.transform.position;
        range = 1.2f;
        shootTimerMax = .2f;
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            shootTimer = shootTimerMax;
            
            Stickman stickman = GetClosestStickman();
            if (stickman != null)
            {
                int damageAmount = Random.Range(10, 50); // Random damage amount between 10 and 50
                RedEraserProjectile.Create(projectilePrefab,shootPosition, stickman, damageAmount );
            }
            
        }
       
    }

    private Stickman GetClosestStickman()
    {
        return Stickman.GetClosestStickman(shootPosition, range);
    }
    
    public static Tower Create(Transform towerPrefab, Vector3 position)
    {
        Transform towerTransform = Instantiate(towerPrefab, position, Quaternion.identity);
        Tower towerHandler = towerTransform.GetComponent<Tower>();
        return towerHandler;
    }
}
