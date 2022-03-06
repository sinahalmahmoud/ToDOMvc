using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample
{
    [TestClass]
    public class EdgeDriverTest
    {
        private const string edgeDriverDirectory = ".";
        private const string bradUrl = "http://127.0.0.1:5500/ToDo10/index.html#";
        private EdgeDriver browser;

        // This is run before each test.
        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            browser = new EdgeDriver(edgeDriverDirectory);
            // We want to go to the same URL for all tests.
            browser.Url = bradUrl;
        }

        [TestMethod]
        public void CheckPageTitle()
        {
            // Check the page title.
            Assert.AreEqual("Todo List App", browser.Title);


        }

        [TestMethod]
        public void CheckItemAdded()
        {


            // Find the search input at the top of the page.
            var input = browser.FindElementByCssSelector(".input_text");

            // Type into it.
            input.SendKeys("swim");
            // Press Enter
            input.SendKeys(Keys.Enter);

            Assert.AreEqual("swim", browser.FindElementByCssSelector(".todo-text").Text);

        }
        [TestMethod]
        public void CheckNumberLeft()
        {
            var input1 = browser.FindElementByCssSelector(".input_text");
            input1.SendKeys("football");
            input1.SendKeys(Keys.Enter);

            Assert.AreEqual("1", browser.FindElementByCssSelector("#uncompleted").Text);
            var check = browser.FindElementByCssSelector(".toggle");
            check.Click();
            Assert.AreEqual("0", browser.FindElementByCssSelector("#uncompleted").Text);
        }
       
        
        [TestMethod]
        public void CheckallList()
        {
            var input = browser.FindElementByCssSelector(".input_text");
            input.SendKeys("run");
            input.SendKeys(Keys.Enter);
            input.SendKeys("shopping");
            input.SendKeys(Keys.Enter);
            input.SendKeys("eat");
            input.SendKeys(Keys.Enter);
            Assert.AreEqual("3", browser.FindElementByCssSelector("#uncompleted").Text);
            var check = browser.FindElementByCssSelector(".toggle");
            check.Click();
            Assert.AreEqual("2", browser.FindElementByCssSelector("#uncompleted").Text);

           

        }
        
        /*
                [TestMethod]
                public void CheckMovieWithImplicitWait()
                {
                    // If some parts of the page might not be available after the initial page load, tell the browser to allow for a few seconds to pass whenever calling the "Find" methods. We should set this at the start of the test, and it will apply whenever we use the "Find" methods.
                    browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    // Check if the text "Burn After Reading" appears *anywhere* on the page. Do this by getting the Text property of the root element, which returns all of the *visible* text on the page in a single string.
                    // It should not appear, because by default Burn After Reading is hidden inside a collapsed section.
                    var root = browser.FindElementByCssSelector("html");
                    Assert.IsFalse(root.Text.Contains("Burn After Reading"));

                    // Now click the section header to expand the section.
                    var link = browser.FindElementByLinkText("Actor");
                    link.Click();

                    // The above operation will take some time to complete, because the page needs to load the movies that were previously hidden. Luckily, our ImplicitWait setting will make the browser automatically wait (for up to the specified amount of time) if an element is not available immediately.
                    // "tt0887883" is the ID of the movie that we are looking for. We found this by examining the HTML of the page.
                    var movieLink = browser.FindElementByCssSelector("#actor-tt0887883 a");

                    // Finally, check that "Burn After Reading" is now visible on the page.
                    Assert.AreEqual("Burn After Reading", movieLink.Text);
                }

                // This test uses a different kind of waiting than the previous one: explicit rather than implicit. With explicit waits, the browser does not automatically wait whenever we try to find an element. Instead, we need to explicitly state when to wait, and what condition to wait for. It also uses a more "fuzzy" assertion because it just looks for the movie title anywhere on the page, which might be more difficult to do with implicit wait because it does not actually call one of the Find methods to do it. (Only Find methods automatically wait when using implicit waits.)
                [TestMethod]
                public void CheckMovieWithExplicitWait()
                {
                    // Click the link.
                    var link = browser.FindElementByLinkText("Actor");
                    link.Click();

                    // Wait until the movie has appeared.
                    var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(5));
                    var root = browser.FindElementByCssSelector("html");
                    wait.Until(b => root.Text.Contains("Burn After Reading"));

                    // Optionally make an assertion. (Optional because Wait will throw an exception if the specified condition does not become true in time, in turn also automatically failing the test.)
                    // Assert.IsTrue(root.Text.Contains("Burn After Reading"));
                }

                [TestMethod]
                public void CheckMovieSearch()
                {
                    // Find the search input at the top of the page.
                    var searchInput = browser.FindElementByCssSelector("#suggestion-search");

                    // Type "Troy" into it.
                    searchInput.SendKeys("Troy");

                    // Wait until there is at least one link in the suggestion dropdown that appears. (It takes a while because the page is loading the data from the server.)
                    var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(5));
                    wait.Until(b => browser.FindElementByCssSelector(".imdb-header__search-menu a"));

                    // Press Down followed by Enter.
                    searchInput.SendKeys(Keys.ArrowDown);
                    searchInput.SendKeys(Keys.Enter);

                    // The browser will automatically wait until the new page has loaded. After that, check that we are on the Troy page as expected.
                    Assert.AreEqual("Troy (2004) - IMDb", browser.Title);
                }

                // This is run after each test.
                [TestCleanup]
                public void EdgeDriverCleanup()
                {
                    browser.Quit();
                }
            }*/
    }
} 