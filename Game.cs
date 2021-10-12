using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
    
    public Animator animator;
    public bool Alive;
    public Shop Shop;
     public Ads Ads;
     public UIControl UIControl;
    public GameObject DoubleBtn;
    public GameObject Enemy;
     public GameObject[] EventsObjects;
    public GameObject Bonus;
    public GameObject Player;
    public GameObject[] Texts;
    public Sprite[] EnemySprites;
    public int Score;
    public int ScoreInGame;
    public Text scoreText;
     public Text ShopScoreText;  
     public Sprite[] ShaftSprites;
    public bool isShaft;
    public int UpgradeGameCount = 0;
    public float SpawnEnemyTime = 2.0f;
    public float SpawnBonusTime = 3.0f;
    public bool sizeevent;
    int death;
  
  public void StartCourtines(){
    StartCoroutine(SpawnEnemy());
    StartCoroutine(FastTextEvent(Texts[2], 5.0f));
  }
   void Spawn()
   {
            GameObject EnemyObj = Instantiate(Enemy, new Vector3(Random.Range(-2.61f, 2.61f), 5f, 0), Quaternion.identity);
            int i = Random.Range(1, ShaftSprites.Length);
             if(isShaft)
            {
            EnemyObj.GetComponent<SpriteRenderer>().sprite = ShaftSprites[i];
            }
            else if (!isShaft)
            {
            EnemyObj.GetComponent<SpriteRenderer>().sprite = EnemySprites[i];
            }
            if (sizeevent)
            {
              EnemyObj.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
            }
   }
  
   void DestroyAllObjects()
 {
    var gameObjects = GameObject.FindGameObjectsWithTag ("enemy");
     for(var i = 0 ; i < gameObjects.Length ; i ++)
     {
         if(gameObjects != null)
     {
         Destroy(gameObjects[i]);
     }
     }
     var gameObjects1 = GameObject.FindGameObjectsWithTag ("bonus");
     for(var i = 0 ; i < gameObjects1.Length ; i ++)
     {
         if(gameObjects1 != null)
     {
         Destroy(gameObjects1[i]);
     }
     }
 }
   public void Death()
   {
          StopAllCoroutines();
          DestroyAllObjects();
          Texts[0].SetActive(false);
          Texts[1].SetActive(false);
          sizeevent = false;
          UIControl.animatorBool(false,"Start");
          Alive = true;
          UIControl.StartButton.interactable = true;
          UpgradeGame(false);
   }
   public void DoubleCoins(){
       Ads.ShowAds();
       ScoreInGame = ScoreInGame * 2;
       SaveScore(ScoreInGame,false);
       DoubleBtn.SetActive(false);
   }
   public void SaveScore(int score, bool inGame){
        Score = PlayerPrefs.GetInt("Save", Score);
       Score += score;
       if(inGame)
       {
           ScoreInGame += score;
       }
       PlayerPrefs.SetInt("Save", Score);
       scoreText.text = ScoreInGame.ToString();
       ShopScoreText.text = Score.ToString();
   }
   public void ScoreAdd()
   {
       SaveScore(1,true);
       
       if(ScoreInGame == 5 && UpgradeGameCount == 0)
       {
        UpgradeGame(true);
       }
       else if(ScoreInGame == 15 && UpgradeGameCount == 1 || ScoreInGame == 20 && UpgradeGameCount == 1)
       {
        EventCreate();
       }
   }

   public void Start()
   {
       isShaft = PlayerPrefs.GetInt("bool") == 1 ? true : false;
     
       if(isShaft) 
       {
           Player.GetComponent<Image>().sprite = ShaftSprites[0];
           Player.GetComponent<Image>().color = new Color32(255,255,255,255);
           RectTransform rt = Player.GetComponent (typeof (RectTransform)) as RectTransform;
           rt.sizeDelta = new Vector2 (80, 80);
       }
   }
    public void shaftMiner()
    {
        if(isShaft == false)
        {
        isShaft = true;
        Score -= 500;
         Player.GetComponent<Image>().sprite = ShaftSprites[0];
          Player.GetComponent<Image>().color = new Color32(255,255,255,255);
          RectTransform rt = Player.GetComponent (typeof (RectTransform)) as RectTransform;
           rt.sizeDelta = new Vector2 (80, 80);
        PlayerPrefs.SetInt("Save", Score);
        ShopScoreText.text = Score.ToString();
        PlayerPrefs.SetInt("bool", isShaft ? 1 : 0);
        }
    }
    public void EventCreate()
    {
       sizeevent = true;
       StartCoroutine(TimerSize());
       StartCoroutine(FastTextEvent(Texts[1], 3.0f));
    }
   public void UpgradeGame(bool Stage)
   {
     if(Stage)
     {
     UpgradeGameCount++;
     SpawnEnemyTime -= 1;
     SpawnBonusTime -= 1;
     StartCoroutine(FastTextEvent(Texts[0], 3.0f));
     StartCoroutine(FastTextEvent(Texts[3], 5.0f));
     }
     else
     {
     UpgradeGameCount = 0;
     SpawnEnemyTime += 1;
     SpawnBonusTime += 1;
     }
   }


   public IEnumerator FastTextEvent(GameObject TextObj, float TimeToRemove)
   {
       TextObj.SetActive(true);
       yield return new WaitForSeconds(TimeToRemove);
       TextObj.SetActive(false);
       StopCoroutine(FastTextEvent(TextObj, TimeToRemove));
   }
   IEnumerator TimerSize()
    {
        yield return new WaitForSeconds(20.0f);
        sizeevent = false;
    }
    public IEnumerator SpawnEnemy()
   {
        while(true)
        {
            yield return new WaitForSeconds(SpawnEnemyTime);
            Spawn();
            if(Random.Range(0,3) >= 2)
            {
                Spawn();
                
            }
            else if (Random.Range(0,3) >= 3) 
            {
                 Spawn();
                 Spawn();
            }
            yield return new WaitForSeconds(SpawnBonusTime);
            
                Instantiate(Bonus, new Vector3(Random.Range(-2.61f, 2.61f), 5f, 0), Quaternion.identity);
        }
   }
}
