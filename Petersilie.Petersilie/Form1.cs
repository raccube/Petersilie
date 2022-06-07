namespace Petersilie.Petersilie;

using Viewers;
using NPet;

public partial class Form1 : Form
{
    public PetFile? CurrentDocument = null;

    public Form1()
    {
        InitializeComponent();
    }

    private void openToolStripButton_Click(object sender, EventArgs e)
    {
        var result = openFileDialog.ShowDialog(this);
        if (result == DialogResult.OK)
        {
            UseWaitCursor = true;
            
            CurrentDocument = new PetFile(openFileDialog.FileName);
            var baseName = Path.GetFileName(openFileDialog.FileName);
            Text = $"{baseName} - {Application.ProductName}";
            
            BuildTree(baseName);

            UseWaitCursor = false;
        }
    }

    private void BuildTree(string FileName)
    {
        treeView1.Nodes.Clear();
        var rootNode = treeView1.Nodes.Add("root", Path.GetFileNameWithoutExtension(FileName));
        rootNode.Tag = CurrentDocument.Header;
        foreach (var contentType in CurrentDocument.Header.IndexTable)
        {
            var newNode = rootNode.Nodes.Add(contentType.Name);
            newNode.Tag = contentType;
        }

        rootNode.Expand();
        treeView1.SelectedNode = rootNode;
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node.Tag is PetHeader tag) {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(new HeaderView(tag));
        }
    }
}