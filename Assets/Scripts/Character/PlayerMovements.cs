using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovements : MonoBehaviour
{
	private Animator anim;
	private Rigidbody2D rb2d;
	private bool wallJumping;
	// Biến tốc độ chay
	private float speed = 6.0f;
	// Biến tốc độ bay
	private float flyspeed = 5.0f;
	// Biến lực nhảy
	private float jumpForce = 12.0f;
	// Biến tốc độ nhảy
	private float wallJumpspeed = 11.0f;
	// Biến khoảng cách trong va chạm
	private float distance = 4.0f;
	// Biến hứa giá trị true/false chạm đất hay chưa
	public bool grounded;
	// Biến điểm chạm đất
	public Transform point;
	// Biến điểm chạm là mặt đất
	public LayerMask onlyGroundMask;
	// Biến thời gian được nhảy lần tiếp theo nhỏ hơn maxTime
	private float timer;
	// Biến thời gian được nhảy lần tiếp theo
	private float maxTime = 0.1f;
	// Biến có thể nhảy
	private bool canJump;
	// Biến có thể bay
	private bool canFly;
	// Biến chứa tên scene
	private string scenename;
	private bool isdead;
	public bool clear;
	// Biến chứa vị trí hồi sinh nhân vật check point
	public GameObject respawn;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		scenename = SceneManager.GetActiveScene ().name;

	}

	void Update ()
	{
		//Khi nào chạm đất mới được di chuyển
		if (grounded && !isdead) {
			if (transform.localScale.x > 0) {
				Run (1, 1);
			} else {
				Run (-1, -1);
			}
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Vector2 touch = Input.GetTouch (0).position;
			double hafscreen = Screen.width / 2.0;

			// Khi nào bấm chuột và chạm collider canFly được thì mới bay được
			if (touch.x > hafscreen && canFly && !isdead) {
				if (transform.localScale.x > 0) {
					Fly (1, 1);
				} else {
					Fly (-1, -1);
				}
			}
		}


		// Khi nào bấm chuột và chạm collider canFly được thì mới bay được
		if (Input.GetButton ("Fire1") && canFly && !isdead) {
			if (transform.localScale.x > 0) {
				Fly (1, 1);
			} else {
				Fly (-1, -1);
			}
		}


		// Nhận biết các collider nằm trong vùng raycast (CỦA NHÂN VẬT)
		Physics2D.queriesStartInColliders = false;
		// Hàm nhận biết va chạm, Vector.right là viết tắt của (1,0) * transform.localScale.x của nhân vật cho đúng tâm của nhân vật 0.2
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance);

		// Nếu bấm W, không chạm đất, va chạm với vật trước mặt thì nhảy
		if (Input.GetKeyDown (KeyCode.W) && !grounded && hit.collider != null && wallJumping) {
			// Add lực nhảy, hit.normal.x trả lại x theo hướng mặt nhân vật để add lực nhảy theo hướng đó
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (wallJumpspeed * hit.normal.x, wallJumpspeed);
			// Chạy hàm flip để xoay nhân vật
			StartCoroutine ("Flip");
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Vector2 touch = Input.GetTouch (0).position;
			double hafscreen = Screen.width / 2.0;

			// Nếu bấm W, không chạm đất, va chạm với vật trước mặt thì nhảy
			if (touch.x < hafscreen && !grounded && hit.collider != null && wallJumping) {
				// Add lực nhảy, hit.normal.x trả lại x theo hướng mặt nhân vật để add lực nhảy theo hướng đó
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (wallJumpspeed * hit.normal.x, wallJumpspeed);
				// Chạy hàm flip để xoay nhân vật
				StartCoroutine ("Flip");
			}
		}
	}

	void FixedUpdate ()
	{
		// Check đã chạm đất chưa
		grounded = Physics2D.OverlapCircle (point.position, 0.2f, onlyGroundMask);
		//print (grounded);
		if (Input.GetKey (KeyCode.W) && grounded && !wallJumping) {
			//print ("wall" + wallJumping);
			Jump ();
		} else if (Input.GetKey (KeyCode.W) && timer < maxTime && canJump && wallJumping) {
			// + đến maxTime thì ngưng
			timer += Time.deltaTime;
			Jump ();
		}
		// && Input.GetTouch (0).phase == TouchPhase.Stationary
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Vector2 touch = Input.GetTouch (0).position;
			double hafscreen = Screen.width / 2.0;

			if (touch.x < hafscreen && grounded && !wallJumping) {
				//print ("wall" + wallJumping);
				Jump ();
			} else if (touch.x < hafscreen && timer < maxTime && canJump && wallJumping) {
				// + đến maxTime thì ngưng
				timer += Time.deltaTime;
				Jump ();
			}
		}
	}

	// Chạy
	void Run (float runSpeed, float scalesValue)
	{
		// Vận tốc chạy
		rb2d.velocity = new Vector2 (runSpeed * speed, rb2d.velocity.y);
		PlayerScale (scalesValue);
	}

	// Bay
	void Fly (float flySpeed, float scalesValue)
	{
		// Vận tốc bay
		rb2d.velocity = new Vector2 (flySpeed * flyspeed, 8.0f);
		PlayerScale (scalesValue);
	}

	// Phuong thuc Nhảy
	void Jump ()
	{
		// Add lực để nhảy
		//rb2d.AddForce (new Vector2 (0, jumpForce * rb2d.mass * rb2d.gravityScale));
		if (transform.localScale.x > -0.2f) {
			rb2d.velocity = new Vector2 (speed, jumpForce);
		} else {
			rb2d.velocity = new Vector2 (-speed, jumpForce);
		}
	}

	// Lật hình sang trái & sang phải
	void PlayerScale (float scalesValue)
	{
		transform.localScale = new Vector2 (scalesValue * 0.2f, 0.2f);
	}
	
	// Phương thức đợi FixedUpdate xong thì thực thi
	IEnumerator Flip ()
	{
		yield return new WaitForFixedUpdate ();
		// Biến xoay nhân vật, đang quay mặt bên trái thì xoay qua phải và ngược lại trong lúc nhảy trên tường
		transform.localScale = transform.localScale.x == -0.2f ? new Vector2 (0.2f, 0.2f) : new Vector2 (-0.2f, 0.2f);
	}
	
	// Phương thức load lại scene khi nhân vật chết, cho đợi vài giây để animation
	IEnumerator Dead ()
	{
		isdead = true;
		anim.SetBool ("Dizzy", true);
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene (scenename);
	}

	// Phương thức vẽ để thấy khoảng cách
	void OnDrawGizmos ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
	}

	void OnCollisionStay2D (Collision2D other)
	{
		// Set giá trị wallJumping để có thể nhảy trên tường
		if (other.collider.tag == "Wall") {
			wallJumping = true;
		}

		if (other.collider.tag == "Ground") {
			anim.SetBool ("Ground", true);
			anim.SetBool ("Run", true);
			anim.SetBool ("Jump", false);
			canJump = true;
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		// Set giá trị wallJumping để không thể nhảy trên tường
		if (other.collider.tag == "Wall") {
			wallJumping = false;
		}

		if (other.collider.tag == "Ground") {
			anim.SetBool ("Ground", false);
			anim.SetBool ("Run", false);
			anim.SetBool ("Jump", true);
			canJump = false;
			timer = 0;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// Set giá trị canFly để có thể bay hay hok
		if (other.tag == "CanFly") {
			canFly = true;
			anim.SetBool ("Fly", canFly);
			if (!grounded) {
				anim.SetBool ("Ground", canFly);
			}
		} else if (other.tag == "CantFly") {
			canFly = false;
			anim.SetBool ("Fly", canFly);
			if (grounded) {
				anim.SetBool ("Ground", canFly);
			}
		}

		if (other.tag == "Die" || other.tag == "KillPlayer") {
			StartCoroutine ("Dead");
		}
			
		if (other.tag == "Clear") {
			clear = true;
		}

		if (other.tag == "Respawn") {
			transform.position = respawn.transform.position;
		}
	}
}
