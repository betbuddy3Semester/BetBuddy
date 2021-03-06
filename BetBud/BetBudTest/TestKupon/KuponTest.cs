﻿using System.Collections.Generic;
using System.Linq;
using ModelLibrary.Models.Kupon;
using NUnit.Framework;

namespace BetBudTest.TestKupon {
    [TestFixture]
    public class KuponTest {
        private readonly List<Kamp> kampe = new List<Kamp>();

        public KuponTest() {
            KampTest testObject = new KampTest();
            kampe.Add(testObject.kamp1);
            kampe.Add(testObject.kamp2);
        }

        // AFVENT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [Test]
        public void BekræftKupon() {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.ElementAt(0), false, true, false);
            kupon.TilføjKamp(kampe.ElementAt(1), true, false, false);
            kupon.Point = 1000;

            //Assert
            //?????????????
        }

        [Test]
        public void FjernKamp() {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.First(), false, false, true);
            kupon.FjernKamp(kampe.First());

            //Assert
            Assert.AreEqual(kupon.delKampe.Count(), 0);
        }

        [Test]
        public void KontrolAfKupon() {
            //Arrange
            //Act
            //Assert
        }

        [Test]
        public void Kontrolleret() {
            //Arrange
            //Act
            //Assert
        }

        [Test]
        public void MuligGevist() {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.ElementAt(0), false, true, false);
            kupon.TilføjKamp(kampe.ElementAt(1), true, false, false);
            kupon.Point = 1000;

            //Assert
            Assert.AreEqual(5760, kupon.MuligGevist());
        }

        [Test]
        public void OddsUdregning() {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.ElementAt(0), false, true, false);
            kupon.TilføjKamp(kampe.ElementAt(1), true, false, false);

            //Assert
            Assert.AreEqual(kupon.OddsUdregning(), 5.76);
        }

        [Test]
        public void TilføjKampTest() {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.First(), true, false, false);

            //Assert
            DelKamp dk = kupon.delKampe.First();
            Assert.AreEqual(kampe.First(), dk.Kampe);
        }
    }
}