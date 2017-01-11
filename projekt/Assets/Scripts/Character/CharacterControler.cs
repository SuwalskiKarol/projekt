using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterControler : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;

    private static List<string> pass = new List<string>() { "Floor" };
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        Ray r = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        RaycastHit hit;

        if (Physics.Raycast(r, out hit, 3000) && Input.GetMouseButtonDown(0))
        {

            if (hit.transform.tag == "Terrain")
            {
               

                Vector3 clickedPosition = hit.point;
                agent.SetDestination(new Vector3(clickedPosition.x, 0, clickedPosition.z));
            }
        }

        float velocity = agent.velocity.magnitude;
        if (velocity > 1)
        {
            anim.SetBool("canWalk", true);
        }
        else
        {
            anim.SetBool("canWalk", false);

        }
    }
}
