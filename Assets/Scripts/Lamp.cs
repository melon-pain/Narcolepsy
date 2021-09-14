using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public void Fix()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("Fix");
        this.gameObject.tag = "Untagged";
        this.gameObject.GetComponent<Lamp>().enabled = false;
    }
}
