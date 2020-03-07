using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 30f;
    private float countdown = 45f;

    public Text waveCountdownText;

    public GameManager gameManager;

    private int waveIndex = 0;

    public static Wave waveflag;
    public static int waveindexflag;
    void Start()
    {
        EnemiesAlive=0;
        if(Levelloader.iscomefromload){
            waveflag = waves[PlayerPrefs.GetInt("waveindex")];
            waveIndex=PlayerPrefs.GetInt("waveindex");
        }else{
            waveflag = waves[0];
        }
        
    }
    void Update()
    {
        Levelloader.iscomefromload=false;
        if(waveIndex<waves.Length){
            waveflag = waves[waveIndex];
            waveindexflag=waveIndex;
        }
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        
        for (int i = 0; i < wave.count.Length; i++){
            EnemiesAlive = wave.count[i]+EnemiesAlive;
        }
        for (int i = 0; i < wave.count.Length; i++)
        {
            for (int j = 0; j < wave.count[i]; j++){
                SpawnEnemy(wave.enemy[i]);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        waveIndex++;
        
        
        
        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}