using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuCon : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource soundBG;
    void Start()
    {
        soundBG.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playgame() {
        SceneManager.LoadScene("GamePlay");
    }
    public void playgameBOT()
    {
        SceneManager.LoadScene("GamePlay_BOT");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
