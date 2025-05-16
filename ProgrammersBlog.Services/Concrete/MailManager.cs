using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Options;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Entities.Dtos.Contacts;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;

namespace ProgrammersBlog.Services.Concrete
{
    public class MailManager:IMailService
    {
        private readonly SmtpSettings _smtpSettings;

        public MailManager(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public IResult Send(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail), //alpertunga004@outlook.com
                To = { new MailAddress(emailSendDto.Email) }, //alper@altu.dev
                Subject = emailSendDto.Subject, //Şifremi Unuttum // Siparişiniz Başarıyla Kargolandı.
                IsBodyHtml = true,
                Body = emailSendDto.Message // "12345" No'lu siparişiniz kargolanmıştır.
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = Convert.ToInt32(_smtpSettings.Port), // String'den int'e dönüştürme
                EnableSsl = true, // Bu kesinlikle true olmalı
                UseDefaultCredentials = false, // Bu false olmalı
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);

            return new Result(ResultStatus.Success, $"E-Postanız başarıyla gönderilmiştir.");
        }

        public IResult SendContactEmail(EmailSendDto emailSendDto)
        {
            string htmlBody = $@"
    <!DOCTYPE html>
    <html lang='tr'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>İletişim Formu</title>
        <style>
            body {{
                font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                line-height: 1.6;
                color: #333;
                max-width: 600px;
                margin: 0 auto;
                padding: 20px;
            }}
            .header {{
                background-color: #3498db;
                color: white;
                padding: 20px;
                text-align: center;
                border-radius: 5px 5px 0 0;
            }}
            .content {{
                background-color: #f9f9f9;
                padding: 20px;
                border-left: 1px solid #ddd;
                border-right: 1px solid #ddd;
            }}
            .footer {{
                background-color: #f2f2f2;
                padding: 15px;
                text-align: center;
                font-size: 14px;
                color: #666;
                border-radius: 0 0 5px 5px;
                border: 1px solid #ddd;
            }}
            .info-label {{
                font-weight: bold;
                color: #3498db;
            }}
            .message-content {{
                background-color: white;
                padding: 15px;
                border-left: 4px solid #3498db;
                margin: 15px 0;
            }}
            .logo {{
                max-height: 60px;
                margin-bottom: 10px;
            }}
        </style>
    </head>
    <body>
        <div class='header'>
            <h2>🌟 Yeni İletişim Mesajı</h2>
        </div>
        <div class='content'>
            <p>Merhaba,</p>
            <p>Blog sayfanız üzerinden yeni bir iletişim mesajı aldınız.</p>
            
            <p><span class='info-label'>Gönderen:</span> {emailSendDto.Name}</p>
            <p><span class='info-label'>E-posta:</span> {emailSendDto.Email}</p>
            <p><span class='info-label'>Konu:</span> {emailSendDto.Subject}</p>
            
            <p><span class='info-label'>Mesaj:</span></p>
            <div class='message-content'>
                {emailSendDto.Message.Replace("\n", "<br/>")}
            </div>
            
            <p>Bu mesaj {DateTime.Now:dd.MM.yyyy HH:mm} tarihinde gönderilmiştir.</p>
        </div>
        <div class='footer'>
            <p>© {DateTime.Now.Year} MuglaBlogPortal - Tüm Hakları Saklıdır</p>
        </div>
    </body>
    </html>";

            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                To = { new MailAddress("mhmtgler12@gmail.com") },
                Subject = $"Yeni İletişim Mesajı: {emailSendDto.Subject}",
                IsBodyHtml = true,
                Body = htmlBody
            };

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = Convert.ToInt32(_smtpSettings.Port),
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            smtpClient.Send(message);
            return new Result(ResultStatus.Success, $"E-Postanız başarıyla gönderilmiştir. 10 Saniye Sonra Ana Sayfaya Yönlendirileceksiniz.");
        }
    }
}
