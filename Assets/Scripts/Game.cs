using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	private int maxWaveLenght = 3;
	private float maxHealth;
	private int highscorevalue;
	public GameObject Player;
	public GameObject[] Mobs;
	public GameObject gameoverScrenn;
	public int maxScore;
	public int currentScore;
	public float mobSpawnRate;
	private float lastmobspawned;
	public float distMin;
	public float distMax;
	public Image healthbar;
	public TextMeshProUGUI highscore;
	public TextMeshProUGUI curscrore;
	
	
	// Use this for initialization
	void Start ()
	{
		highscorevalue = PlayerPrefs.GetInt("Highscore");
		highscore.text = highscorevalue.ToString();
		maxHealth = Player.GetComponent<PLayerController>().Health;
	}

	public void retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Player.GetComponent<PLayerController>().Health < 0)
		{
			gameoverScrenn.SetActive(true);
			return;
		}
		
		healthbar.fillAmount = Player.GetComponent<PLayerController>().Health / maxHealth;
		healthbar.color = Color.Lerp(Color.red, Color.white, healthbar.fillAmount);
		
		curscrore.text = currentScore.ToString();
		if (currentScore > highscorevalue)
		{
			highscore.text = curscrore.text;
			highscorevalue = currentScore;
		}
		lastmobspawned -= Time.deltaTime;
		if (lastmobspawned <= 0 )
		{
			var waveLenght = Random.Range(3, maxWaveLenght);
			for (int i = 0; i < waveLenght; i++)
			{
				var mob = Instantiate(Mobs[Random.Range(0, Mobs.Length)]);
				var vector2 = Random.insideUnitCircle.normalized * Random.Range(distMin, distMax);
				var position = new Vector3(vector2.x, 0, vector2.y);
				mob.transform.position = position;
				
			}

			maxWaveLenght += 2;
			mobSpawnRate *= 0.99f;
			lastmobspawned = mobSpawnRate;
		}
	}


	private void OnDestroy()
	{
		highscorevalue = PlayerPrefs.GetInt("Highscore");
		if (currentScore > highscorevalue) 
		{
			PlayerPrefs.SetInt("Highscore", currentScore);
		}
	}
}
