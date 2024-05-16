using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int maxHealth = 3;
    public static int health = maxHealth;
    public Image[] hearts;

    public Sprite FullHeart;
    public Sprite EmptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts) { img.sprite = EmptyHeart; }
        for (int i = 0;i < health; i++) 
        {
            hearts[i].sprite = FullHeart;
        }
        
    }

    public static void ResetHealth()
    {
        health = maxHealth; // Reset health to maximum
    }
}
