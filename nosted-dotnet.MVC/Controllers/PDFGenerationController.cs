using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using nosted_dotnet.MVC.Data.ServiceSkjema;

namespace nosted_dotnet.MVC.Controllers
{
    public class PdfGenerationController : Controller
    {
        private readonly ISjekklisteRepository _sjekklisteRepository;
        private readonly IServiceSkjemaRepository _serviceSkjemaRepository;

        public PdfGenerationController(ISjekklisteRepository sjekklisteRepository, IServiceSkjemaRepository serviceSkjemaRepository)
        {
            _sjekklisteRepository = sjekklisteRepository;
            _serviceSkjemaRepository = serviceSkjemaRepository;
        }

        public IActionResult GeneratePdf(string orderType, int orderId)
        {
            // Logic to generate the PDF for the specified order type and order ID
            byte[] pdfBytes = GeneratePdfForOrder(orderType, orderId);

            if (pdfBytes != null && pdfBytes.Length > 0)
            {
                // Set appropriate content type and file name
                return File(pdfBytes, "application/pdf", $"{orderType}.pdf");
            }
            else
            {
                // Handle the case where PDF generation fails
                return Content("PDF generation failed.");
            }
        }

        private byte[] GeneratePdfForOrder(string orderType, int orderId)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                        // Create a new document
                        Document document = new Document();
                        PdfWriter writer = PdfWriter.GetInstance(document, ms);

                        document.Open();
                        
                        if (orderType == "Sjekkliste")
                        {
                            var sjekkliste = _sjekklisteRepository.Get(orderId);
                            if (sjekkliste == null)
                            {
                                return null;
                            }

                        // Add content to the PDF for SjekklisteOrder
                        document.Add(new Phrase("Verdi 1 = ok, Verdi 2 = defekt, Verdi 3 = bør skiftes"));
                        document.Add(new Paragraph("Sjekkliste ID: " + sjekkliste.Id));
                        //document.Add(new Paragraph("Customer Name: " + sjekkliste.CustomerName));
                        document.Add(new Paragraph("Clutch Lameller: " + sjekkliste.ClutchLameller));
                        document.Add(new Paragraph("Bremser BP: " + sjekkliste.BremserBP));
                        document.Add(new Paragraph("Trommel Lager: " + sjekkliste.TrommelLager));
                        document.Add(new Paragraph("Kjedestrammer: " + sjekkliste.Kjedestrammer));
                        document.Add(new Paragraph("Wire: " + sjekkliste.Wire));
                        document.Add(new Paragraph("Pinion Lager: " + sjekkliste.PinionLager));
                        document.Add(new Paragraph("Kjedehjul Kile: " + sjekkliste.KjedehjulKile));
                        document.Add(new Paragraph("Sylinder Lekasje: " + sjekkliste.SylinderLekasje));
                        document.Add(new Paragraph("Slanger: " + sjekkliste.Slanger));
                        document.Add(new Paragraph("Hydraulikkblokk Test: " + sjekkliste.HydraulikkblokkTest));
                        document.Add(new Paragraph("Oljeskifte Tank: " + sjekkliste.OljeskifteTank));
                        document.Add(new Paragraph("Oljeskifte Girboks: " + sjekkliste.OljeskifteGirboks));
                        document.Add(new Paragraph("Ringsylinder Tetninger: " + sjekkliste.RingsylinderTetninger));
                        document.Add(new Paragraph("Bremsesylinder Tetninger: " + sjekkliste.BremsesylinderTetninger));
                        document.Add(new Paragraph("Ledningsnett: " + sjekkliste.Ledningsnett));
                        document.Add(new Paragraph("Radio: " + sjekkliste.Radio));
                        document.Add(new Paragraph("Knappekasse: " + sjekkliste.Knappekasse));
                    }

                    else if (orderType == "serviceSkjema")
                    {
                        var serviceSkjema = _serviceSkjemaRepository.Get(orderId);
                        if (serviceSkjema == null)
                        {
                            return null;
                        }
                        
                        // Add content to the PDF for ServiceSkjemaOrder
                        document.Add(new Paragraph("Serviceskjema ID: " + serviceSkjema.Id));
                        document.Add(new Paragraph("Kunde: " + serviceSkjema.AvtaltKunde));
                        document.Add(new Paragraph("Avtalt Kunde: " + serviceSkjema.AvtaltKunde));
                        document.Add(new Paragraph("Deler Brukt: " + serviceSkjema.DelerBrukt));
                        document.Add(new Paragraph("Reperasjons Beskrivelse: " + serviceSkjema.RepBeskrivelse));
                        document.Add(new Paragraph("Utført av: " + serviceSkjema.UtførtAv));
                    }
                        document.Close();

                    // Convert the document to a byte array
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during PDF generation
                // You can log the error or return null in case of failure
                return null;
            }
        }
    }
}