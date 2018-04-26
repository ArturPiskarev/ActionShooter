using Shooter.Interface;
using UnityEngine;
using UnityEngine.UI;

public class SetDamagePlayerController : MonoBehaviour, ISetDamage
{
    [SerializeField] public float _hp;
    [SerializeField] private Text _textDeath;
    [SerializeField] private Image _imageDeath;
    private float _maxHp;
    private bool _isDeath;

    public bool IsDeath
    {
        get { return _isDeath; }
        set { _isDeath = value; } 
    }

    public void ApplyDamage(float damage)
    {
        if (_hp > 0)
        {
            _hp -= damage; 
        }
        else if(_hp<0)
        {
            _hp = 0;
            _isDeath = true;
            _textDeath.gameObject.SetActive(true);
            _imageDeath.gameObject.SetActive(true);
            
        }
    }

    public float GetCurrentHpForUI()
    {
        return _hp / _maxHp;
    }

    void Start()
    {
        _maxHp = _hp;
    }
}
