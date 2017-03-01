using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Impl
{
    public class DocumentRepo : IDocumentRepo
    {
        public void CreateDocument(Document d)
        {
            using (var db = new SearchDesktopEntities1())
            {
                db.Document.Add(d);
                db.SaveChanges();
            }
        }
    }
}
