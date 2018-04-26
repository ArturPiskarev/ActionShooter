using UnityEngine;
using UnityEngine.UI;

public class UILight : MonoBehaviour
{
    public Image img;

	private void Start ()
	{
       
    }
	
	
	private void Update () {
       

        //_current = Main.Instance.GetFlashLightController.TimeEnter / Main.Instance.GetFlashLightController.TimeLighting;
	    
        
        img.rectTransform.localScale = new Vector3(Main.Instance.GetFlashLightController.Current(), 1, 1);
        
    }

}
