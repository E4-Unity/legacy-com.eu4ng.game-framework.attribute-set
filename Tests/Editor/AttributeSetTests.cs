using NUnit.Framework;
using UnityEngine;

public class AttributeSetTests
{
    [Test]
    public void HealthTests()
    {
	    var testObject = new GameObject();
	    var attribute = testObject.AddComponent<TestAttributeSet>();

	    attribute.Health.OnValueUpdated += delegate(float health)
	    {
		    Assert.AreEqual(health, attribute.Health.Value, "OnValueUpdated에서 출력되는 값이 Health 값과 다릅니다.");

		    if(health < attribute.Health.MinValue || health > attribute.Health.MaxValue)
			    Assert.Fail("Health 값이 범위를 벗어났습니다.");

		    if (Mathf.Approximately(health, 0))
			    Assert.True(attribute.IsDead, "Health 값이 0이면 IsDead = true여야 합니다");
		    else
			    Assert.False(attribute.IsDead, "Health 값이 0이 아니라면 IsDead = false여야 합니다");
	    };

	    attribute.Health.OnMaxValueUpdated += delegate(float maxHealth)
	    {
		    Assert.AreEqual(maxHealth, attribute.Health.MaxValue, "OnMaxValueUpdated에서 출력되는 값이 MaxHealth 값과 다릅니다.");

		    if(maxHealth < attribute.Health.MinValue)
			    Assert.Fail("MaxHealth 값이 범위를 벗어났습니다.");
	    };

	    attribute.OnDied += delegate
	    {
		    Assert.True(attribute.IsDead, "IsDead == true일 때만 OnDied 이벤트가 호출됩니다.");
	    };

	    attribute.Health.Value = float.MinValue;
	    attribute.Health.Value = float.MaxValue;
	    attribute.Health.MaxValue = float.MinValue;
	    attribute.Health.MaxValue = float.MaxValue;

	    for (int i = 0; i < 10000; i++)
	    {
		    var testValue = Random.Range(attribute.Health.MinValue, attribute.Health.MinValue);
		    attribute.Health.Value = testValue;
		    attribute.Health.MaxValue = testValue;
	    }
    }

    internal class TestAttributeSet : AttributeSet
    {
	    protected override void TakeDamage(float damage, DamagePayload damagePayload)
	    {

	    }
    }
}
