using UnityEngine;
using System.Collections;

public class CameraPath : MonoBehaviour 
{
	
	public GUIStyle txtStyle;
	
	Vector3[] POSITIONS = new Vector3[]
	{
		new Vector3(0,0,-10),
		new Vector3(-0.5f,0.5f,-1.3f),
		new Vector3(-2.9f,-1.0f,-3.5f),
		new Vector3(0.5f,-2.5f,-11),
		new Vector3(-1.31f,-5.42f,-5.3f),
		new Vector3(0.0f,-2.5f,-12)
		
	};
	
	Vector3[] ROTATION = new Vector3[]
	{
		new Vector3(20,0,0),
		new Vector3(10,18,0),
		new Vector3(18f,1.0f,0),
		new Vector3(10,0,0),
		new Vector3(33.2f,36.1f,0),
		new Vector3(10,0,0)
	};
	
	float[] TIMES = new float[]
	{
		5.0f,
		5.0f,
		5.0f,
		5.0f,
		4.0f,
		3.0f
	};
	
	Vector3 ROT=Vector3.zero;
	
	int FRAME_CURRENT=0;
	int FRAME_TOTAL=0;
	
	float TIMER=0;
	
	void Start () 
	{
		FRAME_TOTAL = POSITIONS.Length;
		ROT = this.transform.rotation.eulerAngles;
		
		txtStyle.fontSize = (int)(Screen.height*0.04f);
	}
	
	
	void Update () 
	{
		if (FRAME_CURRENT<FRAME_TOTAL)
		{
			
			TIMER += Time.deltaTime;
					
			this.transform.position += (POSITIONS[FRAME_CURRENT]-this.transform.position)*0.05f*(TIMER/TIMES[FRAME_CURRENT])*(Time.deltaTime*50);
			
			ROT += (ROTATION[FRAME_CURRENT]-this.transform.rotation.eulerAngles)*0.05f*(Time.deltaTime*50);
				
			this.transform.rotation = Quaternion.Euler( ROT );
			
			if (TIMER>=TIMES[FRAME_CURRENT]){FRAME_CURRENT++; TIMER=0;}
		}
	}
	
	void OnGUI()
	{
		if (FRAME_CURRENT==0)
			GUI.Label ( new Rect(Screen.width*0.2f,Screen.height*0.7f,Screen.width*0.6f,Screen.height*0.2f),
				"Добро Пожаловать в \'Виртуальную Комнату\'!",txtStyle);
		
		if (FRAME_CURRENT==1)
			GUI.Label ( new Rect(Screen.width*0.2f,Screen.height*0.7f,Screen.width*0.6f,Screen.height*0.2f),
				"Для включения/выключения щелкните мышью по выключателю.",txtStyle);
		
		if (FRAME_CURRENT==2)
			GUI.Label ( new Rect(Screen.width*0.2f,Screen.height*0.7f,Screen.width*0.6f,Screen.height*0.2f),
				"Чтобы покинуть комнату нажмите на ключ.",txtStyle);
		if (FRAME_CURRENT==3)
			GUI.Label ( new Rect(Screen.width*0.2f,Screen.height*0.7f,Screen.width*0.6f,Screen.height*0.2f),
				"Управляйте стойками и лампой с помощью мыши.",txtStyle);
		if (FRAME_CURRENT==4)
			GUI.Label ( new Rect(Screen.width*0.2f,Screen.height*0.7f,Screen.width*0.6f,Screen.height*0.2f),
				"Кликните мышью по кнопке, чтобы включить/отключить светильник.",txtStyle);
			
	}
}
