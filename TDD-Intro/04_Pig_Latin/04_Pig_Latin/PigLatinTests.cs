using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Pig_Latin
{
    [TestClass]
    public class PigLatinTests
    {
        //Pig Latin

        //Pig Latin is a made-up children's language that's intended to be confusing. It obeys a few simple rules (below) but when it's spoken quickly
        // it's really difficult for non-children (and non-native speakers) to understand.
        //Rule 1: If a word begins with a vowel sound, add an "ay" sound to the end of the word.
        //Rule 2: If a word begins with a consonant sound, move it to the end of the word, and then add an "ay" sound to the end of the word.
        //(There are a few more rules for edge cases, and there are regional variants too, but that should be enough to understand the tests.)
        //See <http://en.wikipedia.org/wiki/Pig_latin> for more details.

        [TestMethod]
        public void TranslateWordBeginningWithAVowel()
        {
            Translator translator = new Translator();
            Assert.AreEqual("appleay", translator.Translate("apple"));
        }
        [TestMethod]
        public void TranslateWordBeginningWithAConsonant()
        {
            Translator translator = new Translator();
            Assert.AreEqual("ananabay", translator.Translate("banana"));
        }
        [TestMethod]
        public void TranslateWordBeginningWithTwoConsonants()
        {
            Translator translator = new Translator();
            Assert.AreEqual("errychay", translator.Translate("cherry"));
        }
        [TestMethod]
        public void TranslateTwoWords()
        {
            Translator translator = new Translator();
            Assert.AreEqual("eatay iepay", translator.Translate("eat pie"));
        }
        [TestMethod]
        public void TranslateWordBeginningWithThreeConsonants()
        {
            Translator translator = new Translator();
            Assert.AreEqual("eethray", translator.Translate("three"));
        }
        [TestMethod]
        public void Count_SCH_AsASinglePhoneme()
        {
            Translator translator = new Translator();
            Assert.AreEqual("oolschay", translator.Translate("school"));
        }
        [TestMethod]
        public void Count_QU_AsASinglePhoneme()
        {
            Translator translator = new Translator();
            Assert.AreEqual("ietquay", translator.Translate("quiet"));
        }
        [TestMethod]
        public void Count_QU_AsAConsonantEvenWhenPreceededByAConsonant()
        {
            Translator translator = new Translator();
            Assert.AreEqual("aresquay", translator.Translate("square"));
        }
        [TestMethod]
        public void TranslateManyWords()
        {
            Translator translator = new Translator();
            Assert.AreEqual("ethay ickquay ownbray oxfay", translator.Translate("the quick brown fox"));
        }
        //Test-driving bonus:
        // write a test asserting that capitalized words are still capitalized (but with a different initial capital letter, of course)
        // retain the punctuation from the original phrase

    }
}
