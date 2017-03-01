using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexDesktop
{
    class FileParser
    {
        Facade facade = new Facade();
        public void ReadFiles(string path)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                string fileName;

                fileName = Path.GetFileName(path);

                int position = 0;
                Document document = new Document();
                document.DateCreated = DateTime.Now;
                document.Path = path;
                document.Title = fileName;


                facade.getDocumentsRepo().CreateDocument(document);



                var myFiles = MemoryMappedFile.CreateFromFile(path);
                using (Stream mmStream = myFiles.CreateViewStream())
                {
                    using (StreamReader sr = new StreamReader(mmStream, ASCIIEncoding.ASCII))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] lineWords = line.Split(' ');
                            foreach (string word in lineWords)
                            {
                                string a = word.Replace(",", "");
                                string b = a.Replace(".", "");
                                string c = b.Replace(" ", "");
                                string d = c.Replace(";", "");
                                string e = d.Replace(":", "");
                                string f = e.Replace("?", "");
                                string g = f.Replace("!", "");
                                string h = g.Replace("-", "");
                                h = h.Trim(" ".ToCharArray());

                                if (!string.IsNullOrWhiteSpace(h))
                                {
                                    Term term = new Term();
                                    term.Value = h;
                                    facade.getTermsRepo().CreateTerm(term);

                                    Index index = new Index();
                                    index.Document = document;
                                    index.Term = term;

                                    index.DocId = document.Id;
                                    index.TermId = term.Id;
                                    index.Position = position;

                                    facade.getIndexsRepo().CreateIndex(index);

                                    position += 1;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            watch.Stop();
            double elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine("Files - " + FilePosition);
            //Console.WriteLine("Timer Secounds - " + elapsedMs + " ms");
            //Console.WriteLine("Timer Secounds - " + elapsedMs / 1000 + " s");
            //Console.WriteLine("Timer Minuts - " + elapsedMs / 1000 / 60 + " m");
            //Console.WriteLine("Timer Hours - " + elapsedMs / 1000 / 60 / 60 + " h");
        }
    }
}
