using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundedDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
    }
    
    void FixedUpdate()
    {
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit,0.3f)) 
		{
			Debug.Log(hit.transform.name);
			if (hit.transform.gameObject.isStatic) 
			{
				GetComponent<movePlayer>().GroundedSet(true);
			} 
			else 
			{
				GetComponent<movePlayer>().GroundedSet(false);
			}
		}
	}

}
