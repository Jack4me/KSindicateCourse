using Logic;
using UnityEngine;

namespace UI.Elements
{
  public class ActorUI : MonoBehaviour
  {
    public HpBar HpBar;

    private IHealth _health;

    private void Start()
    {
      IHealth health = GetComponent<IHealth>();
      
      if(health != null)
        SetHp(health);
    }

    public void SetHp(IHealth health)
    {
      _health = health;
      _health.HealthChanged += UpdateHpBar;
    }

    private void UpdateHpBar()
    {
      HpBar.SetValue(_health.CurrentHp, _health.MaxHp);
    }

    private void OnDestroy()
    {
      if (_health != null)
        _health.HealthChanged -= UpdateHpBar;
    }
  }
}