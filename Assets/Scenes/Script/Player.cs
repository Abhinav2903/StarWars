using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 6f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float fireRate = 0.15f;
    [SerializeField]
    private float canFire = 0f;
    [SerializeField]
    private int lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject _triplePrefab;
    [SerializeField]
    private bool tripleShotActive = false;
    [SerializeField]
    private bool speedUpActive = false;
    [SerializeField]
    private float speedMultiplier = 2;
    [SerializeField]
    private bool shieldActive = false;
    [SerializeField]
    private GameObject shieldVisualizer;
    void Start()
    {
      transform.position= new Vector3(0,0,0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.Log("No spwaning");
        }
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement(); // Movement of Player
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            fireLaser();     // Laser Shooting
        }

    }

    void calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.up* verticalInput *Time.deltaTime * speed);
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        
        // for movement restriction use
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-10f,10f),Mathf.Clamp(transform.position.y,-4.0f,1.0f),0);

        transform.Translate(new Vector3(horizontalInput * Time.deltaTime * speed, verticalInput * Time.deltaTime *speed, 0));   

        /*if (transform.position.x > 10.5f || transform.position.x < -10.5f)
        {
            transform.position = new Vector3(transform.position.x * -1.0f, transform.position.y, 0);
        }*/
    }
    void fireLaser()
    {
        canFire = Time.time + fireRate;
        if (tripleShotActive == true)
        {
            Instantiate(_triplePrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 1.0f, 0), Quaternion.identity);
        }
        
    }

    public void Damage()
    {
        if (shieldActive == true)
        {
            shieldActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }
        
            lives =lives - 1;
            if (lives == 0)
            {
                _spawnManager.onPlayerDeath();
                Destroy(this.gameObject);
            }
    }

    public void TripleShotPowerUp()
    {
        tripleShotActive = true;
        StartCoroutine(TripleShotPowerDown());
    }

    IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        tripleShotActive = false;
    }

    public void SpeedPowerUP() {
        speedUpActive = true;
        speed = speed * speedMultiplier;
        StartCoroutine(SpeedPowerDown());
    }

    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        speedUpActive = false;
        speed = speed / speedMultiplier;
    }

    public void ShieldPowerUp()
    {
        shieldActive = true;
        shieldVisualizer.SetActive(true);   
    }

}
