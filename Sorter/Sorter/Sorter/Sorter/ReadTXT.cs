using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Sorter
{
    class ReadTXT
    {
        
        public List<NameClass> openTxt(String txtPath)
        {
            String line;
            List<NameClass> list = new List<NameClass>();
            NameClass name = new NameClass();
            try
            {
                StreamReader file = new StreamReader(txtPath);
                while ((line = file.ReadLine()) != null)
                {
                    String[] sArr = line.Split(' ');
                    for(int i =0; i< sArr.Length; i++)
                    {
                        if (!"".Equals(sArr[i]))
                        {
                            if (name.firstName==null)
                            {
                                name.firstName = sArr[i];
                            }
                            else
                            {
                                name.lastName = sArr[i];
                            } 
                        }
                        
                    }
                    list.Add(name);
                    name = new NameClass();
                }
                file.Close();
            }
            catch
            {
                list.Clear();
                return list;
            }
            return list;
        }
        public void saveToTxt(String path,IEnumerable<NameClass> sortedName)
        {
            String savePath = path + @"\output.txt";
            StreamWriter file = new StreamWriter(savePath);
            foreach (NameClass name in sortedName)
            {
                if (name.firstName != null || name.lastName != null)
                {
                    file.WriteLine(name.firstName+ " " + name.lastName);
                }
            }
            file.Close();
        }
    }
}
