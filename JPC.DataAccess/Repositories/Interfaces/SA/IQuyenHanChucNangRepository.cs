using System;
using System.Collections.Generic;
using System.Data;

namespace JPC.DataAccess.Repositories.Interfaces.SA
{
    public interface IQuyenHanChucNangRepository
    {
        DataTable GetRolePermissionMatrix();
        bool UpsertPermission(string vaiTroId, string chucNangId, bool quyenHan);
        bool IsFunctionEnabledForRole(string vaiTroId, string chucNangId);
    }
}
