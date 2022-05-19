using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveThePlayer : MonoBehaviour
{
    //public GameObject personaje;
    public NavMeshAgent agentenavmesh;
    private RaycastHit hit;
    public Camera camara;
    public Animator animador;


    // Start is called before the first frame update
    void Start()
    {
        agentenavmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver){
            this.enabled = false;
            return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log("mouse position");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agentenavmesh.SetDestination(hit.point);
                //Debug.Log("SetDestination");
            }

        }

        bool isWalking = !(agentenavmesh.remainingDistance <= agentenavmesh.stoppingDistance);

        // Cambiamos el estado de la animación
        animador.SetBool("IsWalking", isWalking);
    }
}
