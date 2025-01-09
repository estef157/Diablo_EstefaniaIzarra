using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaBlendTree : MonoBehaviour
{
    private Animator animEnemigo;
    [SerializeField] NavMeshAgent agent;
    // Start is called before the first frame update
    private void Awake()
    {
        animEnemigo = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animEnemigo.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
    }
    private void OnAnimatorMove()
    {
        
    }
}
