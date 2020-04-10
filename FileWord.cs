using System;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace Work_Creator
{
    /// <summary>
    /// Класс для работы с Doc файлами (создание, наполнение, сохранение)
    /// </summary>
    /// <remarks>
    ///                      как работать с классом  
    /// для начало нужно создать процесс WordOffice с помощью метода createDoc;
    /// устанавливаем шаблон документа(шрифты, выравнивание, отступы итд) с помощью метода
    /// setDefaultOption... в завимости от вида работы;
    ///                                     делаем наполнение с помощью addContent... в завимости от вида работы; ????
    /// сохраняем документ с помощью метода saveDoc;
    /// закрываем документ с помощью метода closeDoc;
    /// </remarks>
    public class FileWord 
    {
        const string CM = "см/с";
        const string RAD = "рад/с";
        private Word.Application wordApp; // для открытия приложения
        //private Word.Documents wordDocuments; // для создания документа
        private Word.Document wordDocument;
        private Word.Paragraph wordParagraph; // для работы с параграфом
        public Word.Paragraphs wordParagraphs;
        public FileWord()
        {
            /*----------------------------------*/
            /*----------запуск Word-------------*/
            /*----------------------------------*/
            try
            {
                wordApp = new Word.Application();
                //wordApp.Visible = true; // отладочное, после удалить
            }
            catch (Exception ex)
            {
                MessageBox.Show("Word не получилось открыть:\n" + ex.Message);
            }
        }
        private void Test(string Name)
        {
            // переделать
            object begin = 5;
            object end = Type.Missing;
            Word.Range wordRange = wordDocument.Range(ref begin, ref end);
            for (int i = (int)begin; i < wordRange.Text.Length; i++)
            {
                if(wordRange.Text[i] == 'O')
                {
                  wordRange.Text = wordRange.Text[i + 1].ToString();
                  wordRange.Font.Subscript = 7;
                }
            }
            wordRange.Font.Size = 20;
        }
        private void addParagraph(int count)
        {
            object oMissing = System.Reflection.Missing.Value;
            for (int i = 0; i < count; i++)
                wordDocument.Paragraphs.Add(ref oMissing);
        }
        internal void createDoc()
        {
            object template = Type.Missing;
            object newTemplate = false;
            object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            object visible = true;
            wordDocument = wordApp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
        }
        internal void setDefaultOptionRGR()
        {
            wordDocument.Content.Font.Name = "Times New Roman";
            wordDocument.Content.Font.Size = 14;
        }
        internal void addElementO1A(float WO1A, float O1A, float countV)
        {
            addParagraph(2);
            wordParagraphs = wordDocument.Paragraphs;
            // параграф 1
            wordParagraph = (Word.Paragraph)wordParagraphs[1];
            wordParagraph.Range.Text = "Звено " + "O1A" + ":";
            // параграф 2
            wordParagraph = (Word.Paragraph)wordParagraphs[2];
            wordParagraph.Range.Text = "VA = WO1A * O1A = " + WO1A + " + " + O1A + " = " + countV +  " " + CM + ";";
        }
        internal void addElements(Element element, Element elementO)
        {
            addParagraph(1);
            wordParagraphs = wordDocument.Paragraphs;
            // Звено (имя звена): точка * полюс
            wordParagraph = (Word.Paragraph)wordParagraphs.Last;
            wordParagraph.Range.Text = "Звено " + element.Name + ", " + elementO.Name + ": " + "точка " + element.Name[0] + " полюс";
            // V(вторая буква звена) = V(первая буква звена) + V(вторая и первая буква звена);
            addParagraph(1);
            wordParagraph = (Word.Paragraph)wordParagraphs.Last;
            wordParagraph.Range.Text = "V" + element.Name[1] + " = " + "V" + element.Name[0] + " + V" + element.Name[1] + element.Name[0] + ";";
            // V(вторая буква звена) = о(вторая буква звена) * 2 = значение * 2 = результат + см / с + ;
            addParagraph(1);
            wordParagraph = (Word.Paragraph)wordParagraphs.Last;
            wordParagraph.Range.Text = "V" + element.Name[1] + " = " + "o" + element.Name[1] + " * 2 = " + element.Length + " * 2 = " + element.DoubleLength(element.Length) + ";";



            //W(имя звена) = скорость (вторая буква звена) / имя звена = значение / значение = результат рад / с + ;
            addParagraph(1);
            wordParagraph = (Word.Paragraph)wordParagraphs.Last;
            wordParagraph.Range.Text = "W";
        }
        internal void saveDoc()
        {
            object fileName = @"E:\New\test.doc";
            object fileFormat = Word.WdSaveFormat.wdFormatDocument;
            object lockComments = false;
            object password = "";
            object addToRecentFiles = false;
            Object writePassword = "";
            Object readOnlyRecommended = false;
            Object embedTrueTypeFonts = false;
            Object saveNativePictureFormat = false;
            Object saveFormsData = false;
            Object saveAsAOCELetter = Type.Missing;
            Object encoding = Type.Missing;
            Object insertLineBreaks = Type.Missing;
            Object allowSubstitutions = Type.Missing;
            Object lineEnding = Type.Missing;
            Object addBiDiMarks = Type.Missing;
            wordDocument.SaveAs2(ref fileName, ref fileFormat, ref lockComments,
                                 ref password, ref addToRecentFiles, ref writePassword,
                                 ref readOnlyRecommended, ref embedTrueTypeFonts,
                                 ref saveNativePictureFormat, ref saveFormsData,
                                 ref saveAsAOCELetter, ref encoding, ref insertLineBreaks,
                                 ref allowSubstitutions, ref lineEnding, ref addBiDiMarks);
        }
        internal void closeDoc()
        {
            object saveChanges = Word.WdSaveOptions.wdSaveChanges;
            object originalFormat = Word.WdOriginalFormat.wdWordDocument;
            object routeDocument = Type.Missing;
            wordApp.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
            wordApp = null;
        }
    }
}

/*
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
есть OpenXML SDK для работы с XML внутри word
 */
