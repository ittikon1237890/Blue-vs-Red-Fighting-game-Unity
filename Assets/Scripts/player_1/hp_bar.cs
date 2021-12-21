using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hp_bar : MonoBehaviour
{
    // Start is called before the first frame update
    Image hpBar1;
    float maxHp = 100f;
    public static float hp;


    void Start()
    {
        hpBar1 = GetComponent<Image>();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar1.fillAmount = hp / maxHp;
    }
}
