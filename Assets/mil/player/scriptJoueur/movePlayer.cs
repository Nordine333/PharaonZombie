using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movePlayer : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    public bool grounded = true;
    
    private Rigidbody rb;
    private Animator animatorPlayer;
    private float AxeX;
    private float AxeY;
    
    private float NextFenetreJump;
    
    private InputAction sprintAction;

    
    // Start is called before the first frame update
    void Start()
    {
		NextFenetreJump = Time.time;
        rb = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector3.back * AxeY * Time.deltaTime);
        transform.Translate(speed * Vector3.right * AxeX * Time.deltaTime);
    }
    
    private void OnEnable()
    {
        sprintAction = GetComponent<PlayerInput>().actions.FindAction("Sprint");
        sprintAction.started += OnSprintStarted;
        sprintAction.canceled += OnSprintCanceled;
        sprintAction.Enable();
    }

    private void OnDisable()
    {
        sprintAction.started -= OnSprintStarted;
        sprintAction.canceled -= OnSprintCanceled;
        sprintAction.Disable();
    }

    
    private void OnSprintStarted(InputAction.CallbackContext context)
    {
		speed = speed * 1.75f;
    }

    private void OnSprintCanceled(InputAction.CallbackContext context)
    {
        speed = 5f;

    }
    

    void OnHorizontal(InputValue val)
    {
        AxeX = val.Get<float>();
        if(AxeX == -1) // va a gauche
        {
			animatorPlayer.SetBool("walkL",true); 
		}
		else if (AxeX == 1) // va a droite
		{
			animatorPlayer.SetBool("walkR",true);
		}
		else // ne va n'y a gauche ni a droite
		{
			animatorPlayer.SetBool("walkL",false); 
			animatorPlayer.SetBool("walkR",false); 
		}
    }

    void OnVertical(InputValue val)
    {
        AxeY = val.Get<float>();
        if(AxeY == -1) // avance 
        {
			animatorPlayer.SetBool("walkF",true); 
		}
		else if (AxeY == 1) // recule
		{
			animatorPlayer.SetBool("walkB",true);
		}
		else // n'avance pas et ne recule pas
		{
			animatorPlayer.SetBool("walkF",false); 
			animatorPlayer.SetBool("walkB",false); 
		}

    }

    void OnJump()
    {
		
		//Le premier if marche bien sur l'editeur mais sur le build il n'a pas l'air de reconnaitre les raycast qui detecte 
		//si le joueur est au sol, donc grounded reste a false par consequent j'ai mis un deuxieme systeme qui attend un delai pour re-sauter
		
        if(grounded && Time.time >= NextFenetreJump)  
        {
	      grounded = false;
		  rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		  //animatorPlayer.SetTrigger("jump");
		  NextFenetreJump = Time.time + 1.4f; // calcule prochain fenetre de saut		
        }
        
        else if(Time.time >= NextFenetreJump+1f)
        {
		  grounded = false;
		  rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		  //animatorPlayer.SetTrigger("jump");
		  NextFenetreJump = Time.time + 1f; // calcule prochain fenetre de saut	
		}
    }
    
    public void GroundedSet(bool newEtat)
    {
		grounded = newEtat;
	}
}
