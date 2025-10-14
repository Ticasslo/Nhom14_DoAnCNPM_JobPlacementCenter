using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPC.Business.Services.Interfaces.SA;
using JPC.DataAccess.Repositories.Interfaces.SA;
using JPC.DataAccess.Repositories.Implementations.SA;

namespace JPC.Business.Services.Implementations.SA
{
    public class QuyenHanChucNangService : IQuyenHanChucNangService
    {
        private readonly IQuyenHanChucNangRepository _repo;

        public QuyenHanChucNangService()
        {
            _repo = new QuyenHanChucNangRepository();
        }

        public DataTable GetRolePermissionMatrix()
        {
            return _repo.GetRolePermissionMatrix();
        }

        public bool UpsertPermission(string vaiTroId, string chucNangId, bool quyenHan)
        {
            return _repo.UpsertPermission(vaiTroId, chucNangId, quyenHan);
        }
    }
}
