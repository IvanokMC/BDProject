namespace ProjectBD
{
    partial class FormMusica
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.btnSearchArtistas = new System.Windows.Forms.Button();
            this.btnSearchCanciones = new System.Windows.Forms.Button();
            this.btnSearchAlbums = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnAgregarCancion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(120, 16);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Término de búsqueda:";
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(138, 17);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(300, 22);
            this.txtSearchTerm.TabIndex = 1;
            this.txtSearchTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtSearchTerm.ForeColor = System.Drawing.Color.White;
            // 
            // btnSearchArtistas
            // 
            this.btnSearchArtistas.Location = new System.Drawing.Point(15, 50);
            this.btnSearchArtistas.Name = "btnSearchArtistas";
            this.btnSearchArtistas.Size = new System.Drawing.Size(150, 30);
            this.btnSearchArtistas.TabIndex = 2;
            this.btnSearchArtistas.Text = "Buscar Artistas por Nombre";
            this.btnSearchArtistas.UseVisualStyleBackColor = true;
            this.btnSearchArtistas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSearchArtistas.ForeColor = System.Drawing.Color.White;
            this.btnSearchArtistas.Click += new System.EventHandler(this.btnSearchArtistas_Click);
            // 
            // btnSearchCanciones
            // 
            this.btnSearchCanciones.Location = new System.Drawing.Point(171, 50);
            this.btnSearchCanciones.Name = "btnSearchCanciones";
            this.btnSearchCanciones.Size = new System.Drawing.Size(200, 30);
            this.btnSearchCanciones.TabIndex = 3;
            this.btnSearchCanciones.Text = "Buscar Canciones (Título/Género)";
            this.btnSearchCanciones.UseVisualStyleBackColor = true;
            this.btnSearchCanciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSearchCanciones.ForeColor = System.Drawing.Color.White;
            this.btnSearchCanciones.Click += new System.EventHandler(this.btnSearchCanciones_Click);
            // 
            // btnSearchAlbums
            // 
            this.btnSearchAlbums.Location = new System.Drawing.Point(377, 50);
            this.btnSearchAlbums.Name = "btnSearchAlbums";
            this.btnSearchAlbums.Size = new System.Drawing.Size(180, 30);
            this.btnSearchAlbums.TabIndex = 4;
            this.btnSearchAlbums.Text = "Buscar Álbumes (Título/Artista)";
            this.btnSearchAlbums.UseVisualStyleBackColor = true;
            this.btnSearchAlbums.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSearchAlbums.ForeColor = System.Drawing.Color.White;
            this.btnSearchAlbums.Click += new System.EventHandler(this.btnSearchAlbums_Click);
            // 
            // dgvResultados
            // 
            this.dgvResultados.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultados.ForeColor = System.Drawing.Color.Black;
            this.dgvResultados.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvResultados.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvResultados.EnableHeadersVisualStyles = false;
            this.dgvResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultados.Location = new System.Drawing.Point(15, 95);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.RowHeadersWidth = 51;
            this.dgvResultados.Size = new System.Drawing.Size(770, 343);
            this.dgvResultados.TabIndex = 5;
            // 
            // btnAgregarCancion
            // 
            this.btnAgregarCancion.Location = new System.Drawing.Point(563, 50);
            this.btnAgregarCancion.Name = "btnAgregarCancion";
            this.btnAgregarCancion.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarCancion.TabIndex = 6;
            this.btnAgregarCancion.Text = "Agregar Canción";
            this.btnAgregarCancion.UseVisualStyleBackColor = true;
            this.btnAgregarCancion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnAgregarCancion.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCancion.Click += new System.EventHandler(this.btnAgregarCancion_Click);
            // 
            // btnGestionarAlbums
            // 
            this.btnGestionarAlbums = new System.Windows.Forms.Button();
            this.btnGestionarAlbums.Location = new System.Drawing.Point(719, 50);
            this.btnGestionarAlbums.Name = "btnGestionarAlbums";
            this.btnGestionarAlbums.Size = new System.Drawing.Size(150, 30);
            this.btnGestionarAlbums.TabIndex = 7;
            this.btnGestionarAlbums.Text = "Gestionar Álbumes";
            this.btnGestionarAlbums.UseVisualStyleBackColor = true;
            this.btnGestionarAlbums.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnGestionarAlbums.ForeColor = System.Drawing.Color.White;
            this.btnGestionarAlbums.Click += new System.EventHandler(this.btnGestionarAlbums_Click);
            // 
            // btnGestionarArtistas
            // 
            this.btnGestionarArtistas = new System.Windows.Forms.Button();
            this.btnGestionarArtistas.Location = new System.Drawing.Point(875, 50);
            this.btnGestionarArtistas.Name = "btnGestionarArtistas";
            this.btnGestionarArtistas.Size = new System.Drawing.Size(150, 30);
            this.btnGestionarArtistas.TabIndex = 8;
            this.btnGestionarArtistas.Text = "Gestionar Artistas";
            this.btnGestionarArtistas.UseVisualStyleBackColor = true;
            this.btnGestionarArtistas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnGestionarArtistas.ForeColor = System.Drawing.Color.White;
            this.btnGestionarArtistas.Click += new System.EventHandler(this.btnGestionarArtistas_Click);
            // 
            // FormMusica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 450); // Aumentar el ancho para el nuevo botón
            this.Controls.Add(this.btnGestionarArtistas);
            this.Controls.Add(this.btnGestionarAlbums);
            this.Controls.Add(this.btnAgregarCancion);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.btnSearchAlbums);
            this.Controls.Add(this.btnSearchCanciones);
            this.Controls.Add(this.btnSearchArtistas);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.lblSearch);
            this.Name = "FormMusica";
            this.Text = "Música";
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Button btnSearchArtistas;
        private System.Windows.Forms.Button btnSearchCanciones;
        private System.Windows.Forms.Button btnSearchAlbums;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnAgregarCancion;
        private System.Windows.Forms.Button btnGestionarAlbums;
        private System.Windows.Forms.Button btnGestionarArtistas;
    }
}
