using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    
    // Speed the laser moving
    [SerializeField]
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Moving Up
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        #endregion

        #region Limits
        if (transform.position.y > 5.70f)
        {
            Destroy(this.gameObject);
        }
        #endregion
    }
}
