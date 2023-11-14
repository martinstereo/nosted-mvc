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
                        document.Add(new Paragraph("Sjekkliste ID: " + sjekkliste.Id));
                        //document.Add(new Paragraph("Customer Name: " + sjekkliste.CustomerName));
                        document.Add(new Paragraph("Clutch Lameller: " + GetStatusText(sjekkliste.ClutchLameller)));
                        document.Add(new Paragraph("Bremser BP: " + GetStatusText(sjekkliste.BremserBP)));
                        document.Add(new Paragraph("Trommel Lager: " + GetStatusText(sjekkliste.TrommelLager)));
                        document.Add(new Paragraph("Kjedestrammer: " + GetStatusText(sjekkliste.Kjedestrammer)));
                        document.Add(new Paragraph("Wire: " + GetStatusText(sjekkliste.Wire)));
                        document.Add(new Paragraph("Pinion Lager: " + GetStatusText(sjekkliste.PinionLager)));
                        document.Add(new Paragraph("Kjedehjul Kile: " + GetStatusText(sjekkliste.KjedehjulKile)));
                        document.Add(new Paragraph("Sylinder Lekasje: " + GetStatusText(sjekkliste.SylinderLekasje)));
                        document.Add(new Paragraph("Slanger: " + GetStatusText(sjekkliste.Slanger)));
                        document.Add(new Paragraph("Hydraulikkblokk Test: " + GetStatusText(sjekkliste.HydraulikkblokkTest)));
                        document.Add(new Paragraph("Oljeskifte Tank: " + GetStatusText(sjekkliste.OljeskifteTank)));
                        document.Add(new Paragraph("Oljeskifte Girboks: " + GetStatusText(sjekkliste.OljeskifteGirboks)));
                        document.Add(new Paragraph("Ringsylinder Tetninger: " + GetStatusText(sjekkliste.RingsylinderTetninger)));
                        document.Add(new Paragraph("Bremsesylinder Tetninger: " + GetStatusText(sjekkliste.BremsesylinderTetninger)));
                        document.Add(new Paragraph("Ledningsnett: " + GetStatusText(sjekkliste.Ledningsnett)));
                        document.Add(new Paragraph("Radio: " + GetStatusText(sjekkliste.Radio)));
                        document.Add(new Paragraph("Knappekasse: " + GetStatusText(sjekkliste.Knappekasse)));
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
                        document.Add(new Paragraph("Utført av: " + serviceSkjema.UtfortAv));
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
        private string GetStatusText(string statusValue)
        {
            if (int.TryParse(statusValue, out int intValue))
            {
                switch (intValue)
                {
                    case 1:
                        return "ok";
                    case 2:
                        return "defekt";
                    case 3:
                        return "bør skiftes";
                    default:
                        return "Ukjent status";
                }
            }
            else
            {
                return "Ugyldig verdi";
            }
        }

    }
}