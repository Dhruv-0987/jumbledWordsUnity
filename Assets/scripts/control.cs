using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class control : MonoBehaviour
{
    public static control instance;

    public worddata[] optionlist1;
    public worddata[] optionlist2;
    public worddata[] optionlist3;
    public worddata[] optionlist4;
    public worddata[] answerlist1;
    public worddata[] answerlist2;
    public worddata[] answerlist3;
    public worddata[] answerlist4;

    public GameObject displayobject;
    public Text[] displaytext;
    public GameObject[] backgrounds;
    public GameObject complete_message;
    public Text complete_msg_text;
    //int temp1 = answer1.Length();
    private char[] answers1;
    private char[] answers2;
    private char[] answers3;
    private char[] answers4;
    private StringBuilder enter2 = new StringBuilder();
    private StringBuilder enter3 = new StringBuilder();
    private StringBuilder enter4 = new StringBuilder();
    public StringBuilder enter1 = new StringBuilder();
    private StringBuilder finalstring = new StringBuilder();
    private List<string> answer = new List<string>();
    private List<char[]> answers = new List<char[]>();
    private List<worddata[]> optionlist = new List<worddata[]>();
    private List<worddata[]> answerlist = new List<worddata[]>();
    [SerializeField]
    private questiondata questiondata;
    //private List<worddata[]> answerlist = new List<worddata[]>();
    // Start is called before the first frame update
    private int answerindex1; private int answerindex2;
    private int answerindex3; private int answerindex4;
    private int superindex = 0;
    private bool display;
    private int count = 0;
    private List<int> selectedindex1;
    private List<int> selectedindex2;
    private List<int> selectedindex3;
    private List<int> selectedindex4;
    private Gamestatus gamestatus = Gamestatus.Playing;
    private bool word1, word2, word3, word4;
    private string temp1, temp2, temp3, temp4;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        selectedindex1 = new List<int>();
        selectedindex2 = new List<int>();
        selectedindex3 = new List<int>();
        selectedindex4 = new List<int>();
    }
    private void Start()
    {
        optionlist.Add(optionlist1);
        optionlist.Add(optionlist2);
        optionlist.Add(optionlist3);
        optionlist.Add(optionlist4);

        answerlist.Add(answerlist1);
        answerlist.Add(answerlist2);
        answerlist.Add(answerlist3);
        answerlist.Add(answerlist4);
        setoptions(0);
    }


    private void Update()
    {
        displayndisable();
        if (count > 3 && superindex < questiondata.answertoshow.Count())
        {
            Invoke("set_next_level", 2.0f);
            count = 0;
        }
    }

    
    private void set_next_level()
    {
        setoptions(0);
        Debug.Log("here");
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].gameObject.SetActive(true);
        }
        finalstring.Clear();
        
    }

    

    private void displayndisable()
    {
        if (answerindex2 == answer[1].Length)
        {
            temp2 = string.Empty;
            temp2 = enter2.ToString();

            if (temp2 == answer[1].ToUpper())
            {
                word2 = true;
                count++;
                //finalstring.Append(temp2);
                for (int i = 0; i < answerlist2.Length; i++)
                {
                    answerlist2[i].wordtext.text = "";
                    answerlist2[i].gameObject.SetActive(false);
                }
                backgrounds[2].SetActive(false);
                backgrounds[3].SetActive(false);
                if (!display)
                {
                    StartCoroutine(displaymsg(temp2));
                    display = false;
                }

            }
            else
            {
                setoptions(2);
                resetanswerlist(2);
            }
            answerindex2 = 0;
            enter2.Clear();
            
        }

        if (answerindex1 == answer[0].Length)
        {
            temp1 = string.Empty;
            temp1 = enter1.ToString();
            if (temp1 == answer[0].ToUpper())
            {
                count++;
                word1 = true;
                //finalstring.Append( temp1);
                for(int i = 0; i < answerlist1.Length; i++)
                {
                    answerlist1[i].wordtext.text = "";
                    answerlist1[i].gameObject.SetActive(false);
                }
                backgrounds[0].SetActive(false);
                backgrounds[1].SetActive(false);
                if (!display)
                {
                    StartCoroutine(displaymsg(temp1));
                    display = false;
                }
            }
            else
            {
                setoptions(1);
                resetanswerlist(1);
            }
            answerindex1 = 0;
            enter1.Clear();
            
        }

        if (answerindex3 == answer[2].Length)
        {
             temp3 = string.Empty;
             temp3 = enter3.ToString();
           
            
            
            if (temp3 == answer[2].ToUpper())
            {
                count++;
                word3 = true;
                //finalstring.Append( temp3);
                for (int i = 0; i < answerlist3.Length; i++)
                {
                    answerlist3[i].wordtext.text = "";
                    answerlist3[i].gameObject.SetActive(false);
                }
                backgrounds[4].SetActive(false);
                backgrounds[5].SetActive(false);
                if (!display)
                {
                    StartCoroutine(displaymsg(temp3));
                    display = false;
                }
            }
            else
            {
                setoptions(3);
                resetanswerlist(3);
            }
            
            answerindex3 = 0;
            enter3.Clear();
            
        }

        if (answerindex4 == answer[3].Length)
        {
            temp4 = string.Empty;
            temp4 = enter4.ToString();

           
            if (temp4 == answer[3].ToUpper())
            {
                count++;
                word4 = true;
                //finalstring.Append(" "+temp4);
                for (int i = 0; i < answerlist4.Length; i++)
                {
                    answerlist4[i].wordtext.text = "";
                    answerlist4[i].gameObject.SetActive(false);
                }
                backgrounds[6].SetActive(false);
                backgrounds[7].SetActive(false);
                if (!display)
                {
                    StartCoroutine(displaymsg(temp4));
                    display = false;
                }
            }
            else
            {
                setoptions(4);
                resetanswerlist(4);
            }
            answerindex4 = 0;
            enter4.Clear();
            
        }
       
    }
       
       

    private void resetanswerlist(int n)
    {
        if(n == 1)
        {
            for(int i = 0; i < answerlist1.Length; i++)
            {
                answerlist1[i].SetWord(' ');
            }
        }

        if (n == 2)
        {
            for (int i = 0; i < answerlist2.Length; i++)
            {
                answerlist2[i].SetWord(' ');
            }
        }

        if (n == 3)
        {
            for (int i = 0; i < answerlist3.Length; i++)
            {
                answerlist3[i].SetWord(' ');
            }
        }

        if (n == 4)
        {
            for (int i = 0; i < answerlist4.Length; i++)
            {
                answerlist4[i].SetWord(' ');
            }
        }



    }

    IEnumerator displaymsg(string s)
    {
        display = true;
        displayon(s);
        yield return new WaitForSeconds(2);
        displayoff();
        
    }
    int k = 1;
    void displayon(string s)
    {
        if (word1)
        {
            displaytext[0].text = s;
            word1 = false;
        }
        else if (word2)
        {
            displaytext[1].text = s;
            word2 = false;
        }
        else if (word3)
        {
            displaytext[2].text = s;
            word3 = false;
        }
        else if (word4)
        {
            displaytext[3].text = s;
            word4 = false;
        }


        if (count > 3)
        {
            complete_message.SetActive(true);
            complete_msg_text.text = "stage " + k + " complete";
            k++;
        }
    }
    
    void displayoff()
    {   
     complete_message.SetActive(false);
        
    }


    private void setoptions(int n)
    {
        //correctanswer = true;
        gamestatus = Gamestatus.Playing;
        answerindex1 = 0;
        answerindex2 = 0;
        answerindex3 = 0;
        answerindex4 = 0;
        
        if (n == 0)
        {
            word1 = false;
            word2 = false;
            word3 = false;
            word4 = false;
            answer.Clear();
            answers.Clear();
            answers1 = new char[questiondata.answertoshow[superindex].Length];
            answer.Add(questiondata.answertoshow[superindex++]);
            answers2 = new char[questiondata.answertoshow[superindex].Length];
            answer.Add(questiondata.answertoshow[superindex++]);
            answers3 = new char[questiondata.answertoshow[superindex].Length];
            answer.Add(questiondata.answertoshow[superindex++]);
            answers4 = new char[questiondata.answertoshow[superindex].Length];
            answer.Add(questiondata.answertoshow[superindex++]);

            answers.Add(answers1);
            answers.Add(answers2);
            answers.Add(answers3);
            answers.Add(answers4);

            selectedindex1.Clear();
            selectedindex2.Clear();
            selectedindex3.Clear();
            selectedindex4.Clear();
            int x;
            for ( x = 0; x < answer.Count; x++)
            {
                string str = answer[x];
                char[] chr = answers[x];
                worddata[] opt = optionlist[x];
                worddata[] ansopt = answerlist[x];
                for (int i = 0; i < chr.Length; i++)
                {
                    chr[i] = char.ToUpper(str[i]);
                }

                chr = ShuffleList.ShuffleListItems<char>(chr.ToList()).ToArray();
                for (int j = 0; j < chr.Length; j++)
                {
                    ansopt[j].gameObject.SetActive(true);
                    opt[j].gameObject.SetActive(true);
                    opt[j].wordtext.transform.position = opt[j].transform.position;
                    opt[j].SetWord(chr[j]);
                }
               
            }
           
            for(int j = 0; j < 4; j++)
            {
                StringBuilder tempstr = new StringBuilder();
                for(int k = 0; k < answer[j].Length; k++)
                {
                    tempstr.Append("_ ");
                }
                displaytext[j].text = tempstr.ToString();
            }
            
        }

        if(n == 1)

        {
            selectedindex1.Clear();
            string str = answer[n-1];
            char[] chr = answers[n-1];
            worddata[] opt = optionlist[n-1];
            for (int i = 0; i < chr.Length; i++)
            {
                chr[i] = char.ToUpper(str[i]);
            }

            chr = ShuffleList.ShuffleListItems<char>(chr.ToList()).ToArray();
            for (int j = 0; j < chr.Length; j++)
            {
                opt[j].gameObject.SetActive(true);
                opt[j].SetWord(chr[j]);
            }

        }

        if (n == 2)
        {
            selectedindex2.Clear();
            string str = answer[n-1];
            char[] chr = answers[n-1];
            worddata[] opt = optionlist[n-1];
            for (int i = 0; i < chr.Length; i++)
            {
                chr[i] = char.ToUpper(str[i]);
            }

            chr = ShuffleList.ShuffleListItems<char>(chr.ToList()).ToArray();
            for (int j = 0; j < chr.Length; j++)
            {
                opt[j].gameObject.SetActive(true);
                opt[j].SetWord(chr[j]);
            }

        }

        if (n == 3)
        {
            selectedindex3.Clear();
            string str = answer[n-1];
            char[] chr = answers[n-1];
            worddata[] opt = optionlist[n-1];
            for (int i = 0; i < chr.Length; i++)
            {
                chr[i] = char.ToUpper(str[i]);
            }

            chr = ShuffleList.ShuffleListItems<char>(chr.ToList()).ToArray();
            for (int j = 0; j < chr.Length; j++)
            {
                opt[j].gameObject.SetActive(true);
                opt[j].SetWord(chr[j]);
            }

        }

        if (n == 4)
        {
            selectedindex4.Clear();
            string str = answer[n-1];
            char[] chr = answers[n-1];
            worddata[] opt = optionlist[n-1];
            for (int i = 0; i < chr.Length; i++)
            {
                chr[i] = char.ToUpper(str[i]);
            }

            chr = ShuffleList.ShuffleListItems<char>(chr.ToList()).ToArray();
            for (int j = 0; j < chr.Length; j++)
            {
                opt[j].gameObject.SetActive(true);
                opt[j].SetWord(chr[j]);
            }

        }
    }


    
    public void setselectedoption(worddata data)
    {
        
            if (data.CompareTag("first"))
            {
                selectedindex1.Add(data.transform.GetSiblingIndex());
                answerlist1[answerindex1].SetWord(data.getcharvalue());
                enter1.Append(data.getcharvalue());
                data.gameObject.SetActive(false);
                answerindex1++;
            }

            else if (data.CompareTag("firstanswer"))
            {
                answerlist1[answerindex1].wordtext.text = "";
                answerindex1--;
                int index1 = selectedindex1[selectedindex1.Count() - 1];
                optionlist1[index1].gameObject.SetActive(true);
                optionlist1[index1].wordtext.transform.position = optionlist1[index1].wordtext.transform.parent.transform.position;
                Debug.Log(optionlist1[index1].wordtext.text.ToString());
                selectedindex1.RemoveAt(selectedindex1.Count - 1);
                enter1.Remove(enter1.Length - 1, 1);
                data.wordtext.text = " ";


            }

            else if (data.CompareTag("second"))
            {
                selectedindex2.Add(data.transform.GetSiblingIndex());
                answerlist2[answerindex2].SetWord(data.getcharvalue());
                enter2.Append(data.getcharvalue());
                data.gameObject.SetActive(false);
                answerindex2++;
            }

            else if (data.CompareTag("secondanswer"))
            {
                answerlist2[answerindex2].wordtext.text = " ";
                answerindex2--;
                int index2 = selectedindex2[selectedindex2.Count() - 1];
                optionlist2[index2].gameObject.SetActive(true);
                optionlist2[index2].wordtext.transform.position = optionlist2[index2].wordtext.transform.parent.transform.position;
                selectedindex2.RemoveAt(selectedindex2.Count - 1);
                enter2.Remove(enter2.Length - 1, 1);
                data.wordtext.text = " ";

            }

            else if (data.CompareTag("third"))
            {
                selectedindex3.Add(data.transform.GetSiblingIndex());
                answerlist3[answerindex3].SetWord(data.getcharvalue());
                enter3.Append(data.getcharvalue());
                answerindex3++;
                data.gameObject.SetActive(false);
            }

            else if (data.CompareTag("thirdanswer"))
            {
                answerlist3[answerindex3].wordtext.text = " ";
                answerindex3--;
                int index3 = selectedindex3[selectedindex3.Count() - 1];
                optionlist3[index3].gameObject.SetActive(true);
                optionlist3[index3].wordtext.transform.position = optionlist3[index3].wordtext.transform.parent.transform.position;
                selectedindex3.RemoveAt(selectedindex3.Count - 1);
                enter3.Remove(enter3.Length - 1, 1);
                data.wordtext.text = " ";

            }

            else if (data.CompareTag("fourth"))
            {
                selectedindex4.Add(data.transform.GetSiblingIndex());
                answerlist4[answerindex4].SetWord(data.getcharvalue());
                enter4.Append(data.getcharvalue());
                answerindex4++;
                data.gameObject.SetActive(false);
            }

            else if (data.CompareTag("fourthanswer"))
            {
                answerlist4[answerindex4].wordtext.text = " ";
                answerindex4--;
                int index4 = selectedindex4[selectedindex4.Count() - 1];
                optionlist4[index4].gameObject.SetActive(true);
                optionlist4[index4].wordtext.transform.position = optionlist4[index4].wordtext.transform.parent.transform.position;
                selectedindex4.RemoveAt(selectedindex4.Count - 1);
                enter4.Remove(enter4.Length - 1, 1);
                data.wordtext.text = " ";

            }
        
       

    }
    
    public void dragsetselectedoption(draggable input)
    {
        if (input.gameObject.CompareTag("first"))
        {
            selectedindex1.Add(input.transform.parent.transform.GetSiblingIndex());
            string c = input.draggertext.text.ToString();
            //char[] x = c.ToCharArray();
            //answerlist1[answerindex1].wordtext.text = input.draggertext.text;
            enter1.Append(c);
            answerindex1++;
            input.transform.parent.gameObject.SetActive(false);
            Debug.Log(enter1.ToString());
            //input.startposition = new Vector3(0, 0, 0);

        }

        else if (input.gameObject.CompareTag("second"))
        {
            selectedindex2.Add(input.transform.parent.transform.GetSiblingIndex());
            string c1 = input.draggertext.text.ToString();
            char[] x1 = c1.ToCharArray();
            answerlist2[answerindex2].SetWord(x1[0]);
            enter2.Append(c1);
            answerindex2++;
            input.transform.parent.gameObject.SetActive(false);
            Debug.Log(enter2.ToString());

        }

        else if (input.gameObject.CompareTag("third"))
        {
            selectedindex3.Add(input.transform.parent.transform.GetSiblingIndex());
            string c2 = input.draggertext.text.ToString();
            char[] x2 = c2.ToCharArray();
            answerlist3[answerindex3].SetWord(x2[0]);
            enter3.Append(c2);
            answerindex3++;
            input.transform.parent.gameObject.SetActive(false);
            Debug.Log(enter3.ToString());

        }

        else if (input.gameObject.CompareTag("fourth"))
        {
            selectedindex4.Add(input.transform.parent.transform.GetSiblingIndex());
            string c3 = input.draggertext.text.ToString();
            char[] x3 = c3.ToCharArray();
            answerlist4[answerindex4].SetWord(x3[0]);
            enter4.Append(c3);
            answerindex4++;
            input.transform.parent.gameObject.SetActive(false);
            Debug.Log(enter4.ToString());

        }
    }
}


public enum Gamestatus
{
    next, 
    Playing
}


