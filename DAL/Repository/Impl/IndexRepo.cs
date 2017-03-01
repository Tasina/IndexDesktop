using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Impl
{
    public class IndexRepo : IIndexRepo
    {
        public void CreateIndex(Index i)
        {
            using (var db = new SearchDesktopEntities1())
            {
                db.Index.Add(i);
                db.SaveChanges();
            }
        }
    }
}
