using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMO
{
  public   class MailClass
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="data">邮件内容</param>
      public static void SendStrMail(Dictionary<string, object> _MailSeting, string data, string title)
        {
            try
            {
                // string host = "smtp.163.com";// 邮件服务器smtp.163.com表示网易邮箱服务器 
                //string host = ""; //"smtp.qq.com";//QQ SMTP服务器地址  
                //if(_MailSeting!=null&&_MailSeting.ContainsKey("SEND_SERVER_IP"))
                //{
                //    host = _MailSeting["SEND_SERVER_IP"].ToString();
                //}
                //string userName = "";//  发送端账号   
                //if (_MailSeting != null && _MailSeting.ContainsKey("SEND_EMAIL_ID"))
                //{
                //    userName = _MailSeting["SEND_EMAIL_ID"].ToString();
                //}
                //string password = "";//"dpncdesudbtbheii";// 发送端密码(这个客户端重置后的密码)
                //if (_MailSeting != null && _MailSeting.ContainsKey("SEND_PASSWORD"))
                //{
                //    password = _MailSeting["SEND_PASSWORD"].ToString();
                //}
                //int Port = 587;
                //if (_MailSeting != null && _MailSeting.ContainsKey("SEND_PORT"))
                //{
                //    Port = CommomHelper.ToInt(_MailSeting["SEND_PORT"]);
                //}
                //string  strto = "";
                //if (_MailSeting != null && _MailSeting.ContainsKey("RECIPIENT_EMAIL_IDS"))
                //{
                //    strto = _MailSeting["RECIPIENT_EMAIL_IDS"].ToString();
                //}
                //string strcc = "";
                //if (_MailSeting != null && _MailSeting.ContainsKey("CC_EMAIL_IDS"))
                //{
                //    strcc = _MailSeting["CC_EMAIL_IDS"].ToString();
                //}

                string host = "smtp.qq.com";//QQ SMTP服务器地址  
                string userName = "1489706032@qq.com";// 发送端账号   
                string password = "dpncdesudbtbheii";// 发送端密码(这个客户端重置后的密码)
                int Port = 587;

                string strto = "1029598322@qq.com";
                string strcc = "942389213@qq.com";//抄送

                if(string.IsNullOrEmpty(strto))
                {
                    return;
                }

                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式    
                client.Host = host;//邮件服务器
                client.Port = Port;//SMTP端口，QQ邮箱填写587  
                client.UseDefaultCredentials = true;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(userName, password);//用户名、密码


                string strfrom = userName;


                string subject = title;//邮件的主题             

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new MailAddress(strfrom, title);
                msg.To.Add(strto);
                msg.CC.Add(strcc);

                msg.Subject = subject;//邮件标题   
                msg.Body = data;//邮件内容   
                msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码   
                msg.IsBodyHtml = true;//是否是HTML邮件   
                msg.Priority = MailPriority.High;//邮件优先级   


                try
                {
                    client.Send(msg);
                    Console.WriteLine("发送成功");
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    Console.WriteLine(ex.Message, "发送邮件出错");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

       
        //表头邮件内容
        public static void SendLargeMsg(TableLayoutPanel ctl, DataGridView data, string title, Dictionary<string, object> MailSeting)
        {
           string  LargeMailBody = "";
            if (title != "")
                LargeMailBody += "<p style=\"font-size: 10pt\">" + title + "</p>";

         
            for (int i = 0; i < ctl.RowCount; i++)
            {
                LargeMailBody += " <form>";
                for (int j = 0; j < ctl.ColumnCount; j++)
                {
                    Control _control = ctl.GetControlFromPosition(j, i) as Control;
                    if(_control!=null)
                    {
                        if(_control is Label)
                        {
                           // LargeMailBody += string.Format(_control.Text+":");
                            LargeMailBody += string.Format("  <span style=\"display:inline-block;text-align:right;width:200px\">{0}:</span>", _control.Text); 
                        }
                        else
                        {
                            LargeMailBody += string.Format("<input type=\"text\" name=\"{0}\" value=\"{1}\"> &nbsp;&nbsp;&nbsp;", _control.Name, _control.Text);
                        }
                      
                    }

                }
                LargeMailBody += "   </form> ";
            }

            if (data != null)
            {
                LargeMailBody += "<div align=\"center\">";

                LargeMailBody += "<table cellspacing=\"1\" cellpadding=\"3\" border=\"0\" bgcolor=\"000000\" style=\"font-size: 10pt;line-height: 15px;\">";

                LargeMailBody += "<tr>";
                for (int hcol = 0; hcol < data.Columns.Count; hcol++)
                {
                    LargeMailBody += "<td style=\"white-space:nowrap\" bgcolor=\"999999\">&nbsp;&nbsp;&nbsp;";
                    LargeMailBody += data.Columns[hcol].HeaderText.ToString();
                    LargeMailBody += "&nbsp;&nbsp;&nbsp;</td>";
                }
                LargeMailBody += "</tr>";

                for (int row = 0; row < data.Rows.Count; row++)
                {
                    if (data.Rows[row].Cells["ITM"].Value==null)
                    { continue;  }
                    if (string.IsNullOrEmpty(data.Rows[row].Cells["ITM"].Value.ToString()))
                    { continue; }
                    LargeMailBody += "<tr>";
                    for (int col = 0; col < data.Columns.Count; col++)
                    {
                        LargeMailBody += "<td style=\"white-space:nowrap\" bgcolor=\"dddddd\">&nbsp;&nbsp;&nbsp;";
                        LargeMailBody += data.Rows[row].Cells[col].Value == null ? "" : data.Rows[row].Cells[col].Value.ToString();
                        LargeMailBody += "&nbsp;&nbsp;&nbsp;</td>";
                    }
                    LargeMailBody += "</tr>";
                }

                LargeMailBody += "</table><br>";
                LargeMailBody += "</div>";
            }
            SendStrMail(MailSeting, LargeMailBody, title);
        }



  }

}
