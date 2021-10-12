using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIControl : MonoBehaviour
{
    [SerializeField] Game Game;
    
    [SerializeField] Animator animator;
    public Text scoreText;
    [SerializeField] GameObject shopGameObject;
    public Button StartButton;

        public void StartGame()
        {

        if(!animator.GetBool("Start"))
        {
          StartButton.interactable = false;
          ResumeScoreUI();
         Game.StartCourtines();
         animatorBool(true,"Start");
        }
        else
        {
            Game.Alive = !Game.Alive;
           animatorBool(false,"Start");
        }
    }
    void ResumeScoreUI(){
         Game.ScoreInGame = 0;
          scoreText.text = Game.ScoreInGame.ToString();
    }
    public void animatorBool(bool status, string name){
     animator.SetBool(name,status);
    }
    public void OpenShop(){
        
        animatorBool(!animator.GetBool("Shop"),"Shop");
        Game.SaveScore(0, false);
    }
}
