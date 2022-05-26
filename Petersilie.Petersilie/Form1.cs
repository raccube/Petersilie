namespace Petersilie.Petersilie;

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
            CurrentDocument = new PetFile(openFileDialog.FileName);
            propertyGrid1.SelectedObject = CurrentDocument.Header.IndexTable[0];
        }
    }
}