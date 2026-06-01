using UnityEngine;

public class RoomDetection : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesToSpawn;
    [SerializeField] private Collider2D _currentRoomSpawnableArea;
    private GameObject _player;
    private Collider2D _collider;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _collider = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            //Calculating the exit direction
            Vector2 exitDirection = (collision.transform.position - _collider.bounds.center).normalized;

            //If we exited from the right
            if (exitDirection.y > 0)
            {
                //Spawn in enemies
                ZombieSpawner.instance.SpawnEnemies(_currentRoomSpawnableArea, _enemiesToSpawn);
            }
        }
    }
}
