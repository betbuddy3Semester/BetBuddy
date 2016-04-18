using ModelLibrary;
using ModelLibrary.Interface_Bruger;
using NUnit.Framework;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary.Bruger;
using Assert = NUnit.Framework.Assert;

namespace BetBudTest
{
    [TestFixture]
    public class BrugerTest
    {
        #region BrugernavnTest
        /// <summary>
        /// Testing to see if the name is actually what we want.
        /// </summary>
        [Test]
        public void TestGetBrugerNavn()
        {
            IBruger stub = new Bruger();
            stub.BrugerNavn = "BrugerNavn";
            Assert.AreEqual("BrugerNavn", stub.BrugerNavn);
        }

        /// <summary>
        /// Testing to see if I can set the username
        /// </summary>
        [Test]
        public void TestSetBrugerNavn()
        {
            IBruger stub = new BrugerStub();
            Assert.AreEqual("BrugerNavn", stub.BrugerNavn);

            stub.BrugerNavn = "BrugerNavnTest";

            Assert.AreEqual("BrugerNavnTest", stub.BrugerNavn);
        }
        #endregion

        #region NavnTest 
        /// <summary>
        /// Tests to see if we get the name out properly
        /// </summary>
        [Test]
        public void TestGetNavn()
        {
            BrugerStub stub = new BrugerStub();
            Assert.AreEqual("Navn", stub.Navn);
        }

        /// <summary>
        /// Testing to see if we can set the name properly
        /// </summary>
        [Test]
        public void TestSetNavn()
        {
            BrugerStub stub = new BrugerStub();
            Assert.AreEqual("Navn", stub.Navn);

            stub.Navn = "NavnTest";

            Assert.AreEqual("NavnTest", stub.Navn);
        }
        #endregion

        #region Alias

        /// <summary>
        /// Test to see if we can get the alias correctly
        /// </summary>
        [Test]
        public void TestGetAlias()
        {
            IBruger stub = new BrugerStub();
            Assert.AreEqual("Alias", stub.Alias);
        }

        /// <summary>
        /// Tests to see if we can set the alias correctly
        /// </summary>
        [Test]
        public void TestSetAlias()
        {
            IBruger stub = new BrugerStub();
            Assert.AreEqual("Alias", stub.Alias);

            stub.Alias = "TestAlias";

            Assert.AreEqual("TestAlias", stub.Alias);
        }

        #endregion

        #region Email
        /// <summary>
        /// Test to see if we can get the email correctly
        /// </summary>
        [Test]
        public void TestGetEmail()
        {
            IBruger stub = new BrugerStub();
            Assert.AreEqual("Email", stub.Email);
        }
        /// <summary>
        /// Test to see if we can set the email correctly
        /// </summary>
        [Test]
        public void TestSetEmail()
        {
            IBruger stub = new BrugerStub();
            Assert.AreEqual("Email", stub.Email);

            stub.Alias = "TestEmail";

            Assert.AreEqual("Email", stub.Email);
        }
        #endregion
    }
}
