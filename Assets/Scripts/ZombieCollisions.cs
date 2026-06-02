using UnityEngine;

public class ZombieCollisions : MonoBehaviour
{
    [SerializeField] private Healthbar _healthbarScript;
    
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damageTaken;

    [SerializeField] float hurtProgress;
    [SerializeField] float hurtDuration;
    bool tookDamage;

    CarMovement _carMovementScript;
    SpriteRenderer _mySpriteRenderer;
    
    public float _currentHealth;


    private void Start()
    {
        _carMovementScript = GetComponent<CarMovement>();

        _mySpriteRenderer = GetComponent<SpriteRenderer>();

        _currentHealth = _maxHealth;

        _healthbarScript.UpdateHealthbar(_maxHealth, _currentHealth);

        tookDamage = false;
    }
    private void Update()
    {
        if (tookDamage == true)
        { 
            HurtSignifier();
        }

        if (_currentHealth <= 0)
        {
            _carMovementScript.DisableControls();
            _mySpriteRenderer.color = Color.red;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            _currentHealth -= _damageTaken;
            _healthbarScript.UpdateHealthbar(_maxHealth, _currentHealth);

            tookDamage = true;
        }
    }

    void HurtSignifier()
    {
        hurtProgress += Time.deltaTime;

        if (hurtProgress <= hurtDuration)
        { 
            _mySpriteRenderer.color = Color.red;
        }
        if (hurtProgress >= hurtDuration)
        { 
            _mySpriteRenderer.color = Color.white;
            tookDamage = false;
            hurtProgress = 0f;
        }
    }
}
