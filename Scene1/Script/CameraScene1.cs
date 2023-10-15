using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    public LayerMask enemyLayer; // Layer mask for enemy objects
    public string enemyTag = "Enemy"; // Tag of enemy objects
    public LayerMask obstacleLayer; // Layer mask for obstacles
    public float maxRayDistance = 100f; // Maximum raycast distance
    public Transform CameraPlayer;
    private EnemyMove enemymove;

    private Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main; // Get the main camera (you can also set it explicitly)
        enemymove = GameObject.FindWithTag("Enemy").GetComponent<EnemyMove>();
    }

    private void Update()
    {
        CheckForEnemiesInSight();
    }

    private void CheckForEnemiesInSight()
    {
        // Get all objects in the enemy layer
        Collider[] enemies = Physics.OverlapSphere(transform.position, maxRayDistance, enemyLayer);

        foreach (Collider enemy in enemies)
        {
            // Get the enemy's position in screen space
            Vector3 screenPos = playerCamera.WorldToViewportPoint(enemy.transform.position);

            // Check if the enemy is within the camera's view (screen aspect)
            if (screenPos.x >= 0f && screenPos.x <= 1f && screenPos.y >= 0f && screenPos.y <= 1f && screenPos.z > 0f)
            {
                // Check if there's an obstacle between the player and the enemy
                if (!IsObstacleInPath(enemy.transform))
                {
                    Debug.Log("See enemy: " + enemy.name);
                    enemymove.UpdateSpeed(0f);
                }
                else
                {
                    Debug.Log("Don't see enemy: " + enemy.name);
                    enemymove.UpdateSpeed(10f);
                }
            }
            else
            {
                Debug.Log("Don't see enemy: " + enemy.name);
                enemymove.UpdateSpeed(10f);
            }
        }
    }

    private bool IsObstacleInPath(Transform target)
    {
        Vector3 directionToTarget = target.position - CameraPlayer.position;

        
        Debug.DrawRay(CameraPlayer.position, directionToTarget, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(CameraPlayer.position, directionToTarget, out hit, maxRayDistance, obstacleLayer))
        {
            Debug.DrawRay(CameraPlayer.position, directionToTarget.normalized * hit.distance, Color.red);
            return true; // An obstacle is in the way
        }

        return false; // No obstacles in the way
    }
}
