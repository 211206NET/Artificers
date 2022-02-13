using UI;
using System.IO;
using System.Text;
//=============================================================\\
//                   Flash Card NET Program                    \\
//-------------------------------------------------------------\\
 string path = "../DL/Score.json";

//check for existence of Score.json
if(!File.Exists(path))
{
    // Create the file, and give it contents.
    try
    {
    using (FileStream fs = File.Create(path))
    {
        //File.Create("../DL/Score.json");
        byte[] info = new UTF8Encoding(true).GetBytes("[]");
        // Add some information to the file.
        fs.Write(info, 0, info.Length);
    }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

//Proceed to main menu
MenuFactory.GetMenu("main").Start();

//2/1/2022 v1.1
//Note: Scores are saved separately and added to gitignore, so pulling a new version will not erase your scores
//1/17/2022 v1.0
//Note: Scores are not saved separately and added to gitignore, so pulling a new version will erase your scores
