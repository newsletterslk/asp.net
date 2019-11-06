using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
/**
 * Newsletters.lk SMS Client 
 * Version : C# .NET CORE ASP - V1.0
 * Copyright @ 2017 - 2020 newsletters.lk
 * Customer Service : +94-(0)11-4348585
 * Email : support@newsletters.lk
 */
namespace Websms.lk
{
    public class Websmslk
    {
        private String user_token; // USER API TOKEN
        private String user_key; //USER API KEY
        private String sender_id = "WebSMS"; //USER SENDER KEY AND DEFAULT WebSMS
        private String country_code = "94";//Default Country Code Sri Lanka //94 with out +
        protected String url = "http://app.newsletters.lk/smsAPI?";// ALWAYS USE THIS LINK TO CALL API SERVICE

        public String msgType = "sms";// Message type sms/voice/unicode/flash/music/mms/whatsapp
        public int route = 0;// Your Routing Path Default 0
        public String file;// File URL for voice or whatsapp. Default not set
        public String scheduledate;//Date and Time to send message (YYYY-MM-DD HH:mm:ss) Default not use
        public String duration;//Duration of your voice message in seconds (required for voice)
        public String language;//Language of voice message (required for text-to-speach)
        /**
        * To Find your api details please log and go into https://app.newsletters.lk/apis
        */
        public string Call(String Param)
        { //Web Client Call, Where we are call to api link
            if (!String.IsNullOrEmpty(Param))
            { //Check empty or not null param request
                string html = string.Empty; // Assign output
                string url = this.url+Param;//Use full link
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "C# console client";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                return html;
            }
            else
            {
                return "5";
            }
        }
        public bool setMsgType(String type)
        {
            if (!String.IsNullOrEmpty(type))
            {
                this.msgType = type;
                return true;
            }else
            {
                return false;
            }
        }
        public bool setUser(String key, String token)
        {
            if (!String.IsNullOrEmpty(key))
            {
                if (!String.IsNullOrEmpty(token))
                {
                    this.user_key = key;
                    this.user_token = token;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /**
         * SET SENDER ID
         */
        public bool setSenderID(string sender_id)
        {
            if (string.IsNullOrEmpty(sender_id))
            {
                this.sender_id = sender_id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RouteNumber(string number)
        {
            String output;

            if (number == null)
            {
                return "0";
            }
            else
            {
                if(number[0] == '+')
                {
                    output = number.Remove(0);
                }
                else
                {
                    if(number[0] == '0')
                    {
                        number = number.Substring(1);
                    }
                    output = this.country_code + number ;
                }

                return output;
            }

        }
        public static int[] digitArr2(int n)
        {
            var result = new int[n];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = n % 10;
                n /= 10;
            }
            return result;
        }
        public string CheckBalance(bool json = false)
        {
            var param = "balance&apikey="+this.user_key+"&apitoken="+this.user_token;
            var send = this.Call(param);
            string ret = string.Empty;
            if (send != "error")
            {
                return send;
            }else
            {
                ret = "{status:falied}";
                return ret;
            }
        }
        public string CheckStatus(int groud_id, bool json = false)
        {
            var param = "groupstatus&apikey="+this.user_key+"&apitoken="+this.user_token+ "&groupid="+groud_id;
            var send = this.Call(param);
            string ret = string.Empty;
            if (send != "error")
            {
                return send;
            }
            else
            {
                ret = "{status:falied}";
                return ret;
            }
        }

        public String SendMessage(String Mobile,String Text,bool json = false)
        { 
            if(this.sender_id !="" && this.user_key != "" && this.user_token !="")
            {
                if( !String.IsNullOrEmpty(Mobile) && !String.IsNullOrEmpty(Text))
                {//bug found --Bug cleared at 2019-11-05-16-55
                    Mobile = this.RouteNumber(Mobile);
                    String param = "sendsms&apikey="+this.user_key+"&apitoken="+this.user_token+"&from="+this.sender_id+"&to="+Mobile+"&type="+this.msgType; if (this.route != 0) param=param+"&route="+this.route;
                    if (this.msgType =="sms" || this.msgType == "unicode")
                    {
                        param= param +"&text="+Text;
                    }else if(this.msgType == "voice" || this.msgType == "mms"){
                        //Voice And MMS
                        if (!String.IsNullOrEmpty(this.file)){
                            param= param+"&text="+Text+"&file="+this.file;
                            if (this.msgType == "voice" && this.duration != ""){
                                param = param + "&duration="+this.duration;
                            }
                        }else{
                            return "0";
                        }
                    }else if(this.msgType == "whatsapp"){
                        //WhatsAPP
                        param= param+ "&text="+Text;
                        if (!String.IsNullOrEmpty(this.file)){
                            param = param+ "&file="+this.file;
                        }
                    }else if(this.msgType == "flash"){
                        //Flash
                        param= param+ "&text="+Text;
                        if (!String.IsNullOrEmpty(this.file)){
                            param= param+ "&file="+this.file;
                        }
                    }
                    if (!String.IsNullOrEmpty(this.scheduledate)){
                        param= param+ "&scheduledate="+this.scheduledate;
                    }
                    if (!String.IsNullOrEmpty(this.language)){
                        param = param+ "&language="+this.language;
                    }
                    String res =this.Call(param);
                    return param;
                }
                else
                {
                    return "0";
                }
            }else
            {
                return "0";
            }
        }
    }
}