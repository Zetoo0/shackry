using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ChatSetForACharacter : MonoBehaviour
{
    [SerializeField] List<string> WNames;
    [SerializeField] List<string> Wordiies;
    public Dictionary<string, string> WordiiesWNames;
    //Kirakja amib�l v�laszthat a karakter a k�perny�re �s ut�na azok k�z�l v�laszthat azt�n azt kezdi el ki�rni.
    //Odamegy egy karakterhez �s pl megnyomja az E bet�t, �gy felhozza a v�laszt�men�t ami a dictionaryb�l nyeri ki a Kulcsokat majd ezeknek a value-j�t �rja ki a k�perny�re

    private void Start()
    {
        WordiiesWNames = new Dictionary<string, string>();
        for(int i = 0; i < WNames.Count; i++)
        {
          //  print(WNames[i]);
          //  print(Wordiies[i]);
            WordiiesWNames.Add(WNames[i], Wordiies[i]);                                             
        }

        print(WordiiesWNames["Ap�d"]);
    }
}
