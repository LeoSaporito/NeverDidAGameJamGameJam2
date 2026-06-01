using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner instance;

    [SerializeField] private LayerMask _layersEnemiesCannotSpawnOn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void SpawnEnemies(Collider2D spawnableAreaCollider, GameObject[] enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition(spawnableAreaCollider);
            GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
    private Vector2 GetRandomSpawnPosition(Collider2D spawnableAreaCollider)
    {
        Vector2 spawnPosition = Vector2.zero;
        bool isSpawnPositionValid = false;

        int attemptsCount = 0;
        int maxAttempts = 200;

        while (!isSpawnPositionValid && attemptsCount < maxAttempts)
        {
            spawnPosition = GetRandomPointInCollider(spawnableAreaCollider);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 2f);

            bool isInvalidCollision = false;

            foreach (Collider2D collider in colliders)
            {
                if (((1 << collider.gameObject.layer) & _layersEnemiesCannotSpawnOn) != 0)
                { 
                    isInvalidCollision = true;
                    break;
                }
            }

            if (!isInvalidCollision)
            {
                isSpawnPositionValid = true;
            }

            attemptsCount++;
        }

        if (!isSpawnPositionValid)
        {
            Debug.Log("Could not find a valid spawn position");
        }

        return spawnPosition;
    }

    private Vector2 GetRandomPointInCollider(Collider2D collider, float offset = 1f)
    {
        Bounds collBounds = collider.bounds;

        Vector2 minBounds = new Vector2(collBounds.min.x + offset, collBounds.min.y + offset);
        Vector2 maxBounds = new Vector2(collBounds.max.x - offset, collBounds.max.y - offset);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);

        return new Vector2(randomX, randomY);
    }
}
