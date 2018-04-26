using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIHp : MonoBehaviour
{
    [Inject] private SetDamagePlayerController _setDamagePlayerController;

    public Image _curentHp;


	void Update () {
	    _curentHp.rectTransform.localScale = new Vector3(_setDamagePlayerController.GetCurrentHpForUI(), 1, 1);
    }
}
