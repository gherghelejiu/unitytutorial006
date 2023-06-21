using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] GameObject explosionVfx;
    [SerializeField] GameObject hitVfx;
    [SerializeField] GameObject parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitsToKill = 15;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidbody();
        parent = GameObject.FindWithTag("SpawnAtRuntime");
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        //
        Debug.Log($"{this.name} hit by particles {other.gameObject.name}");
        ProcessHit();
        if (hitsToKill < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitsToKill--;
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject explosion = Instantiate(hitVfx, this.transform.position, Quaternion.identity);
        explosion.transform.parent = parent.transform;
    }

    private void KillEnemy()
    {
        GameObject explosion = Instantiate(explosionVfx, this.transform.position, Quaternion.identity);
        explosion.transform.parent = parent.transform;
        Destroy(this.gameObject);
    }
}
