using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires.Domaine.Constats
{
    [TestClass]
    public class TestFichier
    {
        [TestMethod]
        public void TestFichier_unFichierAvecLaMauvaisExtensionEstInvalide()
        {
            Stream données = new MemoryStream(Encoding.Default.GetBytes("pouet"));
            Fichier unFichierInvalide = Fichier.initialiser("pouet.bat", données);
            Assert.IsNotNull(unFichierInvalide.Id);
            Assert.AreNotEqual(new Guid(), unFichierInvalide.Id);
            Assert.IsFalse(unFichierInvalide.estValide());
            Assert.IsNull(unFichierInvalide.Données);
        }

        [TestMethod]
        public void TestFichier_unFichierAvecLaBonneExtensionEstValide()
        {
            Stream données = new MemoryStream(Encoding.Default.GetBytes("pouet"));
            Fichier unFichierInvalide = Fichier.initialiser("pouet.doc", données);
            Assert.IsNotNull(unFichierInvalide.Id);
            Assert.AreNotEqual(new Guid(), unFichierInvalide.Id);
            Assert.IsNotNull(unFichierInvalide.Données);
            Assert.IsTrue(unFichierInvalide.estValide());
            Assert.IsNotNull(unFichierInvalide.Données);
        }

        [TestMethod]
        public void TestFichier_unFichierDocumentEstValide()
        {
            Stream données = new MemoryStream(Encoding.Default.GetBytes("pouet"));
            Fichier unFichierValide = Fichier.initialiser("pouet.doc", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnDocument);
            unFichierValide = Fichier.initialiser("pouet.docx", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnDocument);
            unFichierValide = Fichier.initialiser("pouet.odt", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnDocument);
            unFichierValide = Fichier.initialiser("pouet.pdf", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnDocument);
        }

        [TestMethod]
        public void TestFichier_unFichierAudioEstValide()
        {
            Stream données = new MemoryStream(Encoding.Default.GetBytes("pouet"));
            Fichier unFichierValide = Fichier.initialiser("pouet.wav", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnFichierAudio);
            unFichierValide = Fichier.initialiser("pouet.mp3", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnFichierAudio);
            unFichierValide = Fichier.initialiser("pouet.mp4", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnFichierAudio);
        }

        [TestMethod]
        public void TestFichier_unFichierImageEstValide()
        {
            Stream données = new MemoryStream(Encoding.Default.GetBytes("pouet"));
            Fichier unFichierValide = Fichier.initialiser("pouet.jpg", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnFichierImage);
            unFichierValide = Fichier.initialiser("pouet.jpeg", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnFichierImage);
            unFichierValide = Fichier.initialiser("pouet.png", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnFichierImage);
            unFichierValide = Fichier.initialiser("pouet.gif", données);
            Assert.IsTrue(unFichierValide.estValide());
            Assert.IsTrue(unFichierValide.EstUnFichierImage);
        }
    }
}
