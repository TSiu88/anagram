using System;
using System.Collections.Generic;

namespace AnagramList.Models
{
  public class Words
  {
    public static string InputWord { get; set; }
    public static string InputString { get; set; }
    public static List<string> InputList = new List<string>();
    
    public Words(string str, string stringList)
    {
      InputWord = str;
      InputString = stringList;
      AddToList();
    }

    public void AddToList()
    {
      string[] newArr = InputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
      for(int i = 0; i < newArr.Length; i++)
      {
        InputList.Add(newArr[i]);
      }
    }

    public List<string> AnagramMatch()
    {
      List<string> output = new List<string>();
      string sortedWord = LetterSort(InputWord);
      for(int i = 0; i < InputList.Count; i++)
      {
        string sortedListWord = LetterSort(InputList[i]);
        if(sortedListWord.Equals(sortedWord))
        {
          output.Add(InputList[i]);
        }
        else
        {
          bool matched = PartialMatch(sortedWord, sortedListWord);
          if (matched){
            output.Add(InputList[i]);
          }
        }
      }
      return output;
    }

    public bool PartialMatch(string sortedWord, string sortedListWord)
    {
      int counter = 0;
      for(int i = 0; i < sortedWord.Length; i++)
      {
        for(int j = 0; j < sortedListWord.Length; j++)
          if(sortedWord[i] == sortedListWord[j])
          {
            counter++;
            break;
          }
      }
      float matchFraction = (float)counter/(float)sortedListWord.Length;
      if(matchFraction >= .75){
        return true;
      } else {
        return false;
      }
    }

    private string LetterSort(string word)
    {
      char[] toSort = word.ToCharArray();
      Array.Sort(toSort);
      return new string(toSort);
    }

    public static void ClearAll()
    {
      InputWord = "";
      InputString = "";
      InputList.Clear();
    }
  }
}