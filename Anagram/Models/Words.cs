using System;
using System.Collections.Generic;

namespace AnagramList.Models
{
  public class Words
  {
    public string InputWord { get; set; }
    public string InputString { get; set; }
    public List<string> InputList = new List<string>();
    
    public Words(string str, string stringList)
    {
      InputWord = str;
      InputString = stringList;
      AddToList();
    }

    public void AddToList()
    {
      //InputList = InputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
      string[] newArr = InputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
      for(int i = 0; i < newArr.Length; i++)
      {
        InputList.Add(newArr[i]);
      }
    }
  }
}