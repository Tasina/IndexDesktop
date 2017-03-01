using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Impl
{
    class TermRepo : ITermRepo
    {
        public void CreateTerm(Term t)
        {
            using (var db = new SearchDesktopEntities1())
            {
                db.Term.Add(t);
                db.SaveChanges();
            }
        }
    }
}
