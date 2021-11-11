using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Classes
{
#if a
    class tmpClassForTesting
    {

        // filestream for creating a saved text:
        public async Task aaaAsync()
        {
            FileStream destStream = new FileStream(destPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            string destPath = @"C:\test\streets.txt";

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("Score.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);

            await Windows.Storage.FileIO.AppendTextAsync(sampleFile, textToSave + System.Environment.NewLine);
        }
    }



    [Serializable]
  class Tutorial
  {
  public int ID;
  public String Name;
   static void Main(string[] args)
   {
    Tutorial obj = new Tutorial();
    obj.ID = 1;
    obj.Name = ".Net";

    IFormatter formatter = new BinaryFormatter();
    Stream stream = new FileStream(@"E:\ExampleNew.txt",FileMode.Create,FileAccess.Write);

    formatter.Serialize(stream, obj);
    stream.Close();

    stream = new FileStream(@"E:\ExampleNew.txt",FileMode.Open,FileAccess.Read);
    Tutorial objnew = (Tutorial)formatter.Deserialize(stream);

    Console.WriteLine(objnew.ID);
    Console.WriteLine(objnew.Name);

    Console.ReadKey();
  }
 }
#endif
}
