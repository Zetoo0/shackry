using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatPanelBaseScript : MonoBehaviour
{
    string chatHi = "Hey I ate my kock KEKW"; 
    string chatWelc = "Welcum ma friend";
    [SerializeField]List<string> chatLis;
    [SerializeField]private int chatTextSpeed;
    

    [SerializeField] TMP_Text text;
    private void Start()
    {
        ListUpload();
        StartCoroutine(WriteTextsOut(chatLis));
    }

    void ListUpload()
    {
        chatLis = new List<string>();
        chatLis.Add(chatHi);
        chatLis.Add(chatWelc);
    }

    private IEnumerator WriteTextsOut(List<string> chatList)
    {
        if(chatList.Count == 0)
        {
            Debug.Log("nulle");
        }
        else
        {
            foreach(string chatT in chatList)
            {
                for (int i = 0; i < chatT.Length; i+=2)
                {
                    text.text += chatT.Substring(i,2);
                    //    Debug.Log(chatList[0].);  
                    yield return new WaitForSecondsRealtime(0.1f);
                }
                yield return new WaitForSecondsRealtime(5.0f);
                text.text = "";
            }
            
            /*chatList.RemoveAt(0);
            //majd implementáljam azt hogy gombnyomás után folytassa a szöveget ha van next elem
            if (chatList.Count != 0)
            {
                
                WriteTextsOut(chatList);
            }*/
        }

      // return null;
    }
}
