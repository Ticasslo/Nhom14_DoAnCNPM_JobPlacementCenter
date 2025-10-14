using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Services.Interfaces.SA
{
    public interface IQuyenHanChucNangService
    {
        DataTable GetRolePermissionMatrix();
        bool UpsertPermission(string vaiTroId, string chucNangId, bool quyenHan);
    }
}
