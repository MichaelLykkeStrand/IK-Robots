using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{

    public void DoDespawn(float time)
    {
        StartCoroutine(CountDown(time));
    }

    private IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
