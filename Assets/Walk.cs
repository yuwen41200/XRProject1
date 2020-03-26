using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;    //使用UnityEngine.AI
using UnityEngine;

public class Walk : MonoBehaviour
{
    public NavMeshAgent agent;    //宣告NavMeshAgent
    public GameObject target_obj;    //目標物件
    public GameObject walker;
    public GameObject attackEffect;
    private float att_range = 20;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, target_obj.transform.position);
        if (dist < att_range)
        {
            GameObject attackEffectClone = Instantiate(attackEffect, walker.transform.position, Quaternion.identity);
            Destroy(walker, 0.25f);
            Destroy(attackEffectClone, 16);
        }
        else
        {
            agent.SetDestination(target_obj.transform.position);
        }
    }
}
