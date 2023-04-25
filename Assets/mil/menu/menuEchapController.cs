using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class menuEchapController : MonoBehaviour
{
	public GameObject menuEchap;
	private bool isVisible;
	
    // Start is called before the first frame update
    void Start()
    {
        isVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnEchap()
    {
		isVisible = !isVisible;
		menuEchap.SetActive(isVisible);
		if(isVisible) GetComponent<sceneController>().CurseurOn();
		else GetComponent<sceneController>().CurseurOff();
	}
}
