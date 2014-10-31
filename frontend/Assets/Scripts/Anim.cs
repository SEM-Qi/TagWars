using UnityEngine;
using System;

/* The ANIM class is a wrapper for the Unity.Animator object
it stores all Animators in our project */

public class Anim : MonoBehaviour
{
    // Game objects with Animators
    public GameObject anim1; // default animator
    public GameObject anim2;


    //----------------------------

    // Awake binds all Animators
    void Awake()
    {

    }

    // Getters & Setters

    // default animator
    public void SetTrigger(String trigger)
    {

    }

    public void SetBool(String boolName, bool b)
    {

    }

    public int GetAnimationLength()
    {
        Debug.Log("animation length: ");
        return 0;
    }

    // other animators
    public void SetTrigger(String animator, String trigger)
    {

    }

    public void SetBool(String animator, String boolName, bool b)
    {

    }

    public int GetAnimationLength(String animator)
    {
        Debug.Log("animation length from animator: " + animator);
        return 0;
    }

}
