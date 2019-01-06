using Microsoft.EntityFrameworkCore;
using System.Collections;
using System;
namespace Helloworld.API.Data
{
    public class HelloWorldKubeDBContext:DbContext
    {
        public DbSet<InvokeLog> InvokeLogs { get; set; }
    }

    public class InvokeLog
    {
        public int Id { get; set; }
        public DateTime InvokeTime { get; set; }
        public string RequestorHostName { get; set; }
        public string  ServerHostName { get; set; }
    }
}