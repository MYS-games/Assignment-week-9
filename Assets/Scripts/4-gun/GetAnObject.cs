using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAnObject : MonoBehaviour
{
    private bool picked = false;
    //public static void Label(Rect position, string text);
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnergyCapsule")
        {
            if (!picked)
            {
                OnGUI();
                picked = true;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "Engine")
        {
            if (picked)
            {
                picked = false;


            }
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnergyCapsule" && enabled)
        {
            if (!picked)
            {
                OnGUI();
                picked = true;
                Destroy(other.gameObject);
            }
        }
        if (other.tag == "Engine" && enabled)
        {
            if (picked)
            {
                picked = false;
            }
        }
    }*/

    void OnGUI()
    {
        Debug.Log(" on gui");
        GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
