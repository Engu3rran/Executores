using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Executores
{
    public class Fichier
    {
        public Guid Id { get; set; }
        public DateTime DateDAjout { get; set; }
        public string Nom { get; set; }
        public byte[] Données { get; set; }

        public string Extension
        {
            get
            {
                if (aUnNom())
                {
                    int indexDuDernierPoint = Nom.LastIndexOf('.');
                    return Nom.Substring(indexDuDernierPoint);
                }
                return null;
            }
        }

        public Fichier()
        {
            Id = Guid.NewGuid();
            DateDAjout = DateTime.Now;
        }

        public static Fichier initialiser(string nom, Stream données)
        {
            Fichier fichierInitialisé = new Fichier();
            fichierInitialisé.Nom = nom;
            if (fichierInitialisé.estValide())
                copierLesDonnées(données, fichierInitialisé);
            return fichierInitialisé;
        }

        private static void copierLesDonnées(Stream données, Fichier fichierInitialisé)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                données.CopyTo(ms);
                fichierInitialisé.Données = ms.ToArray();
            }
        }

        public bool EstUnDocument
        {
            get
            {
                string extensionDuFichier = Extension;
                return extensionDuFichier == ".doc"
                       || extensionDuFichier == ".docx"
                       || extensionDuFichier == ".odt"
                       || extensionDuFichier == ".pdf";
            }
        }

        public bool EstUnFichierAudio
        {
            get
            {
                string extensionDuFichier = Extension;
                return extensionDuFichier == ".wav"
                       || extensionDuFichier == ".mp3"
                       || extensionDuFichier == ".mp4";
            }
        }

        public bool EstUnFichierImage
        {
            get
            {
                string extensionDuFichier = Extension;
                return extensionDuFichier == ".jpg"
                       || extensionDuFichier == ".jpeg"
                       || extensionDuFichier == ".png"
                       || extensionDuFichier == ".gif";
            }
        }

        public bool estValide()
        {
            return aUnNom() 
                && estUnFichierAutorisé();
        }

        private bool aUnNom()
        {
            return !string.IsNullOrEmpty(Nom);
        }

        private bool aDesDonnées()
        {
            return Données != null && Données.Length > 0;
        }

        private bool estUnFichierAutorisé()
        {
            return EstUnDocument
                || EstUnFichierAudio
                || EstUnFichierImage;
        }
    }
}
