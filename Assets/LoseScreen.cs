using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoseScreen : MonoBehaviour
{

    // Start is called before the first frame update
    public void OnClickToMainMenu()
    {
       
        SceneManager.LoadScene(0);
        
    }

    // Update is called once per frame
    public void OnClickRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
