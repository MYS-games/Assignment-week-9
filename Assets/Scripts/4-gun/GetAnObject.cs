using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAnObject : MonoBehaviour
{
    private bool picked = false;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnergyCapsule")
        {
            if (!picked)
            {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
