using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;

namespace JwtVisualizer
{
    public partial class JwtForm : Form
    {
        public JwtForm()
        {
            InitializeComponent();
        }
        
        public string RawJwt { get; set; }
        private string header { get; set; }
        private string signed { get; set; }
        private string signature { get; set; }

        private void JwtForm_Load_1(object sender, EventArgs e)
        {
            txtRaw.Text = RawJwt;
            txtUnEncoded.Text = UnEncodeRaw(RawJwt);
        }

        private string UnEncodeRaw(string raw)
        {
            var rawsplit = raw.Split('.');
            if (rawsplit.Length != 3)
            {
                return "wrong number of segments, expecting 3";
            }
            try
            {
                signed = rawsplit[0] + "." + rawsplit[1];
                signature = rawsplit[2];

                header = Pretty(base64decodeutf8(rawsplit[0]), chkPretty.Checked);
                var segment2 = Pretty(base64decodeutf8(rawsplit[1]), chkPretty.Checked);
                return $"{header}.{segment2}.{rawsplit[2]}";
            }
            catch(Exception e)
            {
                return "could not decode" + e.Message;
            }
        }

        private string Pretty(string target, bool pretty)
        {
            if (!pretty) return target;

            var padding = 0;
            var newline = false;
            StringBuilder builder = new StringBuilder();
            var chars = target.ToCharArray();

            foreach (var theChar in chars)
            {
                if (theChar == '}')
                {
                    padding -= 3;
                    builder.Append("\r\n" + "".PadRight(padding));
                }

                builder.Append(theChar);

                if (theChar == '{')
                {
                    padding += 3;
                    newline = true;
                }
                if (theChar == '}')
                {
                    newline = true;
                }
                if (theChar == ',')
                {
                    newline = true;
                }
                if (newline)
                {
                    builder.Append("\r\n" + "".PadRight(padding));
                    newline = false;
                }
            }
            return builder.ToString();
        }

        private string base64decodeutf8(string raw)
        {
            var mod = raw.Length % 4;
            if (mod > 0) 
                raw = raw.PadRight(raw.Length + (4 - mod), '=');
            return Encoding.UTF8.GetString(base64decodeAddPadding(raw));
        }

        private byte[] base64decodeAddPadding(string raw)
        {
            var mod = raw.Length % 4;
            if (mod > 0)
                raw = raw.PadRight(raw.Length + (4 - mod), '=');
            raw = raw.Replace('-', '+');
            raw = raw.Replace('_', '/');
            return Convert.FromBase64String(raw);
        }

        private string GetAlg()
        {
            var pattern = @"""alg""\s*:\s*""(\w+)""";
            var match = Regex.Match(header, pattern);
            if (!match.Success) return null;
            return match.Groups[1].Value;
        }
        

        private void chkPretty_CheckedChanged(object sender, EventArgs e)
        {
            txtUnEncoded.Text = UnEncodeRaw(RawJwt);
        }

        private void txtCert_TextChanged(object sender, EventArgs e)
        {
            StringBuilder log = new StringBuilder();

            if (txtCert.Text.Length == 0)
            {
                log.AppendLine("Please enter certificate");
                results.Text = log.ToString();
                return;
            }

            var alg = GetAlg();
            if (String.IsNullOrEmpty(alg))
            {
                log.AppendLine("could not retreive alg");
            }
            else
            {
                log.AppendLine("found alg " + alg);
            }
            checkSignature(log, alg);
            results.Text = log.ToString();
        }

        private void checkSignature(StringBuilder log, string alg)
        {
            //if (alg == "HS256")
            switch(alg)
            {
                case "HS256":
                    log.AppendLine("checking signature with HS256");
                    var hs256 = new HMACSHA256(Encoding.UTF8.GetBytes(txtCert.Text));
                    var resultBytes = hs256.ComputeHash(Encoding.UTF8.GetBytes(signed));
                    var result = Convert.ToBase64String(resultBytes).Replace("=", "");

                    log.AppendLine("calculated signuatre: " + result);
                    log.AppendLine("signuatre from JWT: " + signature);

                    if (signature.Equals(result))
                    {
                        log.AppendLine("OK!");
                    }
                    else
                    {
                        log.AppendLine("FAILED!");
                    }
                    break;
                case "RS256":
                    log.AppendLine("checking signature with RS256");
                    VerifiyRs256(log);
                    break;
                default:
                    log.AppendLine("alg not implemented");
                    break;

            }
            
        }

        private byte[] GetCertBytes(string certText, StringBuilder log)
        {
            var beginCert = "-----BEGIN CERTIFICATE-----";
            if (certText.IndexOf(beginCert) > -1)
            {
                log.AppendLine("certificate in PEM format");
                certText = certText.Replace(beginCert, "");
                certText = certText.Replace("-----END CERTIFICATE-----", "");
                certText = Regex.Replace(certText, @"\s", "");
            }
            else
            {
                log.AppendLine("treating certificate as raw");
            }

            return Encoding.UTF8.GetBytes(certText);
        }

        private void VerifiyRs256(StringBuilder log)
        {
            try
            {
                using (var sha = new SHA256CryptoServiceProvider())
                {
                   byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(signed));
                    var x5C = new X509Certificate2(GetCertBytes(txtCert.Text, log));
                    //AsymmetricAlgorithm alg = AsymmetricAlgorithm.Create()
                    var pkcs1 = new RSAPKCS1SignatureDeformatter(x5C.PublicKey.Key as RSACryptoServiceProvider);

                    pkcs1.SetHashAlgorithm("SHA256");

                    if (pkcs1.VerifySignature(hash, base64decodeAddPadding(signature)))
                    {
                        log.AppendLine("OK!");
                    }
                    else
                    {
                        log.AppendLine("FAILED!");
                    }
                }
            }
            catch (Exception e)
            {
                log.AppendLine("FAILED! " + e.Message);
            }
        }
    }
}
