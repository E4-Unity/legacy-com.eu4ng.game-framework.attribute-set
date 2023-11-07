# Attribute Set

## 특성(Attribute)
- 캐릭터의 상태를 나타내는 요소 중 하나로 특정 행동을 하기 위한 자원(Cost)이나 조건 등으로 사용된다
- 특성 값(Value)은 최소값(MinValue) 이상 최대값(MaxValue) 이하의 값을 갖는다
- 특성 값과 최대값이 변할 때마다 호출되는 이벤트가 정의되어 있다
  - OnValueUpdated
  - OnMaxValueUpdated

## 특성 집합(AttributeSet)
- 필요에 따라 여러 특성들이 정의되는 추상 컴포넌트이다.
  - 예시 : 마나, 기력 등
- 체력(Health)과 죽음(IsDead)이 기본적으로 정의되어 있다.
  - 체력
    - 특성
    - 0이 되는 순간 OnDied 이벤트 호출
  - 죽음
    - 체력 값이 0이면 true를 반환하는 bool 프로퍼티
- IDamageable 인터페이스 구현
- 추상 메서드 TakeDamage
  - IDamageable.ApplyDamage에서 호출되며, 자손 클래스에서 데미지 계산식을 작성하는 곳이다

## 데미지(Damage)
- 피격 대상의 체력을 감소시키는 기본값이다
- IDamageable 인터페이스를 사용한다

## 데미지 페이로드(Damage Payload)
- IDamageable 인터페이스의 매개 변수로 사용된다
- 데미지 타입, 공격 주체, 공격 방향 등 데미지와 관련된 추가 정보가 필요한 경우 자손 클래스를 생성하여 전달한다.