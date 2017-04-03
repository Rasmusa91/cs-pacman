// Rasmus Appelqvist
// 09/01-15
// Project: Pacman

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    /// <summary>
    /// Class that serialize objects to a binary file
    /// </summary>
    public class BinSerializerUtility
    {
        /// <summary>
        /// Serialize the object and save to a binary file
        /// </summary>
        /// <param name="pObject">The object to be serialized</param>
        /// <param name="pFileName">The file the object should be saved to</param>
        /// <returns>If the object could be saved</returns>
        public static void Serialize(object pObject, string pFileName)
        {
            FileStream file = null;

            try
            {
                file = new FileStream(pFileName, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(file, pObject);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }

        /// <summary>
        /// DeSerialize a file and save
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pFileName"></param>
        /// <returns>The loaded object</returns>
        public static T DeSerialize<T>(string pFileName)
        {
            FileStream file = null;
            T obj = default(T);

            try
            {
                file = new FileStream(pFileName, FileMode.Open);

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                obj = (T)binaryFormatter.Deserialize(file);

            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }

            return obj;
        }
    }
}
