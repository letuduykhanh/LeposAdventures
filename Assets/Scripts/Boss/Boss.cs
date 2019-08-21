using UnityEngine;
using System.Collections;
using System;

public class Boss : Character
{
    private IEnemyState currentState;

    public GameObject Target { get; set; }

	public GameObject door;

	[SerializeField]
    protected float gamespeed = 2f;

    [SerializeField]
    private Transform leftEdge;

    [SerializeField]
    private Transform rightEdge;

	private Canvas healthCanvas;
			
    public override bool IsDead
    {
        get
        {
            return healthStat.CurrentValue <= 0;
        }
    }

    // Use this for initialization
    public override void Start () {
        base.Start();
        Character_movement.Instance.Dead += new DeadEventHandler(RemoveTarget);
        ChangeState(new IdleState());	
		healthCanvas = transform.GetComponentInChildren<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!IsDead) {
            if (!TakingDamage) {
                currentState.Execute();
            }
            LookatTarget();
        }    
	}

    public void RemoveTarget() {
        Target = null;
        ChangeState(new PatrolState());
    }

    public void LookatTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;
            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }

    public void ChangeState(IEnemyState newState) {
        if (currentState != null) {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }

    public void Move() {
        if (!Attack) {
            if (GetDirection().x > 0 && transform.position.x < rightEdge.position.x) {
                MyAnimator.SetFloat("speed", 1);			
                transform.Translate(GetDirection() * (gamespeed * Time.deltaTime));
            } else if(GetDirection().x < 0 && transform.position.x > leftEdge.position.x) {
                MyAnimator.SetFloat("speed", 1);
                transform.Translate(-GetDirection() * (gamespeed * Time.deltaTime));
            }
            else if (currentState is PatrolState) {
                ChangeDirection();
            }
        }
    }
	
	public override  void ChangeDirection(){
		Transform tmp = transform.FindChild("BossCanvas").transform;
		
		Vector3 pos = tmp.position;
		
		tmp.SetParent(null);
		
		base.ChangeDirection();
		
		tmp.SetParent(transform);
		
		tmp.position = pos;	
	}

    public Vector2 GetDirection() {
        return facingRight ? Vector2.right : Vector2.left;
    }
		
    public  override void OnTriggerEnter2D(Collider2D other) {
        base.OnTriggerEnter2D(other);
        currentState.OnTriggerEnter(other);
    }
		
    public override IEnumerator TakeDamage()
    {	
        healthStat.CurrentValue -= 5;
        if (!IsDead)
        {
        }
        else {
            MyAnimator.SetTrigger("die");
			yield return new WaitForSeconds (2);
			Destroy (gameObject);
			door.SetActive (true);
            yield return null;
        }
    }
		
}
