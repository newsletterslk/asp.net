using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Websms.lk
{
    public partial class sample_send : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Console.Write("hi");
        }
        protected void submit_button_Click(Object sender, EventArgs e)
        {
            Websmslk sms = new Websmslk();
            sms.setUser(api_key.Text, api_token.Text); // Set APi Key And Api Token
            sms.setSenderID(sender_id.Text); // Set Sender Id
            sms.setMsgType(msgType.Text); // Set Message Type
            String status=sms.SendMessage(mobile.Text, text.Text); // Send Message 
            Response.Write(status);//Write Response To See What Happaned
        }
    }
}
