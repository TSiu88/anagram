using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnagramList.Models;
using System;
using System.Collections.Generic;

namespace AnagramList.Models
{
  [TestClass]
  public class WordsTests
  {
    
    [TestMethod]
    public void AddToList_AddsItemToInputList_InputList()
    {
      Words myWords = new Words("ball", "bite bool labbo llab");
      myWords.AddToList();
      List <string> output = new List<string> {"bite", "bool", "labbo", "llab"};
      CollectionAssert.AreEquivalent(output, myWords.InputList);
    }
  }
}