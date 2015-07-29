using UnityEngine;
using System.Collections;

public class Frame
{
	public Vector3 _position;
	public Vector3 _rotation;
	public float _time;
	public string _message;
	
	public Frame (Vector3 position, Vector3 rotation, float time, string message)
	{
		_position = position;
		_rotation = rotation;
		_time = time;
		_message = message;
	}
}
