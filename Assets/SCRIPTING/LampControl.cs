using UnityEngine;
using System.Collections;

public class LampControl : MonoBehaviour 
{
	
	public Transform SHTAT1;
	public Transform SHTAT2;
	public Transform LAMP;
	
	public Transform UPOR1;
	public Transform UPOR2;
	
	public Light LIG1;
	public Light LIG2;
	
	bool isShtat1Control=false;
	bool isShtat2Control=false;
	bool isLampControl=false;
	
	RaycastHit hit;
	Ray ray;
	
	float mouse_y_pos=0;
	
	void Start () 
	{
		LIG1.enabled = false;
		LIG2.enabled = false;
	}
	
	
	
	void Update () 
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray,out hit))
			{
				if (hit.collider.gameObject.name=="Lamp")
				{
					isLampControl=true;
					mouse_y_pos = Input.mousePosition.y;
				}
				if (hit.collider.gameObject.name=="Shtat1")
				{
					isShtat1Control=true;
					mouse_y_pos = Input.mousePosition.y;
				}
				if (hit.collider.gameObject.name=="Shtat2")
				{
					isShtat2Control=true;
					mouse_y_pos = Input.mousePosition.y;
				}
				
				if (hit.collider.gameObject.name=="Place")
				{
					LIG1.enabled = !LIG1.enabled;
					LIG2.enabled = !LIG2.enabled;
				}
			}
			
		}
		
		
		if (!Input.GetMouseButton(0))
		{
			isLampControl=false;
			isShtat1Control=false;
			isShtat2Control=false;
		}
		
		if (isLampControl)
		{
			
			if (Input.mousePosition.y > mouse_y_pos)
			{
				if (LAMP.transform.localRotation.eulerAngles.z > 260 || LAMP.transform.localRotation.eulerAngles.z < 100 )LAMP.transform.Rotate(Vector3.forward* (mouse_y_pos - Input.mousePosition.y)*0.02f );
			}
			else
			{
				if (LAMP.transform.localRotation.eulerAngles.z < 65 || LAMP.transform.localRotation.eulerAngles.z > 200)LAMP.transform.Rotate(Vector3.forward* (mouse_y_pos - Input.mousePosition.y)*0.02f );
			}
			
		}
		
		
		if (isShtat1Control)
		{
			
			if (Input.mousePosition.y > mouse_y_pos)
			{
				if (SHTAT1.transform.localRotation.eulerAngles.z > 15 )SHTAT1.transform.Rotate(Vector3.forward* (mouse_y_pos - Input.mousePosition.y)*0.02f );
			}
			else
			{
				if (SHTAT1.transform.localRotation.eulerAngles.z < 80 )SHTAT1.transform.Rotate(Vector3.forward* (mouse_y_pos - Input.mousePosition.y)*0.02f );
			}
			
			
			UPOR2.localRotation = Quaternion.Euler( Vector3.forward*(185-SHTAT1.transform.localRotation.eulerAngles.z/2.2f));
			UPOR1.localRotation = Quaternion.Euler( Vector3.forward*(-6+SHTAT1.transform.localRotation.eulerAngles.z/1.5f));
			
		}
		
		if (isShtat2Control)
		{
			
			if (Input.mousePosition.y < mouse_y_pos)
			{
				if (SHTAT2.transform.localRotation.eulerAngles.z > 300 || SHTAT2.transform.localRotation.eulerAngles.z < 100 )SHTAT2.transform.Rotate(Vector3.forward* (mouse_y_pos - Input.mousePosition.y)*-0.02f );
			}
			else
			{
				if (SHTAT2.transform.localRotation.eulerAngles.z < 20 || SHTAT2.transform.localRotation.eulerAngles.z > 200)SHTAT2.transform.Rotate(Vector3.forward* (mouse_y_pos - Input.mousePosition.y)*-0.02f );
			}
			
			Debug.Log(SHTAT2.transform.localRotation.eulerAngles.z.ToString("n"));
			
		}
		
		
	}
}
