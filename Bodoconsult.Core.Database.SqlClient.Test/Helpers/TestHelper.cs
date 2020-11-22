﻿using System.IO;

namespace Bodoconsult.Core.Database.SqlClient.Test.Helpers
{
    public static class TestHelper
    {
        /// <summary>
        /// Connection string to postgress db. Adjust path to your connectionstring file
        /// </summary>
        public static string SqlServerString => File.ReadAllText(@"D:\Daten\Projekte\_work\Data\sqlserver.txt");
    }
}
