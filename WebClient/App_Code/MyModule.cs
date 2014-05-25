using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebClient
{
    public class MyModule : IHttpModule
    {
        private HttpApplication _context;        

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            _context = context;

            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            if (_context.Request.Path.Contains("aspx"))
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                _context.Context.Items["_stopwatch"] = sw;
            }
        }

        void context_EndRequest(object sender, EventArgs e)
        {            
            if (_context.Request.Path.Contains("aspx"))
            {
                Stopwatch sw = (Stopwatch)_context.Context.Items["_stopwatch"];

                string s = String.Format("Elapsed: {0}", sw.ElapsedMilliseconds);
                _context.Response.Write(s);
                _context.Context.Items.Remove("_stopwatch");
            }
            
        }       
    }
}