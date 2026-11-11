using MunicipalServicesApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp.UI
{
    // Central place for the look and feel of the whole application.
    // Change a colour here and every form follows.
    public static class Theme
    {
        public static readonly Color Primary = Color.FromArgb(12, 74, 110);
        public static readonly Color PrimaryDark = Color.FromArgb(7, 44, 70);
        public static readonly Color PrimaryHover = Color.FromArgb(21, 101, 146);
        public static readonly Color Accent = Color.FromArgb(0, 122, 77);
        public static readonly Color Gold = Color.FromArgb(255, 182, 18);
        public static readonly Color Background = Color.FromArgb(238, 243, 248);
        public static readonly Color Surface = Color.White;
        public static readonly Color TextDark = Color.FromArgb(30, 41, 54);
        public static readonly Color TextMuted = Color.FromArgb(98, 112, 128);
        public static readonly Color Border = Color.FromArgb(205, 214, 224);
        public static readonly Color RowAlternate = Color.FromArgb(246, 249, 252);

        // Colours of the South African flag, used for the header strip.
        public static readonly Color[] FlagColors = new Color[]
        {
            Color.FromArgb(0, 122, 77),
            Color.FromArgb(255, 182, 18),
            Color.FromArgb(222, 56, 49),
            Color.FromArgb(0, 35, 149),
            Color.FromArgb(20, 20, 20)
        };

        public static Color StatusColor(RequestStatus status)
        {
            switch (status)
            {
                case RequestStatus.Submitted:
                    return Color.FromArgb(108, 117, 125);
                case RequestStatus.UnderReview:
                    return Color.FromArgb(205, 125, 0);
                case RequestStatus.InProgress:
                    return Color.FromArgb(13, 110, 185);
                default:
                    return Accent;
            }
        }

        public static Color PriorityColor(int priority)
        {
            switch (priority)
            {
                case 1:
                    return Color.FromArgb(200, 35, 51);
                case 2:
                    return Color.FromArgb(225, 105, 0);
                case 3:
                    return Color.FromArgb(150, 120, 0);
                default:
                    return Color.FromArgb(80, 110, 130);
            }
        }

        // Applies the theme to a form and everything on it.
        public static void Apply(Form form)
        {
            form.BackColor = Background;
            StyleChildren(form);
        }

        private static void StyleChildren(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // These controls draw themselves.
                if (c is AppHeader || c is TileButton)
                {
                    continue;
                }

                UseSegoeFont(c);

                TabPage page = c as TabPage;

                if (page != null)
                {
                    page.UseVisualStyleBackColor = false;
                    page.BackColor = Background;
                }

                Button button = c as Button;

                if (button != null)
                {
                    StyleButton(button);
                }

                DataGridView grid = c as DataGridView;

                if (grid != null)
                {
                    StyleGrid(grid);
                }

                if (c is GroupBox || c is Panel || c is TabControl || c is TabPage)
                {
                    StyleChildren(c);
                }
            }
        }

        private static void UseSegoeFont(Control c)
        {
            if (c.Font != null && c.Font.Name == "Microsoft Sans Serif")
            {
                c.Font = new Font("Segoe UI", c.Font.Size, c.Font.Style, c.Font.Unit);
            }
        }

        private static bool IsSecondaryButton(string text)
        {
            string t = (text ?? "").ToLower();

            return t.Contains("back") || t.Contains("exit") ||
                   t.Contains("close") || t.Contains("clear") ||
                   t.Contains("reset") || t.Contains("show all");
        }

        public static void StyleButton(Button button)
        {
            button.UseVisualStyleBackColor = false;
            button.FlatStyle = FlatStyle.Flat;
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 1;

            if (IsSecondaryButton(button.Text))
            {
                button.BackColor = Color.White;
                button.ForeColor = Primary;
                button.FlatAppearance.BorderColor = Primary;
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(225, 236, 245);
                button.FlatAppearance.MouseDownBackColor = Color.FromArgb(205, 223, 238);
            }
            else
            {
                button.BackColor = Primary;
                button.ForeColor = Color.White;
                button.FlatAppearance.BorderColor = Primary;
                button.FlatAppearance.MouseOverBackColor = PrimaryHover;
                button.FlatAppearance.MouseDownBackColor = PrimaryDark;
            }
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.EnableHeadersVisualStyles = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(226, 232, 240);

            grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(205, 226, 243);
            grid.DefaultCellStyle.SelectionForeColor = TextDark;
            grid.DefaultCellStyle.ForeColor = TextDark;
            grid.AlternatingRowsDefaultCellStyle.BackColor = RowAlternate;
        }

        // A rounded rectangle outline, used for cards and tiles.
        public static GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
