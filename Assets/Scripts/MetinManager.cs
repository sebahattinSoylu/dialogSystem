using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetinManager : MonoBehaviour
{
   [SerializeField] List<MetinData> metinler;
   [SerializeField] Transform metinPanel_1,metinPanel_2;

   [SerializeField] AudioClip clip;

   string characterAd,metin;
   Sprite characterSprite;

   int kacinciMetin;
   [SerializeField] float beklemeSuresi;

   private void Start() 
   {
        //characterAd=metinler[0].characterName;
        //metin=metinler[0].metin;
        //characterSprite=metinler[0].characterSprite;
        

        //StartCoroutine(metinPanel_1.GetComponent<DialogSystem>().TextiYazdirFNC(metin,characterAd,characterSprite,0.1f,clip));
        StartCoroutine(DialogYazFNC());
   }


    IEnumerator DialogYazFNC()
    {
        characterAd=metinler[kacinciMetin].characterName;
        metin=metinler[kacinciMetin].metin;
        characterSprite=metinler[kacinciMetin].characterSprite;

        TumPanelleriKapat();

        if(kacinciMetin%2==0)
        {
            metinPanel_1.gameObject.SetActive(true);
            StartCoroutine(metinPanel_1.GetComponent<DialogSystem>().TextiYazdirFNC(metin,characterAd,characterSprite,0.1f,clip));
            yield return new WaitUntil(()=>metinPanel_1.GetComponent<DialogSystem>().metinBittimi);

        } else
        {
             metinPanel_2.gameObject.SetActive(true);
            StartCoroutine(metinPanel_2.GetComponent<DialogSystem>().TextiYazdirFNC(metin,characterAd,characterSprite,0.1f,clip));
            yield return new WaitUntil(()=>metinPanel_2.GetComponent<DialogSystem>().metinBittimi);
        }

        yield return new WaitForSeconds(beklemeSuresi);

        kacinciMetin++;

        YeniCumleyeGec();

    }

    void YeniCumleyeGec()
    {
        if(kacinciMetin>=metinler.Count)
            kacinciMetin=0;

        StartCoroutine(DialogYazFNC());
    }
   void TumPanelleriKapat()
   {
        metinPanel_1.gameObject.SetActive(false);
        metinPanel_2.gameObject.SetActive(false);
   }
}
