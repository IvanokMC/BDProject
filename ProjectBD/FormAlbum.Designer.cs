namespace ProjectBD
{
    partial class FormAlbum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAlbums;
        private System.Windows.Forms.Button btnEditarAlbum;
        private System.Windows.Forms.Button btnEliminarAlbum;

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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblArtista = new System.Windows.Forms.Label();
            this.cmbArtista = new System.Windows.Forms.ComboBox();
            this.lblAnioLanzamiento = new System.Windows.Forms.Label();
            this.txtAnioLanzamiento = new System.Windows.Forms.TextBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.btnGuardarAlbum = new System.Windows.Forms.Button();
            this.dgvAlbums = new System.Windows.Forms.DataGridView();
            this.btnEditarAlbum = new System.Windows.Forms.Button();
            this.btnEliminarAlbum = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbums)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(30, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(43, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título:";
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(150, 27);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(250, 22);
            this.txtTitulo.TabIndex = 1;
            this.txtTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtTitulo.ForeColor = System.Drawing.Color.White;
            // 
            // lblArtista
            // 
            this.lblArtista.AutoSize = true;
            this.lblArtista.Location = new System.Drawing.Point(30, 70);
            this.lblArtista.Name = "lblArtista";
            this.lblArtista.Size = new System.Drawing.Size(51, 16);
            this.lblArtista.TabIndex = 2;
            this.lblArtista.Text = "Artista:";
            this.lblArtista.ForeColor = System.Drawing.Color.White;
            // 
            // cmbArtista
            // 
            this.cmbArtista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArtista.FormattingEnabled = true;
            this.cmbArtista.Location = new System.Drawing.Point(150, 67);
            this.cmbArtista.Name = "cmbArtista";
            this.cmbArtista.Size = new System.Drawing.Size(250, 24);
            this.cmbArtista.TabIndex = 3;
            this.cmbArtista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmbArtista.ForeColor = System.Drawing.Color.White;
            // 
            // lblAnioLanzamiento
            // 
            this.lblAnioLanzamiento.AutoSize = true;
            this.lblAnioLanzamiento.Location = new System.Drawing.Point(30, 110);
            this.lblAnioLanzamiento.Name = "lblAnioLanzamiento";
            this.lblAnioLanzamiento.Size = new System.Drawing.Size(114, 16);
            this.lblAnioLanzamiento.TabIndex = 4;
            this.lblAnioLanzamiento.Text = "Año Lanzamiento:";
            this.lblAnioLanzamiento.ForeColor = System.Drawing.Color.White;
            // 
            // txtAnioLanzamiento
            // 
            this.txtAnioLanzamiento.Location = new System.Drawing.Point(150, 107);
            this.txtAnioLanzamiento.Name = "txtAnioLanzamiento";
            this.txtAnioLanzamiento.Size = new System.Drawing.Size(100, 22);
            this.txtAnioLanzamiento.TabIndex = 5;
            this.txtAnioLanzamiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtAnioLanzamiento.ForeColor = System.Drawing.Color.White;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(30, 150);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(57, 16);
            this.lblGenero.TabIndex = 6;
            this.lblGenero.Text = "Género:";
            this.lblGenero.ForeColor = System.Drawing.Color.White;
            // 
            // txtGenero
            // 
            this.txtGenero.Location = new System.Drawing.Point(150, 147);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(250, 22);
            this.txtGenero.TabIndex = 7;
            this.txtGenero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtGenero.ForeColor = System.Drawing.Color.White;
            // 
            // btnGuardarAlbum
            // 
            this.btnGuardarAlbum.Location = new System.Drawing.Point(30, 200);
            this.btnGuardarAlbum.Name = "btnGuardarAlbum";
            this.btnGuardarAlbum.Size = new System.Drawing.Size(100, 35);
            this.btnGuardarAlbum.TabIndex = 8;
            this.btnGuardarAlbum.Text = "Guardar";
            this.btnGuardarAlbum.UseVisualStyleBackColor = true;
            this.btnGuardarAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnGuardarAlbum.ForeColor = System.Drawing.Color.White;
            this.btnGuardarAlbum.Click += new System.EventHandler(this.btnGuardarAlbum_Click);
            // 
            // dgvAlbums
            // 
            this.dgvAlbums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbums.Location = new System.Drawing.Point(420, 27);
            this.dgvAlbums.Name = "dgvAlbums";
            this.dgvAlbums.RowHeadersWidth = 51;
            this.dgvAlbums.RowTemplate.Height = 24;
            this.dgvAlbums.Size = new System.Drawing.Size(350, 350);
            this.dgvAlbums.TabIndex = 9;
            this.dgvAlbums.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlbums.ForeColor = System.Drawing.Color.Black;
            this.dgvAlbums.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvAlbums.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvAlbums.EnableHeadersVisualStyles = false;
            this.dgvAlbums.SelectionChanged += new System.EventHandler(this.dgvAlbums_SelectionChanged);
            // 
            // btnEditarAlbum
            // 
            this.btnEditarAlbum.Location = new System.Drawing.Point(150, 200);
            this.btnEditarAlbum.Name = "btnEditarAlbum";
            this.btnEditarAlbum.Size = new System.Drawing.Size(100, 35);
            this.btnEditarAlbum.TabIndex = 10;
            this.btnEditarAlbum.Text = "Editar";
            this.btnEditarAlbum.UseVisualStyleBackColor = true;
            this.btnEditarAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEditarAlbum.ForeColor = System.Drawing.Color.White;
            this.btnEditarAlbum.Click += new System.EventHandler(this.btnEditarAlbum_Click);
            // 
            // btnEliminarAlbum
            // 
            this.btnEliminarAlbum.Location = new System.Drawing.Point(270, 200);
            this.btnEliminarAlbum.Name = "btnEliminarAlbum";
            this.btnEliminarAlbum.Size = new System.Drawing.Size(100, 35);
            this.btnEliminarAlbum.TabIndex = 11;
            this.btnEliminarAlbum.Text = "Eliminar";
            this.btnEliminarAlbum.UseVisualStyleBackColor = true;
            this.btnEliminarAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEliminarAlbum.ForeColor = System.Drawing.Color.White;
            this.btnEliminarAlbum.Click += new System.EventHandler(this.btnEliminarAlbum_Click);
            // 
            // FormAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEliminarAlbum);
            this.Controls.Add(this.btnEditarAlbum);
            this.Controls.Add(this.dgvAlbums);
            this.Controls.Add(this.btnGuardarAlbum);
            this.Controls.Add(this.txtGenero);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.txtAnioLanzamiento);
            this.Controls.Add(this.lblAnioLanzamiento);
            this.Controls.Add(this.cmbArtista);
            this.Controls.Add(this.lblArtista);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormAlbum";
            this.Text = "Álbum";
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Load += new System.EventHandler(this.FormAlbum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbums)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblArtista;
        private System.Windows.Forms.ComboBox cmbArtista;
        private System.Windows.Forms.Label lblAnioLanzamiento;
        private System.Windows.Forms.TextBox txtAnioLanzamiento;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.Button btnGuardarAlbum;
    }
}