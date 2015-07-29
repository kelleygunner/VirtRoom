using UnityEngine;
using System.Collections;

public class LampControl : MonoBehaviour 
{
	
	#region parts & lights
	public Transform SHTAT1;
	public Transform SHTAT2;
	public Transform LAMP;	
	public Transform UPOR1;
	public Transform UPOR2;
	public Light LIG1;
	public Light LIG2;
	
	public GameObject SWICH_BUTTON;
	
	Transform ObjControlled = null;
	int PartNumber = -1;
	#endregion
	
	RaycastHit hit;
	Ray ray;
	
	float mouse_y_pos=0;
	
	string[] LampPartNames;
	
	float[,] part_turn_options = new float[,]{{310,100},{50,40},{330,50}}; //средний угол; максимальное отклонение от среднего угла;
	
	float speed = 1;
	
	void Start () 
	{
		LampPartNames = new string[]{LAMP.gameObject.name, SHTAT1.gameObject.name, SHTAT2.gameObject.name};
		
		speed = 10.0f/Screen.height; //установим зависимость скорости от высоты экрана
	}	
	
	
	void Update () 
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray,out hit))
			{
				int index = System.Array.IndexOf(LampPartNames,hit.collider.gameObject.name);

				if (index!=-1)
				{
					ObjControlled = hit.collider.transform;
					PartNumber=index;
					mouse_y_pos = Input.mousePosition.y;
				}
				
				if (hit.collider.gameObject.name==SWICH_BUTTON.name)
				{
					LIG1.enabled = !LIG1.enabled;
					LIG2.enabled = !LIG2.enabled;
				}
			}
			
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			ObjControlled = null;
			PartNumber=-1;
		}
		
		if (PartNumber>-1)MoveLampPart();
		
	}
	
	void MoveLampPart ()
	{
		//
		if ( 
			Mathf.DeltaAngle(part_turn_options[PartNumber,0],ObjControlled.transform.localRotation.eulerAngles.z)//расчитываем отклонение
			* Mathf.Sign(mouse_y_pos - Input.mousePosition.y)//меняем знак в зависимости от напрвления движения по экрану
			< part_turn_options[PartNumber,1] //сравниваем с максимальным отклонением
			)
			ObjControlled.transform.Rotate(Vector3.forward* (mouse_y_pos - Input.mousePosition.y)*speed );
		
		if (PartNumber==1)
		{
			//Нижеследующие формулы получены путем проеобразований вычислений равных углов
			//равнобедренного треугольника. Длина упоров равна => углы между упорами и штативами
			//одинаковы и равны (180 - угол между штативами) => каждый из них равен половине этого значения
			
			UPOR1.localRotation =  Quaternion.Euler( Vector3.forward*( 0 - SHTAT1.localRotation.eulerAngles.z/2)*-1);
			UPOR2.localRotation = Quaternion.Euler( Vector3.forward* ( (180 - SHTAT1.localRotation.eulerAngles.z/2)));
		}
		
	}

}
