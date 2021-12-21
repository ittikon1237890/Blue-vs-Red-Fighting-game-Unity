using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class status : MonoBehaviour
{
    public float Hp;
    public float damage;
    public Animator animator;
    public bool die_check = false;
    public Walk_Play1 player1;
    public Walk_Play2 player2;

    public int countP1;
    public int countP2;
    public bool checkEndGame = false;

    public AudioSource punchSound;
    public AudioSource dieSound;

    // Start is called before the first frame update
    void Start()
    {
        countP1 = PlayerPrefs.GetInt("countP1");
        countP2 = PlayerPrefs.GetInt("countP2");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Hp <= 0 && die_check == false)
        {
        //print("Die");   
        animator.SetTrigger("die1");
        dieSound.Play();
        die_check = true;
        player1.enablePlayer = false;
        player2.enablePlayer = false;
            //Debug.Log(die_check);
            if (countP1 == 2 || countP2 == 2)
            {
                PlayerPrefs.SetInt("countP1", 0);
                PlayerPrefs.SetInt("countP2", 0);
                PlayerPrefs.Save();
                checkEndGame = true;
                SceneManager.LoadScene("Menu");
            }
            if (checkEndGame == false) {
                
                StartCoroutine(Example()); // ดีเลย์โหลดฉาก
            }
           
        }      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hitbox") {
            if (die_check == false)
            {
                Hp -= damage;
                hp_bar.hp -= damage;
                //print("hit");
                animator.SetTrigger("damage");
                punchSound.Play();
            }


        }
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print(Time.time);
    }
}
