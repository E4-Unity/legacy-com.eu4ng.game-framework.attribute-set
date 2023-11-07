using NUnit.Framework;
using UnityEngine;

public class AttributeSetTests
{
    [Test]
    public void HealthTests()
    {
	    var testObject = new GameObject();
	    var attribute = testObject.AddComponent<TestAttributeSet>();

	    Assert.AreEqual(attribute.Health.Value, attribute.Health.MaxValue, "Health 값은 Max Health 값으로 초기화되어야 합니다");
    }

    internal class TestAttributeSet : AttributeSet
    {
	    protected override void TakeDamage(float damage, DamagePayload damagePayload)
	    {

	    }
    }
}
