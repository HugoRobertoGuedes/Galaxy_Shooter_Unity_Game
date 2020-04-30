using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Seralized
    // Speed for enemie
    [SerializeField]
    private float speed = 1.0f;

    // Animation Explosion
    [SerializeField]
    private GameObject EnemyExplosion;

    // punctuation for destroy
    [SerializeField]
    private int scoreForDestroy;

    // Explosion Audio Clip
    [SerializeField]
    private AudioClip audioClip;
    #endregion

    #region Private
    private UiManager uiManager;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Game_UI").GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Moving
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        #endregion

        #region Limits
        if(transform.position.y < -5.90)
        {
            Destroy(this.gameObject);
        }
        #endregion
    }

    // Hit shoot laser
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Gun")
        {
            switch (collider.tag)
            {
                case "Gun":
                    Destroy(collider.gameObject);
                    uiManager.UpdateScore(scoreForDestroy);
                    AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
                    Instantiate(EnemyExplosion, transform.position,Quaternion.identity);
                    Destroy(this.gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
