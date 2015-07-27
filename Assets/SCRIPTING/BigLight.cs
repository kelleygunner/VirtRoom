using UnityEngine;
using System.Collections;

public class BigLight : MonoBehaviour 
{
	RaycastHit hit;
	Ray ray;
	
	public Light BIG_LIGHT;
	public Light LL_LIGHT;
	
	public Transform BUTTON;
	
	public static bool isSwitchOn=true;
	
	void Start () 
	{
		isSwitchOn = true;
		BIG_LIGHT.enabled=true;
		LL_LIGHT.enabled=false;
		BUTTON.localRotation = Quaternion.Euler(Vector3.right*83);
	}
	

	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray,out hit))
			{
				if (hit.collider.gameObject.name=="BLSwitch")
				{
					isSwitchOn=!isSwitchOn;
					BIG_LIGHT.enabled = isSwitchOn;
					LL_LIGHT.enabled = !isSwitchOn;
					if (isSwitchOn)BUTTON.localRotation = Quaternion.Euler(Vector3.right*83);
					else BUTTON.localRotation = Quaternion.Euler(Vector3.right*-83);
				}
			}
			
		}
		
	}
}
