using DirtyDand.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static DirtyDand.Globals.GlobalVariables;


namespace DirtyDand
{
    public partial class SpellSearchForm : Form
    {
        Dictionary<string,Spell> spellList = new Dictionary<string, Spell>(spellRegistry);
        DataTable spellTable;
        MainForm main;
         
        public SpellSearchForm(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeSpells();
        }

        private void InitializeSpells()
        {

            spellTable = new DataTable();
            spellTable.Columns.Add("Spell Name", typeof(string));
            spellTable.Columns.Add("Level", typeof(int));
            spellTable.Columns.Add("School", typeof(School));
            spellTable.Columns.Add("Ritual", typeof(bool));
            spellTable.Columns.Add("Cast Time", typeof(string));
            spellTable.Columns.Add("Range", typeof(string));
            spellTable.Columns.Add("Con.", typeof(bool));
            spellTable.Columns.Add("Duration", typeof(string));
            spellTable.Columns.Add("Source", typeof(Source));
            foreach (KeyValuePair<string,Spell> spell in spellList)
            {
                spellTable.Rows.Add(spell.Value.spellName, spell.Value.level, spell.Value.school, spell.Value.ritual, spell.Value.GetCastTime(), spell.Value.GetRange(), spell.Value.concentration, spell.Value.duration, spell.Value.source);
            }
            dataGridViewSpells.DataSource = spellTable;
            dataGridViewSpells.ReadOnly = true;

            dataGridViewSpells.AutoResizeColumns();
            dataGridViewSpells.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewSpells.RowHeadersVisible = false;

        }

        private void UpdateTable(string search)
        {

            Dictionary<string, Spell> temp = new Dictionary<string, Spell>(spellRegistry);
            spellList = new Dictionary<string, Spell>(spellRegistry);
            foreach (KeyValuePair<string,Spell> spell in temp)
            {
                if (!spell.Key.ToLower().Contains(search.ToLower()))
                        spellList.Remove(spell.Key);
                    
            }
            spellTable.Clear();
            foreach (KeyValuePair<string, Spell> spell in spellList)
            {
                spellTable.Rows.Add(spell.Value.spellName, spell.Value.level, spell.Value.school, spell.Value.ritual, spell.Value.GetCastTime(), spell.Value.GetRange(), spell.Value.concentration, spell.Value.duration, spell.Value.source);
            }
            dataGridViewSpells.DataSource = spellTable;
            dataGridViewSpells.ClearSelection();

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            UpdateTable(textBoxSearchBar.Text);
        }

        private void dataGridViewSpells_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewSpells.SelectedRows;
            if (rows.Count == 1)
                main.OpenSpellForm(spellList[rows[0].Cells[0].Value.ToString().ToLower()]);
                
        }
         
        private void textBoxSearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                UpdateTable(textBoxSearchBar.Text);
        }
    }



}
