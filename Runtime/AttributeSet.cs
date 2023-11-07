using System;
using UnityEngine;

public abstract class AttributeSet : MonoBehaviour, IDamageable
{
    /* 필드 */
    [SerializeField] Attribute<float> _health = new Attribute<float>(0, 100);

    public Attribute<float> Health => _health;
    public bool IsDead => Mathf.Approximately(_health.Value, 0);

    /* 이벤트 */
    public event Action OnDied;

    /* MonoBehaviour */
    protected virtual void Awake()
    {
        // 체력이 0이 되면 IsDead = true
        _health.OnValueUpdated += delegate(float health)
        {
	        if (Mathf.Approximately(health, 0))
	        {
		        OnDied?.Invoke();
	        }
        };
    }

    protected virtual void OnEnable()
    {
	    // Max 값으로 초기화
	    _health.Value = _health.MaxValue;
    }

    /* 메서드 */
    // 자손 클래스에서 데미지 계산식 작성
    protected abstract void TakeDamage(float damage, DamagePayload damagePayload);

    /* IDamageable */
    public void ApplyDamage(float damage, DamagePayload damagePayload)
    {
	    TakeDamage(damage, damagePayload);
    }
}
