using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed;
    [SerializeField] float distanceToPlayer;
    [SerializeField] ZombieCollisions zombieCollisionsScript;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public GameObject bloodSplatter;
    public GameObject particalSplatter;

    CarMovement carMovementScript;
    ZombieSpawner zombieSpawnerScript;

    Vector3 position;
    Vector3 direction;
    
    void Start()
    {
        carMovementScript = FindFirstObjectByType<CarMovement>();
        zombieSpawnerScript = FindFirstObjectByType<ZombieSpawner>();
        zombieCollisionsScript = FindFirstObjectByType<ZombieCollisions>();
    }

    void Update()
    {
        if (zombieCollisionsScript._currentHealth <= 0) { return; }
        
        MoveTowardsPlayer();
        FacePlayer();
    }

    void MoveTowardsPlayer()
    {
        //Enemy has script
        //Find position of the player
        //previous distance from last frame and subtract it from the player position

        float distance = Vector2.Distance(carMovementScript.transform.position, transform.position);

        if (distance < distanceToPlayer)
        { 
            position = transform.position;

            direction = (carMovementScript.transform.position - transform.position).normalized;

            transform.up = -direction;

            position -= transform.up * enemyMoveSpeed * Time.deltaTime;
            position.z = 0f;

            transform.position = position;    
        }
    }

    void FacePlayer()
    {
        transform.Rotate(0f, 0f, direction.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameObject spawnedBlood = Instantiate(bloodSplatter, transform.position , Quaternion.identity);
            GameObject spawnedSplatter = Instantiate(particalSplatter, transform.position, Quaternion.identity);
        }
    }
}
