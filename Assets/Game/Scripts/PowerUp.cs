using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    #region Serialized
    // Speed Power Up
    [SerializeField]
    private float speed = 3.0f;
    // Audio Clip
    [SerializeField]
    private AudioClip audioClip;
    #endregion

    #region Public
    // Power identification
    public int powerId;
    #endregion

    #region Private
    #endregion



    // Update is called once per frame
    void Update()
    {
        #region Moviment
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        #endregion

        #region Limits
        if (transform.position.y < -5.90f)
        {
            Destroy(this.gameObject);
        }
        #endregion
    }


    // Active power Up after colider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Player player = collider.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
            switch (powerId)
            {
                case 1:
                    player.powerTripleShoot = true;
                    player.countTripleShot = 0;
                    player.totalTripleShot += 3;
                    player.UpdateUi();
                    Destroy(this.gameObject);
                    break;
                case 2:
                    player.powerOnBoost = true;
                    Destroy(this.gameObject);
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}
