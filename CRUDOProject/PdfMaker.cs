using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Repository.Models;

namespace CRUDOProject
{
    public class PdfMaker
    {
        private Advertisement advertisement;
        public PdfMaker (Advertisement ad)
        {
            advertisement = ad;
        }

        public MemoryStream GeneratePdf(MemoryStream ms)
        {
            StringBuilder status = new StringBuilder("");
            Document doc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            PdfPTable table = new PdfPTable(2);

            PdfWriter.GetInstance(doc, ms).CloseStream = false;
            doc.Open();
            doc.Add(AddContentToPdf(table));

            doc.Close();

            byte[] byteInfo = ms.ToArray();
            ms.Write(byteInfo, 0, byteInfo.Length);
            ms.Position = 0;

            return ms;

        }



        private PdfPTable AddContentToPdf(PdfPTable table)
        {

            Image image;

            using (MemoryStream ms = new MemoryStream(advertisement.Image))
            {
                image = Image.GetInstance(ms);
            }

            image.ScaleAbsolute(120f, 155f);


            table.AddCell(new Phrase("Tytul: "));
            table.AddCell(new Phrase(advertisement.Title));
            table.AddCell(new Phrase("Opis: "));
            table.AddCell(new Phrase(advertisement.Content));
            table.AddCell(new Phrase("Cena: "));
            table.AddCell(new Phrase(advertisement.Price.ToString() + " PLN"));
            table.AddCell(new Phrase("Data dodania:"));
            table.AddCell(new Phrase(advertisement.AddTime.ToString("yyy-MM-dd")));
            table.AddCell(new Phrase("Kategoria: "));
            table.AddCell(new Phrase(advertisement.Categories.Title));
            table.AddCell(new Phrase("Zdjęcie: "));
            table.AddCell(new PdfPCell(image));
            table.AddCell(new Phrase("Kontakt: "));
            table.AddCell(new Phrase(advertisement.InternalUser.EmailAddress));

            return table;



        }

    }
}