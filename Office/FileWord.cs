using System;
using System.Windows;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Office
{
    /// <summary>
    /// Класс для работы с doc файлами от Microsoft Office (создание, сохранение, закрытие)
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class FileWord
    {
        WordprocessingDocument wordDoc;
        MainDocumentPart mainPart;
        Body body;
        Paragraph paragraph;
        Run run;
        Text text;
        public FileWord(string path)
        {
            wordDoc = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document);
            mainPart = wordDoc.AddMainDocumentPart();
            mainPart.Document = new Document(new Body());
            body = mainPart.Document.Body;
        }
        public void addParagraph(string _paragraph)
        {
            paragraph = body.AppendChild(new Paragraph());
            run = paragraph.AppendChild(new Run());
            text = run.AppendChild(new Text(_paragraph));
        }
        public void save()
        {
            wordDoc.MainDocumentPart.Document.Save();
        }
        public void saveChangesAndClose()
        {
            wordDoc.Close();
        }
    }
}

