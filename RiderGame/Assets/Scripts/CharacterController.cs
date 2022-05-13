using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
	private Collider2D collider2D;

	public Transform DeadBody;

	public Transform SpawnPoint;
	int deathTriggerCount = 1;


	Animator animator;
	Rigidbody2D rb;


	private void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		collider2D = GetComponent<Collider2D>();
		Time.timeScale = 1;
	}

	public void killMe()
	{
		transform.position = SpawnPoint.position;
	}

	private void FixedUpdate()
	{
		deathTriggerCount = 1;	
	}


	public void Die()
    {
		collider2D.enabled = false;
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Ouille")
		{
			--deathTriggerCount; //Cette variable sert a ne pas respawn plusieur fois au cas ou le joueur touche differnets "ouille" à la meme frame
			if (deathTriggerCount == 0)
			{
				DeadBody.position = transform.position;
				DeadBody.GetComponent<Rigidbody2D>().velocity = rb.velocity;

				transform.position = SpawnPoint.position;
				rb.velocity = Vector3.zero;

			}
		}

		switch (col.name)
		{
			case "TriggerSuccess":
				PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel") + 1);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
				break;		
		}
	}

}
 