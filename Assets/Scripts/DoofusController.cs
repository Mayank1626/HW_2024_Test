using UnityEngine;
using TMPro;


[System.Serializable]
public class GameConfig
{
    public PlayerData player_data;
    public PulpitData pulpit_data;

    [System.Serializable]
    public class PlayerData
    {
        public float speed;
    }

    [System.Serializable]
    public class PulpitData
    {
        public float min_pulpit_destroy_time;
        public float max_pulpit_destroy_time;
        public float pulpit_spawn_time;
    }
}

public class DoofusController : MonoBehaviour
{
    public float speed = 3.0f; 
    public TextMeshProUGUI gameOverText; 
    private bool isGameOver = false;
    private float fallThreshold = -5.0f;

    void Start()
    {
       
        TextAsset jsonTextAsset = Resources.Load<TextAsset>("game_config");
        if (jsonTextAsset != null)
        {
            string jsonText = jsonTextAsset.ToString();
            GameConfig config = JsonUtility.FromJson<GameConfig>(jsonText);

            
            speed = config.player_data.speed;
        }
        else
        {
            Debug.LogError("Failed to load");
        }
    }

    void Update()
    {
        if (isGameOver) return;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement);
        if (transform.position.y < fallThreshold)
        {
            GameOver(); 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Pulpit"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true); 
        Time.timeScale = 0;
    }
}
