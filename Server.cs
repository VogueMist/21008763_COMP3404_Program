using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _21008763_COMP3404_Program
{
    public class Server : IServer
    {
        private Dictionary<string, Image> imageStore;

        public Server()
        {
            imageStore = new Dictionary<string, Image>();
            LoadDefaultImages();
        }

        public void LoadDefaultImages()
        {
            string[] defaultFilePaths = Directory.GetFiles("Assets", "*.png");
            foreach (string filePath in defaultFilePaths)
            {
                string fileName = Path.GetFileName(filePath);
                Image tempImage = Image.FromFile(filePath);
                imageStore.Add(fileName, tempImage);
            }
        }

        public IList<string> ComboBox()
        {
            return new List<string>(imageStore.Keys); 
        }

        public IList<string> Load(IList<string> pPathfilenames)
        {
            List<string> uniqueIdentifiers = new List<string>();
            try
            {
                foreach (string filePath in pPathfilenames)
                {
                    Image image = Image.FromFile(filePath);

                    imageStore.Add(Path.GetFileName(filePath), image);
                    uniqueIdentifiers.Add(Path.GetFileName(filePath));
                }
                return uniqueIdentifiers;
            }
            catch (System.Exception ex)
            {
                TomsLogger.Log(LogType.Error, $"{ex.Message}", GetType().Name, MethodBase.GetCurrentMethod());
                return null;
            }
        }

        public Image GetImage(string pUid, int pFrameWidth, int pFrameHeight)
        {
            if (imageStore.ContainsKey(pUid))
            {
                Image originalImage = imageStore[pUid];
                // Add scaling to image, how is that going to work? --TODO
                TomsLogger.Log(LogType.Log, $"Image displayed: {pUid}", GetType().Name, MethodBase.GetCurrentMethod());
                return originalImage;
            }
            else
            {
                // Add exception or add sample image if image was not found in the dictionary --TODO
                TomsLogger.Log(LogType.Error, "Could not GetImage", GetType().Name, MethodBase.GetCurrentMethod());
                return null;
            }
        }
    }
}