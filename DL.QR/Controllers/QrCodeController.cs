using System.Text.Json;
using DinkToPdf;
using DinkToPdf.Contracts;
using DL.QR.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace DL.QR.Controllers;

[ApiController]
[Route("[controller]")]
public class QrCodeController : ControllerBase
{
    private readonly IConverter _converter;

    public QrCodeController(IConverter converter)
    {
        _converter = converter;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateQrCode([FromBody] QrCodeRequest request)
    {
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(JsonSerializer.Serialize(request), QRCodeGenerator.ECCLevel.Q);
        var qrCode = new PngByteQRCode(qrCodeData);
        var qrCodeImage = qrCode.GetGraphic(5);

        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 }
        };

        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = $@"
                    <html>
                    <body>
                        <img src=""data:image/png;base64,{Convert.ToBase64String(qrCodeImage.ToArray())}"" />
                        <img src=""data:image/png;base64,{Convert.ToBase64String(qrCodeImage.ToArray())}"" />
                        <img src=""data:image/png;base64,{Convert.ToBase64String(qrCodeImage.ToArray())}"" />
                        <img src=""data:image/png;base64,{Convert.ToBase64String(qrCodeImage.ToArray())}"" />
                        <img src=""data:image/png;base64,{Convert.ToBase64String(qrCodeImage.ToArray())}"" />
                    </body>
                    </html>",
            WebSettings = { DefaultEncoding = "utf-8" }
        };

        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        var file = _converter.Convert(pdf);
        return File(file, "application/pdf", $"{request.Name}_QR.pdf");
    }
}