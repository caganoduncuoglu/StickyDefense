using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEraserProjectile : MonoBehaviour
{
    public static void Create(Transform prefab, Vector3 spawnPosition, Stickman stickman, int damageAmount)
    {
        Transform projectile = Instantiate(prefab, spawnPosition, Quaternion.identity);
        
        RedEraserProjectile redEraserProjectile = projectile.GetComponent<RedEraserProjectile>();
        redEraserProjectile.Setup(stickman, damageAmount);
    }

    private Stickman stickman;
    private int damageAmount;
    
    private void Setup(Stickman stickman, int damageAmount)
    {
        this.stickman = stickman;
        this.damageAmount = damageAmount;
    }

    private void Update()
    {
        if (stickman == null) // to prevent the projectile from flying forever
            Destroy(gameObject);
        
        Vector3 targetPosition = stickman.transform.position;
        Vector3 direction = targetPosition - transform.position;
        
        float moveSpeed = 5f;
        
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        
        float destroyDistance = 0.3f;
        if (Vector3.Distance(transform.position, targetPosition) < destroyDistance)
        {
            stickman.Damage(damageAmount);
            Destroy(gameObject);
        }
    }

}
