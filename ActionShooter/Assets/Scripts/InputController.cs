using Shooter.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController :BaseController
{
    private bool _isActiveLight;
    private bool _isActiveWeaponZero;
    private bool _isActiveWeaponOne;

    private GameObject _damageController;
    void Start ()
    {
        _damageController = GameObject.FindGameObjectWithTag("Player");
    }
	
	
	void Update () {
	    if (Input.GetKeyDown(KeyCode.F))
	    {
	        _isActiveLight = !_isActiveLight;
	        if (_isActiveLight)
	        {
	            Main.Instance.GetFlashLightController.On();
	        }
	        else
	        {
                Main.Instance.GetFlashLightController.Off();
            }
	    }
	    if (Input.GetKeyDown(KeyCode.Alpha1))
	    {
	        _isActiveWeaponZero = !_isActiveWeaponZero;
	        if (_isActiveWeaponZero)  
	        {

	            SetWeapons(0);
	        }
	        else
	        {
                SetWeaponsOff();
	        }
	    }
	    else if(Input.GetKeyDown(KeyCode.Alpha2)) 
	    {
	        _isActiveWeaponOne = !_isActiveWeaponOne;
	        if (_isActiveWeaponOne)
	        {
                SetWeapons(1);
	        }
	        else
	        {
	            SetWeaponsOff();
	        }
        }
	        if (Input.GetKeyDown(KeyCode.Alpha8))
	        {
	            if (_damageController.GetComponent<SetDamagePlayerController>().IsDeath)
	            {
	                SceneManager.LoadScene("MainGame");
	            }
	        }
	}

    private void SetWeapons(int i)
    {
       // Main.Instance.GetWeaponController.Off();  
       var tempWeapones = Main.Instance.GetObjectManager.GetWeaponses[i];
        if (tempWeapones)
        {
            Main.Instance.GetWeaponController.On(tempWeapones, Main.Instance.GetObjectManager.GetAmmunitions[i]);
            if (i == 0)
            {
                _isActiveWeaponZero = true;
            }
            else
            {
                _isActiveWeaponOne = true;
            }
        }
    }
    private void SetWeaponsOff()
    {
        Main.Instance.GetWeaponController.Off();
        
    }
}
