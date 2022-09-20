using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charakterTxt;
    [SerializeField] TextMeshProUGUI metinHolderTxt;
    [SerializeField] Image charakterImg;

    public bool metinBittimi;
    public IEnumerator TextiYazdirFNC(string metin,string charakterAd, Sprite charakterSprite,float textDelay,AudioClip clip)
    {
        metinBittimi=false;
        metinHolderTxt.text="";

        charakterTxt.text=charakterAd;
        charakterImg.sprite=charakterSprite;

        for (int i = 0; i < metin.Length; i++)
        {
            metinHolderTxt.text+=metin[i];
            
            yield return new WaitForSeconds(textDelay);
           
        }
        metinBittimi=true;
    }
}
