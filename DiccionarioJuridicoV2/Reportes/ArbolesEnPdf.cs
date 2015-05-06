using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DiccionarioJuridicoV2.Reportes
{
    public class ArbolesEnPdf
    {

        private Document myDocument;

        private readonly int materia;
        private ObservableCollection<Temas> coleccionTemas;

        public ArbolesEnPdf(int materia)
        {
            this.materia = materia;
        }

        public ArbolesEnPdf(ObservableCollection<Temas> coleccionTemas)
        {
            this.coleccionTemas = coleccionTemas;
        }

        public void GeneraPdf()
        {

            myDocument = new iTextSharp.text.Document(PageSize.A4, 50, 50, 50, 50);

            string filepath = Path.GetTempFileName() + ".pdf";

            try
            {

                PdfWriter writer = PdfWriter.GetInstance(myDocument, new FileStream(filepath, FileMode.Create));
                //HeaderFooter pdfPage = new HeaderFooter();
                //writer.PageEvent = pdfPage;
                myDocument.Open();

                for (int x = 0; x < 2; x++)
                {
                    iTextSharp.text.Paragraph white = new iTextSharp.text.Paragraph(" ");
                    myDocument.Add(white);
                }
                //Temas dummyTema = new Temas();
                //dummyTema.Materia = materia;
                PoneNodosPDF(coleccionTemas,0);

                myDocument.Close();
                System.Diagnostics.Process.Start(filepath);
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }


        }


        
        //private void PoneNodosPDF(Temas temaEnvia,int indentValue)
        //{


        //    ObservableCollection<Temas> temas = TemasModel.GetTemasTematico(temaEnvia, materia, true);

        //    foreach (Temas tema in temas)
        //    {

        //        iTextSharp.text.Paragraph par;

        //        par = (tema.IdOrigen == 0) ? new iTextSharp.text.Paragraph(tema.Descripcion + "    " + tema.AbogadoCrea) :
        //            new iTextSharp.text.Paragraph(tema.Descripcion);
        //        par.IndentationLeft = indentValue;
        //        myDocument.Add(par);

        //        PoneNodosPDF(tema, indentValue + 10);
        //    }
        //}

        private void PoneNodosPDF(ObservableCollection<Temas> temasEnvia, int indentValue)
        {

            foreach (Temas tema in temasEnvia)
            {

                if (tema.IdOrigen == 0)
                    TemasModel.GetAbogadoCrea(tema);

                iTextSharp.text.Paragraph par;

                Font red = FontFactory.GetFont("Arial", 12);
                red.Color = new BaseColor(255, 0, 0);

                Font black = FontFactory.GetFont("Arial", 12);
                black.Color = new BaseColor(0, 0, 0);

                Font blur = FontFactory.GetFont("Arial", 5);
                blur.Color = new BaseColor(0, 0, 255);

                Chunk c1 = new Chunk(tema.Descripcion,black);
                Chunk c2 = new Chunk("          " + tema.AbogadoCrea.ToUpper(), red);
                Chunk c3 = new Chunk("          " + tema.RegIusString, blur);

                Phrase phrase = new Phrase();
                phrase.Add(c1);
                phrase.Add(c2);
                phrase.Add(c3);

                par = new Paragraph();
                par.Add(phrase);
                par.IndentationLeft = indentValue;
                myDocument.Add(par);

                PoneNodosPDF(tema.SubTemas, indentValue + 10);
            }
        }

        
    }
}
