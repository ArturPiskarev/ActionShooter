using UnityEngine;
using  Shooter;
using Shooter.Interface;

public class Box : BaseObjectScene,ISetDamage
{

    [SerializeField] private float _hp = 100;
    private bool _isDead = false;
    private float _step = 0.005f;
	
	private void Update () {
	    if (_isDead)
	    {
	        Color color = GetMaterial.color;
	        if (color.a > 0)
	        {
	            color.a -= _step;
	            Color = color;
	        }

	        if (color.a < 1)
	        {
	            Destroy(GetGameObject,5);
	        }
	    }
	}

    public void ApplyDamage(float damage)
    {
        if (_hp >= 0)
        {
            _hp -= damage;
        }
        if (_hp <= 0)
        {
            _hp = 0;
            Color = Color.red;
            _isDead = true;
        }
    }
}
