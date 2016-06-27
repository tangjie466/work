using UnityEngine;
using System.Collections;

public class Role : MonoBehaviour {

	public Transform target;
	public float f_speed;

	private Rigidbody _rig;
	private float _f_distance;
	private Vector3 _V_yAx;

	private bool _b_jump;
	public bool _b_currentState;


	public bool b_jump
	{
		get
		{
			return _b_jump;
		}
		set
		{
			_b_jump = value;
		}
	}
	// Use this for initialization
	void Start () {

		_f_distance = (transform.position - target.position).magnitude;
		_V_yAx = new Vector3(0,-1,0);
		_rig = GetComponent<Rigidbody>() as Rigidbody;
		_b_jump = false;
		_b_currentState = false;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 forward = transform.position - target.position;

		transform.forward = forward;

		transform.RotateAround(target.position,_V_yAx,f_speed*Time.deltaTime);


	}

	void OnCollisionEnter(Collision collision){

		_b_currentState = false;
		_b_jump = false;

	}



	void FixedUpdate()
	{
		
		if(!_b_currentState && _b_jump)
		{
			_rig.AddForce(new Vector3(0,200,0));
			_b_jump = false;
			_b_currentState = true;
		}
	}


}
