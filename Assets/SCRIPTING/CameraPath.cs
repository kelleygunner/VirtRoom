using UnityEngine;
using System.Collections;

public class CameraPath : MonoBehaviour 
{
	
	public GUIStyle txtStyle;
	
	Frame[] FRAMES = new Frame[6]
	{
		#region Ключевые точки
		new Frame(new Vector3(0,0,-10),new Vector3(20,0,0),5,"Добро Пожаловать в \'Виртуальную Комнату\'!"),
		new Frame(new Vector3(-0.5f,0.5f,-1.3f),new Vector3(10,18,0),5,"Для включения/выключения щелкните мышью по выключателю."),
		new Frame(new Vector3(-2.9f,-1.0f,-3.5f),new Vector3(18f,1.0f,0),4,"Чтобы покинуть комнату нажмите на ключ."),
		new Frame(new Vector3(0.5f,-2.5f,-11),new Vector3(10,0,0),5,"Управляйте стойками и лампой с помощью мыши."),
		new Frame(new Vector3(-1.31f,-5.42f,-5.3f),new Vector3(33.2f,36.1f,0),4,"Кликните мышью по кнопке, чтобы включить/отключить светильник."),
		new Frame(new Vector3(0.0f,-2.5f,-12),new Vector3(10,0,0),3,"by Ivanov Anatoly")
		#endregion
	};
	
	Vector3 TargetPosition;
	Vector3 TargetRotation;
	Vector3 ROTATION=Vector3.zero;
	string TargetMessage;
	
	int FRAME_CURRENT=0;
	int FRAME_TOTAL=0;
	
	Transform cam;	
	
	//Регулируем резкость камеры
	[Range(0.01f,0.05f)]
	public float move_speed=0.02f;
	[Range(0.02f,0.07f)]
	public float rotate_speed=0.05f;

	void Start () 
	{
		cam = Camera.main.transform;	
		
		FRAME_TOTAL = FRAMES.Length;
		
		StartCoroutine(MoveCamera());

		txtStyle.fontSize = (int)(Screen.height*0.04f);
	}
	
	
	IEnumerator MoveCamera()
	{
		for (FRAME_CURRENT=0; FRAME_CURRENT<FRAME_TOTAL; FRAME_CURRENT++)
		{
			TargetMessage = FRAMES[FRAME_CURRENT]._message;
			TargetPosition = FRAMES[FRAME_CURRENT]._position;
			TargetRotation = FRAMES[FRAME_CURRENT]._rotation;
			yield return new WaitForSeconds (FRAMES[FRAME_CURRENT]._time);
		}
	}
	
	void Update () 
	{
		//обновим позишн
		cam.position += (TargetPosition-cam.position)*move_speed;
		//обновим угол
		ROTATION += (TargetRotation-cam.eulerAngles)*rotate_speed;		
		cam.rotation = Quaternion.Euler( ROTATION );
	}
	
	void OnGUI()
	{
		if (FRAME_CURRENT<FRAME_TOTAL) GUI.Label ( new Rect(Screen.width*0.2f,Screen.height*0.7f,Screen.width*0.6f,Screen.height*0.2f),TargetMessage,txtStyle);
	}
}
