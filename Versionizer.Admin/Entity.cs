using System.Windows.Forms;
using Versionizer.Shared;
using System;

namespace Versionizer.Admin
{
    public partial class Entity : Form
    {
        public AssemblyInfo AssemblyInfo { get; private set; }

        public Entity()
        {
            InitializeComponent();
        }

        public Entity(AssemblyInfo _AssemblyInfo)
        {
            InitializeComponent();

            AssemblyInfo = _AssemblyInfo;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (AssemblyInfo != null)
            {
                AssemblyInfo.ID = Guid.Parse(txtID.Text);
                txtName.Text = AssemblyInfo.Name;
                txtTitle.Text = AssemblyInfo.Title;
                txtDescription.Text = AssemblyInfo.Description;
                txtConfiguration.Text = AssemblyInfo.Configuration;
                txtCompany.Text = AssemblyInfo.Company;
                txtProduct.Text = AssemblyInfo.Product;
                txtCopyright.Text = AssemblyInfo.Copyright;
                txtTrademark.Text = AssemblyInfo.Trademark;
                txtCulture.Text = AssemblyInfo.Culture;
                txtVersion.Text = AssemblyInfo.Version;
                txtFileVersion.Text = AssemblyInfo.FileVersion;
                cbComVisibility.SelectedIndex = cbComVisibility.FindString(AssemblyInfo.ComVisibility.ToString());
            }
        }

        private void OnAccept(object sender, EventArgs e)
        {
            AssemblyInfo.ID = Guid.Parse(txtID.Text);
            AssemblyInfo.Name = txtName.Text;
            AssemblyInfo.Title = txtTitle.Text;
            AssemblyInfo.Description = txtDescription.Text;
            AssemblyInfo.Configuration = txtConfiguration.Text;
            AssemblyInfo.Company = txtCompany.Text;
            AssemblyInfo.Product = txtProduct.Text;
            AssemblyInfo.Copyright = txtCopyright.Text;
            AssemblyInfo.Trademark = txtTrademark.Text;
            AssemblyInfo.Culture = txtCulture.Text;
            AssemblyInfo.Version = txtVersion.Text;
            AssemblyInfo.FileVersion = txtFileVersion.Text;
            AssemblyInfo.ComVisibility = bool.Parse(cbComVisibility.SelectedItem.ToString());

            Close();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
