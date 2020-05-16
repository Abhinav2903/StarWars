using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriplePowerup : MonoBehaviour
{

    [SerializeField]
    private float pupSpeed = 3.0f;
    // Start is called before the first frame update
    [SerializeField]
    private int PowerUpTypeId;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * pupSpeed * Time.deltaTime);
        if (transform.position.y < -5.3f )
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Player")
        {

            Destroy(this.gameObject);
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (PowerUpTypeId)
                {
                    case 0:
                        player.TripleShotPowerUp();
                        break;
                    case 1:
                        player.SpeedPowerUP();
                        break;
                    case 2:
                        player.ShieldPowerUp();
                        break;
  

                }

            }
        }
    }
}
