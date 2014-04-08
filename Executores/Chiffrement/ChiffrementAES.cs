using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Executores.Chiffrement
{
    public class ChiffrementAES
    {
        public string chiffrer(string chaine)
        {
            if (chaine != null)
            {
                ICryptoTransform crypteur = obtenirLesParamètres().CreateEncryptor();
                using (MemoryStream msCrypteur = new MemoryStream())
                {
                    using (CryptoStream csCrypteur = new CryptoStream(msCrypteur, crypteur, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swCrypteur = new StreamWriter(csCrypteur))
                        {
                            swCrypteur.Write(chaine);
                        }
                        byte[] bits = msCrypteur.ToArray();
                        return Encoding.Default.GetString(bits);
                    }
                }
            }
            return null;
        }

        public string déchiffrer(string binaire)
        {
            if (binaire != null)
            {
                byte[] bits = Encoding.Default.GetBytes(binaire);
                ICryptoTransform décrypteur = obtenirLesParamètres().CreateDecryptor();
                using (MemoryStream msDécrypteur = new MemoryStream(bits))
                {
                    using (CryptoStream csDécrypteur = new CryptoStream(msDécrypteur, décrypteur, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDécrypteur = new StreamReader(csDécrypteur))
                        {
                            return srDécrypteur.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        private Aes obtenirLesParamètres()
        {
            Aes paramètres = Aes.Create();
            paramètres.Key = Encoding.Default.GetBytes("Epsil0n3Epsil0n3Epsil0n3Epsil0n3");
            paramètres.IV = Encoding.Default.GetBytes("y3sCaB@il1Ff.bck");
            return paramètres;
        }
    }
}
