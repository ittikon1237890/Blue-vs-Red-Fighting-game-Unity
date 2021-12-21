using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class battleCon : MonoBehaviour
{
    // Start is called before the first frame update
    public Walk_Play1 p1;
    public Walk_Play2 p2;

    public status player1;
    public status2 player2;

    bool win1 = false;
    bool win2 = false;

    bool p1c1 = false;
    bool p1c2 = false;

    bool p2c1 = false;
    bool p2c2 = false;

    public int countP1;
    public int countP2;

    public Image P1Dot1;
    public Image P1Dot2;

    public Image P2Dot1;
    public Image P2Dot2;

    public Image BannerWin1;
    public Image BannerWin2;

    public Image Banner1;
    public Image Banner2;

    public AudioSource BGM;

    public AudioSource Ready; 
    public AudioSource Fight;
    void Start()
    {
        countP1 = PlayerPrefs.GetInt("countP1");
        countP2 = PlayerPrefs.GetInt("countP2");
        
            BGM.Play();
            print("p1 win : " + countP1);
            print("p2 win : " + countP2);
            p1.enablePlayer = false;
            p2.enablePlayer = false;
        if (countP1 < 2 || countP2 <  2)
        {
            Banner1.gameObject.SetActive(true);
            Ready.Play();
            StartCoroutine(Banner());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.Hp <= 0 && win2 == false) {
            win2 = true;
            countP2 += 1 ;
            PlayerPrefs.SetInt("countP2", countP2);
            PlayerPrefs.Save();
            print("p2 win : " + countP2);
        }
        if (player2.Hp <= 0 && win1 == false)
        {
            win1 = true;
            countP1 += 1;
            PlayerPrefs.SetInt("countP1", countP1);
            PlayerPrefs.Save();
            print("p1 win : "+ countP1);
        }
        if (countP1 == 1 && p1c1 == false) {
            P1Dot1.gameObject.SetActive(true);
            p1c1 = true;
        }
        if (countP1 == 2 && p1c2 == false)
        {
            P1Dot2.gameObject.SetActive(true);
            BannerWin1.gameObject.SetActive(true);
            p1c2 = true;
            print("P1WIN!!!!");
        }
        if (countP2 == 1 && p2c1 == false)
        {
            P2Dot1.gameObject.SetActive(true);
            p2c1 = true;
        }
        if (countP2 == 2 && p2c2 == false)
        {
            P2Dot2.gameObject.SetActive(true);
            BannerWin2.gameObject.SetActive(true);
            p2c2 = true;
            print("P2WIN!!!!");
        }        
    }

    IEnumerator Banner()
    {
        if (countP1 < 2 || countP2 < 2)
        {
            
            yield return new WaitForSeconds(2);
            Banner1.gameObject.SetActive(false);

            Banner2.gameObject.SetActive(true);
            Fight.Play();
            yield return new WaitForSeconds(2);
            Banner2.gameObject.SetActive(false);
            p1.enablePlayer = true;
            p2.enablePlayer = true;
        }

    }

    public void backMenu() {
        PlayerPrefs.SetInt("countP1", 0);
        PlayerPrefs.SetInt("countP2", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");
    }


}
