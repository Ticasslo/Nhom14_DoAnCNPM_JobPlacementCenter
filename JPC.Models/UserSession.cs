using JPC.Models.QuanTri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Models
{
    public static class UserSession
    {
        public static string Username { get; set; }
        public static NhanVien NhanVien { get; set; }

        public static void Clear()
        {
            Username = null;
            NhanVien = null;
        }
    }
}
