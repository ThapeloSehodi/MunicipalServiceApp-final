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
    // A large card-style button used on the main menu.
    public class TileButton : Button
    {
        private bool hover;
        private string title = "Title";
        private string description = "";
        private string iconText = "!";
        private Color accentColor = Color.FromArgb(12, 74, 110);

        public TileButton()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            Cursor = Cursors.Hand;
            FlatStyle = FlatStyle.Flat;
        }

        [Category("Tile")]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                Invalidate();
            }
        }

        [Category("Tile")]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                Invalidate();
            }
        }

        [Category("Tile")]
        public string IconText
        {
            get { return iconText; }
            set
            {
                iconText = value;
                Invalidate();
            }
        }

        [Category("Tile")]
        public Color AccentColor
        {
            get { return accentColor; }
            set
            {
                accentColor = value;
                Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (Width < 20 || Height < 20)
            {
                return;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.Clear(Parent != null ? Parent.BackColor : Theme.Background);

            Rectangle card = new Rectangle(2, 2, Width - 7, Height - 8);
            Rectangle shadow = new Rectangle(card.X + 2, card.Y + 3, card.Width, card.Height);

            using (GraphicsPath shadowPath = Theme.RoundedRectangle(shadow, 10))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(28, 0, 0, 0)))
            {
                g.FillPath(shadowBrush, shadowPath);
            }

            using (GraphicsPath cardPath = Theme.RoundedRectangle(card, 10))
            {
                Color fill = hover ? Color.FromArgb(244, 250, 255) : Color.White;
                Color border = hover ? accentColor : Theme.Border;

                using (SolidBrush fillBrush = new SolidBrush(fill))
                {
                    g.FillPath(fillBrush, cardPath);
                }

                // Accent bar on the left edge, clipped to the card shape
                g.SetClip(cardPath);

                using (SolidBrush accentBrush = new SolidBrush(accentColor))
                {
                    g.FillRectangle(accentBrush, card.X, card.Y, 7, card.Height);
                }

                g.ResetClip();

                using (Pen borderPen = new Pen(border, hover ? 2f : 1f))
                {
                    g.DrawPath(borderPen, cardPath);
                }
            }

            // Icon circle
            Rectangle icon = new Rectangle(card.X + 26, card.Y + 22, 54, 54);

            using (SolidBrush iconBrush = new SolidBrush(accentColor))
            {
                g.FillEllipse(iconBrush, icon);
            }

            using (Font iconFont = new Font("Segoe UI Symbol", 20F, FontStyle.Bold))
            using (StringFormat center = new StringFormat())
            {
                center.Alignment = StringAlignment.Center;
                center.LineAlignment = StringAlignment.Center;
                g.DrawString(iconText ?? "", iconFont, Brushes.White, icon, center);
            }

            // Title and description
            using (Font titleFont = new Font("Segoe UI Semibold", 12.5F))
            using (SolidBrush titleBrush = new SolidBrush(Theme.TextDark))
            {
                g.DrawString(title ?? "", titleFont, titleBrush, card.X + 24, card.Y + 88);
            }

            using (Font descFont = new Font("Segoe UI", 9F))
            using (SolidBrush descBrush = new SolidBrush(Theme.TextMuted))
            {
                RectangleF descRect = new RectangleF(
                    card.X + 24,
                    card.Y + 116,
                    card.Width - 44,
                    card.Height - 122);

                g.DrawString(description ?? "", descFont, descBrush, descRect);
            }
        }
    }
}
