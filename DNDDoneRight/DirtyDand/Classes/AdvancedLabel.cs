using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DirtyDand.Classes
{
    public class AdvancedLabel : Panel
    {

        string text;
        public Label main;
        Label bold;
        List<Label> tipLabels = new List<Label>();
        public AdvancedLabel(string text, string[] tips = null, string[] spell = null)
        {
            string bold = "";
            this.text = text;
            main = new Label();


            string[] ary = text.Split(new char[] { '|' });
            if (ary.Length == 2)
            {
                this.bold = new Label();
                bold = ary[0];
                text = ary[1];
            }
            if (tips != null)
                for(int i = 0; i < tips.Length; i++)
                {
                    string replacement = "tip" + i;
                    while (TextRenderer.MeasureText(replacement, main.Font).Width < TextRenderer.MeasureText(tips[i], main.Font).Width)
                        replacement += " ";
                    tipLabels.Add(new Label());
                    Controls.Add(tipLabels.Last());
                    tipLabels.Last().Text = "TESTING THE TIP LABEL";
                    tipLabels.Last().Location = new Point(TextRenderer.MeasureText(text.Substring(0, text.ToLower().IndexOf(tips[i].ToLower())), main.Font).Width % Size.Width, TextRenderer.MeasureText(text.Substring(0, text.ToLower().IndexOf(tips[i].ToLower())), main.Font).Width / Size.Width);
                    this.text = this.text.Substring(0, text.IndexOf(tips[i])) + replacement + text.Remove(0, text.IndexOf(tips[i]) + replacement.Length);
                }


            if (this.bold != null)
            {
                Controls.Add(this.bold);
                this.bold.Text = bold;
                this.bold.Font = new Font(this.bold.Font.FontFamily, 10, FontStyle.Bold);
                this.bold.BringToFront();
                this.bold.AutoSize = true;
                this.bold.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                do
                {
                    text = "  " + text;
                }
                while (TextRenderer.MeasureText(text.Substring(0, text.LastIndexOf("  ")), new Font(this.bold.Font.FontFamily, 10, FontStyle.Regular)).Width < TextRenderer.MeasureText(bold, new Font(this.bold.Font.FontFamily, 10, FontStyle.Bold)).Width);
                text = text.Remove(0, 1);
            }

            main.Text = this.text;
            main.Dock = DockStyle.Fill;
            main.AutoSize = true;
            main.MaximumSize = Size;
            Controls.Add(main);
            Text += "\n";
        }

        public void UpdateLocation()
        {
            for(int i = 0; i < tipLabels.Count; i++)
            {
                tipLabels[i].Location = new Point(TextRenderer.MeasureText(text.Substring(0, text.IndexOf("tip"+i)), main.Font).Width % Size.Width, TextRenderer.MeasureText(text.Substring(0, text.IndexOf("tip" + i)), main.Font).Width / Size.Width);
            }
        }
        /*protected override void OnPaint(PaintEventArgs e)
         {
            Point drawPoint = new Point(0, 0);

            string[] ary = Text.Split(new char[] { '|' });
            if (ary.Length == 2)
            {
                Font normalFont = this.Font;

                Font boldFont = new Font(normalFont, FontStyle.Bold);

                Size boldSize = TextRenderer.MeasureText(ary[0], boldFont);
                Size normalSize = TextRenderer.MeasureText(ary[1], normalFont);

                Rectangle boldRect = new Rectangle(drawPoint, boldSize);
                Rectangle normalRect = new Rectangle(
                    boldRect.Right, boldRect.Top, normalSize.Width, normalSize.Height);

                TextRenderer.DrawText(e.Graphics, ary[0], boldFont, boldRect, ForeColor);
                TextRenderer.DrawText(e.Graphics, ary[1], normalFont, normalRect, ForeColor);
            }
            else
            {
                TextRenderer.DrawText(e.Graphics, Text, Font, drawPoint, ForeColor);
            }
        }*/
    }
}
