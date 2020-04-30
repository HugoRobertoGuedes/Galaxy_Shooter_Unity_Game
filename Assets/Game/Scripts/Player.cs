using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    #region Serialized Fields
    // Lives
    [SerializeField]
    public int lives = 0;

    // Player Animation Explosion
    [SerializeField]
    private GameObject PlayerExplosion;

    // Speed for player nave
    [SerializeField]
    private float speed = 5.0f;

    // time for next fire
    [SerializeField]
    private float timeRate = 0.25f;

    // Explosion Audio Clip
    [SerializeField]
    private AudioClip audioClip;
    #endregion

    #region Publics
    // Total fire triple shoot
    public int totalTripleShot = 0;

    // Prefab laser
    public GameObject laserPrefab;

    // Active triple shoot
    public bool powerTripleShoot = false;

    // Count shoots
    public int countTripleShot = 0;

    // Active boost
    public bool powerOnBoost = false;

    // Super Speed
    public float boost = 10.0f;
    #endregion

    #region Private
    // Time for can fire
    private float canFire = 0.0f;
    // UiManager
    private UiManager uiManager;
    // Audio Source Laser
    private AudioSource audioSource;
    // Game Manager
    private GameManager gameManager;
    // Game IA
    private Game_IA game_IA;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        uiManager = GameObject.Find("Game_UI").GetComponent<UiManager>();
        uiManager.UpdateLive(lives);
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        game_IA = GameObject.Find("Game_IA").GetComponent<Game_IA>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Moving Player
        // Move in axis X
        transform.Translate(Vector3.right * Time.deltaTime * ((powerOnBoost) ? speed : boost) * Input.GetAxis("Horizontal"));

        // Move in axis Y
        transform.Translate(Vector3.up * Time.deltaTime * ((powerOnBoost) ? speed : boost) * Input.GetAxis("Vertical"));
        #endregion

        #region Limits
        // Limits for screen player
        // Axis Y
        if (transform.position.y > 4.20f)
        {
            transform.position = new Vector3(transform.position.x, 4.20f, 0);
        }
        if (transform.position.y < -4.20f)
        {
            transform.position = new Vector3(transform.position.x, -4.20f, 0);
        }
        // Axis X
        if (transform.position.x > 8.30f)
        {
            transform.position = new Vector3(8.30f, transform.position.y, 0);
        }
        if (transform.position.x < -8.30f)
        {
            transform.position = new Vector3(-8.30f, transform.position.y, 0);
        }
        #endregion

        #region Lasers Fire
        // Space bar : One Laser shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fired");
            if (Time.time > canFire)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.45f, 0), Quaternion.identity);
                audioSource.Play();
                canFire = Time.time + timeRate;
            }
        }

        // T : Triple Shoot
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (powerTripleShoot)
            {
                if (countTripleShot < totalTripleShot)
                {
                    // Left
                    Instantiate(laserPrefab, transform.position + new Vector3(-0.553f, 0.196f, 0), Quaternion.identity);
                    // Center
                    Instantiate(laserPrefab, transform.position + new Vector3(0, 0.45f, 0), Quaternion.identity);
                    // Right
                    Instantiate(laserPrefab, transform.position + new Vector3(0.553f, 0.201f, 0), Quaternion.identity);
                    // Add count
                    countTripleShot++;
                    uiManager.UpdateTripleShoot(totalTripleShot - countTripleShot);
                    audioSource.Play();
                }
                if (countTripleShot == totalTripleShot)
                {
                    totalTripleShot = 0;
                }
            }
        }
        #endregion
    }

    // update UI
    public void UpdateUi()
    {
        uiManager.UpdateTripleShoot(totalTripleShot);
    }

    // Hit enemy
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            lives--;
            uiManager.UpdateLive(lives);
            if (lives == 0)
            {
                Instantiate(PlayerExplosion, transform.position, Quaternion.identity);
                uiManager.ShowTitleScreen();
                gameManager.gameOver = true;
                game_IA.generateEnemies = false;
                game_IA.generatePowerUps = false;
                AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
    }

}
