using UnityEngine;
using System.Collections;

public class BigLight : MonoBehaviour 
{
	RaycastHit hit;
	Ray ray;
	
	public Light BIG_LIGHT; //верхний свет
	public Light LL_LIGHT; //лампочка на выключателе
	
	public Transform BUTTON; //клавиша переключателя
	
	float button_angle = 80; //угол поворота клавиши выключателя
	
	
	
	void Start () 
	{
		BIG_LIGHT.enabled=true;
		LL_LIGHT.enabled=false;
		BUTTON.localRotation = Quaternion.Euler(Vector3.right*button_angle);
	}
	

	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray,out hit))
			{
				if (hit.collider.gameObject.name==BUTTON.gameObject.name)
				{
					BIG_LIGHT.enabled = !BIG_LIGHT.enabled;
					LL_LIGHT.enabled = !LL_LIGHT.enabled;
					
					if (BIG_LIGHT.enabled)BUTTON.localRotation = Quaternion.Euler(Vector3.right*button_angle);
					else BUTTON.localRotation = Quaternion.Euler(Vector3.right*-1*button_angle);
				}
			}
			
		}
		
	}
}
