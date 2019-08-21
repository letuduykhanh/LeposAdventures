using System;
using System.Collections;
using UnityEngine;

public delegate void DeadEventHandler();

public class Character_movement : Character
{
    private static Character_movement instance;

    public event DeadEventHandler Dead;

    public static Character_movement Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<Character_movement>();
            }
            return instance;
        }
    }
		
    private SpriteRenderer spriteRender;

    public Rigidbody2D MyRigidbody { get; set; }

    public override bool IsDead
    {
        get
        {
            if (healthStat.CurrentValue <= 0) {
             
            }
            return healthStat.CurrentValue <= 0;
        }
    }

    // Use this for initialization
    public override void Start () {
        base.Start();
        spriteRender = GetComponent<SpriteRenderer>();
        MyRigidbody = GetComponent<Rigidbody2D>();	
	}

    void Update() {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
    }

    public override IEnumerator TakeDamage()
    {
            healthStat.CurrentValue -= 0;
            if (!IsDead)
            {
                MyAnimator.SetTrigger("damage");
            }
            else
            {
                MyAnimator.SetLayerWeight(1, 0);
                yield return new WaitForSeconds(1);
                Destroy(gameObject);
            }
    }
		
}
