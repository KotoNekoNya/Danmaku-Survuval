using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Enemy SimpleEnemy;
    public Enemy SimpleEnemyOpposite;
    public Enemy ShooterEnemyLeft;
    public Enemy ShooterEnemyRight;
    public Enemy ShooterSideScroller;



    public void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(SpawnSimple(SimpleEnemy, 0.2f, 10));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpawnSimple(SimpleEnemyOpposite, 0.2f, 10));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpawnSimple(SimpleEnemy, 0.2f, 10));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SpawnSimple(SimpleEnemyOpposite, 0.2f, 10));
        yield return StartSequence();

        yield return StartSequence();

        yield return StartSequence();
    }

    public IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(4.0f);
        StartCoroutine(SpawnSimple(SimpleEnemy, 0.2f, 10));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SpawnSimple(SimpleEnemyOpposite, 0.2f, 10));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnSimple(ShooterEnemyLeft, 0.2f, 1));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnSimple(ShooterEnemyRight, 0.2f, 1));
        StartCoroutine(SpawnSimple(ShooterSideScroller, 0.2f, 10));
        yield return new WaitForSeconds(4.0f);
        StartCoroutine(SpawnSimple(SimpleEnemy, 0.2f, 10));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SpawnSimple(SimpleEnemyOpposite, 0.2f, 10));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnSimple(ShooterEnemyLeft, 0.2f, 1));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnSimple(ShooterEnemyRight, 0.2f, 1));
        yield return new WaitForSeconds(4.5f);
        StartCoroutine(SpawnSimple(SimpleEnemy, 0.2f, 10));
        StartCoroutine(SpawnSimple(ShooterEnemyLeft, 0.2f, 1));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpawnSimple(SimpleEnemyOpposite, 0.2f, 10));
        StartCoroutine(SpawnSimple(ShooterEnemyRight, 0.2f, 1));
        StartCoroutine(SpawnSimple(ShooterSideScroller, 0.4f, 3));

    }


    public IEnumerator SpawnSimple(Enemy enemy, float wait, int amount)
    {
        for (int t = 0; t < amount; t++)
        {
            yield return new WaitForSeconds(wait);
            Instantiate(enemy);
        }
    }
}
