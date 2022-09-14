using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthView : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _healthBar;
    private Coroutine _moveValue;
    private float _stepReached = .5f;

    private void Awake()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = 1;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }


    public void OnHealthChanged(float health, float maxHealth)
    {
        if ( _moveValue != null )
        {
            StopCoroutine(_moveValue);
        }

        _moveValue = StartCoroutine(JobMoveHealth(health, maxHealth));
    }

    private IEnumerator JobMoveHealth(float health, float maxHealth)
    {
        float currentHealth = health / maxHealth;

        var waitForSeconds = new WaitForFixedUpdate();

        while ( _healthBar.value != currentHealth )
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, currentHealth, _stepReached * Time.deltaTime);
            yield return waitForSeconds;
        }
    }
}