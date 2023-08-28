using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TittleScreen : MonoBehaviour
{

    public Text tittle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Texto());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    IEnumerator Texto()
    {
        yield return new WaitForSeconds(0.8f);
        tittle.enabled = false;
        yield return new WaitForSeconds(0.8f);
        tittle.enabled = true;

        StartCoroutine(Texto());
    }
}
