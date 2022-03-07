using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        // throw new NotImplementedException();
    }

    // End of dialogue and start of gameplay
    public void Action()
    {
        Debug.Log("Action goes here");
    }
    
    //End of dialogue and moving to next scene
    public void NoAction(float time)
    {
        if (time <= .01)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        StartCoroutine(WaitForSounds(time));
    }

    private IEnumerator WaitForSounds(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            NoAction(0);
        }
    }
}
