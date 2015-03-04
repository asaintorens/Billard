using UnityEngine;
using System.Collections;

public class TableScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsRolling(CanneScript canne)
    {

        canne.isRolling = false;
        for (int i = 0; i < 7; i++)
        {
            GameObject bille = GameObject.Find("BilleNoire" + i);
            float mouvement = bille.rigidbody.velocity.magnitude;
          
            if (mouvement> 0.5f)
            {
                canne.isRolling = true;
                break;
            }
        }

        if (!canne.isRolling)
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject bille = GameObject.Find("BilleRouge" + i);
                float mouvement = bille.rigidbody.velocity.magnitude;
                if (mouvement > 0.5f)
                {
                    canne.isRolling = true;
                    break;
                }
            }

        }
        if (!canne.isRolling)
        {
            GameObject bille = GameObject.Find("BilleBlanche");
            float mouvement = bille.rigidbody.velocity.magnitude;
            if(mouvement>0.5f)
            {
                canne.isRolling = true;
            }
        }


    }
}
