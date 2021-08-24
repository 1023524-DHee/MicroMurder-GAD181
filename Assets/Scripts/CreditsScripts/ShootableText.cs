using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableText : MonoBehaviour
{
    private int currentHealth;
    private bool triggered;

    public List<GameObject> bloodPrefabs;
    public AudioClip gunSound;
    public int maxHealth;
    public bool invulnerableText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

	private void Update()
	{
        if (transform.position.y >= 7.5f && !triggered)
        {
            triggered = true;
            Destroy(gameObject);
        }
	}

	private void TakeDamage()
    {
        AudioSource.PlayClipAtPoint(gunSound, transform.position);
        currentHealth--;
        if (currentHealth <= 0)
        {
            EndSceneGEM.current.NameKilled();
            Destroy(gameObject);
        }
    }

	private void OnMouseDown()
	{
        if (!invulnerableText)
        {
            EndSceneGEM.current.TextShot();
            TakeDamage();

            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(bloodPrefabs[Random.Range(0, bloodPrefabs.Count)], new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity, transform);
        }
	}
}
