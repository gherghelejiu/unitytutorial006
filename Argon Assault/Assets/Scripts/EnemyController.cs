using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        // 
        //
        Debug.Log($"{this.name} hit by particles {other.gameObject.name}");
        Destroy(this.gameObject);
    }
}
