using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_IA : MonoBehaviour
{
    #region Serialized
    // Time generate Triple Shoot
    [SerializeField]
    private float timeGenerateTripleShot = 0f;

    // Time generate speed
    [SerializeField]
    private float timeGenerateSpeed = 0f;

    // Time for await generate enemies
    [SerializeField]
    private float timeGenerateEnemies = 0f;

    // Game object Enemie
    [SerializeField]
    private GameObject EnemiePrefab;

    [SerializeField]
    private List<GameObject> PowerUps;
    #endregion

    #region Public
    // generate enimies while true
    public bool generateEnemies = false;

    // geneerate powerups while true
    public bool generatePowerUps = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateEnemies());
        StartCoroutine(GenerateTripleShoot());
        StartCoroutine(GenerateTripleSpeed());
    }


    public void StartGenerate()
    {
        StartCoroutine(GenerateEnemies());
        StartCoroutine(GenerateTripleShoot());
        StartCoroutine(GenerateTripleSpeed());
    }

    // Coroutine generate Speed
    IEnumerator GenerateTripleSpeed()
    {
        while (generatePowerUps)
        {
            Instantiate(PowerUps[1], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeGenerateSpeed);
        }
    }

    // Coroutine generate Triple shoot
    IEnumerator GenerateTripleShoot()
    {
        while (generatePowerUps)
        {
            Instantiate(PowerUps[0], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeGenerateTripleShot);
        }
    }

    // Coroutine generate enemies
    IEnumerator GenerateEnemies()
    {
        while (generateEnemies)
        {
            Instantiate(EnemiePrefab, new Vector3(Random.Range(-7,7), 7, 0),Quaternion.identity);
            yield return new WaitForSeconds(timeGenerateEnemies);
        }
    }
}