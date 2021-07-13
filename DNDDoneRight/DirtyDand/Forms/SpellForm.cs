using DirtyDand.Classes;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DirtyDand
{
    public partial class SpellForm : Form
    {
        Spell spell;
        MainForm main;
        List<AdvancedLabel> labels = new List<AdvancedLabel>();
        List<DataTable> tables = new List<DataTable>();
        List<DataGridView> dataGridViews = new List<DataGridView>();
        List<Panel> tablePanel = new List<Panel>();

        public SpellForm(Spell spell, MainForm main)
        {
            this.spell = spell;
            this.main = main;
            InitializeComponent();
            InitializeOtherComponent();
        }

        private void InitializeOtherComponent()
        {
            List<int> type = new List<int>();
            int tableCount = 0;
            int labelCount = 0;

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();


            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Red;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = Color.LightGray;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = Color.LightGray;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;


            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Red;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = Color.Transparent;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;


            dataGridViewCellStyle3.BackColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.ForeColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionBackColor = Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;


            labels.Add(new AdvancedLabel(spell.spellName));
            type.Add(0);
            labelCount++;
            if (spell.level == 0)
                labels.Add(new AdvancedLabel(spell.school.ToString() + " cantrip"));
            else
            {
                switch (spell.level)
                {
                    case 1:
                        labels.Add(new AdvancedLabel(spell.level + "st-level " + spell.school));
                        break;
                    case 2:
                        labels.Add(new AdvancedLabel(spell.level + "nd-level " + spell.school));
                        break;
                    case 3:
                        labels.Add(new AdvancedLabel(spell.level + "rd-level " + spell.school));
                        break;
                    default:
                        labels.Add(new AdvancedLabel(spell.level + "th-level " + spell.school));
                        break;
                }
            }
            if (spell.ritual)
                labels.Last().Text += " ritual";
            type.Add(0);
            labelCount++;

            labels.Add(new AdvancedLabel("Casting Time:|" + spell.GetCastTime()));
            type.Add(0);
            labelCount++;

            labels.Add(new AdvancedLabel("Range:|" + spell.GetRange()));
            type.Add(0);
            labelCount++;

            labels.Add(new AdvancedLabel("Components:|" + spell.GetComponents()));
            type.Add(0);
            labelCount++;

            if(spell.concentration)
                labels.Add(new AdvancedLabel("Duration:|" + "Concentration, up to " + spell.duration));
            else
                labels.Add(new AdvancedLabel("Duration:|" +  spell.duration));
            type.Add(0);
            labelCount++;

            string bold = string.Empty;
            string[] description = spell.spellDescript.Split('\n');
            List<string> tips = new List<string>();

            for (int i = 0; i < description.Length; i++)
            {
                switch (description[i])
                {
                    case "{BOLD}":
                        bold = description[i + 1];
                        i += 2;
                        break;
                    case "{TIP}":
                        tips.Add(description[i + 1]);
                        i += 2;
                        break;
                    case "{TABLE}":
                        type.Add(1);
                        tableCount++;
                        dataGridViews.Add(new DataGridView());
                        tables.Add(new DataTable());
                        tablePanel.Add(new Panel());
                        dataGridViews.Last().TabIndex = i;
                        i += 2;
                        tables.Last().TableName = description[i];
                        i += 4;
                        do
                        {
                            tables.Last().Columns.Add(description[i], typeof(string));
                            i++;
                        }
                        while (description[i] != "");
                        i += 2;
                        do
                        {
                            List<string> row = new List<string>();
                            do
                            {
                                row.Add(description[i]);
                                i++;
                            } while (description[i] != "");
                            tables.Last().Rows.Add(row.ToArray());
                            i += 2;
                        } while (description[i] != "{/TABLE}");
                        break;
                    default:
                        labels.Add(new AdvancedLabel(bold + "| " + description[i], tips.ToArray()));
                        type.Add(0);
                        labelCount++;
                        labels.Last().TabIndex = i;
                        bold = string.Empty;
                        tips.Clear();
                        break;
                }

            }



            for (int i = type.Count - 1; i >= 0; i--)
            {
                if (type[i] == 0)
                {
                    labelCount--;
                    panelMain.Controls.Add(labels[labelCount]);
                    labels[labelCount].Dock = DockStyle.Top;
                    labels[labelCount].Name = "label" + i;
                    labels[labelCount].AutoSize = true;
                    labels[labelCount].MaximumSize = panelMain.Size;
                }
                else
                {
                    tableCount--;
                    dataGridViews[tableCount].DataSource = tables[tableCount];

                    dataGridViews[tableCount].AutoResizeColumns();
                    dataGridViews[tableCount].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridViews[tableCount].ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    dataGridViews[tableCount].BorderStyle = BorderStyle.None;
                    dataGridViews[tableCount].CellBorderStyle = DataGridViewCellBorderStyle.None;
                    dataGridViews[tableCount].ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    dataGridViews[tableCount].ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
                    dataGridViews[tableCount].DefaultCellStyle = dataGridViewCellStyle1;
                    dataGridViews[tableCount].RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
                    dataGridViews[tableCount].RowsDefaultCellStyle = dataGridViewCellStyle3;


                    panelMain.Controls.Add(tablePanel[tableCount]);
                    tablePanel[tableCount].Controls.Add(dataGridViews[tableCount]);
                    tablePanel[tableCount].Dock = DockStyle.Top;
                    tablePanel[tableCount].AutoSize = true;


                    dataGridViews[tableCount].ReadOnly = true;
                    dataGridViews[tableCount].AllowUserToAddRows = false;
                    dataGridViews[tableCount].AllowUserToDeleteRows = false;
                    dataGridViews[tableCount].AllowUserToOrderColumns = true;
                    dataGridViews[tableCount].AllowUserToResizeColumns = false;
                    dataGridViews[tableCount].AllowUserToResizeRows = false;

                    dataGridViews[tableCount].BackgroundColor = Color.Black;

                    dataGridViews[tableCount].Dock = DockStyle.Fill;

                    dataGridViews[tableCount].GridColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

                    dataGridViews[tableCount].Name = "dataGridViewSpells" + i;
                    dataGridViews[tableCount].RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    dataGridViews[tableCount].SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViews[tableCount].RowHeadersVisible = false;

                    dataGridViews[tableCount].AutoSize = true;
                    tablePanel[tableCount].MaximumSize = new Size(panelMain.Size.Width, 100 * dataGridViews[tableCount].RowCount);
                    tablePanel[tableCount].MinimumSize = new Size(10, 75 * dataGridViews[tableCount].RowCount);
                }
            }

        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            main.closeTopForm();
        }

        private void panelMain_SizeChanged(object sender, System.EventArgs e)
        {
            foreach (AdvancedLabel l in labels)
            {
                l.MaximumSize = panelMain.Size;
                l.main.MaximumSize = panelMain.Size;
                l.UpdateLocation();
            }
            foreach (DataGridView d in dataGridViews)
            {
                d.MaximumSize = panelMain.Size;
            }
        }
    }
}
