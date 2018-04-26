using Shooter;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

	[SerializeField] private Weapons[] _weaponses=new Weapons[5];
    [SerializeField] private Ammunition[] _ammunitions = new Ammunition[5];

    public Weapons[] GetWeaponses
    {
        get { return _weaponses; }
    }

    public Ammunition[] GetAmmunitions
    {
        get { return _ammunitions; }
    }
}
