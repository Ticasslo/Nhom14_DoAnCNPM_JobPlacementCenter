using System;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace JPC.WinForms.Common.UI
{
    public static class UiKit
    {
        /// <summary>
        /// Chuẩn hóa dropdown cho Guna2ComboBox để tránh bung ngược/nhảy vị trí khi nhiều dữ liệu.
        /// </summary>
        public static void TuneCombo(Guna2ComboBox cb, int visibleItems = 10, int minItemHeight = 26)
        {
            // 1) Giới hạn chiều cao dropdown
            cb.IntegralHeight = false;
            cb.ItemHeight = Math.Max(cb.ItemHeight, minItemHeight);
            cb.MaxDropDownItems = Math.Max(visibleItems, 4);
            cb.DropDownHeight = cb.ItemHeight * cb.MaxDropDownItems + 4;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;     // tránh text gõ làm lệch layout
            cb.DrawMode = DrawMode.OwnerDrawFixed;             // Guna2 style ổn định

            // 2) Tắt AutoScroll của container khi bung dropdown (tránh panel cuộn làm combo "nhảy")
            bool savedScroll = false;
            ScrollableControl scrollHost = null;

            cb.DropDown -= Cb_DropDown;
            cb.DropDownClosed -= Cb_DropDownClosed;
            cb.DropDown += Cb_DropDown;
            cb.DropDownClosed += Cb_DropDownClosed;

            void Cb_DropDown(object s, EventArgs e)
            {
                scrollHost = FindScrollHost(cb);
                if (scrollHost != null)
                {
                    savedScroll = scrollHost.AutoScroll;
                    scrollHost.AutoScroll = false;
                }
            }

            void Cb_DropDownClosed(object s, EventArgs e)
            {
                if (scrollHost != null)
                {
                    scrollHost.AutoScroll = savedScroll;
                    scrollHost = null;
                }
            }
        }

        /// <summary>Tìm container gần nhất có AutoScroll = true.</summary>
        private static ScrollableControl FindScrollHost(Control c)
        {
            while (c != null)
            {
                if (c is ScrollableControl sc && sc.AutoScroll) return sc;
                c = c.Parent;
            }
            return null;
        }
    }
}
