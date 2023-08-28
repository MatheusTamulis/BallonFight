using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstanciarMoeda : MonoBehaviour
{

    public GameObject moedaPrefab;


    Vector2 moedaPosition;

    // Start is called before the first frame update
    void Start()
    {     
        StartCoroutine(SpawnMoeda());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMoeda()
    {
        float t = Random.Range(0.5f, 3.0f);
        
        yield return new WaitForSeconds(t);

        moedaPosition.x = Random.Range(-8.65f, 8.70f);
        moedaPosition.y = Random.Range(-4.7f, 4.7f);
        GameObject moedaInstance = Instantiate(moedaPrefab, moedaPosition, Quaternion.identity);

        StartCoroutine(DestroiMoeda(moedaInstance));

        StartCoroutine (SpawnMoeda());
    }

    IEnumerator DestroiMoeda(GameObject moedaInstance)
    {
        float d = Random.Range(2.0f, 5.0f);

        yield return new WaitForSeconds(d);
        Destroy(moedaInstance);
    }
}
