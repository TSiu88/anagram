using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnagramList.Models;
using System;
using System.Collections.Generic;

namespace AnagramList.Tests
{
  [TestClass]
  public class WordsTests : IDisposable
  {
    public void Dispose()
    {
      Words.ClearAll();
    }
    [TestMethod]
    public void AddToList_AddsItemToInputList_InputList()
    {
      Words myWords = new Words("ball", "bite bool labbo llab");
      List <string> output = new List<string> {"bite", "bool", "labbo", "llab"};
      CollectionAssert.AreEquivalent(output, Words.InputList);
    }
    
    [TestMethod]
    public void AnagramMatch_ReturnsAnagrams_ListOfAnagrams()
    {
      Words myWords = new Words("ball", "bite bool labbo llab");
      List <string> output = new List<string> {"llab"};
      List<string> test = myWords.AnagramMatch();
      for(int i=0; i< test.Count;i++)
      {
        Console.WriteLine("Output: " + test[i]);
      }
      CollectionAssert.AreEquivalent(output,myWords.AnagramMatch());
    }

    [TestMethod]
    public void PartialMatch_MatchHigherThan75_True()
    {
      Words myWords = new Words("ball", "bite bool labb llab");
      string sortedWord = "abht";
      string sortedListWord = "abhtz";
      bool matched = myWords.PartialMatch(sortedWord, sortedListWord);
      Assert.AreEqual(true, matched);
    }

    [TestMethod]
    public void AnagramMatch_ListWithPartialMatches_ListOfAnagrams()
    {
      Words myWords = new Words("ball", "bite bool labb llab");
      List <string> output = new List<string> {"labb", "llab"};
      List<string> test = myWords.AnagramMatch();
      for(int i=0; i< test.Count;i++)
      {
        Console.WriteLine("Output: " + test[i]);
      }
      CollectionAssert.AreEquivalent(output, myWords.AnagramMatch());
    }
  }
}