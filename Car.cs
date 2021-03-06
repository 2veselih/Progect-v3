using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public WheelCollider[] FrontCols;
	public WheelCollider[] BackCols;
	public Transform[] FrontMesh;
	public Transform[] MidlMesh;
	public Transform[] BackMesh;
	public Transform centerOfMass;

	public float maxSpeed = 200f;
	public float sideSpeed = 30f;
	public float breakSpeed = 500f;
	private Sounds sound;

	public int directionInput;
	void Start () {
		GetComponent<Rigidbody> ().centerOfMass = centerOfMass.localPosition;
		sound = gameObject.GetComponent<Sounds> ();
	}
	public void Vpered(){
		
		FrontCols [0].motorTorque =  maxSpeed;
		FrontCols [1].motorTorque =  maxSpeed;
		BackCols [0].motorTorque =  maxSpeed;
		BackCols [1].motorTorque =  maxSpeed;
	
	}
	public void Nazad(){
		FrontCols [0].motorTorque =  -maxSpeed;
		FrontCols [1].motorTorque =  -maxSpeed;
		BackCols [0].motorTorque =  -maxSpeed;
		BackCols [1].motorTorque =  -maxSpeed;

	}

	public void Vlevo(){
		FrontCols [0].steerAngle = sideSpeed;
		FrontCols [1].steerAngle = sideSpeed;
		FrontMesh [0].localEulerAngles = new Vector3 (FrontMesh [0].localEulerAngles.x, -sideSpeed, FrontMesh [0].localEulerAngles.z);
		FrontMesh [1].localEulerAngles = new Vector3 (FrontMesh [1].localEulerAngles.x, -sideSpeed, FrontMesh [1].localEulerAngles.z);
	}
		public void Vpravo(){
	FrontCols [0].steerAngle =-sideSpeed;
	FrontCols [1].steerAngle =-sideSpeed;
		FrontMesh [0].localEulerAngles = new Vector3 (FrontMesh [0].localEulerAngles.x, sideSpeed, FrontMesh [0].localEulerAngles.z);
		FrontMesh [1].localEulerAngles = new Vector3 (FrontMesh [1].localEulerAngles.x, sideSpeed, FrontMesh [1].localEulerAngles.z);
		}
	public void Pryamo(){
		FrontCols [0].steerAngle = 0;
		FrontCols [1].steerAngle = 0;
		FrontMesh [0].localEulerAngles = new Vector3 (FrontMesh [0].localEulerAngles.x, 0, FrontMesh [0].localEulerAngles.z);
		FrontMesh [1].localEulerAngles = new Vector3 (FrontMesh [1].localEulerAngles.x, 0, FrontMesh [1].localEulerAngles.z);
	}

	public void Probel(){
			FrontCols [0].brakeTorque = Mathf.Abs (FrontCols [0].motorTorque) * breakSpeed;
			FrontCols [1].brakeTorque = Mathf.Abs (FrontCols [1].motorTorque) * breakSpeed;
			BackCols [0].brakeTorque = Mathf.Abs (FrontCols [0].motorTorque) * breakSpeed;
			BackCols [1].brakeTorque = Mathf.Abs (FrontCols [1].motorTorque) * breakSpeed;
			} 
	public void Probeloff(){
		FrontCols [0].brakeTorque = 0;
		FrontCols [1].brakeTorque = 0;
		BackCols [0].brakeTorque = 0;
		BackCols [1].brakeTorque =0;
	} 
	public void ToMenu(){
		Application.LoadLevel (0);
	}




	public void FixedUpdate() {

		FrontMesh [0].Rotate (0, FrontCols [0].rpm * Time.deltaTime * 0.01f, 0);
		FrontMesh [1].Rotate (0, -FrontCols [1].rpm * Time.deltaTime * 0.01f, 0);
		MidlMesh [0].Rotate (0, FrontCols [0].rpm * Time.deltaTime * 0.01f, 0);
		MidlMesh [1].Rotate (0, -FrontCols [1].rpm * Time.deltaTime * 0.01f, 0);
		BackMesh [0].Rotate (0, FrontCols [0].rpm * Time.deltaTime * 0.01f, 0);
		BackMesh [1].Rotate (0, -FrontCols [1].rpm * Time.deltaTime * 0.01f, 0);
	}
		

	}

