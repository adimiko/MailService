using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class EmailSettingsDetailsDto
    {
        public Guid Id { get;  set; }
        public string Host { get;  set; }
        public int Port { get;  set; }
        public string Username { get;  set; }
    }
}
