using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState
{
	private Boss boss;

    private float patrolTimer;

    private float patrolDuration;

	public void Enter(Boss boss)
    {
        patrolDuration = UnityEngine.Random.Range(3,10);
		this.boss = boss;
    }

    public void Execute()
    {
        Patrol();
		boss.Move();
    }

    public void Exit()
    {
    }

    public void OnTriggerEnter(Collider2D other)
    {
    }

    private void Patrol()
    {
        patrolTimer += Time.deltaTime;
        if (patrolTimer >= patrolDuration)
        {
			boss.ChangeState(new IdleState());
        }
    }
}
