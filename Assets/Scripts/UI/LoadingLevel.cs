using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingLevel : MonoBehaviour
{

    private void Start()
    {
        Initiate.DoneFading();
        
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {

        float randomSecWait = Random.Range(2f, 4f);
        yield return new WaitForSeconds(randomSecWait);
        Initiate.Fade("DemoLevel", Color.black, 1f);


    }
}

