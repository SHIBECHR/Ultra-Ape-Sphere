using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
	public GameObject player1;
	public float CameraDistanceOnZ = -3f;
	public float CameraHeight = 1f;

	public float mouseSpeed = 3;
	public Transform player;
	public Camera yourCam;
	public Camera Above;

	public float turnspeed = 10;

	public Transform to;
	public Transform from;
	public float speed = 1;

	public GameObject parent;
	public GameObject child;
	public DetectCollision barrier;
	public GameObject StartCube;

	Vector3 posSpawn;

	//float t = 0.0f;
	float t2 = 0.0f;
	float t3 = 0.0f;
	float t4 = 0.0f;
	float t5 = 0.0f;
	public float t2_total = 0.0f;
	public float t3_total = 0.0f;
	public float t4_total = 0.0f;
	public float t5_total = 0.0f;


	public bool RotateW;

	
	private void FixedUpdate()
	{
		float X = Input.GetAxis("Mouse X") * mouseSpeed;
		float Y = Input.GetAxis("Mouse Y") * mouseSpeed;

		parent.transform.RotateAround(player.transform.position, Vector3.up, -X); // Player rotates on Y axis, your Cam is child, then rotates too

		//to.transform.Rotate(0, X, 0); // Player rotates on Y axis, your Cam is child, then rotates too
		player.transform.Rotate(-Y / 100f, 0, 0);

		// To scurity check to not rotate 360º 
		if (yourCam.transform.eulerAngles.x + (-Y) > 80 && yourCam.transform.eulerAngles.x + (-Y) < 280)
		{

		}
		else
		{
			yourCam.transform.RotateAround(player.position, yourCam.transform.right, -Y);
		}
	}

	void Update()
	{
		Vector3 pos = player1.transform.position;
		pos.z += CameraDistanceOnZ;
		transform.position = pos;
		pos.y += CameraHeight;
		transform.position = pos;
		//Tilter();
		TilterV2();
		CameraSwitch();
		//posSpawn = StartCube.transform.position;
	}
	void Start()
	{
		yourCam.enabled = true;
		Above.enabled = false;
		//player1.transform.position = posSpawn;
	}
	//experimental code from when hope still resided within
	// On key release, resets rotation slowly
	//public void Tilter()
	//{
	//	if (Input.GetKey(KeyCode.W))
	//	{
	//		t = 0.0f;
	//	}
	//	else
	//	{
	//		t += Time.deltaTime * speed;
	//	}

	//	//child.transform.localRotation = Quaternion.Lerp(child.transform.localRotation, to.rotation, t); want to use this. feels easier
	//	//child.transform.RotateAround(player.transform.position, Vector3.right, -t2);

	//	/*
 //       Quaternion src = child.transform.rotation;
 //       Quaternion dst = src * Quaternion.AngleAxis(angle: 15f, axis: player.transform.right);   this makes it rotate around witout doing much
 //       child.transform.rotation = Quaternion.Slerp(src, dst, t);
 //       */
	//	//Vector3 pivot = player.transform.position;
	//	//Vector3 axis = player.transform.right;
	//	//Vector3 src = child.transform.position;
	//	//Vector3 dst = pivot + Quaternion.AngleAxis(1f, axis) * (src - pivot);  //so does this
	//	//child.transform.position = Vector3.Lerp(src, dst, t);
	//}

	public void CameraSwitch()//switches between cameras, essentailly a map mode to help get bearings
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			yourCam.enabled = false;
			Above.enabled = true;
		}
		if (Input.GetKeyUp(KeyCode.C))
		{
			yourCam.enabled = true;
			Above.enabled = false;
		}
	}

	// On key press, tilts the maze
	public void TilterV2()
	{

		if (Input.GetKey(KeyCode.W))
		{
			RotateW = true;
			t2 = 0.1f;

			if (!barrier.hit)
			{
				t2_total += t2;
				child.transform.RotateAround(player.transform.position, Vector3.right, t2);
			}

		}
		if (Input.GetKey(KeyCode.S))
		{
			t3 = 0.1f;
			if (!barrier.hit)
			{
				child.transform.RotateAround(player.transform.position, Vector3.left, t3);
			}
		}

		if (Input.GetKey(KeyCode.D))
		{
			t4 = 0.1f;
			if (!barrier.hit)
			{
				child.transform.RotateAround(player.transform.position, Vector3.back, t4);
			}
		}
		if (Input.GetKey(KeyCode.A))
		{
			t5 = 0.1f;
			if (!barrier.hit)
			{
				child.transform.RotateAround(player.transform.position, Vector3.forward, t5);
			}
		}

		//experimental code from when i still had dreams
		//      else
		//{
		//          RotateW = true;
		//          t2 = 0.05f;

		//          if (t2_total > 0)
		//          {
		//              t2_total -= t2;
		//              child.transform.RotateAround(player.transform.position, Vector3.right, -t2);
		//          }


		//      }

		//      else if (Input.GetKeyUp(KeyCode.W))
		//{
		//          RotateW = true;
		//      }
		//      if (child.transform.rotation.y > 0 || child.transform.rotation.x > 0 || child.transform.rotation.z > 0|| child.transform.rotation.y < 0 || child.transform.rotation.x < 0 || child.transform.rotation.z < 0)
		//      {
		//          RotateW = false;
		//          t2 = 0.05f;
		//          if(RotateW == true)
		//	{
		//              child.transform.RotateAround(player.transform.position, Vector3.left, t2);
		//	}




		//      }





		//else
		//{
		//    RotateW = true;
		//    t3 = 0.05f;

		//    if (t3_total > 0)
		//    {
		//        t3_total -= t3;
		//        child.transform.RotateAround(player.transform.position, Vector3.left, -t3);
		//    }
		//    t3 = 0.0f;
		//}


		//else
		//{
		//    RotateW = true;
		//    t4 = 0.05f;

		//    if (t4_total > 0)
		//    {
		//        t4_total -= t4;
		//        child.transform.RotateAround(player.transform.position, Vector3.back, -t4);
		//    }
		//    t4 = 0.0f;
		//}

		//if (Input.GetKey(KeyCode.A))
		//{
		//	t5 = 0.05f;
		//	if (!barrier.hit)
		//	{
		//		child.transform.RotateAround(player.transform.position, Vector3.forward, t5);
		//	}
			//}
			//else
			//{
			//    RotateW = true;
			//    t5 = 0.05f;

			//    if (t5_total > 0)
			//    {
			//        t5_total -= t5;
			//        child.transform.RotateAround(player.transform.position, Vector3.forward, -t5);
			//    }
			//    t5 = 0.0f;
			//}
			/*
			else if (Input.GetKeyUp(KeyCode.A))
			{
				t2 = -0.05f;
				if (child.transform.rotation.y != 0 && child.transform.rotation.x != 0 && child.transform.rotation.z != 0)
				{
					child.transform.RotateAround(player.transform.position, Vector3.forward, t2);
				}

			}
			else if (Input.GetKeyUp(KeyCode.S))
			{
				t2 = -0.05f;
				if (child.transform.rotation.y != 0 && child.transform.rotation.x != 0 && child.transform.rotation.z != 0)
				{
					child.transform.RotateAround(player.transform.position, Vector3.left, t2);
				}

			}
			else if (Input.GetKeyUp(KeyCode.D))
			{
				t2 = -0.05f;
				if (child.transform.rotation.y != 0 && child.transform.rotation.x != 0 && child.transform.rotation.z != 0)
				{
					child.transform.RotateAround(player.transform.position, Vector3.back, t2);
				}

			}
			*/





			// print(child.GetComponent<Rigidbody>().velocity);

	}



	
}
