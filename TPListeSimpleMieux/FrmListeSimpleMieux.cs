using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPListeDeroulante
{
    public partial class FrmListeSimpleMieux : Form
    {
        public FrmListeSimpleMieux()
        {
            InitializeComponent();
        }
        private void FrmListeSimple_Load(object sender, EventArgs e)
        {
            lstItems.Items.Add("Marie");
            lstItems.Items.Add("Jean");
            lstItems.Items.Add("Pierre");
            lstItems.Items.Add("Julien");
            lstItems.Items.Add("Françoise");
            lstItems.Items.Add("Hélène");

            txtSaisie.Focus();
        }

        private void chkLocked_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLocked.Checked)
            { 
                lstItems.SelectionMode = SelectionMode.None;
                lstItems.Enabled = false;
            }
            else {
                lstItems.SelectionMode = SelectionMode.One;
                lstItems.Enabled = true;
            }
        }

        private void txtSaisie_TextChanged(object sender, EventArgs e)
        {
            btnAjouter.Enabled = true;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            lstItems.Items.Add(txtSaisie.Text);
            txtSaisie.Clear();
            btnAjouter.Enabled = false;
           
        }
        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSupprimer.Enabled = true;
            if (lstItems.Items.Count > 0)
                btnAffiche.Enabled = true;
            else
                btnAffiche.Enabled = false;

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count > 0)  //ne supprime que si il y a des éléments sélectionnées
            {
                for (int i = 0; i < lstItems.SelectedItems.Count; i++)
                    lstItems.Items.Remove(lstItems.SelectedItems[i]);
                lstItems.Items.Remove(lstItems.SelectedItem);
                btnSupprimer.Enabled = false;
            }
        }

        private void btnAffiche_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach(string item in lstItems.SelectedItems)
                message += item + "\n";
            MessageBox.Show(message);
        }

        private void OptSelectionListe(object sender, EventArgs e)
        {
            if (rdBtn1.Checked)
                lstItems.SelectionMode = SelectionMode.One;
            else if (rdBtn2.Checked)
                lstItems.SelectionMode = SelectionMode.MultiSimple;
            else if (rdBtn3.Checked)
                lstItems.SelectionMode = SelectionMode.MultiExtended;
        }


    }
}
