using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;
using Processing.Document;
using ResourceLibrary;
using ResourceLibrary.Properties;
using GemBox.Document;

namespace University.Documents
{
    public class ContractDocument : OpenXmlDocument
    {
        public ContractDocument(StudentContract _contract)
        {
            contract = _contract;
            DocumentType = OpenXmlDocumentType.Document;
        }

        StudentContract contract;

        public override void CreatePackage(string fileName)
        {
            var doc = DocumentModel.Load(Extractor.ExtractDocument(Resources.StudentContract));
            doc.Save(fileName);
        }
    }
}
