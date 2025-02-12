using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObsticable : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision) //Tym trzeba siê zaj¹æ, tylko jak? Najproœciej jak to mo¿liwe!
    {
        //if (collision.gameObject.tag == "Obsticle")
        //{
            Debug.Log(collision.gameObject.tag);
        //}
    }
}
