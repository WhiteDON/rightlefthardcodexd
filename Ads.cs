using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class Ads : MonoBehaviour
{
    public Game Game;
    
        public void Start() {
        if(Advertisement.isSupported){
            Advertisement.Initialize(".....",false);
        }
    }
    public void ShowAds(){
    if(Advertisement.IsReady()){
        Advertisement.Show("Interstitial_Android");
        Game.SaveScore(10, false);
    }
    }
}
