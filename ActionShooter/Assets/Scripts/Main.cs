using Shooter.Controller;
using UnityEngine;

public class Main : MonoBehaviour {

	public static Main Instance { get; private set; }

    public InputController GetInputController
    {
        get { return _inputController; }
    }
    public SetDamagePlayerController GetDamagePlayerController
    {
        get { return _damagePlayerController; }
    }

    public FlashLightController GetFlashLightController
    {
        get { return _flashLightController; }
    }

    public WeaponController GetWeaponController
    {
        get { return _weaponController; }
    }

    public ObjectManager GetObjectManager
    {
        get { return _objectManager; }
    }

    public BotController GetBotController
    {
        get { return _botController; }
    }

    private GameObject _controllers;
    private InputController _inputController;
    private FlashLightController _flashLightController;
    private WeaponController _weaponController;
    private ObjectManager _objectManager;
    private BotController _botController;
    private SetDamagePlayerController _damagePlayerController;
	private void Start ()
	{
	    Instance = this;
        _controllers=new GameObject("AllControlers");
	    _inputController = _controllers.AddComponent<InputController>();
	    _flashLightController = _controllers.AddComponent<FlashLightController>();
        _weaponController = _controllers.AddComponent<WeaponController>();
	    _objectManager = GetComponent<ObjectManager>();
	    _botController = _controllers.AddComponent<BotController>();
	    _damagePlayerController = _controllers.AddComponent<SetDamagePlayerController>();
        DontDestroyOnLoad(gameObject);

	}
	public enum MyEnum
	{
	    LeftButton,
        RightButton,
        CenterButton
	}
	
	
}
