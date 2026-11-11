using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp.UI
{
    // The banner shown at the top of every form.
    // Set the Title and Subtitle properties in the designer.
    public class AppHeader : Panel
    {
        private string title = "Municipal Services";
        private string subtitle = "";

        public AppHeader()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            Dock = DockStyle.Top;
            Height = 72;
        }

        [Category("Header")]
        [DefaultValue("Municipal Services")]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                Invalidate();
            }
        }

        [Category("Header")]
        [DefaultValue("")]
        public string Subtitle
        {
            get { return subtitle; }
            set
            {
                subtitle = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;

            if (rect.Width <= 0 || rect.Height <= 0)
            {
                return;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Background gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, Theme.PrimaryDark, Theme.PrimaryHover, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, rect);
            }

            // South African flag colour strip along the bottom
            int stripHeight = 4;
            float segmentWidth = rect.Width / (float)Theme.FlagColors.Length;

            for (int i = 0; i < Theme.FlagColors.Length; i++)
            {
                using (SolidBrush stripBrush = new SolidBrush(Theme.FlagColors[i]))
                {
                    g.FillRectangle(
                        stripBrush,
                        i * segmentWidth,
                        rect.Height - stripHeight,
                        segmentWidth + 1,
                        stripHeight);
                }
            }

            // Emblem
            int emblemSize = 44;
            Rectangle emblem = new Rectangle(
                20,
                (rect.Height - stripHeight - emblemSize) / 2,
                emblemSize,
                emblemSize);

            using (SolidBrush goldBrush = new SolidBrush(Theme.Gold))
            {
                g.FillEllipse(goldBrush, emblem);
            }

            using (Pen ring = new Pen(Color.White, 2f))
            {
                g.DrawEllipse(ring, emblem);
            }

            using (Font emblemFont = new Font("Segoe UI", 13F, FontStyle.Bold))
            using (SolidBrush emblemBrush = new SolidBrush(Theme.PrimaryDark))
            using (StringFormat center = new StringFormat())
            {
                center.Alignment = StringAlignment.Center;
                center.LineAlignment = StringAlignment.Center;
                g.DrawString("MS", emblemFont, emblemBrush, emblem, center);
            }

            // Title and subtitle
            using (Font titleFont = new Font("Segoe UI Semibold", 17F))
            using (SolidBrush white = new SolidBrush(Color.White))
            {
                g.DrawString(title ?? "", titleFont, white, 76, 9);
            }

            using (Font subtitleFont = new Font("Segoe UI", 9.5F))
            using (SolidBrush soft = new SolidBrush(Color.FromArgb(196, 219, 236)))
            {
                g.DrawString(subtitle ?? "", subtitleFont, soft, 78, 41);
            }

            // Right hand side: portal name and today's date
            if (rect.Width > 650)
            {
                using (StringFormat far = new StringFormat())
                using (Font smallBold = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (Font small = new Font("Segoe UI", 9F))
                using (SolidBrush goldText = new SolidBrush(Theme.Gold))
                using (SolidBrush soft = new SolidBrush(Color.FromArgb(196, 219, 236)))
                {
                    far.Alignment = StringAlignment.Far;

                    RectangleF line1 = new RectangleF(rect.Width - 340, 16, 320, 20);
                    RectangleF line2 = new RectangleF(rect.Width - 340, 38, 320, 20);

                    g.DrawString("MUNICIPAL SERVICES PORTAL", smallBold, goldText, line1, far);
                    g.DrawString(DateTime.Now.ToString("dddd, d MMMM yyyy"), small, soft, line2, far);
                }
            }
        }
    }
}
