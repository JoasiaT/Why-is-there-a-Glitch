using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObsticable : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision) //Tym trzeba si� zaj��, tylko jak? Najpro�ciej jak to mo�liwe!
    {
        //if (collision.gameObject.tag == "Obsticle")
        //{
            Debug.Log(collision.gameObject.tag);
        //}
    }
}
