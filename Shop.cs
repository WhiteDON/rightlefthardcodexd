using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   
 
   public Text caption;
   public Text priceText;
   public GameObject ShopImage;
   public Sprite[] shopSprites;
   public int number = 1;
   public int[] price;
   public Game Game;
   public Ads Ads;
   
   public void Start()
   {
     price = new int[] {500,500,200,300,400};
     caption.text = "Shaft Miner";
     priceText.text = price[number].ToString();
   }

   public void Next()
   {
    number++;
    switch (number)
      {
          case 1:
              caption.text = "Shaft Miner";
              priceText.text = price[number].ToString();
              ShopImage.GetComponent<Image>().sprite = shopSprites[0];
              break;
          case 2:
              caption.text = "Soon...";
              priceText.text = price[number].ToString();
              ShopImage.GetComponent<Image>().sprite = shopSprites[1];
              break;
          case 3:
               caption.text = "Soon...";
               priceText.text = price[number].ToString();
               ShopImage.GetComponent<Image>().sprite = shopSprites[2];
               break;
         
          default:
              number = 3;
              caption.text = "Soon...";
              ShopImage.GetComponent<Image>().sprite = shopSprites[2];
              priceText.text = price[number].ToString();
              break;
      }
   }
   public void BuyShaft()
   {
      if(Game.Score >= 500)
      {
        Game.shaftMiner();
      }
      else{
         Debug.Log("nem");
      }
   }
   public void ShowAdForPoints(){
     Ads.ShowAds();
   }
   public void Prev()
   {
    number--;
    switch (number)
      {
          case 1:
              caption.text = "Shaft Miner";
              priceText.text = price[number].ToString();
              ShopImage.GetComponent<Image>().sprite = shopSprites[0];
              break;
          case 2:
              caption.text = "Soon...";
              priceText.text = price[number].ToString();
              ShopImage.GetComponent<Image>().sprite = shopSprites[1];
              break;
          case 3:
               caption.text = "Soon...";
               priceText.text = price[number].ToString();
               ShopImage.GetComponent<Image>().sprite = shopSprites[2];
               break;
          default:
              number = 1;
              caption.text = "Shaft Miner";
              ShopImage.GetComponent<Image>().sprite = shopSprites[0];
              priceText.text = price[number].ToString();
              break;
      }
   }
}
