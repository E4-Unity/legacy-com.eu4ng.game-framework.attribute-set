using System;
using UnityEngine;

/// <summary>
/// Value는 MinValue 이상 MaxValue 이하의 값을 가지며, Value 값이 변화할 때마다 변화한 Value 값을 출력하는 이벤트를 호춣한다.
/// MinValue는 생성자에서만 변경할 수 있고 일반적으로 0을 사용한다.
/// MaxValue는 인스펙터 창에서 변경할 수 있지만 최소값은 0으로 고정되어 있다. 또한, MinValue 이상의 값을 가진다.
/// 스탯 시스템을 도입하는 경우 MaxValue 값을 스탯 값으로 설정하면 된다.
///
/// MinValue가 0이 아니고, 인스펙터 창에서 MaxValue를 MinValue보다 작은 값으로 설정할 경우를 방지하는 코드는 따로 작성하지 않았다.
/// 위 경우는 인스펙터 창에서 값을 입력할 때 확인해야하는 문제이며,
/// 꼭 필요하다면 Awake 이벤트 때 _entity.MaxValue = _entity.MaxValue; 를 적어주면 된다.
/// </summary>
[Serializable]
public class Attribute<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
{
	/* 필드 */
	T _value;
	T _minValue;
	[SerializeField, Min(0)] T _maxValue;

	/* 프로퍼티 */
	public T Value
	{
		get => _value;
		set
		{
			var result = value;

			if (value.CompareTo(_maxValue) > 0)
				result = _maxValue;

			if (value.CompareTo(_minValue) < 0)
				result = _minValue;

			_value = result;

			OnValueUpdated?.Invoke(_value);
		}
	}

	public T MinValue => _minValue;

	public T MaxValue
	{
		get => _maxValue;
		set
		{
			var result = value;

			if (value.CompareTo(_minValue) < 0)
				result = _minValue;

			_maxValue = result;

			OnMaxValueUpdated?.Invoke(_maxValue);
		}
	}

	/* 이벤트 */
	public event Action<T> OnValueUpdated;
	public event Action<T> OnMaxValueUpdated;

	/* 생성자 */
	public Attribute(T minValue)
	{
		_minValue = minValue;
	}

	public Attribute(T minValue, T maxValue)
	{
		_minValue = minValue;
		_maxValue = maxValue;
	}
}
