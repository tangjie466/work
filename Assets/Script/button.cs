using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

	public Camera myCamera;
	private SpriteRenderer render;

	private bool _b_curState;
	private bool _b_lastState;

	public  Role role;

	// Use this for initialization
	void Start () {
		_b_curState = false;
		_b_lastState = false;
		float cameraHeight = myCamera.orthographicSize * 100;
		float aspectRatio = Screen.width * 1.0f / Screen.height;
		float cameraWidth = cameraHeight * aspectRatio  ;

		float scale = (2.0f*cameraHeight) / Screen.height;

		float offsetX = 75.0f * scale;
		float offsetY = 70.0f * scale;

		float x = (cameraWidth - offsetX)/100.0f;
		float y = (cameraHeight - offsetY)/100.0f;

		transform.position = new Vector3(x,y,transform.position.z);
		render = GetComponent<SpriteRenderer>() as SpriteRenderer;

		Debug.Log("pos x is "+x+",y is "+y);

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0))
		{
			
			RaycastHit hit ;


			if(Physics.Raycast(myCamera.ScreenPointToRay(Input.mousePosition),200,1<<LayerMask.NameToLayer("button")))
			{
				Debug.Log("button down");	
				_b_curState = true;
				if(!role.b_jump)
				{
					role.b_jump = true;
				}
			}
			else
			{
				_b_curState = false;
			}

		}
		else
		{
			_b_curState = false;
		}

		if(_b_curState != _b_lastState)
		{
			_b_lastState = _b_curState;
			if(_b_curState){
	
				render.color = Color.black;
			}
			else
			{
				render.color = Color.red;
			}

		}

	}
}
