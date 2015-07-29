using UnityEngine;
using System.Collections;

public class KeyExit : MonoBehaviour 
{
	RaycastHit hit;
	Ray ray;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray,out hit))
			{
				if (hit.collider.gameObject.name==this.gameObject.name)
				{
					Application.Quit();
				}
			}
			
		}
	}
}
