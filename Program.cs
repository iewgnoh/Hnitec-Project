using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                Console.WriteLine("%%%%% Please select an option %%%%");
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                Console.WriteLine("1.View all files in Image folder\n2.View all files in Text folder\n3.View All files\n4.Perform sorting of files to Image and text folder\n5.Perform Check on abnormal content in Text folder");

                int choice = Convert.ToInt32(Console.ReadLine());
                string path = @"C:\Project\Image";
                string[] pathimg = Directory.GetFiles(path);
                string path2 = @"C:\Project\Text";
                string[] pathtxt = Directory.GetFiles(path2);

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("\n\t1st Option Selected.\n\n");

                        int sn = 0;

                        Console.WriteLine("No\tName and location of the file\t\t\t\t\t\t\t\tType of file");
                        Console.WriteLine("==\t==============================\t\t\t\t\t\t\t\t=============");
                       
                        foreach (string f in pathimg)
                        {
                            FileInfo fi = new FileInfo(f);
                            Console.WriteLine(String.Format("{0,1}\t{1, -80}\t{2}", sn, Path.GetDirectoryName(fi.FullName) + fi.Name, fi.Extension));
                            sn++;
                        }
                        Console.WriteLine("\n\nScan completed!\n");
                        {
                            Console.WriteLine("\nDo you want to delete this file? [Y/N]");
                            string delete;
                            delete = Console.ReadLine();
                            if (delete == "Y" || delete == "y")

                            {
                                Console.WriteLine("Select file number to delete.  To delete file, type file no <comma> file no.  Example: 1, 3, 10");
                                string strOption = Console.ReadLine();
                                string[] strSplit = strOption.Split(new char[] { ',' });
                                foreach (string n in strSplit)
                                {
                                    if (File.Exists(pathimg[Convert.ToInt32(n.Trim())]))
                                    {
                                        File.Delete(pathimg[Convert.ToInt32(n.Trim())]);
                                        Console.WriteLine(n.Trim());
                                        Console.WriteLine(pathimg[Convert.ToInt32(n.Trim())] + "--> File deleted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine(n.Trim());
                                        Console.WriteLine(pathimg[Convert.ToInt32(n.Trim())] + "--> No File deleted.");
                                    }
                                }
                            }
                        }

                        break;

                    case 2:

                        Console.WriteLine("\n\t2nd Option Selected.\n\n");

                        int no = 0;

                        Console.WriteLine("No\tName and location of the file\t\t\t\t\t\t\t\tType of file");
                        Console.WriteLine("==\t==============================\t\t\t\t\t\t\t\t=============");
                       
                        foreach (string f in pathtxt)

                        {
                            FileInfo fi = new FileInfo(f);
                            Console.WriteLine(String.Format("{0,1}\t{1, -80}\t{2}", no, Path.GetDirectoryName(fi.FullName) + fi.Name, fi.Extension));
                            no++;
                        }
                        {
                            Console.WriteLine("\n\nCompleted Scan!\n");
                            Console.WriteLine("\nDo you want to delete this file? [Y/N]");

                            string delete;
                            delete = Console.ReadLine();
                            if (delete == "Y" || delete == "y")
                            {

                                Console.WriteLine("Select file number to delete.  To delete file, type file no <comma> file no.  Example: 1, 3, 10");
                                string strOption2;
                                strOption2 = Console.ReadLine();
                                string[] strSplit2 = strOption2.Split(new char[] { ',' });
                                foreach (string z in strSplit2)
                                {
                                    if (File.Exists(pathtxt[Convert.ToInt32(z.Trim())]))
                                    {
                                        File.Delete(pathtxt[Convert.ToInt32(z.Trim())]);
                                        Console.WriteLine(z.Trim());
                                        Console.WriteLine(pathtxt[Convert.ToInt32(z.Trim())] + "--> File deleted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine(z.Trim());
                                        Console.WriteLine(pathtxt[Convert.ToInt32(z.Trim())] + "--> No File deleted.");
                                    }
                                }
                            }
                        }
                        break;

                    case 3:

                        string AllText = @"C:\Project\Text\";
                        string AllImage = @"C:\Project\Image";
                        string[] All = Directory.GetFiles(AllText, "*", SearchOption.AllDirectories);
                        string[] alli = Directory.GetFiles(AllImage, "*", SearchOption.AllDirectories);

                        Console.WriteLine("{0,-10} {1,-50} {2}", "NO", "Name and location of file", "Type of file");
                        Console.WriteLine("{0,-10} {1,-50} {2}", "==", "=========================", "============");
                        //Displaying all text
                        int i = 0;
                        foreach (string img in alli)
                        {
                            FileInfo im = new FileInfo(img);
                            Console.WriteLine(string.Format("{0,-10} {1,-50} {2}", i, Path.GetDirectoryName(im.FullName) + im.Name, im.Extension));
                            i++;
                        }
                       
                        //Displaying all image
                        foreach (string text in All)
                        {
                            FileInfo textt = new FileInfo(text);
                            Console.WriteLine(string.Format("{0,-10} {1,-50} {2}", i, Path.GetDirectoryName(textt.FullName) + textt.Name, textt.Extension));
                            i++;
                        }

                        Console.WriteLine("\n\nCompleted Scan!");
                        Console.WriteLine("\n\nDo you want to delete the file? (Y/N)");

                        string delete3;
                        delete3 = Console.ReadLine();

                        if (delete3 == "Y" || delete3 == "y")
                        {
                            Console.WriteLine("Select the file to delete. To delete file. Type file NO<Comma>file NO. Example: 1,3");
                            string type3;
                            type3 = Console.ReadLine();
                            string[] a = type3.Split(new char[] { ',' });

                            foreach (string v in a)
                            {
                                int x = Convert.ToInt32(v.Trim());
                                if (x > pathtxt.Length - 1)
                                {
                                    x -= pathtxt.Length;
                                    //x = x - array1.length
                                    File.Delete(pathimg[x]);
                                }
                                else
                                {
                                    File.Delete(pathtxt[x]);
                                }
                                Console.WriteLine("File {0} has been deleted", v);
                            }

                        }
                        else if (delete3 == "N")
                        {
                            Console.WriteLine("No file has been deleted");
                        }


                        break;
                                        

                    case 4:
                        Console.WriteLine("\n\t4th Option Selected.\n\n");
                        {
                            Console.WriteLine("\nFile\t\t\tMove to");
                            Console.WriteLine("===\t\t\t==========");
                        }
                        int imgCounter = 0;
                        int txtCounter = 0;
                        string imagepath = @"C:\Project\Image";
                        string textpath = @"C:\Project\Text";
                        string[] Imagefile = Directory.GetFiles(imagepath);
                        string[] Textfile = Directory.GetFiles(textpath);
                        foreach (string img in Textfile)
                        {
                            FileInfo fi = new FileInfo(img);
                            if (fi.Extension == ".png" || fi.Extension == ".jpg" || fi.Extension == ".jpeg")
                            {
                                File.Move(img, imagepath + "/" + fi.Name);
                                Console.WriteLine("{0} -> {1}", img, imagepath + "/" + fi.Name);
                                imgCounter++;
                            }
                        }
                        foreach (string txt in Imagefile)
                        {
                            FileInfo fi = new FileInfo(txt);
                            if (fi.Extension == ".txt")
                            {
                                File.Move(txt, textpath + "/" + fi.Name);
                                Console.WriteLine("{0} -> {1}", txt, textpath + "/" + fi.Name);
                                txtCounter++;
                            }
                        }
                        Console.WriteLine("\n\nScan Completed!\n");
                        Console.WriteLine("\nTotal Files Sorted: {0}, Text = {1}", imgCounter, txtCounter);

                        break;

                    case 5:

                        Console.WriteLine("\n\t5th Option Selected.\n\n");
                        {
                            
                            Regex r = new Regex(@"[1][A-Za-z0-9]+");
                            string text;

                            int counter = 0;

                            Console.WriteLine("No\tName and location of file\t\t\t\t\t\t\tAbnormal Text detected");
                            Console.WriteLine("==\t==============================\t\t\t\t\t\t\t======================");
                            foreach (string l in pathtxt)
                            {
                                text = File.ReadAllText(l);
                                Match m = r.Match(text);
                                FileInfo fi = new FileInfo(l);
                                if (m.Success)
                                {
                                    Group Abtxt = m.Groups[0];
                                    CaptureCollection CC = Abtxt.Captures;
                                    for (int j = 0; j < CC.Count; j++)
                                    {
                                        Capture C = CC[j];
                                        if (C.Length == 33 || C.Length == 34)
                                        {
                                            Console.WriteLine(String.Format("{0, 2}\t{1,-80}{2} ", counter, Path.GetDirectoryName(fi.FullName) + fi.Name, C.ToString()));
                                            counter++;
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("\n\nCompleted Scan!\n");

                            Console.WriteLine("\nDo you want to delete abnormal content? [Y/N]");

                            string abdel;
                            abdel = Console.ReadLine();
                            if (abdel == "Y" || abdel == "y")
                            {
                                string ab1;
                                ab1 = Console.ReadLine();
                                string[] TxtSplit = ab1.Split(new char[] { ',' });
                                foreach (string g in TxtSplit)
                                {
                                    if (File.Exists(pathtxt[Convert.ToChar(g.Trim())]))
                                    {
                                        File.Delete(pathtxt[Convert.ToInt32(g.Trim())]);
                                        Console.WriteLine(g.Trim());
                                        Console.WriteLine(pathtxt[Convert.ToInt32(g.Trim())] + "--> File deleted.");
                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine(g.Trim());
                                        Console.WriteLine(pathtxt[Convert.ToInt32(g.Trim())] + "--> No File deleted.");
                                    }
                                }

                            }


                        }
                        break;
                }
            }
        }
    }
}
