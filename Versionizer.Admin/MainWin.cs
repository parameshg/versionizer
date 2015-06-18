using System.Windows.Forms;
using Versionizer.Shared;
using System.Collections.Generic;

namespace Versionizer.Admin
{
    public partial class MainWin : Form
    {
        private IApi _api;

        public MainWin()
        {
            InitializeComponent();

            _api = new Api();
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            lstAssembly.Items.Clear();

            foreach (AssemblyInfo i in _api.List())
            {
                ListViewItem item = new ListViewItem(new string[] { i.Name, i.Version, i.FileVersion, i.ComVisibility.ToString() });
                
                item.Tag = i;

                lstAssembly.Items.Add(item);
            }
        }

        private void OnAdd(object sender, System.EventArgs e)
        {
            using (Entity dialog = new Entity())
            {
                if (dialog.ShowDialog().Equals(DialogResult.OK))
                {
                    AssemblyInfo entity = dialog.AssemblyInfo;

                    if (entity != null)
                        _api.Create(entity);
                }
            }

            OnLoad(sender, e);
        }

        private void OnEdit(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in lstAssembly.SelectedItems)
            {
                AssemblyInfo entity = item.Tag as AssemblyInfo;

                if (entity != null)
                {
                    using (Entity dialog = new Entity(entity))
                    {
                        if (dialog.ShowDialog().Equals(DialogResult.OK))
                        {
                            entity = dialog.AssemblyInfo;

                            if (entity != null)
                                _api.Update(entity);
                        }
                    }
                }
            }

            OnLoad(sender, e);
        }

        private void OnDelete(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in lstAssembly.SelectedItems)
            {
                AssemblyInfo entity = item.Tag as AssemblyInfo;

                if (entity != null)
                {
                    if (MessageBox.Show(string.Format("Are you sure to delete the assembly {0}?", entity.Name), "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.Yes))
                        _api.Delete(entity.ID);
                }
            }

            OnLoad(sender, e);
        }
    }
}