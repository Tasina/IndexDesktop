using DAL.Repository;
using DAL.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Facade
    {
        IDocumentRepo IDRepo;
        ITermRepo ITRepo;
        IIndexRepo IIRepo;

        public IDocumentRepo getDocumentsRepo()
        {
            return IDRepo != null ? IDRepo : IDRepo = new DocumentRepo();
        }


        public IIndexRepo getIndexsRepo()
        {
            return IIRepo != null ? IIRepo : IIRepo = new IndexRepo();
        }

        public ITermRepo getTermsRepo()
        {
            return ITRepo != null ? ITRepo : ITRepo = new TermRepo();
        }
    }
}
