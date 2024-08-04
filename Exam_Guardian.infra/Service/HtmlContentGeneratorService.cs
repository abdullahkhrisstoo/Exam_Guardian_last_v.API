using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class HtmlContentGenerator
    {
        public static string GenerateReservationInvoiceHtml(string examName, string examDate, string candidateName, string candidateId, decimal examFee, string examLocation)
        {
            var html = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Exam Invoice</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
        }}
        .container {{
            width: 100%;
            max-width: 800px;
            margin: auto;
        }}
        .header, .footer {{
            text-align: center;
            margin-bottom: 20px;
        }}
        .header h1 {{
            margin: 0;
        }}
        .address {{
            margin-bottom: 20px;
        }}
        .address div {{
            margin-bottom: 5px;
        }}
        .invoice-info {{
            margin-bottom: 20px;
            border: 1px solid #ddd;
            padding: 15px;
            border-radius: 5px;
        }}
        .invoice-info h2 {{
            margin-top: 0;
        }}
        .table {{
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }}
        .table th, .table td {{
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }}
        .table th {{
            background-color: #f4f4f4;
        }}
        .total {{
            text-align: right;
            margin-top: 20px;
        }}
        .total div {{
            margin-bottom: 5px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <!-- Header -->
        <div class='header'>
            <h1>Exam Invoice</h1>
        </div>

        <!-- Company Details -->
        <div class='address'>
            <div>
                <strong>Company Name:</strong> ExamGuardian 
            </div>
            <div>
                <strong>Company Address:</strong> 123 Exam St, Suite 100, Exam City, EX 12345
            </div>
            <div>
                <strong>Phone:</strong> (123) 456-7890
            </div>
            <div>
                <strong>Email:</strong> system.guardian2000@gmail.com
            </div>
        </div>

        <!-- Invoice Information -->
        <div class='invoice-info'>
            <h2>Exam Details</h2>
            <div>
                <strong>Exam Name:</strong> {examName}
            </div>
            <div>
                <strong>Exam Date:</strong> {examDate}
            </div>
            <div>
                <strong>Candidate Name:</strong> {candidateName}
            </div>
            <div>
                <strong>Candidate ID:</strong> {candidateId}
            </div>
            <div>
                <strong>Location:</strong> {examLocation}
            </div>
        </div>

        <!-- Fees Table -->
        <table class='table'>
            <thead>
                <tr>
                    <th>Description</th>
                    <th>Amount</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Exam Fee</td>
                    <td>${examFee:F2}</td>
                </tr>
                <!-- Add more rows as needed -->
            </tbody>
        </table>

        <!-- Total -->
        <div class='total'>
            <div><strong>Total Fee:</strong> ${examFee:F2}</div>
        </div>

        <!-- Footer -->
        <div class='footer'>
            <p>Thank you for choosing ExamGuardian!</p>
            <p>If you have any questions about this invoice, please contact us at (123) 456-7890 or email system.guardian2000@gmail.com.</p>
        </div>
    </div>
</body>
</html>";

            return html;
        }

        public static string GeneratePlanInvoiceHtml(
       string planName,
       decimal planPrice,
       string examProviderName,
       string examProviderPhone,
       string examProviderEmail)
        {
            var html = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Exam Provider Invoice</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
        }}
        .container {{
            width: 100%;
            max-width: 800px;
            margin: auto;
        }}
        .header, .footer {{
            text-align: center;
            margin-bottom: 20px;
        }}
        .header h1 {{
            margin: 0;
        }}
        .address {{
            margin-bottom: 20px;
        }}
        .address div {{
            margin-bottom: 5px;
        }}
        .invoice-info {{
            margin-bottom: 20px;
            border: 1px solid #ddd;
            padding: 15px;
            border-radius: 5px;
        }}
        .invoice-info h2 {{
            margin-top: 0;
        }}
        .table {{
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }}
        .table th, .table td {{
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }}
        .table th {{
            background-color: #f4f4f4;
        }}
        .total {{
            text-align: right;
            margin-top: 20px;
        }}
        .total div {{
            margin-bottom: 5px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <!-- Header -->
        <div class='header'>
            <h1>Plan Invoice</h1>
        </div>

        <!-- Company Details -->
        <div class='address'>
            <div>
                <strong>Company Name:</strong> ExamGuardian
            </div>
            <div>
                <strong>Company Address:</strong> 123 Exam St, Suite 100, Exam City, EX 12345
            </div>
            <div>
                <strong>Phone:</strong> (123) 456-7890
            </div>
            <div>
                <strong>Email:</strong> system.guardian2000@gmail.com
            </div>
        </div>

        <!-- Invoice Information -->
        <div class='invoice-info'>
            <h2>Plan Details</h2>
            <div>
                <strong>Plan Name:</strong> {planName}
            </div>
            <div>
                <strong>Plan Price:</strong> ${planPrice:F2}
            </div>
            <h2>Exam Provider Details</h2>
            <div>
                <strong>Provider Name:</strong> {examProviderName}
            </div>
            <div>
                <strong>Provider Phone:</strong> {examProviderPhone}
            </div>
            <div>
                <strong>Provider Email:</strong> {examProviderEmail}
            </div>
        </div>

        <!-- Fees Table -->
        <table class='table'>
            <thead>
                <tr>
                    <th>Description</th>
                    <th>Amount</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Plan Price</td>
                    <td>${planPrice:F2}</td>
                </tr>
                <!-- Add more rows as needed -->
            </tbody>
        </table>

        <!-- Total -->
        <div class='total'>
            <div><strong>Total Price:</strong> ${planPrice:F2}</div>
        </div>

        <!-- Footer -->
        <div class='footer'>
            <p>Thank you for registering with ExamGuardian!</p>
            <p>If you have any questions about this invoice, please contact us at (123) 456-7890 or email system.guardian2000@gmail.com.</p>
        </div>
    </div>
</body>
</html>";

            return html;
        }


        public static string GenerateProctorNotificationEmail(
        string proctorName,
        string examName,
        string reservationDate,
        string startTime,
        string endTime,
        string proctorActionLink)
        {
            var html = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Proctor Notification</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }}
        .container {{
            max-width: 600px;
            margin: auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }}
        h1 {{
            color: #333;
        }}
        p {{
            color: #555;
        }}
        .button {{
            display: block;
            width: 200px;
            margin: 20px auto;
            padding: 10px;
            background-color: #007bff;
            color: #fff !important;
            text-align: center;
            border-radius: 5px;
            text-decoration: none;
        }}
        .footer {{
            text-align: center;
            margin-top: 20px;
            color: #777;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <h1>Proctor Assignment</h1>
        <p>Dear {proctorName},</p>
        <p>You have been assigned as a proctor for an upcoming exam. Here are the details:</p>
        <p><strong>Exam Name:</strong> {examName}</p>
        <p><strong>Date:</strong> {reservationDate}</p>
        <p><strong>Start Time:</strong> {startTime}</p>
        <p><strong>End Time:</strong> {endTime}</p>
        <p>To view the proctoring details and complete your tasks, please click the button below:</p>
        <a href='{proctorActionLink}' class='button'>View Proctor Details</a>
        <div class='footer'>
            <p>If you have any questions, please contact us at system.guardian2000@gmail.com.</p>
        </div>
    </div>
</body>
</html>";
            return html;
        }

        public static string GenerateStudentReservationConfirmationEmail(
        string studentName,
        string examName,
        string reservationDate,
        string startTime,
        string endTime,
        string studentActionLink)
        {
            var html = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Exam Reservation Confirmation</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }}
        .container {{
            max-width: 600px;
            margin: auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }}
        h1 {{
            color: #333;
        }}
        p {{
            color: #555;
        }}
        .button {{
            display: block;
            width: 200px;
            margin: 20px auto;
            padding: 10px;
            background-color: #007bff;
            color: #fff !important;
            text-align: center;
            border-radius: 5px;
            text-decoration: none;
        }}
        .footer {{
            text-align: center;
            margin-top: 20px;
            color: #777;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <h1>Reservation Confirmation</h1>
        <p>Dear {studentName},</p>
        <p>Your exam reservation has been successfully created. Here are the details:</p>
        <p><strong>Exam Name:</strong> {examName}</p>
        <p><strong>Date:</strong> {reservationDate}</p>
        <p><strong>Start Time:</strong> {startTime}</p>
        <p><strong>End Time:</strong> {endTime}</p>
        <p>To access your exam, please click the button below. Ensure you access it at least 30 minutes before the exam starts:</p>
        <a href='{studentActionLink}'  class='button'>Access Exam</a>
        <div class='footer'>
            <p>If you have any questions, please contact us at system.guardian2000@gmail.com.</p>
        </div>
    </div>
</body>
</html>";
            return html;
        }


        public static string GenerateStudentReservationInvoiceEmail(
        string studentName,
        string examName,
        string reservationDate,
    string startTime,
    string endTime,
    decimal examPrice)
        {
            var html = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Reservation Invoice</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }}
        .container {{
            max-width: 600px;
            margin: auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }}
        h1 {{
            color: #333;
        }}
        p {{
            color: #555;
        }}
        .invoice-details {{
            margin: 20px 0;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }}
        .invoice-details h2 {{
            margin-top: 0;
        }}
        .total {{
            margin-top: 20px;
            text-align: right;
            font-size: 1.2em;
        }}
        .footer {{
            text-align: center;
            margin-top: 20px;
            color: #777;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <h1>Reservation Invoice</h1>
        <p>Dear {studentName},</p>
        <p>Here is your reservation invoice:</p>
        <div class='invoice-details'>
            <h2>Exam Details</h2>
            <p><strong>Exam Name:</strong> {examName}</p>
            <p><strong>Date:</strong> {reservationDate}</p>
            <p><strong>Start Time:</strong> {startTime}</p>
            <p><strong>End Time:</strong> {endTime}</p>
        </div>
        <div class='total'>
            <div><strong>Total Price:</strong> ${examPrice:F2}</div>
        </div>
        <p>If you have any questions or need further assistance, please contact us at system.guardian2000@gmail.com.</p>
        <div class='footer'>
            <p>Thank you for choosing ExamGuardian!</p>
        </div>
    </div>
</body>
</html>";
            return html;
        }




    }

}
