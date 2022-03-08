using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class TreeViewForm<T> : Form
    {
        public TreeViewForm()
        {
            InitializeComponent();
        }

        public TreeViewForm(string name, IEnumerable<T> items)
        {
            InitializeComponent();

            Text = name;
            AddRange(items);
        }

        public TreeViewForm(string name, IEnumerable<T> items, Func<T, string> text)
        {
            InitializeComponent();

            Text = name;
            AddRange(items, text, null);
        }

        public TreeViewForm(string name, IEnumerable<T> items, Func<T, string> text, Func<T, string> group)
        {
            InitializeComponent();

            Text = name;
            AddRange(items, text, group);
        }

        public TreeViewForm(string name, IEnumerable<T> items, Func<T, string> text, Func<T, string> group, Func<T, bool> @checked)
        {
            InitializeComponent();

            Text = name;
            AddRange(items, text, group, @checked);
        }

        private void TreeView_Main_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeView_Main.AfterCheck -= TreeView_Main_AfterCheck;

            TreeNode treeNode = e.Node;

            TreeNode parentTreeNode = treeNode.Parent;

            if (parentTreeNode == null)
            {
                foreach(TreeNode childTreeNode in treeNode.Nodes)
                {
                    childTreeNode.Checked = treeNode.Checked;
                }
            }
            else
            {
                bool all = true;
                foreach (TreeNode childTreeNode in parentTreeNode.Nodes)
                {
                    if (childTreeNode.Checked != treeNode.Checked)
                    {
                        all = false;
                        break;
                    }
                }

                parentTreeNode.Checked = all ? treeNode.Checked : false;
            }

            TreeView_Main.AfterCheck += TreeView_Main_AfterCheck;
        }

        private void TreeViewForm_Load(object sender, EventArgs e)
        {
            
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void AddRange(IEnumerable<T> items, Func<T, string> text = null, Func<T, string> group = null, Func<T, bool> @checked = null)
        {
            if (items == null || items.Count() == 0)
            {
                return;
            }

            TreeView_Main.AfterCheck -= TreeView_Main_AfterCheck;

            foreach (T item in items)
            {
                string value_text = text == null ? item.ToString() : text?.Invoke(item);
                if (value_text == null)
                {
                    continue;
                }

                TreeNode treeNode = new TreeNode(value_text);
                treeNode.Tag = item;

                if(@checked != null)
                {
                    treeNode.Checked = @checked.Invoke(item);
                }

                TreeNode parentTreeNode = GetTreeNode(group?.Invoke(item));
                if (parentTreeNode != null)
                {
                    parentTreeNode.Nodes.Add(treeNode);
                }
                else
                {
                    TreeView_Main.Nodes.Add(treeNode);
                }
            }

            foreach(TreeNode treeNode in TreeView_Main.Nodes)
            {
                if(treeNode.Nodes == null || treeNode.Nodes.Count == 0)
                {
                    continue;
                }

                bool all = true;
                foreach (TreeNode childTreeNode in treeNode.Nodes)
                {
                    if (childTreeNode.Checked == false)
                    {
                        all = false;
                        break;
                    }
                }

                treeNode.Checked = all;
            }

            TreeView_Main.AfterCheck += TreeView_Main_AfterCheck;
        }

        private TreeNode GetTreeNode(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return null;
            }

            foreach (TreeNode treeNode in TreeView_Main.Nodes)
            {
                if(treeNode.Tag == null && text.Equals(treeNode.Text))
                {
                    return treeNode;
                }
            }

            return TreeView_Main.Nodes.Add(text);
        }

        private void ChangeCheckedForAll(bool Checked)
        {
            TreeView_Main.AfterCheck -= TreeView_Main_AfterCheck;

            foreach (TreeNode treeNode in TreeView_Main.Nodes)
            {
                treeNode.Checked = Checked;
                foreach (TreeNode childTreeNode in treeNode.Nodes)
                    childTreeNode.Checked = Checked;
            }

            TreeView_Main.AfterCheck += TreeView_Main_AfterCheck;

        }

        private void Button_SelectAll_Click(object sender, EventArgs e)
        {
            ChangeCheckedForAll(true);
        }

        private void Button_SelectNone_Click(object sender, EventArgs e)
        {
            ChangeCheckedForAll(false);
        }

        public List<T> SelectedItems
        {
            get
            {
                if(TreeView_Main?.Nodes == null)
                {
                    return null;
                }

                List<T> result = new List<T>();
                foreach(TreeNode treeNode in TreeView_Main.Nodes)
                {
                    if(treeNode.Checked && treeNode.Tag is T)
                    {
                        result.Add((T)treeNode.Tag);
                    }

                    foreach(TreeNode childTreeNode in treeNode.Nodes)
                    {
                        if(childTreeNode.Checked && childTreeNode.Tag is T)
                        {
                            result.Add((T)childTreeNode.Tag);
                        }
                    }
                }

                return result;
            }
        }

        public void ExpandAll()
        {

            TreeView_Main.ExpandAll();
        }

        public void CollapseAll()
        {
            TreeView_Main.CollapseAll();
        }
    }
}
