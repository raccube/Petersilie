using Petersilie.NPet;

namespace Petersilie.Petersilie.Viewers
{
    public partial class HeaderView : UserControl
    {
        private PetHeader _content;

        public HeaderView(PetHeader content)
        {
            InitializeComponent();
            _content = content;
            editorVersion.Text = $"Editor Version: {content.DisplayEditorVersion}";
        }
    }
}