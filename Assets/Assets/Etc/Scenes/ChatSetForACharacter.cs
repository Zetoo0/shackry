using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ChatSetForACharacter : MonoBehaviour
{
    [SerializeField] List<string> WNames;
    [SerializeField] List<string> Wordiies;
    public Dictionary<string, string> WordiiesWNames;
    //Kirakja amibõl választhat a karakter a képernyõre és utána azok közül választhat aztán azt kezdi el kiírni.
    //Odamegy egy karakterhez és pl megnyomja az E betût, így felhozza a választómenüt ami a dictionarybõl nyeri ki a Kulcsokat majd ezeknek a value-ját írja ki a képernyõre

    private void Start()
    {
        WordiiesWNames = new Dictionary<string, string>();
        for(int i = 0; i < WNames.Count; i++)
        {
          //  print(WNames[i]);
          //  print(Wordiies[i]);
            WordiiesWNames.Add(WNames[i], Wordiies[i]);                                             
        }

        print(WordiiesWNames["Apád"]);
    }
}
