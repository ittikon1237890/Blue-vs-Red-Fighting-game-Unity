using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hp_bar2 : MonoBehaviour
{
    // Start is called before the first frame update
    Image hpBar2;
    float maxHp = 100f;
    public static float hp;


    void Start()
    {
        hpBar2 = GetComponent<Image>();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar2.fillAmount = hp / maxHp;
    }
}
