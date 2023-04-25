using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mobMove : MonoBehaviour
{
	// deplacement
	public Transform targetPlayer;
	private NavMeshAgent mobMeshAgent;
			
	// animation
	private Animator mobAnim;


    // Start is called before the first frame update
    void Start()
    {
        mobMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        mobAnim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
		// deplacement
		mobMeshAgent.SetDestination(targetPlayer.position);
				
		// animation deplacement
		if(mobMeshAgent.velocity.magnitude > 0 && !(GetComponent<mobStats>().getMort())) // le joueur est en mouvement quand il est pas mort
        {
			mobAnim.SetBool("walk",true);
		}
		else
		{
			mobAnim.SetBool("walk",false);
		}
		
		
    }
}
