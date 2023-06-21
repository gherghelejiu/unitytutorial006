using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] GameObject explosionVfx;
    [SerializeField] GameObject hitVfx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitsToKill = 15;
    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        explosion.transform.parent = parent;
    }

    private void KillEnemy()
    {
        GameObject explosion = Instantiate(explosionVfx, this.transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
