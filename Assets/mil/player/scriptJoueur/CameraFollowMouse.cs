using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollowMouse : MonoBehaviour
{   
    public GameObject player;
    public GameObject orientation;

    [Range(0.1f,1.0f)]
    public static float speed = 0.5f;

    private float mouseAngleX = 0f;
    private float mouseAngleY = 0f;

    private Vector2 sourisAngle;
    
    //camera
    public GameObject cameraTPS;
    public GameObject cameraFPS;

	void Start()
	{
		
	}
    void Update()
    {
         mouseAngleX += sourisAngle.x * speed;
         mouseAngleY += sourisAngle.y * speed;
         mouseAngleY = Mathf.Clamp(mouseAngleY,-20,45); // recadre entre -45 et 45 la rotation
		
		// applique la rotation vertical à la camera selon la position vertical de la souris
        cameraTPS.transform.localEulerAngles = new Vector3(-mouseAngleY,0,transform.localEulerAngles.z);
        cameraFPS.transform.localEulerAngles = new Vector3(-mouseAngleY,0,transform.localEulerAngles.z);

		// applique la rotation horizontal au mesh 3D du joueur selon la position horizontal de la souris
        player.transform.localEulerAngles = new Vector3(0,mouseAngleX,player.transform.localEulerAngles.z);
        
        orientation.transform.position = player.transform.position;
        orientation.transform.rotation = Quaternion.Euler(-mouseAngleY, mouseAngleX, 0);
        cameraTPS.transform.rotation = Quaternion.Euler(-mouseAngleY, mouseAngleX, 0);
        cameraFPS.transform.rotation = Quaternion.Euler(-mouseAngleY, mouseAngleX, 0);
    }
    
    void OnSouris(InputValue val)
    {   
        sourisAngle = val.Get<Vector2>();
    }
    
   
}

