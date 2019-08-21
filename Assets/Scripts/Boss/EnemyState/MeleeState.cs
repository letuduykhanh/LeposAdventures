using UnityEngine;
using System.Collections;
using System;

public class MeleeState : IEnemyState {
    private float attackTimer;
    private float attackCD = 5;
    private bool canAttack = true;

	private Boss boss;

	public void Enter(Boss boss)
    {
		this.boss = boss;    
    }

    public void Execute()
    {
		if (boss.Target != null)
        {
			boss.Move();
        }
		else if (boss.Target = null)
        {
			boss.ChangeState(new IdleState());
        }
        else {
			boss.ChangeState(new IdleState());
        }
    }

    public void Exit(){ }

    public void OnTriggerEnter(Collider2D other){}

    private void Attack() {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCD) {
            canAttack = true;
            attackTimer = 0;
        }

        if (canAttack) {
            canAttack = false;
			boss.MyAnimator.SetTrigger("attack");
        }
    }
}
