using UnityEngine;
using System.Collections;

public class IdleState : IEnemyState
{
    private Boss boss;

    private float idleTimer;

    private float idleDuration;

	public void Enter(Boss boss)
    {
        idleDuration = UnityEngine.Random.Range(1,10);
		this.boss = boss;
    }

    public void Execute()
    {
        Idle();

		if (boss.Target != null) {
			boss.ChangeState(new PatrolState());
        }
    }

    public void Exit() { }

    public void OnTriggerEnter(Collider2D other)
    {
    }

    private void Idle() {
		boss.MyAnimator.SetFloat("speed", 0);
        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDuration) {
			boss.ChangeState(new PatrolState());
        }
    }
}
