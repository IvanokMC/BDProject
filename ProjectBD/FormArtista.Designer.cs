namespace ProjectBD
{
    partial class FormArtista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvArtistas;
        private System.Windows.Forms.Button btnEditarArtista;
        private System.Windows.Forms.Button btnEliminarArtista;

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
            this.lblIdArtista = new System.Windows.Forms.Label();
            this.txtIdArtista = new System.Windows.Forms.TextBox();
            this.lblNombreArtistico = new System.Windows.Forms.Label();
            this.txtNombreArtistico = new System.Windows.Forms.TextBox();
            this.lblTipoArtista = new System.Windows.Forms.Label();
            this.cmbTipoArtista = new System.Windows.Forms.ComboBox();
            this.lblPaisOrigen = new System.Windows.Forms.Label();
            this.txtPaisOrigen = new System.Windows.Forms.TextBox();
            this.lblGeneroPrincipal = new System.Windows.Forms.Label();
            this.txtGeneroPrincipal = new System.Windows.Forms.TextBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblBiografia = new System.Windows.Forms.Label();
            this.txtBiografia = new System.Windows.Forms.TextBox();
            this.lblImagen = new System.Windows.Forms.Label();
            this.txtImagen = new System.Windows.Forms.TextBox();
            this.grpSolista = new System.Windows.Forms.GroupBox();
            this.lblNombreReal = new System.Windows.Forms.Label();
            this.txtNombreReal = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblSexo = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.grpGrupo = new System.Windows.Forms.GroupBox();
            this.lblFechaFormacion = new System.Windows.Forms.Label();
            this.dtpFechaFormacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDisolucion = new System.Windows.Forms.Label();
            this.dtpFechaDisolucion = new System.Windows.Forms.DateTimePicker();
            this.btnGuardarArtista = new System.Windows.Forms.Button();
            this.dgvArtistas = new System.Windows.Forms.DataGridView();
            this.btnEditarArtista = new System.Windows.Forms.Button();
            this.btnEliminarArtista = new System.Windows.Forms.Button();
            this.grpSolista.SuspendLayout();
            this.grpGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtistas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdArtista
            // 
            this.lblIdArtista.AutoSize = true;
            this.lblIdArtista.Location = new System.Drawing.Point(30, 30);
            this.lblIdArtista.Name = "lblIdArtista";
            this.lblIdArtista.Size = new System.Drawing.Size(67, 16);
            this.lblIdArtista.TabIndex = 0;
            this.lblIdArtista.Text = "ID Artista:";
            this.lblIdArtista.ForeColor = System.Drawing.Color.White;
            // 
            // txtIdArtista
            // 
            this.txtIdArtista.Location = new System.Drawing.Point(150, 27);
            this.txtIdArtista.Name = "txtIdArtista";
            this.txtIdArtista.Size = new System.Drawing.Size(100, 22);
            this.txtIdArtista.TabIndex = 1;
            this.txtIdArtista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtIdArtista.ForeColor = System.Drawing.Color.White;
            // 
            // lblNombreArtistico
            // 
            this.lblNombreArtistico.AutoSize = true;
            this.lblNombreArtistico.Location = new System.Drawing.Point(30, 70);
            this.lblNombreArtistico.Name = "lblNombreArtistico";
            this.lblNombreArtistico.Size = new System.Drawing.Size(109, 16);
            this.lblNombreArtistico.TabIndex = 2;
            this.lblNombreArtistico.Text = "Nombre Artístico:";
            this.lblNombreArtistico.ForeColor = System.Drawing.Color.White;
            // 
            // txtNombreArtistico
            // 
            this.txtNombreArtistico.Location = new System.Drawing.Point(150, 67);
            this.txtNombreArtistico.Name = "txtNombreArtistico";
            this.txtNombreArtistico.Size = new System.Drawing.Size(250, 22);
            this.txtNombreArtistico.TabIndex = 3;
            this.txtNombreArtistico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtNombreArtistico.ForeColor = System.Drawing.Color.White;
            // 
            // lblTipoArtista
            // 
            this.lblTipoArtista.AutoSize = true;
            this.lblTipoArtista.Location = new System.Drawing.Point(30, 110);
            this.lblTipoArtista.Name = "lblTipoArtista";
            this.lblTipoArtista.Size = new System.Drawing.Size(84, 16);
            this.lblTipoArtista.TabIndex = 4;
            this.lblTipoArtista.Text = "Tipo Artista:";
            this.lblTipoArtista.ForeColor = System.Drawing.Color.White;
            // 
            // cmbTipoArtista
            // 
            this.cmbTipoArtista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoArtista.FormattingEnabled = true;
            this.cmbTipoArtista.Items.AddRange(new object[] { "solista", "grupo" });
            this.cmbTipoArtista.Location = new System.Drawing.Point(150, 107);
            this.cmbTipoArtista.Name = "cmbTipoArtista";
            this.cmbTipoArtista.Size = new System.Drawing.Size(121, 24);
            this.cmbTipoArtista.TabIndex = 5;
            this.cmbTipoArtista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmbTipoArtista.ForeColor = System.Drawing.Color.White;
            this.cmbTipoArtista.SelectedIndexChanged += new System.EventHandler(this.cmbTipoArtista_SelectedIndexChanged);
            // 
            // lblPaisOrigen
            // 
            this.lblPaisOrigen.AutoSize = true;
            this.lblPaisOrigen.Location = new System.Drawing.Point(30, 150);
            this.lblPaisOrigen.Name = "lblPaisOrigen";
            this.lblPaisOrigen.Size = new System.Drawing.Size(84, 16);
            this.lblPaisOrigen.TabIndex = 6;
            this.lblPaisOrigen.Text = "País Origen:";
            this.lblPaisOrigen.ForeColor = System.Drawing.Color.White;
            // 
            // txtPaisOrigen
            // 
            this.txtPaisOrigen.Location = new System.Drawing.Point(150, 147);
            this.txtPaisOrigen.Name = "txtPaisOrigen";
            this.txtPaisOrigen.Size = new System.Drawing.Size(250, 22);
            this.txtPaisOrigen.TabIndex = 7;
            this.txtPaisOrigen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPaisOrigen.ForeColor = System.Drawing.Color.White;
            // 
            // lblGeneroPrincipal
            // 
            this.lblGeneroPrincipal.AutoSize = true;
            this.lblGeneroPrincipal.Location = new System.Drawing.Point(30, 190);
            this.lblGeneroPrincipal.Name = "lblGeneroPrincipal";
            this.lblGeneroPrincipal.Size = new System.Drawing.Size(109, 16);
            this.lblGeneroPrincipal.TabIndex = 8;
            this.lblGeneroPrincipal.Text = "Género Principal:";
            this.lblGeneroPrincipal.ForeColor = System.Drawing.Color.White;
            // 
            // txtGeneroPrincipal
            // 
            this.txtGeneroPrincipal.Location = new System.Drawing.Point(150, 187);
            this.txtGeneroPrincipal.Name = "txtGeneroPrincipal";
            this.txtGeneroPrincipal.Size = new System.Drawing.Size(250, 22);
            this.txtGeneroPrincipal.TabIndex = 9;
            this.txtGeneroPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtGeneroPrincipal.ForeColor = System.Drawing.Color.White;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(30, 230);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(85, 16);
            this.lblFechaInicio.TabIndex = 10;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            this.lblFechaInicio.ForeColor = System.Drawing.Color.White;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(150, 227);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(250, 22);
            this.dtpFechaInicio.TabIndex = 11;
            this.dtpFechaInicio.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaInicio.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dtpFechaInicio.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dtpFechaInicio.CalendarTitleForeColor = System.Drawing.Color.White;
            // 
            // lblBiografia
            // 
            this.lblBiografia.AutoSize = true;
            this.lblBiografia.Location = new System.Drawing.Point(30, 270);
            this.lblBiografia.Name = "lblBiografia";
            this.lblBiografia.Size = new System.Drawing.Size(65, 16);
            this.lblBiografia.TabIndex = 12;
            this.lblBiografia.Text = "Biografía:";
            this.lblBiografia.ForeColor = System.Drawing.Color.White;
            // 
            // txtBiografia
            // 
            this.txtBiografia.Location = new System.Drawing.Point(150, 267);
            this.txtBiografia.Multiline = true;
            this.txtBiografia.Name = "txtBiografia";
            this.txtBiografia.Size = new System.Drawing.Size(250, 60);
            this.txtBiografia.TabIndex = 13;
            this.txtBiografia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtBiografia.ForeColor = System.Drawing.Color.White;
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.Location = new System.Drawing.Point(30, 340);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(54, 16);
            this.lblImagen.TabIndex = 14;
            this.lblImagen.Text = "Imagen:";
            this.lblImagen.ForeColor = System.Drawing.Color.White;
            // 
            // txtImagen
            // 
            this.txtImagen.Location = new System.Drawing.Point(150, 337);
            this.txtImagen.Name = "txtImagen";
            this.txtImagen.Size = new System.Drawing.Size(250, 22);
            this.txtImagen.TabIndex = 15;
            this.txtImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtImagen.ForeColor = System.Drawing.Color.White;
            // 
            // grpSolista
            // 
            this.grpSolista.Controls.Add(this.lblNombreReal);
            this.grpSolista.Controls.Add(this.txtNombreReal);
            this.grpSolista.Controls.Add(this.lblFechaNacimiento);
            this.grpSolista.Controls.Add(this.dtpFechaNacimiento);
            this.grpSolista.Controls.Add(this.lblSexo);
            this.grpSolista.Controls.Add(this.cmbSexo);
            this.grpSolista.ForeColor = System.Drawing.Color.White;
            this.grpSolista.Location = new System.Drawing.Point(30, 370);
            this.grpSolista.Name = "grpSolista";
            this.grpSolista.Size = new System.Drawing.Size(370, 150);
            this.grpSolista.TabIndex = 16;
            this.grpSolista.TabStop = false;
            this.grpSolista.Text = "Datos Solista";
            // 
            // lblNombreReal
            // 
            this.lblNombreReal.AutoSize = true;
            this.lblNombreReal.Location = new System.Drawing.Point(10, 30);
            this.lblNombreReal.Name = "lblNombreReal";
            this.lblNombreReal.Size = new System.Drawing.Size(88, 16);
            this.lblNombreReal.TabIndex = 0;
            this.lblNombreReal.Text = "Nombre Real:";
            this.lblNombreReal.ForeColor = System.Drawing.Color.White;
            // 
            // txtNombreReal
            // 
            this.txtNombreReal.Location = new System.Drawing.Point(130, 27);
            this.txtNombreReal.Name = "txtNombreReal";
            this.txtNombreReal.Size = new System.Drawing.Size(220, 22);
            this.txtNombreReal.TabIndex = 1;
            this.txtNombreReal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtNombreReal.ForeColor = System.Drawing.Color.White;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(10, 70);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(119, 16);
            this.lblFechaNacimiento.TabIndex = 2;
            this.lblFechaNacimiento.Text = "Fecha Nacimiento:";
            this.lblFechaNacimiento.ForeColor = System.Drawing.Color.White;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(130, 67);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(220, 22);
            this.dtpFechaNacimiento.TabIndex = 3;
            this.dtpFechaNacimiento.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaNacimiento.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dtpFechaNacimiento.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dtpFechaNacimiento.CalendarTitleForeColor = System.Drawing.Color.White;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(10, 110);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(41, 16);
            this.lblSexo.TabIndex = 4;
            this.lblSexo.Text = "Sexo:";
            this.lblSexo.ForeColor = System.Drawing.Color.White;
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] { "M", "F", "Otro" });
            this.cmbSexo.Location = new System.Drawing.Point(130, 107);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(100, 24);
            this.cmbSexo.TabIndex = 5;
            this.cmbSexo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmbSexo.ForeColor = System.Drawing.Color.White;
            // 
            // grpGrupo
            // 
            this.grpGrupo.Controls.Add(this.lblFechaFormacion);
            this.grpGrupo.Controls.Add(this.dtpFechaFormacion);
            this.grpGrupo.Controls.Add(this.lblFechaDisolucion);
            this.grpGrupo.Controls.Add(this.dtpFechaDisolucion);
            this.grpGrupo.ForeColor = System.Drawing.Color.White;
            this.grpGrupo.Location = new System.Drawing.Point(30, 530);
            this.grpGrupo.Name = "grpGrupo";
            this.grpGrupo.Size = new System.Drawing.Size(370, 120);
            this.grpGrupo.TabIndex = 17;
            this.grpGrupo.TabStop = false;
            this.grpGrupo.Text = "Datos Grupo";
            // 
            // lblFechaFormacion
            // 
            this.lblFechaFormacion.AutoSize = true;
            this.lblFechaFormacion.Location = new System.Drawing.Point(10, 30);
            this.lblFechaFormacion.Name = "lblFechaFormacion";
            this.lblFechaFormacion.Size = new System.Drawing.Size(115, 16);
            this.lblFechaFormacion.TabIndex = 0;
            this.lblFechaFormacion.Text = "Fecha Formación:";
            this.lblFechaFormacion.ForeColor = System.Drawing.Color.White;
            // 
            // dtpFechaFormacion
            // 
            this.dtpFechaFormacion.Location = new System.Drawing.Point(130, 27);
            this.dtpFechaFormacion.Name = "dtpFechaFormacion";
            this.dtpFechaFormacion.Size = new System.Drawing.Size(220, 22);
            this.dtpFechaFormacion.TabIndex = 1;
            this.dtpFechaFormacion.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaFormacion.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dtpFechaFormacion.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dtpFechaFormacion.CalendarTitleForeColor = System.Drawing.Color.White;
            // 
            // lblFechaDisolucion
            // 
            this.lblFechaDisolucion.AutoSize = true;
            this.lblFechaDisolucion.Location = new System.Drawing.Point(10, 70);
            this.lblFechaDisolucion.Name = "lblFechaDisolucion";
            this.lblFechaDisolucion.Size = new System.Drawing.Size(119, 16);
            this.lblFechaDisolucion.TabIndex = 2;
            this.lblFechaDisolucion.Text = "Fecha Disolución:";
            this.lblFechaDisolucion.ForeColor = System.Drawing.Color.White;
            // 
            // dtpFechaDisolucion
            // 
            this.dtpFechaDisolucion.Location = new System.Drawing.Point(130, 67);
            this.dtpFechaDisolucion.Name = "dtpFechaDisolucion";
            this.dtpFechaDisolucion.Size = new System.Drawing.Size(220, 22);
            this.dtpFechaDisolucion.TabIndex = 3;
            this.dtpFechaDisolucion.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaDisolucion.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dtpFechaDisolucion.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dtpFechaDisolucion.CalendarTitleForeColor = System.Drawing.Color.White;
            // 
            // btnGuardarArtista
            // 
            this.btnGuardarArtista.Location = new System.Drawing.Point(30, 670);
            this.btnGuardarArtista.Name = "btnGuardarArtista";
            this.btnGuardarArtista.Size = new System.Drawing.Size(100, 35);
            this.btnGuardarArtista.TabIndex = 18;
            this.btnGuardarArtista.Text = "Guardar";
            this.btnGuardarArtista.UseVisualStyleBackColor = true;
            this.btnGuardarArtista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnGuardarArtista.ForeColor = System.Drawing.Color.White;
            this.btnGuardarArtista.Click += new System.EventHandler(this.btnGuardarArtista_Click);
            // 
            // dgvArtistas
            // 
            this.dgvArtistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtistas.Location = new System.Drawing.Point(420, 27);
            this.dgvArtistas.Name = "dgvArtistas";
            this.dgvArtistas.RowHeadersWidth = 51;
            this.dgvArtistas.RowTemplate.Height = 24;
            this.dgvArtistas.Size = new System.Drawing.Size(550, 600);
            this.dgvArtistas.TabIndex = 19;
            this.dgvArtistas.BackgroundColor = System.Drawing.Color.White;
            this.dgvArtistas.ForeColor = System.Drawing.Color.Black;
            this.dgvArtistas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvArtistas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvArtistas.EnableHeadersVisualStyles = false;
            this.dgvArtistas.SelectionChanged += new System.EventHandler(this.dgvArtistas_SelectionChanged);
            // 
            // btnEditarArtista
            // 
            this.btnEditarArtista.Location = new System.Drawing.Point(150, 670);
            this.btnEditarArtista.Name = "btnEditarArtista";
            this.btnEditarArtista.Size = new System.Drawing.Size(100, 35);
            this.btnEditarArtista.TabIndex = 20;
            this.btnEditarArtista.Text = "Editar";
            this.btnEditarArtista.UseVisualStyleBackColor = true;
            this.btnEditarArtista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEditarArtista.ForeColor = System.Drawing.Color.White;
            this.btnEditarArtista.Click += new System.EventHandler(this.btnEditarArtista_Click);
            // 
            // btnEliminarArtista
            // 
            this.btnEliminarArtista.Location = new System.Drawing.Point(270, 670);
            this.btnEliminarArtista.Name = "btnEliminarArtista";
            this.btnEliminarArtista.Size = new System.Drawing.Size(100, 35);
            this.btnEliminarArtista.TabIndex = 21;
            this.btnEliminarArtista.Text = "Eliminar";
            this.btnEliminarArtista.UseVisualStyleBackColor = true;
            this.btnEliminarArtista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEliminarArtista.ForeColor = System.Drawing.Color.White;
            this.btnEliminarArtista.Click += new System.EventHandler(this.btnEliminarArtista_Click);
            // 
            // FormArtista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 720);
            this.Controls.Add(this.btnEliminarArtista);
            this.Controls.Add(this.btnEditarArtista);
            this.Controls.Add(this.dgvArtistas);
            this.Controls.Add(this.btnGuardarArtista);
            this.Controls.Add(this.grpGrupo);
            this.Controls.Add(this.grpSolista);
            this.Controls.Add(this.txtImagen);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.txtBiografia);
            this.Controls.Add(this.lblBiografia);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.txtGeneroPrincipal);
            this.Controls.Add(this.lblGeneroPrincipal);
            this.Controls.Add(this.txtPaisOrigen);
            this.Controls.Add(this.lblPaisOrigen);
            this.Controls.Add(this.cmbTipoArtista);
            this.Controls.Add(this.lblTipoArtista);
            this.Controls.Add(this.txtNombreArtistico);
            this.Controls.Add(this.lblNombreArtistico);
            this.Controls.Add(this.txtIdArtista);
            this.Controls.Add(this.lblIdArtista);
            this.Name = "FormArtista";
            this.Text = "Artista";
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Load += new System.EventHandler(this.FormArtista_Load);
            this.grpSolista.ResumeLayout(false);
            this.grpSolista.PerformLayout();
            this.grpGrupo.ResumeLayout(false);
            this.grpGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtistas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdArtista;
        private System.Windows.Forms.TextBox txtIdArtista;
        private System.Windows.Forms.Label lblNombreArtistico;
        private System.Windows.Forms.TextBox txtNombreArtistico;
        private System.Windows.Forms.Label lblTipoArtista;
        private System.Windows.Forms.ComboBox cmbTipoArtista;
        private System.Windows.Forms.Label lblPaisOrigen;
        private System.Windows.Forms.TextBox txtPaisOrigen;
        private System.Windows.Forms.Label lblGeneroPrincipal;
        private System.Windows.Forms.TextBox txtGeneroPrincipal;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblBiografia;
        private System.Windows.Forms.TextBox txtBiografia;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.TextBox txtImagen;
        private System.Windows.Forms.GroupBox grpSolista;
        private System.Windows.Forms.Label lblNombreReal;
        private System.Windows.Forms.TextBox txtNombreReal;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.GroupBox grpGrupo;
        private System.Windows.Forms.Label lblFechaFormacion;
        private System.Windows.Forms.DateTimePicker dtpFechaFormacion;
        private System.Windows.Forms.Label lblFechaDisolucion;
        private System.Windows.Forms.DateTimePicker dtpFechaDisolucion;
        private System.Windows.Forms.Button btnGuardarArtista;
    }
}