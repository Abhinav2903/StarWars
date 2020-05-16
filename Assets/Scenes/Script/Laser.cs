using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private int lspeed = 10;
    
  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * lspeed * Time.deltaTime);
        if (transform.position.y > 8)
        {
            //if (transform.parent != null) { Destroy(this.gameObject); }

            Destroy(this.gameObject);
        }
    }
}
