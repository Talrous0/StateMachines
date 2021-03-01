using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine_c : MonoBehaviour
{
    public enum State
    {
        idle,
        walking,
        swimming,
        climbing,
        observe,
        shade
    }

    public State currentState = State.idle;
    Vector3 lastPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.idle: Idle(); break;
            case State.walking: Walking(); break;
            case State.swimming: Swimming(); break;
            case State.climbing: Climbing(); break;
            case State.observe: Observe(); break;
            case State.shade: Shade(); break;
            default: break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "WaterTrigger")
        {
            currentState = State.swimming;
        }
        else if(other.name == "MountainTrigger")
        {
            currentState = State.climbing;
        }
        else if(other.name == "MonolithTrigger")
        {
            currentState = State.observe;
        }
        else if(other.name == "ShadeTrigger")
        {
            currentState = State.shade;
        }
    }

    void OnTriggerExit(Collider other)
    {
        currentState = State.walking;
    }

    void Shade()
    {
        Debug.Log("Much cooler from the sun");
    }
    void Observe()
    {
        Debug.Log("Hmmm.. Facinating...");
    }
    void Swimming()
    {
        Debug.Log("I am Swimming");
    }

    void Climbing()
    {
        Debug.Log("I am Climbing");
    }

    void Idle()
    {
        Debug.Log("I am idle");
        if(lastPosition != transform.position)
        {
            currentState = State.walking;
        }
        lastPosition = transform.position;
    }

    void Walking()
    {
        Debug.Log("I am walking");
        if (lastPosition == transform.position)
        {
            currentState = State.idle;
        }
        lastPosition = transform.position;
    }
}
