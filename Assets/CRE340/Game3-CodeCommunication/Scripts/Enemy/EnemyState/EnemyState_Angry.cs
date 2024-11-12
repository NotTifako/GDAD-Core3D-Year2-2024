using System.Collections;
using UnityEngine;

public class EnemyState_Angry : IEnemyState
{
    private float enemyStartRange;
    public void Enter(Enemy enemy)
    {
        Debug.Log("Entering Angry State");
        
        IncreaseDecreaseRange(true, enemy);

        IncreaseDecreaseRange(false, enemy);
    }

    public void Update(Enemy enemy)
    {
        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            enemy.target.position,
            enemy.speed * Time.deltaTime
        );

        if (Vector3.Distance(enemy.transform.position, enemy.target.position) > enemy.chaseRange)
        {
            enemy.SetState(new EnemyState_Idle());
        }
    }

    public void Exit(Enemy enemy)
    {
        Debug.Log("Exiting Angry State");

        if(enemy.chaseRange != enemyStartRange)
        {
            enemy.chaseRange = enemyStartRange;
        }
    }

    private IEnumerator IncreaseDecreaseRange(bool increase, Enemy enemy)
    {
        if(increase)
        {
            enemyStartRange = enemy.chaseRange;
            enemy.chaseRange = enemy.chaseRange * 2;
        }
        else
        {
            new WaitForSeconds(5f);
            enemy.chaseRange = enemyStartRange;
        }
        return null;
    }
}
