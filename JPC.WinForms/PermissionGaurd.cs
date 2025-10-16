using System.Windows.Forms;
using JPC.Business.Services.Implementations.SA;
using JPC.Business.Services.Interfaces.SA;
using JPC.Models;

namespace JPC.WinForms
{
    public static class PermissionGuard
    {
        private static readonly IQuyenHanChucNangService _permissionService = new QuyenHanChucNangService();

        public static bool EnsureEnabled(string chucNangId)
        {
            var currentRoleId = UserSession.NhanVien?.VaiTroId;
            if (string.IsNullOrWhiteSpace(currentRoleId))
            {
                MessageBox.Show("Phiên làm việc không hợp lệ. Vui lòng đăng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool enabled = _permissionService.IsFunctionEnabledForRole(currentRoleId, chucNangId);
            if (!enabled)
            {
                MessageBox.Show("Chức năng đang trong giai đoạn bảo trì, vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}
