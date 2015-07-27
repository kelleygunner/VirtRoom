using UnityEngine;
using System.Collections;

public class LoadingScene : MonoBehaviour 
{
	
	private AsyncOperation async = null;
	float persantage = 0;
	
	public GUIStyle txtStyle;
	
	void Start () 
	{
		txtStyle.fontSize=(int)(Screen.height*0.04f);
		StartCoroutine("_Start");
	}
	
	
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width*0.5f,Screen.height*0.5f,0,0),"LOADING: "+persantage.ToString("n"),txtStyle);
	}
	
	private IEnumerator _Start()
	{
		async = Application.LoadLevelAsync("room");
		
		while( !async.isDone )
		{
			persantage = async.progress;
			yield return null;
		}		
		yield return async;
		
	}
}
