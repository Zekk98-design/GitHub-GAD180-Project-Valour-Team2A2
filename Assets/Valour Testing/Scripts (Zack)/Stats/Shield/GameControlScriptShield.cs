using UnityEngine;

public class GameControlScriptShield : MonoBehaviour
{
    // Controls player Shield UI; activation and deactivation of images/bars to show Shield gain and loss.
    // Attach to empty game object in both level scenes.
    // References Shield gain (Green potions) and loss (enemies) scripts.

    public GameObject shield1, shield2, shield3, shield4, shield5, shield6, shieldGone;
    public GameObject p2Shield1, p2Shield2, p2Shield3, p2Shield4, p2Shield5, p2Shield6, p2ShieldGone;

    public static int shield;
    public static int p2Shield;

    void Start()
    {
        shield = 7;
        shield1.gameObject.SetActive(true);
        shield2.gameObject.SetActive(true);
        shield3.gameObject.SetActive(true);
        shield4.gameObject.SetActive(true);
        shield5.gameObject.SetActive(true);
        shield6.gameObject.SetActive(true);
        shieldGone.gameObject.SetActive(false);

        p2Shield = 7;
        p2Shield1.gameObject.SetActive(true);
        p2Shield2.gameObject.SetActive(true);
        p2Shield3.gameObject.SetActive(true);
        p2Shield4.gameObject.SetActive(true);
        p2Shield5.gameObject.SetActive(true);
        p2Shield6.gameObject.SetActive(true);
        p2ShieldGone.gameObject.SetActive(false);
    }

    void Update()
    {
        // P1.
        if (shield > 6)
            shield = 6;
        switch (shield)
        {
            case 6:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(true);
                shield4.gameObject.SetActive(true);
                shield5.gameObject.SetActive(true);
                shield6.gameObject.SetActive(true);
                
                break;
            case 5:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(true);
                shield4.gameObject.SetActive(true);
                shield5.gameObject.SetActive(true);
                shield6.gameObject.SetActive(false);
                
                break;
            case 4:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(true);
                shield4.gameObject.SetActive(true);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                
                break;
            case 3:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(true);
                shield4.gameObject.SetActive(false);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                
                break;
            case 2:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(false);
                shield4.gameObject.SetActive(false);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                
                break;
            case 1:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(false);
                shield3.gameObject.SetActive(false);
                shield4.gameObject.SetActive(false);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                
                break;
            case 0:
                shield1.gameObject.SetActive(false);
                shield2.gameObject.SetActive(false);
                shield3.gameObject.SetActive(false);
                shield4.gameObject.SetActive(false);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                shieldGone.gameObject.SetActive(true);
                break;
        }
        if (shield > 0)
        {
            shieldGone.gameObject.SetActive(false);
        }
            //p2
            if (p2Shield > 6)
            p2Shield = 6;
        switch (p2Shield)
        {
            case 6:
                p2Shield1.gameObject.SetActive(true);
                p2Shield2.gameObject.SetActive(true);
                p2Shield3.gameObject.SetActive(true);
                p2Shield4.gameObject.SetActive(true);
                p2Shield5.gameObject.SetActive(true);
                p2Shield6.gameObject.SetActive(true);
                
                break;
            case 5:
                p2Shield1.gameObject.SetActive(true);
                p2Shield2.gameObject.SetActive(true);
                p2Shield3.gameObject.SetActive(true);
                p2Shield4.gameObject.SetActive(true);
                p2Shield5.gameObject.SetActive(true);
                p2Shield6.gameObject.SetActive(false);
                
                break;
            case 4:
                p2Shield1.gameObject.SetActive(true);
                p2Shield2.gameObject.SetActive(true);
                p2Shield3.gameObject.SetActive(true);
                p2Shield4.gameObject.SetActive(true);
                p2Shield5.gameObject.SetActive(false);
                p2Shield6.gameObject.SetActive(false);
                
                break;
            case 3:
                p2Shield1.gameObject.SetActive(true);
                p2Shield2.gameObject.SetActive(true);
                p2Shield3.gameObject.SetActive(true);
                p2Shield4.gameObject.SetActive(false);
                p2Shield5.gameObject.SetActive(false);
                p2Shield6.gameObject.SetActive(false);
                
                break;
            case 2:
                p2Shield1.gameObject.SetActive(true);
                p2Shield2.gameObject.SetActive(true);
                p2Shield3.gameObject.SetActive(false);
                p2Shield4.gameObject.SetActive(false);
                p2Shield5.gameObject.SetActive(false);
                p2Shield6.gameObject.SetActive(false);
                
                break;
            case 1:
                p2Shield1.gameObject.SetActive(true);
                p2Shield2.gameObject.SetActive(false);
                p2Shield3.gameObject.SetActive(false);
                p2Shield4.gameObject.SetActive(false);
                p2Shield5.gameObject.SetActive(false);
                p2Shield6.gameObject.SetActive(false);
                
                break;
            case 0:
                p2Shield1.gameObject.SetActive(false);
                p2Shield2.gameObject.SetActive(false);
                p2Shield3.gameObject.SetActive(false);
                p2Shield4.gameObject.SetActive(false);
                p2Shield5.gameObject.SetActive(false);
                p2Shield6.gameObject.SetActive(false);
                p2ShieldGone.gameObject.SetActive(true);
                break;
        }
        if (p2Shield > 0)
        {
            p2ShieldGone.gameObject.SetActive(false);
        }
    }
}