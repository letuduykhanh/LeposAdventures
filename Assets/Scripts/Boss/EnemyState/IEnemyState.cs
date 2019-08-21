using UnityEngine;
using System.Collections;

public interface IEnemyState {
    void Execute();
	void Enter(Boss boss);
    void Exit();
    void OnTriggerEnter(Collider2D other);
}
