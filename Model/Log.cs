using System;

namespace Model
{
    public class Log
    {
        public const String INSERT = "INSERT INTO TB_LOG (dateInformation, description) VALUES (GETDATE(), '{0}')";
        public const String SELECT = "SELECT dateInformation, description FROM TB_LOG";
        public DateTime DateInformation { get; set; }
        public string Description { get; set; }

    }
}
