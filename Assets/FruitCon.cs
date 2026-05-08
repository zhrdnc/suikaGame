using UnityEngine;

public class fruitcon : MonoBehaviour
{
    public bool isDropped = false; 
    public int fruitLevel; 
    public GameObject nextFruitPrefab; 
    private Rigidbody2D rb;
    public float xBound = 2.4f; 
    private bool isMerging = false;

    private static float nextDropTime = 0f; 
    public float dropCooldown = 1.0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (!isDropped) 
        {
            rb.gravityScale = 0;
            GetComponent<Collider2D>().enabled = false; 
        }
    }

    void Update()
    {
        if (!isDropped)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            
            float clampedX = Mathf.Clamp(worldPos.x, -xBound, xBound);
            transform.position = new Vector3(clampedX, transform.position.y, 0);

            if (Input.GetMouseButtonUp(0) && Time.time >= nextDropTime) 
            {
                DropFruit();
            }
        }
    }

    void DropFruit()
    {
        nextDropTime = Time.time + dropCooldown; 
        isDropped = true;
        rb.gravityScale = 1;
        GetComponent<Collider2D>().enabled = true; 
        
        Invoke("RequestNewFruit", 1.0f); 
    }

    void RequestNewFruit()
    {
        FruitSpawner spawner = FindObjectOfType<FruitSpawner>();
        if (spawner != null) spawner.SpawnFruit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Fruit")) return;

        fruitcon other = collision.gameObject.GetComponent<fruitcon>();

        if (other != null && other.fruitLevel == this.fruitLevel && !isMerging && !other.isMerging)
        {
            if (gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
            {
                isMerging = true;
                other.isMerging = true; 
                Merge(collision.transform.position, collision.gameObject);
            }
        }
    }

    void Merge(Vector3 otherPos, GameObject otherObj)
    {
        if (nextFruitPrefab == null) 
        {
            isMerging = false; 
            return; 
        }

        GetComponent<Collider2D>().enabled = false;
        otherObj.GetComponent<Collider2D>().enabled = false;

        Vector3 spawnPos = (transform.position + otherPos) / 2f;
        GameObject newFruit = Instantiate(nextFruitPrefab, spawnPos, Quaternion.identity);
        
        fruitcon newCon = newFruit.GetComponent<fruitcon>();
        if (newCon != null)
        {
            newCon.isDropped = true; 
            Rigidbody2D newRb = newFruit.GetComponent<Rigidbody2D>();
            if (newRb != null)
            {
                newRb.bodyType = RigidbodyType2D.Dynamic;
                newRb.gravityScale = 1.2f;
                newRb.velocity = Vector2.zero; 
            }
        }

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.IncreaseScore((fruitLevel + 1) * 10);
        }

        Destroy(otherObj);
        Destroy(gameObject);

        FruitSpawner spawner = FindObjectOfType<FruitSpawner>();
        if (spawner != null)
        {
            spawner.Invoke("SpawnFruit", 0.5f); 
        }
    }
}