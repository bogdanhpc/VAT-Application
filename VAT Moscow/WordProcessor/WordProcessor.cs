using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using VAT;
using System.Linq;

namespace VAT
{
    public class WordProcessor
    {
        public ICollection<Vat> CheckList { get; set; }

        public WordProcessor(ICollection<Vat> checkList, string fileName)
        {
            CheckList = checkList;
            ExportToWord(fileName);
        }


        private void CreateWordDocument(Word.Document wordDoc)
        {
            object endOfDoc = "\\endofdoc";
            object missing = Type.Missing;
            int rowCount = CheckList.Count;
            int colCount = 5;
            Word.Table table;

            Word.Range range = wordDoc.Bookmarks.get_Item(ref endOfDoc).Range;
            table = wordDoc.Tables.Add(range, rowCount, colCount);

            int indexRow = 1;
            CheckList.Reverse();
            foreach (var item in CheckList)
            {
                table.Cell(indexRow, 1).Range.Text = item.ProductName;
                table.Cell(indexRow, 2).Range.Text = item.Date.ToString();
                table.Cell(indexRow, 3).Range.Text = item.CheckNo;
                table.Cell(indexRow, 4).Range.Text = item.CompanyName + "\r\n" + item.TIN;
                //table.Cell(indexRow, 4).Range.Text = item.TIN;
                table.Cell(indexRow, 5).Range.Text = item.Price.ToString();

                indexRow++;

            }

            //for (int i = rowCount; i >= 0; i--)
            //{
            //    table.Cell(indexRow, 1).Range.Text = CheckList.ProductName;
            //    table.Cell(indexRow, 2).Range.Text = item.Date.ToString();
            //    table.Cell(indexRow, 3).Range.Text = item.CheckNo;
            //    table.Cell(indexRow, 4).Range.Text = item.CompanyName + "\r\n" + item.TIN;
            //    //table.Cell(indexRow, 4).Range.Text = item.TIN;
            //    table.Cell(indexRow, 5).Range.Text = item.Price.ToString();

            //    indexRow++;

            //}
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.AllowAutoFit = true;
            wordDoc.Paragraphs.Add();

        }

        private void ExportToWord(string filename)
        {
            int rowCount = CheckList.Count;
            int colCount = 5;
            object missing = Type.Missing;
            Word.Application wordApp = new Word.Application();
            Word.Document wordDoc = new Word.Document();

            wordApp.Visible = true;
            wordApp.WindowState = Word.WdWindowState.wdWindowStateNormal;
            wordDoc = wordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            wordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            CreateWordDocument(wordDoc);

            SaveDocument(wordApp, filename);
        }

        private void SaveDocument(Word.Application wordApp, string fn)
        {
            object fileName = fn;
            object missing = Type.Missing;
            wordApp.ActiveDocument.SaveAs(ref fileName);
            //wordApp.Quit();
        }
    }
}
