using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthView : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Slider _healthBar;
    private Coroutine _moveValue;
    private float _stepReached = 1f;

    private void Awake()
    {
        _healthBar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }
    

    public void OnHealthChanged(float health)
    {
        if ( _moveValue != null )
        {
            StopCoroutine(_moveValue);
        }
        
        _moveValue = StartCoroutine(JobMoveHealth(health));
    }

    private IEnumerator JobMoveHealth(float health)
    {
        var waitForSeconds = new WaitForFixedUpdate();
        

        while ( _healthBar.value != health )
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, health, _stepReached);
            yield return waitForSeconds;
        }
    }
}