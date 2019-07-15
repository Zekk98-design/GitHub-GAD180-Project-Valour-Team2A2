using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public GameObject bar1, bar2, bar3, bar4, bar5, bar6, bar7, bar8, bar9, gameOver;
    public static int health;
    void Start()
    {
        health = 9;
        bar1.gameObject.SetActive(true);
        bar2.gameObject.SetActive(true);
        bar3.gameObject.SetActive(true);
        bar4.gameObject.SetActive(true);
        bar5.gameObject.SetActive(true);
        bar6.gameObject.SetActive(true);
        bar7.gameObject.SetActive(true);
        bar8.gameObject.SetActive(true);
        bar9.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

    }

    void Update()
    {
        if (health > 9)
            health = 9;
        switch (health)
        {
            case 9:
                bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(true);
                bar7.gameObject.SetActive(true);
                bar8.gameObject.SetActive(true);
                bar9.gameObject.SetActive(true);
                break;
            case 8:
                bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(true);
                bar7.gameObject.SetActive(true);
                bar8.gameObject.SetActive(true);
                bar9.gameObject.SetActive(false);
                break;
            case 7:
                bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(true);
                bar7.gameObject.SetActive(true);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
            case 6:
                bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(true);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
            case 5:
                bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
            case 4:
                bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
            case 3:
                bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(false);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
            case 2:
                bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(false);
                bar4.gameObject.SetActive(false);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
            case 1:
                bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(false);
                bar3.gameObject.SetActive(false);
                bar4.gameObject.SetActive(false);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
            case 0:
                bar1.gameObject.SetActive(false);
                bar2.gameObject.SetActive(false);
                bar3.gameObject.SetActive(false);
                bar4.gameObject.SetActive(false);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                break;
        }
    }
}