using UnityEngine;

public class ZombieCollisions : MonoBehaviour
{
    [SerializeField] private Healthbar _healthbarScript;
    
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damageTaken;

    CarMovement _carMovementScript;
    
    public float _currentHealth;


    private void Start()
    {
        _carMovementScript = GetComponent<CarMovement>();

        _currentHealth = _maxHealth;

        _healthbarScript.UpdateHealthbar(_maxHealth, _currentHealth);
    }
    private void Update()
    {
        if (_currentHealth <= 0)
        {
            _carMovementScript.DisableControls();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            _currentHealth -= _damageTaken;
            _healthbarScript.UpdateHealthbar(_maxHealth, _currentHealth);            
        }
    }
}
