using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachines : MonoBehaviour
{
    public enum EAIStates
    {
        idle,
        chase,
        dead
    };
    public EAIStates currentAIState;
    private float m_health;
    public Transform target;
    public float sightCutoffDistance;
    public float fieldOfViewAngle;
    public float hearingCutOffDistance;
    public float hearingRadius;
    // Start is called before the first frame update
    void Start()
    {
        currentAIState = EAIStates.idle;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        switch (currentAIState)
        {
            case EAIStates.idle:
                idle();
                break;
            case EAIStates.chase:
                chase();
                break;
            case EAIStates.dead:
                dead();
                break;
            default:
                break;
        }
    }

    public void reduceHealth(float amountToReduce)
    {
        m_health -= amountToReduce;
        if (checkDead() == true)
        {
            currentAIState = EAIStates.dead;
        }
    }

    private bool checkDead()
    {
        if (m_health > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }



    private bool canSee()
    {
        if (Vector3.Distance(transform.position, target.position) > sightCutoffDistance)
        {
            return false;
        }
        Vector3 dirToTarget = target.position - transform.position;
        if (Vector3.Angle(transform.position, dirToTarget) > (fieldOfViewAngle / 2))
        {
            return false;
        }
        return true;
    }

    private bool canHear()
    {
        if ((target.gameObject.GetComponent<NoiseMaker>().m_CurrentNoiseLevel + hearingRadius) < hearingCutOffDistance)
        { return false; }
        return true;
    }
   
    


    private void dead()
    {

    }


    private void chase()
    {
        if(!canHear() && !canSee())
        {
            currentAIState = EAIStates.idle;
        }
    }

    private void idle()
    {
        if (canHear() || canSee())
        {
            currentAIState = EAIStates.chase;
        }
    }
}
