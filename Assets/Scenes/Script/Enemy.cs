using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int enemySpd = 4;

    void Update()
    {
        transform.Translate(Vector3.down * enemySpd * Time.deltaTime);
        if (transform.position.y <= -5.0f)
        {     
            transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 5, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            Destroy(this.gameObject);
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
           
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }

       /* if (other.tag == "TripleShot")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }*/


    }

}
