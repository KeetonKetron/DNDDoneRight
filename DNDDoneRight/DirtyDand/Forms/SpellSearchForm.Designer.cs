
namespace DirtyDand
{
    partial class SpellSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSpellMain = new System.Windows.Forms.Panel();
            this.dataGridViewSpells = new System.Windows.Forms.DataGridView();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearchBar = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            this.panelSpellMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpells)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelSpellMain);
            this.panelMain.Controls.Add(this.panelSearch);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1632, 918);
            this.panelMain.TabIndex = 3;
            // 
            // panelSpellMain
            // 
            this.panelSpellMain.AutoScroll = true;
            this.panelSpellMain.BackColor = System.Drawing.Color.Black;
            this.panelSpellMain.Controls.Add(this.dataGridViewSpells);
            this.panelSpellMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSpellMain.Location = new System.Drawing.Point(0, 151);
            this.panelSpellMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelSpellMain.Name = "panelSpellMain";
            this.panelSpellMain.Size = new System.Drawing.Size(1632, 767);
            this.panelSpellMain.TabIndex = 7;
            // 
            // dataGridViewSpells
            // 
            this.dataGridViewSpells.AllowUserToAddRows = false;
            this.dataGridViewSpells.AllowUserToDeleteRows = false;
            this.dataGridViewSpells.AllowUserToOrderColumns = true;
            this.dataGridViewSpells.AllowUserToResizeColumns = false;
            this.dataGridViewSpells.AllowUserToResizeRows = false;
            this.dataGridViewSpells.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewSpells.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSpells.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewSpells.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewSpells.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSpells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSpells.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSpells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSpells.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dataGridViewSpells.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSpells.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewSpells.Name = "dataGridViewSpells";
            this.dataGridViewSpells.ReadOnly = true;
            this.dataGridViewSpells.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSpells.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.LightGray;
            this.dataGridViewSpells.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSpells.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSpells.Size = new System.Drawing.Size(1632, 767);
            this.dataGridViewSpells.TabIndex = 0;
            this.dataGridViewSpells.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSpells_CellDoubleClick);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelSearch.Controls.Add(this.buttonSearch);
            this.panelSearch.Controls.Add(this.textBoxSearchBar);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(4);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1632, 151);
            this.panelSearch.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.ForeColor = System.Drawing.Color.LightGray;
            this.buttonSearch.Location = new System.Drawing.Point(1340, 12);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(200, 127);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearchBar
            // 
            this.textBoxSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxSearchBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 68F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchBar.ForeColor = System.Drawing.Color.LightGray;
            this.textBoxSearchBar.Location = new System.Drawing.Point(13, 12);
            this.textBoxSearchBar.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSearchBar.Name = "textBoxSearchBar";
            this.textBoxSearchBar.Size = new System.Drawing.Size(1303, 103);
            this.textBoxSearchBar.TabIndex = 0;
            this.textBoxSearchBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchBar_KeyPress);
            // 
            // SpellSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 918);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SpellSearchForm";
            this.Text = "SpellForm";
            this.panelMain.ResumeLayout(false);
            this.panelSpellMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpells)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearchBar;
        private System.Windows.Forms.Panel panelSpellMain;
        private System.Windows.Forms.DataGridView dataGridViewSpells;
    }
}