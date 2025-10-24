using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTriggerHandler : MonoBehaviour
{
    public Animator animator;      // Reference to the Animator
    private int c = 0;             // Counter for enabling/disabling Animator
    private int t = 0;             // Counter for setting 'state' parameter

    private int a = 0;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        // Set default state to 1 at start
        animator.SetTrigger("set1");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimTrig"))
        {
            c++;   // Increment enable/disable counter
            t++;   // Increment state counter

            if (t % 2==0)
            {
                a++;
            }
            // Toggle Animator component
                if (c % 2 != 0)
                {
                    animator.enabled = false;
                    Debug.Log("Animator Disabled (c=" + c + ")");
                }
                else
                {

                    animator.enabled = true;

                    if (a % 2 != 0)
                    {
                        animator.Play("tilt1 1");
                    }
                    else
                    {
                        animator.Play("tilt1");
                    }
                    Debug.Log("Animator Enabled (c=" + c + ")");
                }

            // Set state parameter
            /*if (t % 2 != 0)
            {
                animator.SetTrigger("set1");
            }
            else
            {
                animator.SetTrigger("set2");
            }**/
        }
    }
}
