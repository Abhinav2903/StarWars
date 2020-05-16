using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float lspeed = 10f;
    
  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * lspeed * Time.deltaTime);
        if (transform.position.y > 8f)
        {
            //if (transform.parent != null) { Destroy(this.gameObject); }
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
