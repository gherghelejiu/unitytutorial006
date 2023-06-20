using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] GameObject explosionVfx;
    [SerializeField] Transform parent;

    private void OnParticleCollision(GameObject other)
    {
        GameObject explosion = Instantiate(explosionVfx, this.transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        Debug.Log($"{this.name} hit by particles {other.gameObject.name}");
        Destroy(this.gameObject);
    }
}
