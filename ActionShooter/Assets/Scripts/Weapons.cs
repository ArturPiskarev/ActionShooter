using Shooter;
using UnityEngine;

public abstract class Weapons : BaseObjectScene
{
    [SerializeField]protected Transform _barrel;
    [SerializeField] protected float _force = 500f;
    [SerializeField] protected float _rechargeTime = 0.2f;

    protected Timer _timer=new Timer();

    protected bool _fire = true;

    public abstract void Fire(Ammunition amun);

    private void Update()
    {
        _timer.Update();
        if (_timer.IsEvent())
        {
            _fire = true;
        }
    }
}
